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
                string connectionString = $"Data Source=./departments.db";
                return new SqliteConnection(connectionString);
            }
        }


        public static void CheckDepartmentTable()
        {
            SqliteConnection db = DatabaseInterface.Connection;

            try
            {
                /*
                    new variable that is of type List of Department.
                    Query is Dapper method to be able to query the database
                    query also has to be typed of what you expect to get back 
                    what should be created from that data you're querying? 
                    In this case, department instances from the data that comes back
                    It will create object instances based on the cs models we have created - so for example, the db has 3 departments, so we get back 3 instances of departments with the Id and DeptName back in each instance with the data from the db
                 */
                List<Department> departments = db.Query<Department>
                // select = what to do on the database side 
                    ("SELECT Id FROM Department").ToList();
            }
            // if the database table doesn't exist, check the exception and if there is no table, create the table
            catch (System.Exception ex)
            {
                if (ex.Message.Contains("no such table"))
                {
                    // execute statement to make a new table into database
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