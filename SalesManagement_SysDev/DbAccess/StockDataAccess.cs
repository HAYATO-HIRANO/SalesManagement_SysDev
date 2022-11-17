using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev//.DbAccess
{
    class StockDataAccess
    {
        ///////////////////////////////
        //メソッド名：UpdateSmallClassData()
        //引　数   ：在庫データ
        //戻り値   ：True or False
        //機　能   ：在庫データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////

        public bool UpdateStockData(T_Stock updstock)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var stock = context.T_Stocks.Single(x => x.StID == updstock.StID);
                stock.PrID = updstock.PrID;
                stock.StQuantity = updstock.StQuantity;
                stock.StFlag = updstock.StFlag;



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
        //メソッド名：GetStockData()　オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致在庫データ
        //機　能   ：条件一致在庫データの取得
        ///////////////////////////////

        public List<T_Stock> GetStockData(T_Stock selectCondition)
        {
            List<T_Stock> stock = new List<T_Stock>();
            try
            {
                var context = new SalesManagement_DevContext();
                stock = context.T_Stocks.Where(x => x.StID == selectCondition.StID&&x.PrID==selectCondition.PrID).ToList();
                context.Dispose();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return stock;

        }

        ///////////////////////////////
        //メソッド名： GetStockData()
        //引　数   :なし
        //戻り値   :在庫データ
        //機　能   :在庫データの取得
        //////////////////////////////
        
        public List<T_Stock> GetStockData()
        {
            List<T_Stock> stock = new List<T_Stock>();
            try
            {
                var context = new SalesManagement_DevContext();
                stock = context.T_Stocks.ToList();
                context.Dispose();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return stock;
        }



    }
}
