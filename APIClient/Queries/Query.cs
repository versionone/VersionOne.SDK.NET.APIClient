using System;
using System.Collections.Generic;
using VersionOne.SDK.APIClient.Model;
using VersionOne.SDK.APIClient.Model.Asset.Attribute;
using VersionOne.SDK.APIClient.Model.Interfaces;

namespace VersionOne.SDK.APIClient.Queries {
    public class Query {
        private readonly bool isHistorical;
        private readonly IAssetType assetType;
        private readonly IAttributeDefinition parentRelation;
        private readonly Oid oid;
        private AttributeSelection selection = new AttributeSelection();
        private IFilterTerm filter = new NoOpTerm();
        private OrderBy orderBy = new OrderBy();
        private Paging paging = new Paging();
        private DateTime asOf = DateTime.MinValue;
        private readonly IList<QueryVariable> variables = new List<QueryVariable>(); 

        public Query(IAssetType assetType) : this(assetType, false) {}
        public Query(IAssetType assetType, IAttributeDefinition parentrelation) : this(assetType, false, parentrelation) {}
        public Query(IAssetType assetType, bool historical) : this(assetType, historical, null) {}

        public Query(IAssetType assetType, bool historical, IAttributeDefinition parentRelation) {
            Find = null;
            this.assetType = assetType;
            isHistorical = historical;
            oid = Oid.Null;
            this.parentRelation = parentRelation;
            
            if (this.parentRelation != null) {
                if(this.parentRelation.AttributeType != AttributeType.Relation) {
                    throw new ApplicationException("Parent Relation must be a Relation Attribute Type");
                }

                if(this.parentRelation.IsMultiValue) {
                    throw new ApplicationException("Parent Relation cannot be multi-value");
                }
            }
        }

        public Query(Oid oid) : this(oid, false) {}

        public Query(Oid oid, bool historical) {
            Find = null;
            if(oid.IsNull) {
                throw new ApplicationException("Invalid Query OID Parameter");
            }
  
            if(oid.HasMoment && historical) {
                throw new NotSupportedException("Historical Query with Momented OID not supported");
            }

            isHistorical = historical;
            assetType = oid.AssetType;
            this.oid = oid;
        }

        public IAssetType AssetType {
            get { return assetType; }
        }

        public bool IsHistorical {
            get { return isHistorical; }
        }

        public Oid Oid {
            get { return oid; }
        }

        public IAttributeDefinition ParentRelation {
            get { return parentRelation; }
        }

        public AttributeSelection Selection {
            get { return selection; }
            set {
                if(value != null) {
                    selection = value;
                }
            }
        }

        public IFilterTerm Filter {
            get { return filter; }
            set {
                if(value != null) {
                    filter = value;
                }
            }
        }

        public OrderBy OrderBy {
            get { return orderBy; }
            set {
                if(value != null) {
                    orderBy = value;
                }
            }
        }

        public Paging Paging {
            get { return paging; }
            set {
                if(value != null) {
                    paging = value;
                }
            }
        }

        public DateTime AsOf {
            get { return asOf; }
            set { asOf = value; }
        }

        public QueryFind Find { get; set; }

        public ICollection<QueryVariable> Variables {
            get { return variables; }
        } 
    }
}