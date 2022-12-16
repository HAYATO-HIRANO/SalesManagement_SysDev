using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SalesManagement_SysDev
{
    class T_ChumonDetail
    {
        [Key]
        public int ChDetailID { get; set; }     //注文詳細ID
        public int ChID { get; set; }           //注文ID
        public int PrID { get; set; }           //商品ID
        public int ChQuantity { get; set; }	    //数量

    }
    class T_ChumonDetailDsp
    {
        [DisplayName("注文ID")]
        public int ChID { get; set; }
        [DisplayName("注文詳細ID")]
        public int ChDetailID { get; set; }
        [DisplayName("商品ID")]
        public int PrID { get; set; }
        [DisplayName("商品名")]
        public string PrName { get; set; }
        [DisplayName("価格")]
        public int Price { get; set; }
        [DisplayName("数量")]
        public int ChQuantity { get; set; }
        [DisplayName("合計金額")]
        public int TotalPrice { get; set; }
    }
}
