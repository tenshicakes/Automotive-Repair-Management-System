using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olvarra_Capstone
{
    public partial class EditForm : Form
    {
        private DataTable _dtParts;
        private DataTable _originalData;
        public EditForm(DataTable selectedParts)
        {
            InitializeComponent();
            SetupGridStyle();
            _dtParts = selectedParts;
            
            _originalData = selectedParts.Copy();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
        }
        private void SetupGrid()
        {
            editinventorygrid.AutoGenerateColumns = false;
            editinventorygrid.Columns.Clear();
            editinventorygrid.AllowUserToAddRows = false;

            editinventorygrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "PartID", DataPropertyName = "PartID", Visible = false });
            editinventorygrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "PartName", HeaderText = "Part Name", DataPropertyName = "PartName" });
            editinventorygrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "StockQuantity", HeaderText = "Stock Quantity", DataPropertyName = "StockQuantity" });
            editinventorygrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Price", DataPropertyName = "Price" });

            editinventorygrid.DataSource = _dtParts;

            // Wire up essential events
            editinventorygrid.CurrentCellDirtyStateChanged += EditInventoryGrid_CurrentCellDirtyStateChanged;
            editinventorygrid.EditingControlShowing += EditInventoryGrid_EditingControlShowing;
            editinventorygrid.CellValidating += EditInventoryGrid_CellValidating;
        }

        private void SetupGridStyle()
        {
            editinventorygrid.BackgroundColor = Color.White;
            editinventorygrid.BorderStyle = BorderStyle.None;
            editinventorygrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            editinventorygrid.RowHeadersVisible = false;
            editinventorygrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            editinventorygrid.AllowUserToAddRows = false;
            editinventorygrid.DefaultCellStyle.Font = new Font("Candara", 12, FontStyle.Regular);
            editinventorygrid.DefaultCellStyle.BackColor = Color.White;
            editinventorygrid.DefaultCellStyle.ForeColor = Color.Black;
            editinventorygrid.DefaultCellStyle.SelectionBackColor = Color.Black;
            editinventorygrid.DefaultCellStyle.SelectionForeColor = Color.White;
            editinventorygrid.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 13, FontStyle.Bold);
            editinventorygrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            editinventorygrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            editinventorygrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            editinventorygrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            editinventorygrid.EnableHeadersVisualStyles = false;
            editinventorygrid.RowTemplate.Height = 40;
        }

        // 1. Instant Commit (No Enter key required)
        private void EditInventoryGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (editinventorygrid.IsCurrentCellDirty)
            {
                editinventorygrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // 2. Attach specialized key press filters depending on the column
        private void EditInventoryGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox tb)
            {
                tb.KeyPress -= Stock_KeyPress;
                tb.KeyPress -= Price_KeyPress;

                string colName = editinventorygrid.CurrentCell.OwningColumn.Name;

                if (colName == "StockQuantity")
                {
                    tb.KeyPress += Stock_KeyPress;
                }
                else if (colName == "Price")
                {
                    tb.KeyPress += Price_KeyPress;
                }
            }
        }

        // 3a. Filter: Integers only for Stock
        private void Stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // 3b. Filter: Numbers and a single decimal point for Price
        private void Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Prevent a second decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        // 4. Prevent users from leaving a cell completely blank or filled with spaces
        private void EditInventoryGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string colName = editinventorygrid.Columns[e.ColumnIndex].Name;

            if (colName == "PartName" || colName == "StockQuantity" || colName == "Price")
            {
                string input = e.FormattedValue?.ToString().Trim();

                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show($"{colName} cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
            }
        }

        private void editinfobtn_Click(object sender, EventArgs e)
        {
            editinventorygrid.EndEdit();

            List<string> queries = new List<string>();
            List<SqlParameter[]> parametersList = new List<SqlParameter[]>();

            foreach (DataGridViewRow row in editinventorygrid.Rows)
            {
                int partId = Convert.ToInt32(row.Cells["PartID"].Value);
                string newName = row.Cells["PartName"].Value?.ToString().Trim() ?? "";
                string newStockStr = row.Cells["StockQuantity"].Value?.ToString().Trim() ?? "0";
                string newPriceStr = row.Cells["Price"].Value?.ToString().Trim() ?? "0";

                // check against blanks cells
                if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newStockStr) || string.IsNullOrEmpty(newPriceStr))
                {
                    MessageBox.Show("All fields must be completely filled out. Please fix empty cells before saving.", "Save Aborted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int newStock = Convert.ToInt32(newStockStr);
                decimal newPrice = Convert.ToDecimal(newPriceStr);

                // Find the original row to compare values
                DataRow originalRow = _originalData.AsEnumerable().FirstOrDefault(r => r.Field<int>("PartID") == partId);

                if (originalRow != null)
                {
                    string oldName = originalRow.Field<string>("PartName");
                    int oldStock = originalRow.Field<int>("StockQuantity");
                    decimal oldPrice = originalRow.Field<decimal>("Price");

                    // Check if anything ACTUALLY changed
                    if (newName != oldName || newStock != oldStock || newPrice != oldPrice)
                    {
                        string query = "UPDATE SpareParts SET PartName = @PartName, StockQuantity = @StockQuantity, Price = @Price WHERE PartID = @PartID";

                        SqlParameter[] parameters = new SqlParameter[]
                        {
                            new SqlParameter("@PartName", newName),
                            new SqlParameter("@StockQuantity", newStock),
                            new SqlParameter("@Price", newPrice),
                            new SqlParameter("@PartID", partId)
                        };

                        queries.Add(query);
                        parametersList.Add(parameters);
                    }
                }
            }

            if (queries.Count == 0)
            {
                // Silently close or show a message if they hit save without making genuine changes
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            // Execute genuine updates via transaction
            bool success = DatabaseHelper.ExecuteTransaction(queries.ToArray(), parametersList.ToArray());

            if (success)
            {
                MessageBox.Show("Inventory items updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("An error occurred while saving the updates.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }

