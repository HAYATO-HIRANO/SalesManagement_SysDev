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
                flg = context.T_Sales.Any(x => x.SaID == saID);
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
                context.T_Sales.Add(regSale);
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
        public T_Sale GetSaIDData(int OrID)
        {
            T_Sale Sale = new T_Sale();

            try
            {
                var context = new SalesManagement_DevContext();

                Sale = context.T_Sales.Single(x => x.ChID == OrID && x.SaFlag == 0);

                context.SaveChanges();
                context.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return Sale;
        }
        ///////////////////////////////
        //メソッド名：GetSaleData()
        //引　数   ：なし
        //戻り値   ：全売上データ
        //機　能   ：全売上データの取得
        ///////////////////////////////
        public List<T_SaleDsp> GetSaleData()
        {
            List<T_SaleDsp> sale = new List<T_SaleDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_Sales
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID
                         where t1.SaFlag == 0
                         select new
                         {
                             t1.SaID,
                             t1.ClID,
                             t4.ClName,
                             t1.SoID,
                             t2.SoName,                                                      
                             t1.EmID,
                             t3.EmName,
                             t1.ChID,
                             t1.SaDate,                            
                             t1.SaFlag,
                             t1.SaHidden,
                             
                         };
                foreach (var p in tb)
                {
                    sale.Add(new T_SaleDsp()
                    {
                        SaID = p.SaID,
                        ClID = p.ClID,
                        ClName = p.ClName,                        
                        SoID = p.SoID,
                        SoName = p.SoName,
                        EmID = p.EmID,
                        EmName = p.EmName,
                        OrID = p.ChID,
                        SaDate = p.SaDate,
                        SaFlag = p.SaFlag,
                        SaHidden = p.SaHidden


                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return sale;
        }
        ///////////////////////////////
        //メソッド名：GetSaleHiddenData()
        //引　数   ：なし
        //戻り値   ：全売上非表示データ
        //機　能   ：全売上非表示データの取得
        ///////////////////////////////
        public List<T_SaleDsp> GetSaleHiddenData()
        {
            List<T_SaleDsp> sale = new List<T_SaleDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_Sales
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID
                         where t1.SaFlag == 2
                         select new
                         {
                             t1.SaID,
                             t1.ClID,
                             t4.ClName,
                             t1.SoID,
                             t2.SoName,
                             t1.EmID,
                             t3.EmName,
                             t1.ChID,
                             t1.SaDate,
                             t1.SaFlag,
                             t1.SaHidden,

                         };
                foreach (var p in tb)
                {
                    sale.Add(new T_SaleDsp()
                    {
                        SaID = p.SaID,
                        ClID = p.ClID,
                        ClName = p.ClName,
                        SoID = p.SoID,
                        SoName = p.SoName,
                        EmID = p.EmID,
                        EmName = p.EmName,
                        OrID = p.ChID,
                        SaDate = p.SaDate,
                        SaFlag = p.SaFlag,
                        SaHidden = p.SaHidden


                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return sale;
        }

    }
}
