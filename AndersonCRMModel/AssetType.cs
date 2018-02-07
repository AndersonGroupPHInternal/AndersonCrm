using BaseModel;
using System.Collections.Generic;

namespace AndersonCRMModel
{
    public class AssetType : Base
    {
        public int AssetTypeId { get; set; }

        public string Color { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
    }
}
