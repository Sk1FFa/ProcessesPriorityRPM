using System;
using System.Diagnostics;

namespace MyProcessSample
{
    class Processes
    {
        static void Main()
        {
            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                Console.WriteLine("Process: {0}\n ID: {1}\n Priority: {2}\n", theprocess.ProcessName, theprocess.Id, theprocess.BasePriority);
            }

            Console.Write("\nВведите ID процесса: ");
            string? id = Console.ReadLine();
            using (Process chosen = Process.GetProcessById(Int32.Parse(id)))
            {

                Console.WriteLine("\nПроцесс который вы выбрали: {0}({1})\nПриориет процесса: {2}\n", chosen.ProcessName, chosen.Id, chosen.BasePriority);
                Console.WriteLine();
            }

            Console.WriteLine("1 - Idle (Низкий)\n2 - Normal (Обычный)\n3 - High (Высокий)\n4 - RealTime (Реального времени)\n");
            Console.Write("Введите число принимающее значение приоритета, который вы хотите назранчить для этого процесса: ");

            int i = int.Parse(Console.ReadLine());

            if (i == 1)
            {
                Console.WriteLine("\nВы установили приоритет - Idle (Низкий)");
                Process.GetProcessById(Int32.Parse(id)).PriorityClass = ProcessPriorityClass.Idle;
            }
            else if (i == 2)
            {
                Console.WriteLine("\nВы установили приоритет - Normal (Обычный)");
                Process.GetProcessById(Int32.Parse(id)).PriorityClass = ProcessPriorityClass.Normal;
            }
            else if (i == 3)
            {
                Console.WriteLine("\nВы установили приоритет - High (Высокий)");
                Process.GetProcessById(Int32.Parse(id)).PriorityClass = ProcessPriorityClass.High;
            }
            else if (i == 4)
            {
                Console.WriteLine("\nВы установили приоритет - RealTime (Реального времени)");
                Process.GetProcessById(Int32.Parse(id)).PriorityClass = ProcessPriorityClass.RealTime;
            }
            else
                Console.WriteLine("\nВы ввели некорректное значение.");

            Console.WriteLine("\nНажмите Enter для завершения.");
        }
    }
}