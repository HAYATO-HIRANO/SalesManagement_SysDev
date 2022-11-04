using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;



namespace SalesManagement_SysDev
{
    class M_Client
    {
        [Key]
        public int ClID { get; set; }           //顧客ID		
        public int SoID { get; set; }           //営業所ID
        [MaxLength(50)]
        [Required]
        public String ClName { get; set; }      //顧客名
        [MaxLength(50)]
        [Required]
        public String ClAddress { get; set; }   //住所	 
        [MaxLength(13)]
        [Required]
        public String ClPhone { get; set; }     //電話番号	
        [MaxLength(7)]
        [Required]                                        
        public String ClPostal { get; set; }       //郵便番号
        [MaxLength(13)]
        [Required]
        public String ClFAX { get; set; }       //FAX		
        public int ClFlag { get; set; }         //顧客管理フラグ	
        public String ClHidden { get; set; }	//非表示理由		

    }
    //データグリッド表示用
    class M_ClientDsp
    {
        [DisplayName("顧客ID")]
        public int ClID { get; set; }

        [DisplayName("営業所ID")]
        public int SoID { get; set; }

        [DisplayName("営業所名")]
        public string SoName { get; set; }

        [DisplayName("顧客名")]
        public string ClName { get; set; }

        [DisplayName("住所")]
        public string ClAddress { get; set; }

        [DisplayName("電話番号")]
        public string ClPhone { get; set; }

        [DisplayName("郵便番号")]
        public string ClPostal { get; set; }

        [DisplayName("FAX")]
        public string ClFAX { get; set; }

        [DisplayName("顧客管理フラグ")]
        public int ClFlag { get; set; }

        [DisplayName("非表示理由")]
        public string ClHidden { get; set; }
    }
}
