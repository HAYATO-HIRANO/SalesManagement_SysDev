using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SalesManagement_SysDev
{
    class T_SyukkoDetail
    {
        [Key]
        public int SyDetailID { get; set; }     //出庫詳細ID
        public int SyID { get; set; }           //出庫ID
        public int PrID { get; set; }           //商品ID
        public int SyQuantity { get; set; }	    //数量

    }
    class T_SyukkoDetailDsp
    {
        [DisplayName("注文ID")]
        public int SyID { get; set; }
        [DisplayName("出庫詳細ID")]
        public int SyDetailID { get; set; }
        [DisplayName("商品ID")]
        public int PrID { get; set; }
        [DisplayName("商品名")]
        public string PrName { get; set; }
        [DisplayName("価格")]
        public int Price { get; set; }
        [DisplayName("数量")]
        public int SyQuantity { get; set; }


    }

}
