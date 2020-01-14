using HarptosCalendar;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HarptosCalendarTests
{
    [TestClass]
    public class HarptosDateTests
    {
        public const int FirstYear = -700;
        public const int MiddleYearLeap = 500;
        public const int MiddleYearNoLeap = 501;
        public const int LastYear = 1600;
        public const int FirstDayOfYear = 1;
        public const int MiddleDayOfYear = 132;
        public const int LastDayOfYearNoLeap = 365;
        public const int LastDayOfYearLeap = 366;
        public const int DayTooBig = 31;
        public const int DayTooSmall = 30;
        public const int HMidwinter = 31;
        public const int HSpringEquinox = 80;
        public const int HGreengrass = 122;
        public const int HSummerSolstice = 172;
        public const int HMidsummer = 213;
        public const int HShieldmeet = 214;
        public const int HAutumnEquinox = 264;
        public const int HAutumnEquinoxLeap = 265;
        public const int HHighharvestide = 274;
        public const int HHighharvestideLeap = 275;
        public const int HFeastOfTheMoon = 335;
        public const int HFeastOfTheMoonLeap= 336;
        public const int HWinterSolstice = 355;
        public const int HWinterSolsticeLeap = 356;

        [TestMethod]
        public void HarptosDateConstructor1_FirstYear_FirstDayOfYear_ReturnsHarptosDate()
        {
            var test = new HarptosDate(FirstYear, FirstDayOfYear);

            Assert.AreEqual(FirstYear, test.Year.Year);
            Assert.AreEqual(FirstDayOfYear, test.DayOfYear);
        }

        [TestMethod]
        public void HarptosDateConstructor1_MiddleYearNoLeap_LastDayOfYearNoLeap_ReturnsHarptosDate()
        {
            var test = new HarptosDate(MiddleYearNoLeap, LastDayOfYearNoLeap);

            Assert.AreEqual(MiddleYearNoLeap, test.Year.Year);
            Assert.AreEqual(LastDayOfYearNoLeap, test.DayOfYear);
        }

        [TestMethod]
        public void HarptosDateConstructor1_LastYear_LastDayOfYearLeap_ReturnsHarptosDate()
        {
            var test = new HarptosDate(LastYear, LastDayOfYearLeap);

            Assert.AreEqual(LastYear, test.Year.Year);
            Assert.AreEqual(LastDayOfYearLeap, test.DayOfYear);
        }

        [TestMethod]
        public void HarptosDateConstructor1_MiddleYearNoLeap_MiddleDayOfYear_ReturnsHarptosDate()
        {
            var test = new HarptosDate(MiddleYearNoLeap, MiddleDayOfYear);

            Assert.AreEqual(MiddleYearNoLeap, test.Year.Year);
            Assert.AreEqual(MiddleDayOfYear, test.DayOfYear);
        }

        [DataTestMethod]
        [DataRow(HMidwinter)]
        [DataRow(HSpringEquinox)]
        [DataRow(HGreengrass)]
        [DataRow(HSummerSolstice)]
        [DataRow(HMidsummer)]
        [DataRow(HAutumnEquinox)]
        [DataRow(HHighharvestide)]
        [DataRow(HFeastOfTheMoon)]
        [DataRow(HWinterSolstice)]
        public void HarptosDateConstructor1_MiddleYearNoLeap_HolidaysNoLeap_ReturnsHarptosDate(int day)
        {
            var test = new HarptosDate(MiddleYearNoLeap, day);

            Assert.AreEqual(MiddleYearNoLeap, test.Year.Year);
            Assert.AreEqual(day, test.DayOfYear);
            Assert.IsNotNull(test.Holiday);
        }

        [DataTestMethod]
        [DataRow(HMidwinter)]
        [DataRow(HSpringEquinox)]
        [DataRow(HGreengrass)]
        [DataRow(HSummerSolstice)]
        [DataRow(HMidsummer)]
        [DataRow(HShieldmeet)]
        [DataRow(HAutumnEquinoxLeap)]
        [DataRow(HHighharvestideLeap)]
        [DataRow(HFeastOfTheMoonLeap)]
        [DataRow(HWinterSolsticeLeap)]

        public void HarptosDateConstructor1_MiddleYearLeap_HolidaysLeap_ReturnsHarptosDate(int day)
        {
            var test = new HarptosDate(MiddleYearLeap, day);

            Assert.AreEqual(MiddleYearLeap, test.Year.Year);
            Assert.AreEqual(day, test.DayOfYear);
            Assert.IsNotNull(test.Holiday);
        }



    }
}
