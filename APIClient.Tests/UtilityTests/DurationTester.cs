using System;
using System.Globalization;
using NUnit.Framework;

namespace VersionOne.SDK.APIClient.Tests.UtilityTests
{
	[TestFixture]
	public class DurationTester
	{
		[Test] public void DefaultUnitsToDays ()
		{
			Duration d = new Duration();
			Assert.AreEqual(Duration.Unit.Days, d.Units);
		}

		[Test] public void InitializeWithTimeSpanInDays ()
		{
			Duration d = new Duration( new TimeSpan(5, 0, 0, 0) );
			Assert.AreEqual(5, d.Amount, "Amount");
			Assert.AreEqual(Duration.Unit.Days, d.Units, "Units");
		}

		[Test] public void InitializeWithTimeSpanInWeeks ()
		{
			Duration d = new Duration( new TimeSpan(21, 0, 0, 0) );
			Assert.AreEqual(3, d.Amount, "Amount");
			Assert.AreEqual(Duration.Unit.Weeks, d.Units, "Units");
		}

		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		[Test] public void CannotHaveNegativeDuration ()
		{
			Duration d = new Duration(-3, Duration.Unit.Days);
		}

		[Test] public void InferYears ()
		{
			Duration d = new Duration(TimeSpan.FromDays(365+366));
			Assert.AreEqual(24, d.Amount, "Amount");
			Assert.AreEqual(Duration.Unit.Months, d.Units, "Units");
		}

		[Test] public void InferMonths ()
		{
			Duration d = new Duration(TimeSpan.FromDays(91.25));
			Assert.AreEqual(3, d.Amount, "Amount");
			Assert.AreEqual(Duration.Unit.Months, d.Units, "Units");
		}

		[Test] public void InferWeeks ()
		{
			Duration d = new Duration(TimeSpan.FromDays(28));
			Assert.AreEqual(4, d.Amount, "Amount");
			Assert.AreEqual(Duration.Unit.Weeks, d.Units, "Units");
		}

		[Test] public void DaysToString ()
		{
			Duration d = new Duration(5, Duration.Unit.Days);
			Assert.AreEqual("5 Days", d.ToString());
		}

		[Test] public void WeeksToString ()
		{
			Duration d = new Duration(5, Duration.Unit.Weeks);
			Assert.AreEqual("5 Weeks", d.ToString());
		}

		[Test] public void MonthsToString ()
		{
			Duration d = new Duration(5, Duration.Unit.Months);
			Assert.AreEqual("5 Months", d.ToString());
		}

		[Test] public void ParseDays ()
		{
			Duration d = Duration.Parse("10 Days");
			Assert.AreEqual(10, d.Amount, "Amount");
			Assert.AreEqual(Duration.Unit.Days, d.Units, "Units");
		}

		[Test] public void ParseWeeks ()
		{
			Duration d = Duration.Parse("10 Weeks");
			Assert.AreEqual(10, d.Amount, "Amount");
			Assert.AreEqual(Duration.Unit.Weeks, d.Units, "Units");
		}

		[Test] public void ParseMonths ()
		{
			Duration d = Duration.Parse("10 Months");
			Assert.AreEqual(10, d.Amount, "Amount");
			Assert.AreEqual(Duration.Unit.Months, d.Units, "Units");
		}

		[ExpectedException(typeof(FormatException))]
		[Test] public void ParseBadAmount ()
		{
			Duration d = Duration.Parse("1x0 Months");
		}

		[ExpectedException(typeof(FormatException))]
		[Test] public void ParseBadUnit ()
		{
			Duration d = Duration.Parse("10 Moons");
		}

		[Test] public void ParseNull ()
		{
			Duration d = Duration.Parse(null);
			Assert.AreEqual(d.Amount,0);
			Assert.AreEqual(d.Units,Duration.Unit.Days);
		}

		[Test] public void Equality ()
		{
			Duration d1 = new Duration(12, Duration.Unit.Weeks);
			Duration d2 = new Duration(12, Duration.Unit.Weeks);
			Assert.AreEqual(d1, d2);
		}

		[Test] public void EqualOpTrue ()
		{
			Duration d1 = new Duration(12, Duration.Unit.Weeks);
			Duration d2 = new Duration(12, Duration.Unit.Weeks);
			Assert.IsTrue(d1 == d2);
		}

		[Test] public void EqualOpFalse ()
		{
			Duration d1 = new Duration(12, Duration.Unit.Weeks);
			Duration d2 = new Duration(13, Duration.Unit.Weeks);
			Assert.IsFalse(d1 == d2);
		}

		[Test] public void NotEqualOpTrue ()
		{
			Duration d1 = new Duration(12, Duration.Unit.Weeks);
			Duration d2 = new Duration(13, Duration.Unit.Weeks);
			Assert.IsTrue(d1 != d2);
		}

		[Test] public void NotEqualOpFalse ()
		{
			Duration d1 = new Duration(12, Duration.Unit.Weeks);
			Duration d2 = new Duration(12, Duration.Unit.Weeks);
			Assert.IsFalse(d1 != d2);
		}

		[Test] public void ToStringZero ()
		{
			Assert.AreEqual("0 Days", new Duration(0, Duration.Unit.Weeks).ToString());
		}

		[Test] public void FromStringZero ()
		{
			Assert.AreEqual(new Duration(0, Duration.Unit.Weeks), Duration.Parse("0"));
		}

		[Test] public void DaysConversionWeeksToDays()
		{
			Duration d1 = new Duration(12,Duration.Unit.Weeks);
			Assert.AreEqual(84, d1.Days);
		}

		[Test] public void DaysConversionMonthToDays()
		{
			Duration d1 = new Duration(1,Duration.Unit.Months);
			Assert.AreEqual(30, d1.Days);
		}

		[Test] public void DaysConversionMonthsToDays()
		{
			Duration d1 = new Duration(2,Duration.Unit.Months);
			Assert.AreEqual(61, d1.Days);
		}

		[Test] public void DaysConversionSemiYearToDays()
		{
			Duration d1 = new Duration(6,Duration.Unit.Months);
			Assert.AreEqual(183, d1.Days);
		}

		[Test] public void DaysConversionYearToDays()
		{
			Duration d1 = new Duration(12,Duration.Unit.Months);
			Assert.AreEqual(365, d1.Days);
		}

		[Test] public void DaysConversionLucky13MonthsToDays()
		{
			Duration d1 = new Duration(13,Duration.Unit.Months);
			Assert.AreEqual(395, d1.Days);
		}
		
		[Test] public void DaysPropertyToDays()
		{
			Duration d = new Duration(5,Duration.Unit.Days);
			Assert.AreEqual(5,d.Days);
		}
		
		[ExpectedException(typeof(NotSupportedException))]
		[Test] public void DaysPropertyBadUnits()
		{
			Duration d = new Duration(5,(Duration.Unit)2000);
			int days = d.Days;
		}		
		
		[Test] public void AddToDays()
		{
			Duration d = new Duration(5,Duration.Unit.Days);
			Assert.AreEqual(new DateTime(2000,1,6),d.AddTo(new DateTime(2000,1,1)));
		}
		
		[Test] public void AddToMonths()
		{
			Duration d = new Duration(5,Duration.Unit.Months);
			Assert.AreEqual(new DateTime(2000,6,1),d.AddTo(new DateTime(2000,1,1)));
		}		
		
		[Test] public void AddToWeeks()
		{
			Duration d = new Duration(3,Duration.Unit.Weeks);
			Assert.AreEqual(new DateTime(2000,1,22),d.AddTo(new DateTime(2000,1,1)));
		}				
		
		[ExpectedException(typeof(InvalidOperationException), ExpectedMessage = "Unsupported Duration Unit 2000")]
		[Test] public void AddToBadUnits()
		{
			Duration d = new Duration(5,(Duration.Unit)2000);
			d.AddTo(new DateTime(2000, 1, 1));
		}
				
		[Test] public void ConvertibleToString()
		{
			Assert.AreEqual("0 Days", ((IConvertible) new Duration()).ToString(CultureInfo.InvariantCulture));
		}
		
		[Test] public void ToTypeString()
		{
			Assert.AreEqual("0 Days", new Duration().ToType(typeof(string),CultureInfo.InvariantCulture));
		}
		
		[Test] public void ToTypeDuration()
		{
			Assert.AreEqual(new Duration(), new Duration().ToType(typeof(Duration),CultureInfo.InvariantCulture));
		}		
		
		#region Conversion Exceptions
		[ExpectedException(typeof(InvalidCastException))]
		[Test] public void ToTypeOther() { new Duration().ToType(typeof(int), CultureInfo.InvariantCulture); }		
		
		[ExpectedException(typeof(InvalidCastException))]
		[Test] public void ConvertToBoolean() { new Duration().ToBoolean(CultureInfo.InvariantCulture); }

		[ExpectedException(typeof(InvalidCastException))]
		[Test] public void ConvertToByte() { new Duration().ToByte(CultureInfo.InvariantCulture); }
		
		[ExpectedException(typeof(InvalidCastException))]
		[Test] public void ConvertToChar() { new Duration().ToChar(CultureInfo.InvariantCulture); }

		[ExpectedException(typeof(InvalidCastException))]
		[Test] public void ConvertToDateTime() { new Duration().ToDateTime(CultureInfo.InvariantCulture); }
		
		[ExpectedException(typeof(InvalidCastException))]
		[Test] public void ConvertToDecimal() { new Duration().ToDecimal(CultureInfo.InvariantCulture); }
		
		[ExpectedException(typeof(InvalidCastException))]
		[Test] public void ConvertToDouble() { new Duration().ToDouble(CultureInfo.InvariantCulture); }

		[ExpectedException(typeof(InvalidCastException))]
		[Test] public void ConvertToInt16() { new Duration().ToInt16(CultureInfo.InvariantCulture); }
		
		[ExpectedException(typeof(InvalidCastException))]
		[Test] public void ConvertToInt32() { new Duration().ToInt32(CultureInfo.InvariantCulture); }
		
		[ExpectedException(typeof(InvalidCastException))]
		[Test] public void ConvertToInt64() { new Duration().ToInt64(CultureInfo.InvariantCulture); }
		
		[ExpectedException(typeof(InvalidCastException))]
		[Test] public void ConvertToSByte() { new Duration().ToSByte(CultureInfo.InvariantCulture); }
		
		[ExpectedException(typeof(InvalidCastException))]
		[Test] public void ConvertToSingle() { new Duration().ToSingle(CultureInfo.InvariantCulture); }
		
		[ExpectedException(typeof(InvalidCastException))]
		[Test] public void ConvertToUInt16() { new Duration().ToUInt16(CultureInfo.InvariantCulture); }
		
		[ExpectedException(typeof(InvalidCastException))]
		[Test] public void ConvertToUInt32() { new Duration().ToUInt32(CultureInfo.InvariantCulture); }
		
		[ExpectedException(typeof(InvalidCastException))]
		[Test] public void ConvertToUInt64() { new Duration().ToUInt64(CultureInfo.InvariantCulture); }		
		#endregion
	}
}
