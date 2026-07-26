CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    Role NVARCHAR(20) NOT NULL -- 'Owner', 'Secretary', 'Mechanic'
);

INSERT INTO Users (Username, Password, Role) 
VALUES ('admin', 'admin123', 'Owner');

CREATE TABLE CustomerInfo (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(20),
    Address NVARCHAR(200)
);

CREATE TABLE VehicleInfo (
    VehicleID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT FOREIGN KEY REFERENCES CustomerInfo(CustomerID),
    VehicleModel NVARCHAR(100),
    PlateNumber NVARCHAR(20) NOT NULL UNIQUE
);

CREATE TABLE SpareParts (
    PartID INT PRIMARY KEY IDENTITY(1,1),
    PartName NVARCHAR(100) NOT NULL,
    StockQuantity INT DEFAULT 0,
    Price DECIMAL(18,2)
);

CREATE TABLE ServiceLogs (
    LogID INT PRIMARY KEY IDENTITY(1,1),
    VehicleID INT FOREIGN KEY REFERENCES VehicleInfo(VehicleID),
    Issue NVARCHAR(MAX),
    Solution NVARCHAR(MAX),
    PartsUsed NVARCHAR(MAX), -- Option A: Text format (e.g., "2 Brake Pads")
    Status NVARCHAR(20) DEFAULT 'Pending', -- 'Pending', 'In Progress', 'Finished'
    LoggedBy NVARCHAR(50), -- Secretary username
    FixedBy NVARCHAR(50), -- Mechanic username (Updated later)
    DateLogged DATETIME DEFAULT GETDATE(),
    DateFinished DATETIME NULL
);

CREATE TABLE PaymentLogs (
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    LogID INT FOREIGN KEY REFERENCES ServiceLogs(LogID),
    TotalAmount DECIMAL(18,2),
    PaymentDate DATETIME DEFAULT GETDATE(),
    ProcessedBy NVARCHAR(50)
);