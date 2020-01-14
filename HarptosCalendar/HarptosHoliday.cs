using System.Collections.Generic;
using System.Linq;

namespace HarptosCalendar
{
    public class HarptosHoliday
    {
        public string Name { get; }
        public int Day { get; }
        public decimal Month { get; }

        public HarptosHoliday(string name, decimal month, int day)
        {
            Name = name;
            Month = month;
            Day = day;
        }
        public static List<HarptosHoliday> HarptosHolidays =
            new List<HarptosHoliday>
            {
                new HarptosHoliday("Midwinter",1.1m, 1), //31
                new HarptosHoliday("Spring Equinox",3, 19), //80  
                new HarptosHoliday("Greengrass",4.1m, 1), //122
                new HarptosHoliday("Summer Solstice",6, 20), //172
                new HarptosHoliday("Midsummer",7.1m, 1), //213
                new HarptosHoliday("Shieldmeet",7.2m, 1), //214
                new HarptosHoliday("Autumn Equinox",9, 21), //264/5
                new HarptosHoliday("Highharvestide",9.1m, 1), //274/5
                new HarptosHoliday("Feast of the Moon",11.1m, 1), //334/5
                new HarptosHoliday("Winter Solstice",12, 20), //355/356
            };

        // ReSharper disable once UnusedMember.Global
        public static HarptosHoliday GetHarptosHoliday(string name)
        {
            return HarptosHolidays.FirstOrDefault(x => x.Name == name);
        }
        public static HarptosHoliday GetHarptosHoliday(decimal month, int day)
        {
            return HarptosHolidays.FirstOrDefault(x => x.Month == month && x.Day == day);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}