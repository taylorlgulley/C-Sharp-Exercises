using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Text;
using Dapper;
using DapperDepartments.Data;
using DapperDepartments.Models;

/*
    To install required packages from NuGet
        1. `dotnet add package Microsoft.Data.Sqlite`
        2. `dotnet add package Dapper`
        3. `dotnet restore`
 */

namespace DapperDepartments
{
    class Program
    {
        static void Main(string[] args)
        {
            SqliteConnection db = DatabaseInterface.Connection;
            DatabaseInterface.CheckDepartmentTable();
            DatabaseInterface.CheckEmployeeTable();

            /*
                1. Query database
                2. Convert result to list
                3. Use ForEach to iterate the collection
            */
            List<Department> departments = db.Query<Department>(@"SELECT * FROM Department").ToList();
            departments.ForEach(dept => Console.WriteLine($"{dept.DeptName}"));

            // Chaining LINQ statements together
            db.Query<Employee>(@"SELECT * FROM Employee")
              .ToList()
              .ForEach(emp => Console.WriteLine($"{emp.FirstName} {emp.LastName}"));




            /*
                Query the database for each employee, and join in the employee's department
                Since an employee is only assigned to one department at a time, you can simply
                assign the corresponding department as a property on the instance of the
                Employee class that is created by Dapper.
             */
            db.Query<Employee, Department, Employee>(@"
                SELECT e.Id,
                       e.FirstName,
                       e.LastName,
                       d.Id,
                       d.DeptName
                FROM Employee e
                JOIN Department d ON d.Id = e.DepartmentId
            ", (employee, department) =>
            {
                employee.Department = department;
                return employee;
            })
            .ToList()
            .ForEach(emp => Console.WriteLine($"{emp.FirstName} {emp.LastName} works in the  {emp.Department.DeptName}"));
        }
    }
}
