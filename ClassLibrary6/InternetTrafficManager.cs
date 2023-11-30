using System;

namespace ClassLibrary6
{
    /// <summary>
    /// Менеджер для анализа интернет-трафика.
    /// </summary>
    public class InternetTrafficManager
    {
        /// <summary>
        /// Перечисление типов протоколов.
        /// </summary>
        public enum ProtocolType
        {
            HTTP,   // Гипертекстовая передача (HTTP)
            FTP,    // Протокол передачи файлов (FTP)
            Torrent,    // Протокол BitTorrent (Torrent)
            IPTV    // Интернет-телевидение (IPTV)
        }

        /// <summary>
        /// Класс для хранения данных о интернет-трафике.
        /// </summary>
        public struct InternetTraffic
        {
            /// <summary>
            /// Дата использования трафика.
            /// </summary>
            public DateTime Date { get; set; }

            /// <summary>
            /// Тип протокола.
            /// </summary>
            public ProtocolType Protocol { get; set; }

            /// <summary>
            /// Использованный объем трафика в МБ.
            /// </summary>
            public double TrafficUsage { get; set; }

            /// <summary>
            /// Конструктор для создания экземпляра класса InternetTraffic.
            /// </summary>
            /// <param name="date">Дата использования трафика.</param>
            /// <param name="protocol">Тип протокола.</param>
            /// <param name="trafficUsage">Использованный объем трафика в МБ.</param>
            public InternetTraffic(DateTime date, ProtocolType protocol, double trafficUsage)
            {
                Date = date;
                Protocol = protocol;
                TrafficUsage = trafficUsage;
            }
        }

        /// <summary>
        /// Класс для анализа интернет-трафика.
        /// </summary>
        public struct TrafficAnalyzer
        {
            private InternetTraffic[] _trafficData;

            /// <summary>
            /// Конструктор для создания экземпляра класса TrafficAnalyzer.
            /// </summary>
            /// <param name="data">Массив данных о интернет-трафике.</param>
            public TrafficAnalyzer(InternetTraffic[] data)
            {
                _trafficData = data;
            }

            /// <summary>
            /// Вычисляет общий объем трафика на указанную дату.
            /// </summary>
            /// <param name="specifiedDate">Дата для анализа трафика.</param>
            /// <returns>Общий объем трафика в МБ на указанную дату.</returns>
            public double TotalTrafficOnDate(DateTime specifiedDate)
            {
                double totalTraffic = 0;

                foreach (InternetTraffic traffic in _trafficData)
                {
                    if (traffic.Date == specifiedDate)
                    {
                        totalTraffic += traffic.TrafficUsage;
                    }
                }

                return totalTraffic;
            }

            /// <summary>
            /// Вычисляет средний трафик за день для указанного протокола в заданном периоде.
            /// </summary>
            /// <param name="protocol">Тип протокола для анализа.</param>
            /// <param name="startDate">Начальная дата периода.</param>
            /// <param name="endDate">Конечная дата периода.</param>
            /// <returns>Средний трафик в МБ в день.</returns>
            public double AverageTrafficPerDay(ProtocolType protocol, DateTime startDate, DateTime endDate)
            {
                double avgTraffic = 0;
                int daysCount = 0;

                if (endDate < startDate)
                {
                    throw new InternetTrafficException("Конечная дата не может быть раньше начальной даты.");
                }

                foreach (InternetTraffic traffic in _trafficData)
                {
                    if (traffic.Protocol == protocol && traffic.Date >= startDate && traffic.Date <= endDate)
                    {
                        avgTraffic += traffic.TrafficUsage;
                        daysCount++;
                    }
                }

                return avgTraffic / daysCount;
            }

            /// <summary>
            /// Определяет день с максимальным трафиком для указанного протокола.
            /// </summary>
            /// <param name="protocol">Тип протокола для анализа.</param>
            /// <returns>Дата с максимальным трафиком для указанного протокола.</returns>
            public DateTime DayWithMaxTraffic(ProtocolType protocol)
            {
                DateTime maxTrafficDate = DateTime.MinValue;
                double maxTraffic = 0;

                foreach (InternetTraffic traffic in _trafficData)
                {
                    if (traffic.Protocol == protocol && traffic.TrafficUsage > maxTraffic)
                    {
                        maxTraffic = traffic.TrafficUsage;
                        maxTrafficDate = traffic.Date;
                    }
                }

                return maxTrafficDate;
            }
        }
    }
}
