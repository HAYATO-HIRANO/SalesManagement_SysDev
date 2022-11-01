using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManagement_SysDev//.Common
{
    public class M_Message
    {

        //private Dictionary<String, String> messageMap = new Dictionary<string, string>();

        //public Messages()
        //{

        //    messageMap get("MSG0001", "メッセージ０１です。");

        //}

        //public String get(string msgCD)
        //{

        //    String msg = messageMap.get(msgCD);

        //    if (msg != null)
        //    {

        //        return msg;

        //    }
        //    return "";
        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(128)]
        [Column("MsgId",TypeName="nvarchar",Order =0)]
        [DisplayName("メッセージ番号")]
        public string MsgId { get; set; }           //メッセージID

        [Required]
        [MaxLength(4000)]
        [Column("MsgComments", TypeName = "nvarchar", Order = 1)]
        [DisplayName("メッセージ内容")]
        public string MsgComments { get; set; }      //メッセージ内容

        [Required]
        [MaxLength(4000)]
        [Column("MsgTitle", TypeName = "nvarchar", Order = 2)]
        [DisplayName("メッセージタイトル")]
        public string MsgTitle { get; set; }         //メッセージタイトル

        [Required]
        [Column("MsgButton", TypeName = "int", Order = 3)]
        [DisplayName("メッセージボタン")]
        public int MsgButton { get; set; }          //メッセージボタン

        [Required]
        [Column("MsgICon", TypeName = "int", Order = 4)]
        [DisplayName("メッセージアイコン")]
        public int MsgICon { get; set; }            //メッセージアイコン




    }

}
