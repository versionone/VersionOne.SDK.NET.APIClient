using System.Collections.Generic;
using System.Linq;

namespace VersionOne.SDK.APIClient.Model.Asset {
    public class AssetList : List<Asset> {
        public AssetList Flatten() {
            var list = new AssetList();
            RecursiveAdd(list, this);
            return list;
        }

        public static void RecursiveAdd(AssetList target, AssetList source) {
            foreach (var asset in source) {
                target.Add(asset);

                if(asset.Children.Count > 0) {
                    RecursiveAdd(target, asset.Children);
                }
            }
        }

        public Oid[] Oids {
            get {
                return this.Select(asset => asset.Oid).ToArray();
            }
        }
    }
}