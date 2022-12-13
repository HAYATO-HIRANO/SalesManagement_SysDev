using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SalesManagement_SysDev
{
    class T_Shipment
    {
        [Key]
        public int ShID { get; set; }               //出荷ID		
        public int ClID { get; set; }               //顧客ID		
        public int EmID { get; set; }               //社員ID		
        public int SoID { get; set; }               //営業所ID		
        public int OrID { get; set; }               //受注ID		
        public int? ShStateFlag { get; set; }	//出荷状態フラグ
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? ShFinishDate { get; set; }  //出荷完了年月日
        public int ShFlag { get; set; }	//出荷管理フラグ
        public String ShHidden { get; set; }	    //非表示理由		

    }
    class T_ShipmentDsp
    {
        [DisplayName("出荷ID")]
        public int ShID { get; set; }
        [DisplayName("受注ID")]
        public int OrID { get; set; }
        [DisplayName("営業所ID")]
        public int SoID { get; set; }
        [DisplayName("営業所名")]
        public string SoName { get; set; }
        [DisplayName("社員ID")]
        public int EmID { get; set; }
        [DisplayName("社員名")]
        public string EmName { get; set; }
        [DisplayName("顧客ID")]
        public int ClID { get; set; }
        [DisplayName("顧客名")]
        public string ClName { get; set; }
        [DisplayName("出荷年月日")]
        public DateTime? ShDate { get; set; }
        [DisplayName("出荷状態フラグ")]
        public int? ShStateFlag { get; set; }
        [DisplayName("出荷管理フラグ")]
        public int ShFlag { get; set; }
        [DisplayName("非表示理由")]
        public string ShHidden { get; set; }
    }
}
