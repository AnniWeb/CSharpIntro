using System;
using System.Diagnostics;
using System.Threading;

namespace les6
{
    class Program
    {
        private static bool killProcess(Process curProcess)
        {
            try
            {
                if (curProcess.CloseMainWindow())
                {
                    curProcess.Close();
                    return true;
                }
                else
                {
                    curProcess.Kill(true);
                }
            }
            catch (NotSupportedException)
            {
                
            }
            catch (InvalidOperationException)
            {
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return false;
        }
        
        /**
         * les6.exe list
         * les6.exe kill -i ID
         * les6.exe kill -n NAME
         */
        static void Main(string[] args)
        {
            Process[] listProcesses;
            
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "list":
                        listProcesses = Process.GetProcesses();
                        Console.WriteLine("Текущие процессы:");
                        Console.WriteLine("{0} {1}", "id", "name");
                        for (int i = 0; i < listProcesses.Length; i++)
                        {
                            Process curProcess = listProcesses[i];
                            Console.WriteLine($"{curProcess.Id, 10} {curProcess.ProcessName, 20}");
                        }

                        return;
                    case "kill":
                        if (args.Length > 2)
                        {
                            if (args[2] == String.Empty)
                            {
                                Console.WriteLine("Не передан индентификатор процесса");
                                return;
                            }
                            switch (args[1])
                            {
                                case "--name":
                                case "-n":
                                case "":
                                    listProcesses = Process.GetProcessesByName(args[2]);
                                    if (listProcesses.Length == 0)
                                    {
                                        Console.WriteLine("Процесс не найден");
                                        return;
                                    }
                                    for (int i = 0; i < listProcesses.Length; i++)
                                    {
                                        if (killProcess(listProcesses[i]) && i != listProcesses.Length-1)
                                        {
                                            // Задержка для закрытия многопоточных процессов
                                            Thread.Sleep(2000);
                                        }
                                    }
                                    break;
                                case "--id":
                                case "-i":
                                    killProcess(Process.GetProcessById(Int32.Parse(args[2])));
                                    break;
                                default:
                                    Console.WriteLine("Неизвестная команда");
                                    return;
                            }
                            Console.WriteLine("Процесс успешно завершен");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Не передан индентификатор процесса");
                            return;
                        }
                }
                
                Console.WriteLine("Неизвестная команда");
            }
            
        }
    }
}