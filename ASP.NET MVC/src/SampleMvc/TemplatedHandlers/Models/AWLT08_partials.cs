using System.ComponentModel.DataAnnotations;

namespace MvcTmpHlprs.Models {
    [MetadataType(typeof(ProductMD))]
    public partial class Product {
        public class ProductMD {
            // Date template applied in Html.DisplayFor overload
            public object SellStartDate { get; set; }

            //[DataType("rbDate")]   // alternate approach to specify rbDate.ascx
            [UIHint("rbDate")]
            public object SellEndDate { get; set; }
            [DataType(DataType.Date)]
            public object DiscontinuedDate { get; set; }

            [DataType(DataType.Currency)]
            public object StandardCost { get; set; }

            [DataType(DataType.Currency)]
            public object ListPrice { get; set; }

            [ScaffoldColumn(false)]
            public object ModifiedDate { get; set; }
            [ScaffoldColumn(false)]
            public object rowguid { get; set; }
            [ScaffoldColumn(false)]
            public object ThumbnailPhotoFileName { get; set; }
        }
    }
}
