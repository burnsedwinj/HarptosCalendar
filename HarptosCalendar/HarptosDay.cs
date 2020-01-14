using System.Collections.Generic;
using System.Linq;

namespace HarptosCalendar
{
    public class HarptosDay
    {
        public int Day { get; }
        public string Name { get; }
        public string Tenday { get; }
        public HarptosDay(int day, string name, string tenday)
        {
            Day = day;
            Name = name;
            Tenday = tenday;
        }

        public static List<HarptosDay> HarptosDays = new List<HarptosDay>
            {
                new HarptosDay(0,"Zero","zero"),
                new HarptosDay(1,"First","First"),
                new HarptosDay(2,"Second","First"),
                new HarptosDay(3,"Third","First"),
                new HarptosDay(4,"Fourth","First"),
                new HarptosDay(5,"Fifth","First"),
                new HarptosDay(6,"Sixth","First"),
                new HarptosDay(7,"Seventh","First"),
                new HarptosDay(8,"Eighth","First"),
                new HarptosDay(9,"Ninth","First"),
                new HarptosDay(10,"Tenth","First"),
                new HarptosDay(11,"First","Second"),
                new HarptosDay(12,"Second","Second"),
                new HarptosDay(13,"Third","Second"),
                new HarptosDay(14,"Fourth","Second"),
                new HarptosDay(15,"Fifth","Second"),
                new HarptosDay(16,"Sixth","Second"),
                new HarptosDay(17,"Seventh","Second"),
                new HarptosDay(18,"Eighth","Second"),
                new HarptosDay(19,"Ninth","Second"),
                new HarptosDay(20,"Tenth","Second"),
                new HarptosDay(21,"First","Third"),
                new HarptosDay(22,"Second","Third"),
                new HarptosDay(23,"Third","Third"),
                new HarptosDay(24,"Fourth","Third"),
                new HarptosDay(25,"Fifth","Third"),
                new HarptosDay(26,"Sixth","Third"),
                new HarptosDay(27,"Seventh","Third"),
                new HarptosDay(28,"Eighth","Third"),
                new HarptosDay(29,"Ninth","Third"),
                new HarptosDay(30,"Tenth","Third"),
            };


        public static HarptosDay GetHarptosDay(int day)
        {
            return HarptosDays.FirstOrDefault(x => x.Day == day);
        }
        // ReSharper disable once UnusedMember.Global
        public static HarptosDay GetHarptosDay(string name)
        {
            return HarptosDays.FirstOrDefault(x => x.Name == name);
        }

        public override string ToString()
        {
            return "The " + Name + " day of the " + Tenday + " tenday";
        }
    }
}