CREATE TABLE `Department` (
    `Id` INTEGER PRIMARY KEY AUTOINCREMENT,
    `DeptName` TEXT NOT NULL
);

CREATE TABLE `Employee` (
    `Id`    INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    `FirstName`    TEXT NOT NULL,
    `LastName`    TEXT NOT NULL,
    `DepartmentId`    INTEGER NOT NULL,
    FOREIGN KEY(`DepartmentId`) REFERENCES `Department`(`Id`)
);

INSERT INTO Department (DeptName) VALUES ('Marketing');
INSERT INTO Department (DeptName) VALUES ('Engineering');
INSERT INTO Department (DeptName) VALUES ('Design');

INSERT INTO Employee
    (FirstName, LastName, DepartmentId)
VALUES
    ('Margorie', 'Klingerman', 1);

INSERT INTO Employee
    (FirstName, LastName, DepartmentId)
VALUES
    ('Sebastian', 'Lefebvre', 2);

INSERT INTO Employee
    (FirstName, LastName, DepartmentId)
VALUES
    ('Jamal', 'Ross', 3);