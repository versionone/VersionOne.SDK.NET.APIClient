using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VersionOne.SDK.MSTestExtensions;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
    [TestClass]
    public class DurationTester
    {
        [TestMethod]
        public void DefaultUnitsToDays()
        {
            Duration d = new Duration();
            Assert.AreEqual(Duration.Unit.Days, d.Units);
        }

        [TestMethod]
        public void InitializeWithTimeSpanInDays()
        {
            Duration d = new Duration(new TimeSpan(5, 0, 0, 0));
            Assert.AreEqual(5, d.Amount, "Amount");
            Assert.AreEqual(Duration.Unit.Days, d.Units, "Units");
        }

        [TestMethod]
        public void InitializeWithTimeSpanInWeeks()
        {
            Duration d = new Duration(new TimeSpan(21, 0, 0, 0));
            Assert.AreEqual(3, d.Amount, "Amount");
            Assert.AreEqual(Duration.Unit.Weeks, d.Units, "Units");
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void CannotHaveNegativeDuration()
        {
            Duration d = new Duration(-3, Duration.Unit.Days);
        }

        [TestMethod]
        public void InferYears()
        {
            Duration d = new Duration(TimeSpan.FromDays(365 + 366));
            Assert.AreEqual(24, d.Amount, "Amount");
            Assert.AreEqual(Duration.Unit.Months, d.Units, "Units");
        }

        [TestMethod]
        public void InferMonths()
        {
            Duration d = new Duration(TimeSpan.FromDays(91.25));
            Assert.AreEqual(3, d.Amount, "Amount");
            Assert.AreEqual(Duration.Unit.Months, d.Units, "Units");
        }

        [TestMethod]
        public void InferWeeks()
        {
            Duration d = new Duration(TimeSpan.FromDays(28));
            Assert.AreEqual(4, d.Amount, "Amount");
            Assert.AreEqual(Duration.Unit.Weeks, d.Units, "Units");
        }

        [TestMethod]
        public void DaysToString()
        {
            Duration d = new Duration(5, Duration.Unit.Days);
            Assert.AreEqual("5 Days", d.ToString());
        }

        [TestMethod]
        public void WeeksToString()
        {
            Duration d = new Duration(5, Duration.Unit.Weeks);
            Assert.AreEqual("5 Weeks", d.ToString());
        }

        [TestMethod]
        public void MonthsToString()
        {
            Duration d = new Duration(5, Duration.Unit.Months);
            Assert.AreEqual("5 Months", d.ToString());
        }

        [TestMethod]
        public void ParseDays()
        {
            Duration d = Duration.Parse("10 Days");
            Assert.AreEqual(10, d.Amount, "Amount");
            Assert.AreEqual(Duration.Unit.Days, d.Units, "Units");
        }

        [TestMethod]
        public void ParseWeeks()
        {
            Duration d = Duration.Parse("10 Weeks");
            Assert.AreEqual(10, d.Amount, "Amount");
            Assert.AreEqual(Duration.Unit.Weeks, d.Units, "Units");
        }

        [TestMethod]
        public void ParseMonths()
        {
            Duration d = Duration.Parse("10 Months");
            Assert.AreEqual(10, d.Amount, "Amount");
            Assert.AreEqual(Duration.Unit.Months, d.Units, "Units");
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void ParseBadAmount()
        {
            Duration d = Duration.Parse("1x0 Months");
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void ParseBadUnit()
        {
            Duration d = Duration.Parse("10 Moons");
        }

        [TestMethod]
        public void ParseNull()
        {
            Duration d = Duration.Parse(null);
            Assert.AreEqual(d.Amount, 0);
            Assert.AreEqual(d.Units, Duration.Unit.Days);
        }

        [TestMethod]
        public void Equality()
        {
            Duration d1 = new Duration(12, Duration.Unit.Weeks);
            Duration d2 = new Duration(12, Duration.Unit.Weeks);
            Assert.AreEqual(d1, d2);
        }

        [TestMethod]
        public void EqualOpTrue()
        {
            Duration d1 = new Duration(12, Duration.Unit.Weeks);
            Duration d2 = new Duration(12, Duration.Unit.Weeks);
            Assert.IsTrue(d1 == d2);
        }

        [TestMethod]
        public void EqualOpFalse()
        {
            Duration d1 = new Duration(12, Duration.Unit.Weeks);
            Duration d2 = new Duration(13, Duration.Unit.Weeks);
            Assert.IsFalse(d1 == d2);
        }

        [TestMethod]
        public void NotEqualOpTrue()
        {
            Duration d1 = new Duration(12, Duration.Unit.Weeks);
            Duration d2 = new Duration(13, Duration.Unit.Weeks);
            Assert.IsTrue(d1 != d2);
        }

        [TestMethod]
        public void NotEqualOpFalse()
        {
            Duration d1 = new Duration(12, Duration.Unit.Weeks);
            Duration d2 = new Duration(12, Duration.Unit.Weeks);
            Assert.IsFalse(d1 != d2);
        }

        [TestMethod]
        public void ToStringZero()
        {
            Assert.AreEqual("0 Days", new Duration(0, Duration.Unit.Weeks).ToString());
        }

        [TestMethod]
        public void FromStringZero()
        {
            Assert.AreEqual(new Duration(0, Duration.Unit.Weeks), Duration.Parse("0"));
        }

        [TestMethod]
        public void DaysConversionWeeksToDays()
        {
            Duration d1 = new Duration(12, Duration.Unit.Weeks);
            Assert.AreEqual(84, d1.Days);
        }

        [TestMethod]
        public void DaysConversionMonthToDays()
        {
            Duration d1 = new Duration(1, Duration.Unit.Months);
            Assert.AreEqual(30, d1.Days);
        }

        [TestMethod]
        public void DaysConversionMonthsToDays()
        {
            Duration d1 = new Duration(2, Duration.Unit.Months);
            Assert.AreEqual(61, d1.Days);
        }

        [TestMethod]
        public void DaysConversionSemiYearToDays()
        {
            Duration d1 = new Duration(6, Duration.Unit.Months);
            Assert.AreEqual(183, d1.Days);
        }

        [TestMethod]
        public void DaysConversionYearToDays()
        {
            Duration d1 = new Duration(12, Duration.Unit.Months);
            Assert.AreEqual(365, d1.Days);
        }

        [TestMethod]
        public void DaysConversionLucky13MonthsToDays()
        {
            Duration d1 = new Duration(13, Duration.Unit.Months);
            Assert.AreEqual(395, d1.Days);
        }

        [TestMethod]
        public void DaysPropertyToDays()
        {
            Duration d = new Duration(5, Duration.Unit.Days);
            Assert.AreEqual(5, d.Days);
        }

        [ExpectedException(typeof(NotSupportedException))]
        [TestMethod]
        public void DaysPropertyBadUnits()
        {
            Duration d = new Duration(5, (Duration.Unit)2000);
            int days = d.Days;
        }

        [TestMethod]
        public void AddToDays()
        {
            Duration d = new Duration(5, Duration.Unit.Days);
            Assert.AreEqual(new DateTime(2000, 1, 6), d.AddTo(new DateTime(2000, 1, 1)));
        }

        [TestMethod]
        public void AddToMonths()
        {
            Duration d = new Duration(5, Duration.Unit.Months);
            Assert.AreEqual(new DateTime(2000, 6, 1), d.AddTo(new DateTime(2000, 1, 1)));
        }

        [TestMethod]
        public void AddToWeeks()
        {
            Duration d = new Duration(3, Duration.Unit.Weeks);
            Assert.AreEqual(new DateTime(2000, 1, 22), d.AddTo(new DateTime(2000, 1, 1)));
        }

        [ExpectedExceptionAndMessage(typeof(InvalidOperationException), "Unsupported Duration Unit 2000")]
        [TestMethod]
        public void AddToBadUnits()
        {
            Duration d = new Duration(5, (Duration.Unit)2000);
            d.AddTo(new DateTime(2000, 1, 1));
        }

        [TestMethod]
        public void ConvertibleToString()
        {
            Assert.AreEqual("0 Days", ((IConvertible)new Duration()).ToString(CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void ToTypeString()
        {
            Assert.AreEqual("0 Days", new Duration().ToType(typeof(string), CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void ToTypeDuration()
        {
            Assert.AreEqual(new Duration(), new Duration().ToType(typeof(Duration), CultureInfo.InvariantCulture));
        }

        #region Conversion Exceptions
        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public void ToTypeOther() { new Duration().ToType(typeof(int), CultureInfo.InvariantCulture); }

        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public void ConvertToBoolean() { new Duration().ToBoolean(CultureInfo.InvariantCulture); }

        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public void ConvertToByte() { new Duration().ToByte(CultureInfo.InvariantCulture); }

        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public void ConvertToChar() { new Duration().ToChar(CultureInfo.InvariantCulture); }

        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public void ConvertToDateTime() { new Duration().ToDateTime(CultureInfo.InvariantCulture); }

        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public void ConvertToDecimal() { new Duration().ToDecimal(CultureInfo.InvariantCulture); }

        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public void ConvertToDouble() { new Duration().ToDouble(CultureInfo.InvariantCulture); }

        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public void ConvertToInt16() { new Duration().ToInt16(CultureInfo.InvariantCulture); }

        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public void ConvertToInt32() { new Duration().ToInt32(CultureInfo.InvariantCulture); }

        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public void ConvertToInt64() { new Duration().ToInt64(CultureInfo.InvariantCulture); }

        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public void ConvertToSByte() { new Duration().ToSByte(CultureInfo.InvariantCulture); }

        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public void ConvertToSingle() { new Duration().ToSingle(CultureInfo.InvariantCulture); }

        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public void ConvertToUInt16() { new Duration().ToUInt16(CultureInfo.InvariantCulture); }

        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public void ConvertToUInt32() { new Duration().ToUInt32(CultureInfo.InvariantCulture); }

        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public void ConvertToUInt64() { new Duration().ToUInt64(CultureInfo.InvariantCulture); }
        #endregion
    }
}
