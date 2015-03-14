using System;

namespace VersionOne.SDK.APIClient
{
    public class Duration : IConvertible
    {
        #region Unit enum

        public enum Unit : short
        {
            Days,
            Weeks,
            Months,
        }

        #endregion

        public Duration() : this(0, Unit.Days) { }

        public Duration(int amount, Unit units)
        {
            this.Units = units;
            SetAmount(amount);
        }

        public Duration(TimeSpan span)
            : this(span.Days, Unit.Days)
        {
            if (Amount >= 365 && Amount % 365 <= 1)
            {
                Amount = 12 * Amount / 365;
                Units = Unit.Months;
            }
            else if (Amount >= 30 && Amount % 30 <= 1)
            {
                Amount /= 30;
                Units = Unit.Months;
            }
            else if (Amount >= 7 && Amount % 7 == 0)
            {
                Amount /= 7;
                Units = Unit.Weeks;
            }
        }

        public Duration(string s)
            : this(0, Unit.Days)
        {
            if (string.IsNullOrEmpty(s))
            {
                return;
            }

            try
            {
                var parts = s.Split(' ');
                SetAmount(int.Parse(parts[0]));

                if (Amount != 0)
                {
                    Units = (Unit)Enum.Parse(typeof(Unit), parts[1]);
                }
            }
            catch (Exception e)
            {
                throw new FormatException("Not a valid Duration: " + s, e);
            }
        }

        public int Amount { get; private set; }

        public Unit Units { get; private set; }

        public int Days
        {
            get
            {
                switch (Units)
                {
                    case Unit.Days:
                        return Amount;
                    case Unit.Weeks:
                        return Amount * 7;
                    case Unit.Months:
                        if (Amount <= 1)
                        {
                            return Amount * 30;
                        }

                        if (Amount < 12)
                        {
                            return (Amount * 61) / 2;
                        }

                        return (Amount * 365) / 12;
                    default:
                        throw new NotSupportedException();
                }
            }
        }

        #region IConvertible Members

        string IConvertible.ToString(IFormatProvider provider)
        {
            return ToString();
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            if (conversionType == typeof(string))
            {
                return ToString();
            }

            if (conversionType == typeof(Duration))
            {
                return this;
            }

            throw new InvalidCastException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new InvalidCastException();
        }

        #endregion

        private void SetAmount(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount", amount, "Must be non-negative");
            }

            Amount = amount;

            if (amount == 0)
            {
                Units = Unit.Days;
            }
        }

        public DateTime AddTo(DateTime dt)
        {
            switch (Units)
            {
                case Unit.Days:
                    return dt.AddDays(Amount);
                case Unit.Weeks:
                    return dt.AddDays(Amount * 7);
                case Unit.Months:
                    return dt.AddMonths(Amount);
            }

            throw new InvalidOperationException("Unsupported Duration Unit " + Units);
        }

        public override string ToString()
        {
            return Amount + " " + Units;
        }

        public override bool Equals(object obj)
        {
            var other = obj as Duration;
            return other != null && (Amount == other.Amount && Units == other.Units);
        }

        public override int GetHashCode()
        {
            return HashCode.Hash(Amount, Units);
        }

        public static bool operator ==(Duration a, Duration b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return ReferenceEquals(a, null) && ReferenceEquals(b, null);
            }

            return a.Equals(b);
        }

        public static bool operator !=(Duration a, Duration b)
        {
            return !(a == b);
        }

        public static Duration Parse(string s)
        {
            return new Duration(s);
        }

        public static implicit operator TimeSpan(Duration d)
        {
            return TimeSpan.FromDays(d.Days);
        }

        public static implicit operator Duration(TimeSpan t)
        {
            return new Duration(t);
        }
    }
}