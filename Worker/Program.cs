using System;
using System.Globalization;
using Worker.Entities.Enums;
using Worker.Entities;


namespace Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department name: ");
            string departmentName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter worker data:");
            Console.WriteLine();
            
            Console.Write("Name: ");
            string workerName = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            string level = Console.ReadLine();
            WorkerLevel levels;
            Enum.TryParse<WorkerLevel>(level, true, out levels);
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo. InvariantCulture);
            Console.WriteLine();

            Console.Write("How many contracts to this worker? ");
            int contracts = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Department d = new Department(departmentName);
            Workers worker = new Workers(workerName, levels, baseSalary, d);

            for (int i = 1; i <= contracts; i++)
            {
                Console.WriteLine($"Enter the #{i} contract data");
                Console.WriteLine();
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                Console.WriteLine();

                HourContract c = new HourContract(date, valuePerHour, hours);
                worker.AddContract(c);

            }
            Console.WriteLine();

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string dateIncome = Console.ReadLine();
            int month = int.Parse(dateIncome.Substring(0, 2));
            int year = int.Parse(dateIncome.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for: " + dateIncome + ": " + worker.Income(year,month).ToString("F2", CultureInfo.InvariantCulture));

            Console.ReadLine();


            

            

            





        
        }
    }
}
