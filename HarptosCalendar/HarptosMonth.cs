using System.Collections.Generic;
using System.Linq;

namespace HarptosCalendar
{
    public class HarptosMonth
    {
        private HarptosMonth(decimal month, string name, string secondaryName = null, string tertiaryName = null)
        {
            Month = month;
            Name = name;
            _secondaryName = secondaryName;
            _tertiaryName = tertiaryName;
        }

        private string _secondaryName;
        private string _tertiaryName;
        public decimal Month { get; protected set; }
        public string Name { get; protected set; }
        public string SecondaryName
        {
            get => _secondaryName ?? Name;
            protected set => _secondaryName = value;
        }
        public string TertiaryName
        {
            get => _tertiaryName ?? SecondaryName;
            protected set => _tertiaryName = value;
        }
        public static List<HarptosMonth> HarptosMonths()
        {
            return new List<HarptosMonth>
            {
                new HarptosMonth(1,"Hammer","Deepwinter"),
                new HarptosMonth(1.1m,"Midwinter"),
                new HarptosMonth(2,"Alturiak","The Claw of Winter","The Claws of the Cold"),
                new HarptosMonth(3,"Ches","The Claw of Sunsets"),
                new HarptosMonth(4,"Tarsakh","The Claw of Storms"),
                new HarptosMonth(4.1m,"Greengrass"),
                new HarptosMonth(5,"Mirtul","The Melting"),
                new HarptosMonth(6,"Kythorn","The Time of Flowers"),
                new HarptosMonth(7,"Flamerule","Summertide"),
                new HarptosMonth(7.1m,"Midsummer"),
                new HarptosMonth(7.2m,"Shieldmeet"),
                new HarptosMonth(8,"Eleasis","Highsun"),
                new HarptosMonth(9,"Eleint","The Fading"),
                new HarptosMonth(9.1m,"Highharvestide"),
                new HarptosMonth(10,"Marpenoth","Leaffall"),
                new HarptosMonth(11,"Uktar","The Rotting"),
                new HarptosMonth(11.1m,"Feast of the Moon"),
                new HarptosMonth(12,"Nightal","The Drawing Down"),

            };
        }
        public static HarptosMonth GetHarptosMonth(decimal month)
        {
            return HarptosMonths().FirstOrDefault(x => x.Month == month);

        }

        public static HarptosMonth GetHarptosMonth(string monthName, NameType nameType = NameType.Name)
        {
            HarptosMonth harptosMonth;
            switch (nameType)
            {
                case NameType.Name:
                    harptosMonth = HarptosMonths().FirstOrDefault(x => x.Name == monthName);
                    break;
                case NameType.SecondaryName:
                    harptosMonth = HarptosMonths().FirstOrDefault(x => x.SecondaryName == monthName);
                    break;
                case NameType.TertiaryName:
                    harptosMonth = HarptosMonths().FirstOrDefault(x => x.TertiaryName == monthName);
                    break;
                default:
                    harptosMonth = HarptosMonths().FirstOrDefault(x => x.Name == monthName);
                    break;
            }

            return harptosMonth;

        }

        public enum NameType
        {
            Name = 1,
            SecondaryName,
            TertiaryName
        }

        public override string ToString()
        {
            return Name;
        }
    }
}