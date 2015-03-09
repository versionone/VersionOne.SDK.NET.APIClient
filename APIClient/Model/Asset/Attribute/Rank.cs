using System;
using VersionOne.SDK.APIClient.Utils;

namespace VersionOne.SDK.APIClient.Model.Asset.Attribute {
    public class Rank : IComparable {
        private readonly int rankNumber;
        private readonly int offset;

        private Rank(int rankNumber, int offset) {
            this.rankNumber = rankNumber;
            this.offset = offset;
        }

        public Rank(object o) {
            if (o is Rank) {
                var other = (Rank) o;
                rankNumber = other.rankNumber;
                offset = other.offset;
            } else if (o == DB.Null) {
                rankNumber = int.MaxValue;
            } else if (o is string) {
                var s = (string) o;

                if (s.EndsWith("+")) {
                    rankNumber = int.Parse(s.TrimEnd('+'));
                    offset = 1;
                } else if (s.EndsWith("-")) {
                    rankNumber = int.Parse(s.TrimEnd('-'));
                    offset = -1;
                } else {
                    rankNumber = int.Parse(s);
                }
            } else if (o is IConvertible) {
                rankNumber = Convert.ToInt32(o);
            }
        }

        public Rank Before {
            get { return new Rank(rankNumber, offset - 1); }
        }

        public Rank After {
            get { return new Rank(rankNumber, offset + 1); }
        }

        public bool IsBefore {
            get { return offset < 0; }
        }

        public bool IsAfter {
            get { return offset > 0; }
        }

        public override string ToString() {
            return rankNumber + (IsAfter ? "+" : IsBefore ? "-" : null);
        }

        public static explicit operator int(Rank r) {
            return r.rankNumber;
        }

        public override bool Equals(object obj) {
            return ((IComparable) this).CompareTo(obj) == 0;
        }

        public override int GetHashCode() {
            return rankNumber.GetHashCode();
        }

        int IComparable.CompareTo(object obj) {
            var other = obj as Rank;
            
            if (ReferenceEquals(other, null)) {
                throw new ArgumentException("Rank can only compare to another Rank");
            }
            
            if (IsAfter || IsBefore || other.IsBefore || other.IsAfter) {
                throw new ArgumentException("Transient ranks are not comparable");
            }
            
            return rankNumber - other.rankNumber;
        }

        public static bool operator ==(Rank a, Rank b) {
            return Equals(a, b);
        }

        public static bool operator !=(Rank a, Rank b) {
            return !(a == b);
        }

        public static bool operator <(Rank a, Rank b) {
            return ((IComparable) a).CompareTo(b) < 0;
        }

        public static bool operator <=(Rank a, Rank b) {
            return ((IComparable) a).CompareTo(b) <= 0;
        }

        public static bool operator >(Rank a, Rank b) {
            return ((IComparable) a).CompareTo(b) > 0;
        }

        public static bool operator >=(Rank a, Rank b) {
            return ((IComparable) a).CompareTo(b) >= 0;
        }
    }
}