using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;



namespace SalesManagement_SysDev
{
    class T_Order
    {
        [Key]
        public int OrID { get; set; }           //受注ID		
        public int SoID { get; set; }           //営業所ID		
        public int EmID { get; set; }           //社員ID		
        public int ClID { get; set; }           //顧客ID
        [MaxLength(50)]
        [Required]
        public String ClCharge { get; set; }    //顧客担当者名
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime OrDate { get; set; }    //受注年月日
        public int? OrStateFlag { get; set; }    //受注状態フラグ
        public int OrFlag { get; set; } //受注管理フラグ
        public String OrHidden { get; set; }    //非表示理由


    }
    //データグリッド表示用
    class T_OrderDsp 
    {
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
        [DisplayName("顧客担当者名")]
        public string ClCharge { get; set; }
        [DisplayName("受注年月日")]
        public DateTime OrDate { get; set; }
        [DisplayName("受注確定フラグ")]
        public int? OrStateFlag { get; set; }
        [DisplayName("非表示フラグ")]
        public int OrFlag { get; set; }
        [DisplayName("非表示理由")]
        public string OrHidden { get; set; }







    }
}
