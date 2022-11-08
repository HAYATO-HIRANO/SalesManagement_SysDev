using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev//.DbAccess
{
    class MajorClassificationDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckMcCDExistence()
        //引　数   ：大分類ID
        //戻り値   ：True or False
        //機　能   ：一致する大分類IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckMcCDExistence(int McID)
        {
            bool flg= false;
            try
            {
                var context = new SalesManagement_DevContext();
                flg = context.M_MajorCassifications.Any(x => x.McID == McID);
                context.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }


    }
}
