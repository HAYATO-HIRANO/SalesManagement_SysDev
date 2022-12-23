using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace SalesManagement_SysDev
{
    class T_Sale
    {
        [Key]
        public int SaID { get; set; }           //売上ID	
        public int ClID { get; set; }           //顧客ID	
        public int SoID { get; set; }           //営業所ID	
        public int EmID { get; set; }           //受注社員ID	
        public int ChID { get; set; }           //受注ID
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime SaDate { get; set; }    //売上日時
        public String SaHidden { get; set; }    //非表示理由	
        public int SaFlag { get; set; }	        //売上管理フラグ	

    }
    class T_SaleDsp
    {
        [DisplayName("売上ID")]
        public int SaID { get; set; }           //売上ID	

        [DisplayName("顧客ID")]
        public int ClID { get; set; }           //顧客ID	

        [DisplayName("顧客名")]
        public string ClName { get; set; }      //顧客名

        [DisplayName("営業所ID")]
        public int SoID { get; set; }           //営業所ID	

        [DisplayName("営業所名")]
        public string SoName { get; set; }      //営業所名

        [DisplayName("受注社員ID")]
        public int EmID { get; set; }           //受注社員ID

        [DisplayName("受注社員名")]
        public string EmName { get; set; }      //受注社員名

        [DisplayName("受注ID")]
        public int OrID { get; set; }           //受注ID

        [DisplayName("売上日時")]
        public DateTime SaDate { get; set; }    //売上日時

        [DisplayName("売上管理フラグ")]
        public int SaFlag { get; set; }         //売上管理フラグ

        [DisplayName("非表示理由")]
        public String SaHidden { get; set; }    //非表示理由	
        	

    }

}
