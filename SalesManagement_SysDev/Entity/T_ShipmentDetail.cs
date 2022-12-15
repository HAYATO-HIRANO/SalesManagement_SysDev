using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SalesManagement_SysDev
{
    class T_ShipmentDetail
    {
        [Key]
        public int ShDetailID { get; set; }     //出荷詳細ID
        public int ShID { get; set; }           //出荷ID
        public int PrID { get; set; }           //商品ID
        public int ShDquantity { get; set; }	//数量

    }
    class T_ShipmentDetailDsp
    {
        [DisplayName("出荷ID")]
        public int ShID { get; set; }
        [DisplayName("出荷詳細ID")]
        public int ShDetailID { get; set; }
        [DisplayName("商品ID")]
        public int PrID { get; set; }
        [DisplayName("商品名")]
        public string PrName { get; set; }
        [DisplayName("価格")]
        public int Price { get; set; }
        [DisplayName("数量")]
        public int ShDquantity { get; set; }
        [DisplayName("合計金額")]
        public int TotalPrice { get; set; }


    }

}
