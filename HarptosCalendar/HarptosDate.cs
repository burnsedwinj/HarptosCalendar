using System;
using System.Runtime.Serialization;

namespace HarptosCalendar
{
    [Serializable]
    public struct HarptosDate : IComparable, IComparable<HarptosDate>, IConvertible, IEquatable<HarptosDate>, IFormattable, ISerializable
    {

        #region Constructors
        public HarptosDate(int year, int dayOfYear)
        {

            var leapYear = year % 4 == 0;

            if (!leapYear && dayOfYear > 365)
            {
                year++;
                dayOfYear -= 365;
                this = new HarptosDate(year, dayOfYear);
            }
            else if (dayOfYear > 366)
            {
                year++;
                dayOfYear -= 366;
                this = new HarptosDate(year, dayOfYear);
            }
            if (!leapYear && dayOfYear < 1)
            {
                year--;
                dayOfYear += 365;
                this = new HarptosDate(year, dayOfYear);
            }
            else if (dayOfYear < 1)
            {
                year--;
                dayOfYear += 366;
                this = new HarptosDate(year, dayOfYear);
            }
            else
            {

                var holiday = 0;

                if (dayOfYear > 1 * 30 + 1) //Midwinter
                    holiday++;
                if (dayOfYear > 4 * 30 + 2) //Greengrass
                    holiday++;
                if (dayOfYear > 7 * 30 + 3) //Midsummer
                    holiday++;
                if (leapYear && (dayOfYear > 7 * 30 + 4))//Shieldmeet
                    holiday++;
                if (dayOfYear > 9 * 30 + (leapYear ? 5 : 4))//High harvest tide
                    holiday++;
                if (dayOfYear > 11 * 30 + (leapYear ? 6 : 5))//Feast of the moon
                    holiday++;

                switch (dayOfYear)
                {
                    case 30 + 1:
                        this = new HarptosDate(year, 1.1m);
                        break;
                    case 4 * 30 + 2:
                        this = new HarptosDate(year, 4.1m);
                        break;
                    case 7 * 30 + 3:
                        this = new HarptosDate(year, 7.1m);
                        break;
                    default:
                        {
                            if (leapYear && dayOfYear == 7 * 30 + 4)
                            {
                                this = new HarptosDate(year, 7.2m);
                            }
                            else if (dayOfYear == 9 * 30 + (leapYear ? 5 : 4))
                            {
                                this = new HarptosDate(year, 9.1m);
                            }
                            else if (dayOfYear == 11 * 30 + (leapYear ? 6 : 5))
                            {
                                this = new HarptosDate(year, 11.1m);
                            }
                            else
                            {

                                dayOfYear -= holiday;

                                int month;
                                
                                month = (dayOfYear / 30);

                                if (month != 12)
                                    month++;

                                int day;

                                if (dayOfYear % 30 == 0)
                                {
                                    day = 30;
                                }
                                else
                                {
                                    day = (dayOfYear % 30);
                                }

                                this = new HarptosDate(year, month, day);
                            }

                            break;
                        }
                }
            }

        }
        public HarptosDate(int year, decimal month = 1, int day = 1)
        {
            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12");
            if (day < 1 || day > 30)
                throw new ArgumentOutOfRangeException(nameof(day), "Day must be between 1 and 30");

            int extraDays;
            switch ((int)month)
            {
                case 1:
                    extraDays = 0;
                    break;
                case 2:
                case 3:
                case 4:
                    extraDays = 1;
                    break;
                case 5:
                case 6:
                case 7:
                    extraDays = 2;
                    break;
                case 8:
                case 9:
                    extraDays = 3;
                    break;
                case 10:
                case 11:
                    extraDays = 4;
                    break;
                case 12:
                    extraDays = 5;
                    break;
                default:
                    extraDays = 0;
                    break;
            }

            if (month > 7.1m && year % 4 == 0)
                extraDays++;


            if (month == 1.1m || month == 4.1m || month == 7.1m || month == 7.2m || month == 9.1m || month == 11.1m)
                DayOfYear = 30 * ((int)month) + day + extraDays; //its an extra day
            else
            {
                DayOfYear = 30 * (((int)month) - 1) + day + extraDays; //-1 cause the month isn't over yet    
            }
            


            Year = HarptosYear.GetHarptosYear(year);
            Month = HarptosMonth.GetHarptosMonth(month);
            Day = HarptosDay.GetHarptosDay(day);

            

        }
        #endregion

        #region Fields
        // ReSharper disable once UnusedMember.Global
        public static readonly HarptosDate MaxValue = new HarptosDate(1600,366);
        // ReSharper disable once UnusedMember.Global
        public static readonly HarptosDate MinValue = new HarptosDate(-700);
        #endregion

        #region Properties
        public HarptosDate Date => new HarptosDate(Year.Year, Month.Month, Day.Day);
        public HarptosDay Day { get; }
        public int DayOfYear { get; }
        public HarptosMonth Month { get; }
        public HarptosYear Year { get; }
        public HarptosHoliday Holiday => HarptosHoliday.GetHarptosHoliday(Month.Month, Day.Day);
        public bool IsLeapYear => Year.Year % 4 == 0;
        #endregion

        #region Methods
        public override bool Equals(object obj)
        {
            return obj is HarptosDate other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Day != null ? Day.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ DayOfYear;
                hashCode = (hashCode * 397) ^ (Month != null ? Month.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Year != null ? Year.GetHashCode() : 0);
                return hashCode;
            }
        }

        public int CompareTo(HarptosDate other)
        {
            if (this < other)
                return -1;

            if (this > other)
                return 1;

            return 0;
        }

        public bool Equals(HarptosDate other)
        {
            return this == other;
        }

        public override string ToString()
        {
            return ToString("D");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info));

            info.AddValue("Year", this.Year);
            info.AddValue("Month", this.Month.Month);
            info.AddValue("Day", this.Day.Day);
            info.AddValue("DayOfYear", this.DayOfYear);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return ToString();
        }

        public int CompareTo(object obj)
        {
            return CompareTo((HarptosDate)obj);
        }

        public string ToString(string format)
        {
            var isHoliday = Holiday != null;
            string s = null;
            switch (format)
            {
                case "d":
                    s = (Month.Month).ToString("0#.#") + "/" + Day.Day.ToString("00") + "/" + Year.Year.ToString("0000");
                    break;
                case "D" when isHoliday:
                    s = Holiday.Name + " of " + Year.Year + ": " + Year;
                    break;
                case "D":
                    s = Day + " in the month of " + Month + " in the year of " + Year.Year + ":" + Year;
                    break;
                case "m" when isHoliday:
                    s = Holiday.Name;
                    break;
                case "m":
                    s = Month + " " + Day.Day;
                    break;
                case "y" when isHoliday:
                    s = Holiday.Name;
                    break;
                case "y":
                    s = Month + " " + Year.Year;
                    break;
            }
            return s;
        }
        public HarptosDate AddDays(int days)
        {
            return new HarptosDate(Year.Year, DayOfYear + days);
        }
        public static HarptosDate operator +(HarptosDate d, HarptosTimeSpan t)
        {
            return new HarptosDate(d.Year.Year, d.Day.Day + t.Days);
        }
        public static HarptosDate operator -(HarptosDate d, HarptosTimeSpan t)
        {
            return new HarptosDate(d.Year.Year, d.Day.Day - t.Days);
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            long ticks = TimeSpan.TicksPerDay * (long)((this.Year.Year + 700) * 365.25 + this.DayOfYear);
            return new DateTime(ticks);
        }

        public string ToString(IFormatProvider provider)
        {
            return ToString();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            if (conversionType == typeof(DateTime))
            {
                return this.ToDateTime(provider);
            }
            throw new InvalidCastException();

        }
        #endregion

        #region Operators
        public static bool operator ==(HarptosDate d1, HarptosDate d2)
        {
            return d1.Year.Year == d2.Year.Year && d1.DayOfYear == d2.DayOfYear;
        }
        public static bool operator !=(HarptosDate d1, HarptosDate d2)
        {
            return d1.Year.Year != d2.Year.Year || d1.DayOfYear != d2.DayOfYear;
        }
        public static bool operator >(HarptosDate d1, HarptosDate d2)
        {
            return d1.Year.Year > d2.Year.Year || d1.DayOfYear > d2.DayOfYear;
        }
        public static bool operator >=(HarptosDate d1, HarptosDate d2)
        {
            return d1.Year.Year >= d2.Year.Year && d1.DayOfYear >= d2.DayOfYear;
        }
        public static bool operator <(HarptosDate d1, HarptosDate d2)
        {
            return d1.Year.Year < d2.Year.Year || d1.DayOfYear < d2.DayOfYear;
        }
        public static bool operator <=(HarptosDate d1, HarptosDate d2)
        {
            return d1.Year.Year <= d2.Year.Year && d1.DayOfYear <= d2.DayOfYear;
        }
        #endregion

    }
}