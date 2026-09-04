using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Olvarra_Capstone
{
    public partial class StockForm : Form
    {
        private string _actionType; // Will be "IN" or "OUT"
        private DataTable _dtParts;
        public StockForm(DataTable selectedParts, string actionType)
        {
            InitializeComponent();
            _actionType = actionType;
            _dtParts = selectedParts;
            SetupInventoryGridStyle();



        }

        private void StockForm_Load(object sender, EventArgs e)
        {
            SetupGrid();
        }

        private void SetupGrid()
        {
            inventoryGrid.AutoGenerateColumns = false;
            inventoryGrid.Columns.Clear();
            inventoryGrid.AllowUserToAddRows = false;

            // Add PartID (Hidden)
            inventoryGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "PartID", DataPropertyName = "PartID", Visible = false });

            // Add Read-Only Columns
            inventoryGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "PartName", HeaderText = "Part Name", DataPropertyName = "PartName", ReadOnly = true });
            inventoryGrid.Columns.Add(new DataGridViewTextBoxColumn { Name = "StockQuantity", HeaderText = "Current Stock", DataPropertyName = "StockQuantity", ReadOnly = true });

            // Add Editable Quantity Column
            DataGridViewTextBoxColumn qtyCol = new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = _actionType == "IN" ? "Qty to Add" : "Qty to Reduce",
                DefaultCellStyle = new DataGridViewCellStyle { NullValue = "0", Format = "N0" }
            };
            inventoryGrid.Columns.Add(qtyCol);

            // Bind the passed data
            inventoryGrid.DataSource = _dtParts;

            // Wire up essential validation events
            inventoryGrid.CurrentCellDirtyStateChanged += InventoryGrid_CurrentCellDirtyStateChanged;
            inventoryGrid.EditingControlShowing += InventoryGrid_EditingControlShowing;
            inventoryGrid.CellValidating += InventoryGrid_CellValidating;
        }

        private void SetupInventoryGridStyle()
        {
            inventoryGrid.BackgroundColor = Color.White;
            inventoryGrid.BorderStyle = BorderStyle.None;
            inventoryGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            inventoryGrid.RowHeadersVisible = false;
            inventoryGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            inventoryGrid.MultiSelect = true;
            inventoryGrid.ReadOnly = false;
            inventoryGrid.AllowUserToAddRows = false;
            inventoryGrid.DefaultCellStyle.Font = new Font("Candara", 12, FontStyle.Regular);
            inventoryGrid.DefaultCellStyle.BackColor = Color.White;
            inventoryGrid.DefaultCellStyle.ForeColor = Color.Black;
            inventoryGrid.DefaultCellStyle.SelectionBackColor = Color.Black;
            inventoryGrid.DefaultCellStyle.SelectionForeColor = Color.White;
            inventoryGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Candara", 13, FontStyle.Bold);
            inventoryGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            inventoryGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            inventoryGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            inventoryGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            inventoryGrid.EnableHeadersVisualStyles = false;
            inventoryGrid.RowTemplate.Height = 40;
        }

        // ==========================================
        // GRID EDITING & VALIDATION FIXES
        // ==========================================

        // Fixes the "Must Press Enter" issue by forcing an instant commit
        private void InventoryGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (inventoryGrid.IsCurrentCellDirty && inventoryGrid.CurrentCell.OwningColumn.Name == "Quantity")
            {
                inventoryGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // 2. Hooks into the text box of the cell to restrict keystrokes
        private void InventoryGrid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (inventoryGrid.CurrentCell.OwningColumn.Name == "Quantity" && e.Control is TextBox tb)
            {
                // Remove existing handlers to prevent stacking
                tb.KeyPress -= TextBox_KeyPress;
                tb.KeyPress += TextBox_KeyPress;
            }
        }

        // 3. Blocks letters, spaces, and negative signs
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // 4. Validates final input (Checks Stock-Out limits)
        private void InventoryGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (inventoryGrid.Columns[e.ColumnIndex].Name == "Quantity")
            {
                string input = e.FormattedValue.ToString();
                if (string.IsNullOrWhiteSpace(input)) input = "0";

                int enteredQty;
                if (int.TryParse(input, out enteredQty))
                {
                    if (_actionType == "OUT")
                    {
                        int currentStock = Convert.ToInt32(inventoryGrid.Rows[e.RowIndex].Cells["StockQuantity"].Value);
                        if (enteredQty > currentStock)
                        {
                            MessageBox.Show($"Cannot reduce more than the current stock ({currentStock}).", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            e.Cancel = true; // Reverts the edit
                        }
                    }
                }
            }
        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            // Stop any active editing to ensure the final value is captured
            inventoryGrid.EndEdit();

            List<string> queries = new List<string>();
            List<SqlParameter[]> parametersList = new List<SqlParameter[]>();

            foreach (DataGridViewRow row in inventoryGrid.Rows)
            {
                int qty = 0;
                if (row.Cells["Quantity"].Value != null)
                {
                    int.TryParse(row.Cells["Quantity"].Value.ToString(), out qty);
                }

                // Skip rows where the user left the quantity as 0
                if (qty > 0)
                {
                    int currentStock = Convert.ToInt32(row.Cells["StockQuantity"].Value);

                    // 2. New Guardrail: Final backend check to absolutely prevent negative stock
                    if (_actionType == "OUT" && qty > currentStock)
                    {
                        string partName = row.Cells["PartName"].Value?.ToString() ?? "An item";
                        MessageBox.Show($"Cannot reduce '{partName}' by {qty} because it only has {currentStock} in stock.", "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Halts the entire batch update
                    }

                    int partId = Convert.ToInt32(row.Cells["PartID"].Value);
                    string mathOperator = _actionType == "IN" ? "+" : "-";

                    string query = $"UPDATE SpareParts SET StockQuantity = StockQuantity {mathOperator} @Qty WHERE PartID = @PartID";

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                new SqlParameter("@Qty", qty),
                new SqlParameter("@PartID", partId)
                    };

                    queries.Add(query);
                    parametersList.Add(parameters);
                }
            }

            if (queries.Count == 0)
            {
                MessageBox.Show("No quantities were typed.", "Action Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Execute all updates simultaneously via your DatabaseHelper Transaction
            bool success = DatabaseHelper.ExecuteTransaction(queries.ToArray(), parametersList.ToArray());

            if (success)
            {
                string actionWord = _actionType == "IN" ? "added to" : "reduced from";
                MessageBox.Show($"Stocks successfully {actionWord} inventory.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("An error occurred while updating the inventory. No changes were saved.", "Transaction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
    }


