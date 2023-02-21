using System;
using System.Globalization;
using PedidosLoja.Entities.Enums;
using PedidosLoja.Entities;

namespace PedidosLoja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre com o departamento: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Entre com os dados do trabalhador: ");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Nível (junior/pleno/senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Salário Base: ");
            double baseSalary = double .Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);


            Console.Write("Quantos contratos para esse trabalhador? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Entre com a data do contrato #{i}: ");
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duração (horas): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Entre com o mês e ano para calcular os ganhos (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine("Nome: " + worker.Name);
            Console.WriteLine("Departamento: " + worker.Department.Name);
            Console.WriteLine("Ganhos até " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}