using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SalesManagement_SysDev
{
    class T_OrderDetail
    {
        [Key]
        public int OrDetailID { get; set; }     //受注詳細ID
        public int OrID { get; set; }           //受注ID
        public int PrID { get; set; }           //商品ID
        public int OrQuantity { get; set; }	    //数量
        public int OrTotalPrice { get; set; }	//合計金額

    }
    class T_OrderDetailDsp
    {
        [DisplayName("受注ID")]
        public int OrID { get; set; }
        [DisplayName("受注詳細ID")]
        public int OrDetailID { get; set; }
        [DisplayName("商品ID")]
        public int PrID { get; set; }
        [DisplayName("商品ID")]
        public string PrName { get; set; }
        [DisplayName("価格")]
        public int Price { get; set; }
        [DisplayName("数量")]
        public int OrQuantity { get; set; }
        [DisplayName("合計金額")]
        public int OrTotalPrice { get; set; }


    }
}
