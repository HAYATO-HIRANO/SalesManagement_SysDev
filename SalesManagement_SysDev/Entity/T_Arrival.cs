using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SalesManagement_SysDev
{
    class T_Arrival
    {
        [Key]
        public int ArID { get; set; }               //入荷ID	
        public int SoID { get; set; }               //営業所ID	
        public int EmID { get; set; }               //社員ID	
        public int ClID { get; set; }               //顧客ID	
        public int OrID { get; set; }               //受注ID	
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? ArDate { get; set; }       //入荷年月日	
        public int? ArStateFlag { get; set; }   //入荷状態フラグ
        public int ArFlag { get; set; }	//入荷管理フラグ
        public String ArHidden { get; set; }	    //非表示理由	

    }
    class T_ArrivalDsp
    {
        [DisplayName("入荷ID")]
        public int ArID { get; set; }
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
        [DisplayName("入荷年月日")]
        public DateTime? ArDate { get; set; }
        [DisplayName("入荷状態フラグ")]
        public int? ArStateFlag { get; set; }
        [DisplayName("入荷管理フラグ")]
        public int ArFlag { get; set; }
        [DisplayName("非表示理由")]
        public string ArHidden { get; set; }
    }

}
