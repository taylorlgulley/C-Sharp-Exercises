using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Collections;
using Dapper;
using DapperDepartments.Models;

namespace DapperDepartments.Data
{
    public class DatabaseInterface
    {
        public static SqliteConnection Connection
        {
            get
            {
                string _connectionString = $"Data Source=./departments.db";
                return new SqliteConnection(_connectionString);
            }
        }


        public static void CheckDepartmentTable()
        {
            SqliteConnection db = DatabaseInterface.Connection;

            try
            {
                List<Department> departments = db.Query<Department>
                    ("SELECT Id FROM Department").ToList();
            }
            catch (System.Exception ex)
            {
                if (ex.Message.Contains("no such table"))
                {
                    db.Execute(@"CREATE TABLE `Department` (
                        `Id` INTEGER PRIMARY KEY AUTOINCREMENT,
                        `DeptName` TEXT NOT NULL
                    )");

                    db.Execute(@"
                    INSERT INTO Department (DeptName) VALUES ('Marketing');
                    INSERT INTO Department (DeptName) VALUES ('Engineering');
                    INSERT INTO Department (DeptName) VALUES ('Design');
                    ");
                }
            }
        }

        public static void CheckEmployeeTable()
        {
            SqliteConnection db = DatabaseInterface.Connection;

            try
            {
                List<Employee> employees = db.Query<Employee>
                    ("SELECT Id FROM Employee").ToList();
            }
            catch (System.Exception ex)
            {
                if (ex.Message.Contains("no such table"))
                {
                    db.Execute($@"CREATE TABLE `Employee` (
                        `Id`    INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                        `FirstName`    TEXT NOT NULL,
                        `LastName`    TEXT NOT NULL,
                        `DepartmentId`    INTEGER NOT NULL,
                        FOREIGN KEY(`DepartmentId`) REFERENCES `Department`(`Id`)
                    )");

                    db.Execute($@"
                    INSERT INTO Employee (FirstName, LastName, DepartmentId) VALUES ('Margorie', 'Klingerman', 1);

                    INSERT INTO Employee (FirstName, LastName, DepartmentId) VALUES ('Sebastian', 'Lefebvre', 2);

                    INSERT INTO Employee (FirstName, LastName, DepartmentId) VALUES ('Jamal', 'Ross', 3);
                    ");
                }
            }
        }
    }
}