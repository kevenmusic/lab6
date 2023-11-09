using System;
using static ClassLibrary6.InternetTrafficManager;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InternetTraffic[] trafficData = new InternetTraffic[]
          {
                new InternetTraffic(new DateTime(2023, 11, 5), ProtocolType.HTTP, 100),
                new InternetTraffic(new DateTime(2023, 11, 6), ProtocolType.FTP, 50),
                new InternetTraffic(new DateTime(2023, 11, 6), ProtocolType.HTTP, 200),
                new InternetTraffic(new DateTime(2023, 11, 20), ProtocolType.Torrent, 250),
          };

            TrafficAnalyzer analyzer = new TrafficAnalyzer(trafficData);

            while (true)
            {
                Console.Clear();

                Console.WriteLine("|-------------------------------------------------------|");
                Console.WriteLine("|                   Выберите действие:                  |");
                Console.WriteLine("|          1. Показать трафик на указанную дату         |");
                Console.WriteLine("|   2. Показать средний трафик по протоколу за период   |");
                Console.WriteLine("|   3. Найти день с максимальным трафиком по протоколу  |");
                Console.WriteLine("|                       4. Выйти                        |");
                Console.WriteLine("|-------------------------------------------------------|");


                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите дату в формате ГГГГ-ММ-ДД: ");
                        try
                        {
                            DateTime specifiedDate = DateTime.Parse(Console.ReadLine());
                            double totalTraffic = analyzer.TotalTrafficOnDate(specifiedDate);

                            if (totalTraffic > 0)
                            {
                                Console.WriteLine($"Израсходовано трафика на дату {specifiedDate.ToShortDateString()}: {totalTraffic} МБ");

                            }
                            else
                            {
                                Console.WriteLine($"Данных за указанную дату не найдено.");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Некорректный формат даты. Пожалуйста, используйте формат ГГГГ-ММ-ДД.");
                        }

                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "2":
                        Console.WriteLine("Введите протокол (HTTP, FTP, Torrent, IPTV): ");
                        string protocolInput = Console.ReadLine();
                        ProtocolType protocol;

                        if (Enum.TryParse(protocolInput, true, out protocol))
                        {
                            Console.WriteLine("Введите начальную дату в формате ГГГГ-ММ-ДД: ");
                            DateTime startDate;

                            try
                            {
                                startDate = DateTime.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Некорректный формат даты. Пожалуйста, используйте формат ГГГГ-ММ-ДД.");
                                Console.WriteLine("Нажмите Enter для продолжения...");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }

                            Console.WriteLine("Введите конечную дату в формате ГГГГ-ММ-ДД: ");
                            DateTime endDate;

                            try
                            {
                                endDate = DateTime.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Некорректный формат даты. Пожалуйста, используйте формат ГГГГ-ММ-ДД.");
                                Console.WriteLine("Нажмите Enter для продолжения...");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }

                            if (endDate < startDate)
                            {
                                Console.WriteLine("Конечная дата не может быть раньше начальной даты. Возврат к предыдущему меню.");
                                break;
                            }

                            double avgTraffic = analyzer.AverageTrafficPerDay(protocol, startDate, endDate);

                            if (avgTraffic > 0)
                            {
                                Console.WriteLine($"Средний трафик за период: {avgTraffic} МБ в день");
                            }
                            else
                            {
                                Console.WriteLine($"Данных за указанный период не найдено.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный протокол. Пожалуйста, используйте одно из значений: HTTP, FTP, Torrent, IPTV");
                        }

                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "3":
                        Console.Write("Введите протокол (HTTP, FTP, Torrent, IPTV): ");
                        protocolInput = Console.ReadLine();
                        ProtocolType searchProtocol;

                        if (Enum.TryParse(protocolInput, true, out searchProtocol))
                        {
                            DateTime maxTrafficDate = analyzer.DayWithMaxTraffic(searchProtocol);
                            Console.WriteLine($"Наибольший трафик по протоколу {searchProtocol} был в день {maxTrafficDate.ToShortDateString()}");
                        }
                        else
                        {
                            Console.WriteLine("Некорректный протокол. Пожалуйста, используйте одно из значений: HTTP, FTP, Torrent, IPTV");
                        }

                        Console.WriteLine("Нажмите Enter для продолжения...");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                            
                    case "4":
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}