using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SalesManagement_SysDev
{
    class M_Employee
    {
        [Key]
        public int EmID { get; set; }               //社員ID
        [MaxLength(50)]
        [Required]
        public String EmName { get; set; }          //社員名		
        public int SoID { get; set; }               //営業所ID		
        public int PoID { get; set; }               //役職ID
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EmHiredate { get; set; }    //入社年月日
        [MaxLength(10)]
        [Required]
        public String EmPassword { get; set; }      //パスワード
        [MaxLength(13)]
        [Required]
        public String EmPhone { get; set; }         //電話番号	
        //[MaxLength(13)]
        //[Required]
        // public String EmBarcode { get; set; }    //社員バーコード		
        public int EmFlag { get; set; }             //社員管理フラグ
        public String EmHidden { get; set; }	    //非表示理由		
    }

    //データグリッド表示用
    class M_EmployeeDsp
    {
        [DisplayName("社員ID")]                            //0
        public int EmID { get; set; }
        [DisplayName("社員名")]                            //1
        public string EmName { get; set; }
        [DisplayName("営業所ID")]                          //2
        public int SoID { get; set; }
        [DisplayName("営業所名")]                          //3
        public string SoName { get; set; }
        [DisplayName("役職ID")]                            //4
        public int PoID { get; set; }
        [DisplayName("役職名")]                            //5
        public string PoName { get; set; }
        [DisplayName("入社年月日")]                        //6
        public DateTime? EmHiredate { get; set; }
        [DisplayName("パスワード")]                        //7
        public string EmPassword { get; set; }   
        [DisplayName("電話番号")]                          //8
        public string EmPhone { get; set; }
        [DisplayName("社員管理フラグ")]                    //9
        public int EmFlag { get; set; }
        [DisplayName("非表示理由")]                        //10
        public string EmHidden { get; set; }




    }
}
