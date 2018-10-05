using System;
using System.Collections.Generic;

namespace classes {
    class Program {
        static void Main (string[] args) {
            // Create an instance of a company. Name it whatever you like.
            var company1 = new Company("Acme, Inc.", new DateTime(2018, 10, 5));

            // Create three employees
            var employee1 = new Employee("Joey", "Tribianni", "Chief Medical Officer", DateTime.Now);
            var employee2 = new Employee("Chandler", "Bing", "IT Procurements Manager", DateTime.Now);
            var employee3 = new Employee("Rachel", "Green", "Chief Fashion Officer", DateTime.Now);

            // Assign the employees to the company
            company1.CurrentEmployees.Add(employee1);
            company1.CurrentEmployees.Add(employee2);
            company1.CurrentEmployees.Add(employee3);

            /*
                Iterate the company's employee list and generate the
                simple report shown above
            */
            foreach (Employee employee in company1.CurrentEmployees)
            {
            Console.WriteLine($"{employee.FirstName} {employee.LastName} work for {company1.Name} as {employee.Title} since {employee.StartDate}");
            }
        }
    }
}