using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace SalesManagement_SysDev
{
    class M_SalesOffice
    {
        [Key]
        public int SoID { get; set; }           //営業所ID
        [MaxLength(50)]
        [Required]
        public String SoName { get; set; }      //営業所名	
        [MaxLength(50)]
        [Required]
        public String SoAddress { get; set; }   //住所
        [MaxLength(13)]
        [Required]
        public String SoPhone { get; set; }     //電話番号
        [MaxLength(7)]
        [Required]
        public String SoPostal { get; set; }    //郵便番号	
        [MaxLength(13)]
        [Required]
        public String SoFAX { get; set; }       //FAX		
        public int SoFlag { get; set; }         //営業所管理フラグ	 
        public String SoHidden { get; set; }	//非表示理由		
    }
    //データグリッド表示用
    class M_SalesOfficeDsp
    {
        [DisplayName("営業所ID")]
        public int SoID { get; set; }

        [DisplayName("営業所名")]
        public int SoName { get; set; }

        [DisplayName("電話番号")]
        public int SoPhone { get; set; }

        [DisplayName("FAX")]
        public int SoFAX { get; set; }

        [DisplayName("郵便番号")]
        public int SoPostal { get; set; }

        [DisplayName("住所")]
        public int SoAddress { get; set; }

        [DisplayName("営業所管理フラグ")]
        public int SoFlag { get; set; }

        [DisplayName("非表示理由")]
        public string SoHidden { get; set; }

    }
}
