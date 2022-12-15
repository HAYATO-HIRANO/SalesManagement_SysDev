using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SalesManagement_SysDev
{
    class SaleDetailDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckSaDetailIDExistence()
        //引　数   ：売上詳細ID
        //戻り値   ：True or False
        //機　能   ：一致する売上詳細IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckSaDetailIDExistence(int SaDetailID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                //売上詳細IDで一致するデータが存在するか
                flg = context.T_SaleDetails.Any(x => x.SaDetailID == SaDetailID);
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：AddSaleData()
        //引　数   ：売上詳細データ
        //戻り値   ：True or False
        //機　能   ：売上詳細データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddSaleDetailData(T_SaleDetail regSaleDetail)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_SaleDetails.Add(regSaleDetail);
                context.SaveChanges();
                context.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        ///////////////////////////////
        //メソッド名：GetSaDetailIDData()
        //引　数   :売上詳細ID
        //戻り値   ：売上詳細IDの売上詳細データ
        //機　能   ：売上詳細IDの売上詳細情報取得
        ///////////////////////////////
        public List<T_SaleDetail> GetSaDetailIDData(int SaID)
        {
            List<T_SaleDetail> saleDetail = new List<T_SaleDetail>();

            try
            {
                var context = new SalesManagement_DevContext();

                saleDetail = context.T_SaleDetails.Where(x => x.SaID == SaID ).ToList();

                context.SaveChanges();
                context.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return saleDetail;
        }

    }
}
