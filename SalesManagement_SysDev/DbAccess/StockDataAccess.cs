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

        public bool CheckStIDExistence (int stID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();

                flg = context.T_Stocks.Any(x => x.StID == stID);
                context.Dispose();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
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

        public List<T_StockDsp> GetStockData(int flg, T_StockDsp selectCondition)
        {
            List<T_StockDsp> stock = new List<T_StockDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                if (flg == 1)
                {

                    var tb = from t1 in context.T_Stocks
                             join t2 in context.M_Products
                             on t1.PrID equals t2.PrID
                             where t1.StID.ToString().Contains(selectCondition.StID.ToString()) &&
                             t2.PrID == selectCondition.PrID&&
                             t1.StFlag==selectCondition.StFlag

                             select new
                             {
                                 t1.StID,
                                 t2.PrID,
                                 t2.PrName,
                                 t1.StQuantity,
                                 t1.StFlag

                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        stock.Add(new T_StockDsp()
                        {
                            StID = p.StID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            StQuantity = p.StQuantity,
                            StFlag = p.StFlag
                        });
                    }
                }
                if (flg == 2)
                {
                    var tb = from t1 in context.T_Stocks
                             join t2 in context.M_Products
                             on t1.PrID equals t2.PrID
                             where t1.StID.ToString().Contains(selectCondition.StID.ToString()) &&
                             //t2.PrID == selectCondition.PrID &&
                             t1.StFlag == selectCondition.StFlag

                             select new
                             {
                                 t1.StID,
                                 t2.PrID,
                                 t2.PrName,
                                 t1.StQuantity,
                                 t1.StFlag

                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        stock.Add(new T_StockDsp()
                        {
                            StID = p.StID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            StQuantity = p.StQuantity,
                            StFlag = p.StFlag
                        });
                    }
                }
                if (flg == 3)
                {
                    var tb = from t1 in context.T_Stocks
                             join t2 in context.M_Products
                             on t1.PrID equals t2.PrID
                             where //t1.StID.ToString().Contains(selectCondition.StID.ToString()) &&
                             t2.PrID == selectCondition.PrID &&
                             t1.StFlag == selectCondition.StFlag


                             select new
                             {
                                 t1.StID,
                                 t2.PrID,
                                 t2.PrName,
                                 t1.StQuantity,
                                 t1.StFlag

                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        stock.Add(new T_StockDsp()
                        {
                            StID = p.StID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            StQuantity = p.StQuantity,
                            StFlag = p.StFlag
                        });
                    }
                }
                if (flg == 4)
                {
                    var tb = from t1 in context.T_Stocks
                             join t2 in context.M_Products
                             on t1.PrID equals t2.PrID
                             where //t1.StID.ToString().Contains(selectCondition.StID.ToString()) &&
                             //t2.PrID == selectCondition.PrID &&
                             t1.StFlag == selectCondition.StFlag

                             select new
                             {
                                 t1.StID,
                                 t2.PrID,
                                 t2.PrName,
                                 t1.StQuantity,
                                 t1.StFlag

                             };

                    // IEnumerable型のデータをList型へ
                    foreach (var p in tb)
                    {
                        stock.Add(new T_StockDsp()
                        {
                            StID = p.StID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            StQuantity = p.StQuantity,
                            StFlag = p.StFlag
                        });
                    }
               
                }

                context.Dispose();
            }
            catch (Exception ex)
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

        public List<T_StockDsp> GetStockData()
        {
            List<T_StockDsp> stock = new List<T_StockDsp>();
            try
            {
                var context = new SalesManagement_DevContext();
                //stock = context.T_Stocks.ToList();
                var tb = from t1 in context.T_Stocks
                         join t2 in context.M_Products
                         on t1.PrID equals t2.PrID
                        
                         select new
                         {
                             t1.StID,
                             t2.PrID,
                             t2.PrName,
                             t1.StQuantity,
                             t1.StFlag

                         };

                // IEnumerable型のデータをList型へ
                foreach (var p in tb)
                {
                    stock.Add(new T_StockDsp()
                    {
                        StID=p.StID,
                        PrID=p.PrID,
                        PrName=p.PrName,
                        StQuantity=p.StQuantity,
                        StFlag=p.StFlag
                    });
                }
                context.Dispose();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return stock;
        }



    }
}
