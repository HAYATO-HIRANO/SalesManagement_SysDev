using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace SalesManagement_SysDev
{
    class T_ArrivalDetail
    {
        [Key]
        public int ArDetailID { get; set; }     //入荷詳細ID
        public int ArID { get; set; }           //入荷ID
        public int PrID { get; set; }           //商品ID
        public int ArQuantity { get; set; }	    //数量

    }
    class T_ArrivalDetailDsp
    {
        [DisplayName("入荷ID")]
        public int ArID { get; set; }
        [DisplayName("入荷詳細ID")]
        public int ArDetailID { get; set; }
        [DisplayName("商品ID")]
        public int PrID { get; set; }
        [DisplayName("商品名")]
        public string PrName { get; set; }
        [DisplayName("価格")]
        public int Price { get; set; }
        [DisplayName("数量")]
        public int ArQuantity { get; set; }
        [DisplayName("合計金額")]
        public int TotalPrice { get; set; }


    }

}
