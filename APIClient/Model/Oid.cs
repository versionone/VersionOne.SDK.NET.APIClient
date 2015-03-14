using System;

namespace VersionOne.SDK.APIClient
{
    public class Oid
    {
        protected static readonly string NullOidToken = "NULL";
        public static readonly Oid Null = new Oid();

        private readonly IAssetType type;
        private readonly int id;
        private readonly int? moment;

        private Oid() { }

        public Oid(IAssetType assetType, int id, int? moment)
        {
            if (assetType == null)
            {
                throw new ArgumentNullException("assetType");
            }

            type = assetType;
            this.id = id;
            this.moment = moment;
        }

        public IAssetType AssetType
        {
            get { return type; }
        }

        public virtual object Key
        {
            get { return id; }
        }

        public object Moment
        {
            get { return moment.Value; }
        }

        public bool IsNull
        {
            get { return ReferenceEquals(this, Null); }
        }

        public string Token
        {
            get
            {
                if (IsNull)
                {
                    return NullOidToken;
                }

                if (moment == null)
                {
                    return type.Token + ':' + id;
                }

                return type.Token + ':' + id + ':' + moment;
            }
        }

        public override string ToString()
        {
            return Token;
        }

        public static Oid FromToken(string oidtoken, IMetaModel meta)
        {
            try
            {
                if (oidtoken == NullOidToken)
                {
                    return Null;
                }

                var parts = oidtoken.Split(':');
                var type = meta.GetAssetType(parts[0]);
                var id = (int)DB.Int(parts[1]);
                int? moment = null;

                if (parts.Length > 2)
                {
                    moment = DB.Int(parts[2]);
                }

                return new Oid(type, id, moment);
            }
            catch (Exception e)
            {
                throw new OidException("Invalid OID token", oidtoken, e);
            }
        }

        public virtual Oid Momentless
        {
            get { return moment == null ? this : new Oid(type, id, null); }
        }

        public virtual bool HasMoment
        {
            get { return moment != null; }
        }

        public override bool Equals(object obj)
        {
            var other = obj as Oid;

            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (IsNull || other.IsNull)
            {
                return false;
            }

            return type.Token == other.type.Token && id == other.id && moment == other.moment;
        }

        public override int GetHashCode()
        {
            if (IsNull)
            {
                return 0;
            }

            return moment == null ? HashCode.Hash(type.Token.GetHashCode(), id) : HashCode.Hash(type.Token.GetHashCode(), id, moment);
        }

        public static bool operator ==(Oid a, Oid b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return ReferenceEquals(a, b);
            }

            return a.Equals(b);
        }

        public static bool operator !=(Oid a, Oid b)
        {
            return !(a == b);
        }
    }
}