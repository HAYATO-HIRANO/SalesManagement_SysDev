using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SalesManagement_SysDev
{
    class SaleDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckSaIDExistence()
        //引　数   ：売上ID
        //戻り値   ：True or False
        //機　能   ：一致する売上IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckSaIDExistence(int saID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                //売上IDで一致するデータが存在するか
                flg = context.T_Sale.Any(x => x.SaID == saID);
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
        //引　数   ：売上データ
        //戻り値   ：True or False
        //機　能   ：売上データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddSaleData(T_Sale regSale)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_Sale.Add(regSale);
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
        //メソッド名：GetSaIDData()
        //引　数   :売上ID
        //戻り値   ：売上IDの売上データ
        //機　能   ：売上IDの売上情報取得
        ///////////////////////////////
        public T_Sale GetSaIDData(int SaID)
        {
            T_Sale Sale = new T_Sale();

            try
            {
                var context = new SalesManagement_DevContext();

                Sale = context.T_Sale.Single(x => x.SaID == SaID && x.SaFlag == 0);

                context.SaveChanges();
                context.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return Sale;
        }

    }
}
