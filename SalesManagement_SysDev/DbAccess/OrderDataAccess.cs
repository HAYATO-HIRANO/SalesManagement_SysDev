using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SalesManagement_SysDev
{
    class OrderDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckOrIDExistence()
        //引　数   ：受注ID
        //戻り値   ：True or False
        //機　能   ：一致する受注IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckOrIDExistence(int orID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                //受注IDで一致するデータが存在するか
                flg = context.T_Orders.Any(x => x.OrID == orID);
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：AddOrderData()
        //引　数   ：受注データ
        //戻り値   ：True or False
        //機　能   ：受注データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddOrderData(T_Order regOrder)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_Orders.Add(regOrder);
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
        //メソッド名：GetOrIDData()
        //引　数   :受注ID
        //戻り値   ：受注IDの受注データ
        //機　能   ：受注IDの受注情報取得
        ///////////////////////////////
        public T_Order GetOrIDData(int orID)
        {
            T_Order order = new T_Order();

            try
            {
                var context = new SalesManagement_DevContext();

                order = context.T_Orders.Single(x => x.OrID == orID && x.OrFlag == 0);

                context.SaveChanges();
                context.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return order;
        }

        ///////////////////////////////
        //メソッド名：UpdateStateFlag()
        //引　数   :受注ID
        //戻り値   ：True or False
        //機　能   ：受注状態フラグの更新(0から1)
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateStateFlag(int orID)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var Order = context.T_Orders.Single(x => x.OrID == orID && x.OrFlag == 0);
                Order.OrStateFlag = 1;

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
        //メソッド名：UpdateHiddenFlag()
        //引　数   :受注情報(受注ID,非表示フラグ,非表示理由)
        //戻り値   ：True or False
        //機　能   ：受注管理フラグの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateHiddenFlag(T_Order updOrder)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var Order = context.T_Orders.Single(x => x.OrID == updOrder.OrID);
                Order.OrFlag = updOrder.OrFlag;
                Order.OrHidden = updOrder.OrHidden;

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
        //メソッド名：GetOrIDMaxData()
        //引　数   :なし
        //戻り値   ：受注ID
        //機　能   ：最後の受注IDの取得
        ///////////////////////////////
        public int GetOrIDMaxData()
        {
            int orID=new int();

            try
            {
                var context = new SalesManagement_DevContext();

               var order = context.T_Orders.ToList();
                orID = order[order.Count-1].OrID;
                context.Dispose();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return orID;
        }

        ///////////////////////////////
        //メソッド名：GetOrderData()
        //引　数   ：なし
        //戻り値   ：全受注データ
        //機　能   ：全受注データの取得
        ///////////////////////////////
        public List<T_OrderDsp> GetOrderData()
        {
            List<T_OrderDsp> order = new List<T_OrderDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_Orders
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID
                         where t1.OrFlag == 0
                         select new
                         {
                             t1.OrID,
                             t1.SoID,
                             t2.SoName,
                             t1.EmID,
                             t3.EmName,
                             t1.ClID,
                             t4.ClName,
                             t1.ClCharge,
                             t1.OrDate,
                             t1.OrStateFlag,
                             t1.OrFlag,
                             t1.OrHidden,
                         };
                foreach (var p in tb)
                {
                    order.Add(new T_OrderDsp()
                    {
                        OrID = p.OrID,
                        SoID = p.SoID,
                        SoName = p.SoName,
                        EmID = p.EmID,
                        EmName = p.EmName,
                        ClID = p.ClID,
                        ClName = p.ClName,
                        ClCharge = p.ClCharge,
                        OrDate = p.OrDate,
                        OrStateFlag = p.OrStateFlag,
                        OrFlag = p.OrFlag,
                        OrHidden = p.OrHidden


                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return order;
        }
        ///////////////////////////////
        //メソッド名：GetOrderData() オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致受注データ
        //機　能   ：条件一致受注データの取得
        ///////////////////////////////
        public List<T_OrderDsp> GetOrderData(int flg, T_OrderDsp selectCondition)
        {
            List<T_OrderDsp> order = new List<T_OrderDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                if (flg == 1)
                {
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                             t1.ClCharge.Contains(selectCondition.ClCharge) &&
                             t1.OrFlag == selectCondition.OrFlag &&
                             t1.OrStateFlag == selectCondition.OrStateFlag &&
                             t1.OrHidden.Contains(selectCondition.OrHidden)
                             select new
                             {
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };
                    foreach (var p in tb)
                    {
                        order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden


                        });
                    }
                }
                if (flg == 2)
                {
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ClCharge.Contains(selectCondition.ClCharge) &&
                             t1.OrFlag == selectCondition.OrFlag &&
                             t1.OrStateFlag == selectCondition.OrStateFlag &&
                             t1.OrHidden.Contains(selectCondition.OrHidden)
                             select new
                             {
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };
                    foreach (var p in tb)
                    {
                        order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden


                        });
                    }
                }
                if (flg == 3)
                {
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                             t1.ClCharge.Contains(selectCondition.ClCharge) &&
                             t1.OrFlag == selectCondition.OrFlag &&
                             t1.OrStateFlag == selectCondition.OrStateFlag &&
                             t1.OrHidden.Contains(selectCondition.OrHidden)
                             select new
                             {
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };
                    foreach (var p in tb)
                    {
                        order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden


                        });
                    }
                }
                if (flg == 4)
                {
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ClCharge.Contains(selectCondition.ClCharge) &&
                             t1.OrFlag == selectCondition.OrFlag &&
                             t1.OrStateFlag == selectCondition.OrStateFlag &&
                             t1.OrHidden.Contains(selectCondition.OrHidden)
                             select new
                             {
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };
                    foreach (var p in tb)
                    {
                        order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden


                        });
                    }
                }


                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return order;
        }
        ///////////////////////////////
        //メソッド名：GetOrderDateData() オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致受注データ
        //機　能   ：条件一致受注データの取得
        ///////////////////////////////
        public List<T_OrderDsp> GetOrderDateData(int flg, T_OrderDsp selectCondition,DateTime? startDay, DateTime? endDay)
        {
            List<T_OrderDsp> order = new List<T_OrderDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                if (flg == 1)
                {
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                             t1.ClCharge.Contains(selectCondition.ClCharge) &&
                             t1.OrFlag == selectCondition.OrFlag &&
                             t1.OrStateFlag == selectCondition.OrStateFlag &&
                             t1.OrHidden.Contains(selectCondition.OrHidden)&&
                             t1.OrDate >=startDay&&
                             t1.OrDate <= endDay 


                             select new
                             {
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };
                    foreach (var p in tb)
                    {
                        order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden


                        });
                    }
                }
                if (flg == 2)
                {
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ClCharge.Contains(selectCondition.ClCharge) &&
                             t1.OrFlag == selectCondition.OrFlag &&
                             t1.OrStateFlag == selectCondition.OrStateFlag &&
                             t1.OrHidden.Contains(selectCondition.OrHidden)&&
                             t1.OrDate >= startDay &&
                             t1.OrDate <= endDay

                             select new
                             {
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };
                    foreach (var p in tb)
                    {
                        order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden


                        });
                    }
                }
                if (flg == 3)
                {
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                             t1.ClCharge.Contains(selectCondition.ClCharge) &&
                             t1.OrFlag == selectCondition.OrFlag &&
                             t1.OrStateFlag == selectCondition.OrStateFlag &&
                             t1.OrHidden.Contains(selectCondition.OrHidden) && 
                             t1.OrDate >= startDay &&
                             t1.OrDate <= endDay

                             select new
                             {
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };
                    foreach (var p in tb)
                    {
                        order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden


                        });
                    }
                }
                if (flg == 4)
                {
                    var tb = from t1 in context.T_Orders
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ClCharge.Contains(selectCondition.ClCharge) &&
                             t1.OrFlag == selectCondition.OrFlag &&
                             t1.OrStateFlag == selectCondition.OrStateFlag &&
                             t1.OrHidden.Contains(selectCondition.OrHidden) && 
                             t1.OrDate >= startDay &&
                             t1.OrDate <= endDay

                             select new
                             {
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ClCharge,
                                 t1.OrDate,
                                 t1.OrStateFlag,
                                 t1.OrFlag,
                                 t1.OrHidden,
                             };
                    foreach (var p in tb)
                    {
                        order.Add(new T_OrderDsp()
                        {
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ClCharge = p.ClCharge,
                            OrDate = p.OrDate,
                            OrStateFlag = p.OrStateFlag,
                            OrFlag = p.OrFlag,
                            OrHidden = p.OrHidden


                        });
                    }
                }


                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return order;
        }

        ///////////////////////////////
        //メソッド名：GetOrderHiddenData()
        //引　数   ：なし
        //戻り値   ：非表示データ
        //機　能   ：非表示データの取得
        ///////////////////////////////
        public List<T_OrderDsp> GetOrderHiddenData()
        {
            List<T_OrderDsp> order = new List<T_OrderDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_Orders
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID
                         where t1.OrFlag == 2
                         select new
                         {
                             t1.OrID,
                             t1.SoID,
                             t2.SoName,
                             t1.EmID,
                             t3.EmName,
                             t1.ClID,
                             t4.ClName,
                             t1.ClCharge,
                             t1.OrDate,
                             t1.OrStateFlag,
                             t1.OrFlag,
                             t1.OrHidden,
                         };
                foreach (var p in tb)
                {
                    order.Add(new T_OrderDsp()
                    {
                        OrID = p.OrID,
                        SoID = p.SoID,
                        SoName = p.SoName,
                        EmID = p.EmID,
                        EmName = p.EmName,
                        ClID = p.ClID,
                        ClName = p.ClName,
                        ClCharge = p.ClCharge,
                        OrDate = p.OrDate,
                        OrStateFlag = p.OrStateFlag,
                        OrFlag = p.OrFlag,
                        OrHidden = p.OrHidden


                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return order;
        }
        



    }
}
