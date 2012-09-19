using System;

namespace VersionOne.SDK.APIClient {
    public struct Pair<FirstType, SecondType> : IEquatable<Pair<FirstType, SecondType>> {
        private readonly FirstType first;
        private readonly SecondType second;

        public FirstType First {
            get { return first; }
        }

        public SecondType Second {
            get { return second; }
        }

        public Pair(FirstType first, SecondType second) {
            this.first = first;
            this.second = second;
        }

        public override int GetHashCode() {
            return HashCode.Hash(first, second);
        }

        public override bool Equals(object obj) {
            if (obj == null || !(obj is Pair<FirstType, SecondType>))
                return false;
            return Equals((Pair<FirstType, SecondType>) obj);
        }

        public bool Equals(Pair<FirstType, SecondType> other) {
            return first.Equals(other.first) && second.Equals(other.second);
        }

        public static bool operator ==(Pair<FirstType, SecondType> p1, Pair<FirstType, SecondType> p2) {
            return p1.Equals(p2);
        }

        public static bool operator !=(Pair<FirstType, SecondType> p1, Pair<FirstType, SecondType> p2) {
            return !p1.Equals(p2);
        }
    }
}