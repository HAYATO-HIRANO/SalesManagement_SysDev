using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class ArrivalDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckArIDExistence()
        //引　数   ：入荷ID
        //戻り値   ：True or False
        //機　能   ：一致する入荷IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckArIDExistence(int arID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                //入荷IDで一致するデータが存在するか
                flg = context.T_Arrivals.Any(x => x.ArID == arID);
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：AddArrivalData()
        //引　数   ：入荷データ
        //戻り値   ：True or False
        //機　能   ：入荷データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddArrivalData(T_Arrival regArrival)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_Arrivals.Add(regArrival);
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
        //メソッド名：GetArIDData()
        //引　数   :入荷ID
        //戻り値   ：入荷IDの入荷データ
        //機　能   ：入荷IDの入荷情報取得
        ///////////////////////////////
        public T_Arrival GetArIDData(int arID)
        {
            T_Arrival arrival = new T_Arrival();

            try
            {
                var context = new SalesManagement_DevContext();

                arrival = context.T_Arrivals.Single(x => x.ArID == arID && x.ArFlag == 0);

                context.SaveChanges();
                context.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return arrival;
        }
        ///////////////////////////////
        //メソッド名：GetOrIDData()
        //引　数   :受注ID
        //戻り値   ：受注IDの入荷データ
        //機　能   ：受注IDの入荷情報取得
        ///////////////////////////////
        public T_Arrival GetOrIDData(int orID)
        {
            T_Arrival arrival = new T_Arrival();

            try
            {
                var context = new SalesManagement_DevContext();

                arrival = context.T_Arrivals.Single(x => x.OrID == orID && x.ArFlag == 0);

                context.SaveChanges();
                context.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return arrival;
        }

        ///////////////////////////////
        //メソッド名：UpdateStateFlag()
        //引　数   :入荷ID
        //戻り値   ：True or False
        //機　能   ：入荷状態フラグの更新(0から1)
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateStateFlag(int ArID)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var arrival = context.T_Arrivals.Single(x => x.ArID == ArID && x.ArFlag == 0);
                arrival.ArStateFlag = 1;

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
        //引　数   :入荷情報(入荷ID,非表示フラグ,非表示理由)
        //戻り値   ：True or False
        //機　能   ：入荷管理フラグの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateHiddenFlag(T_Arrival updArrival)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var arrival = context.T_Arrivals.Single(x => x.ArID == updArrival.ArID);
                arrival.ArFlag = updArrival.ArFlag;
                arrival.ArHidden = updArrival.ArHidden;

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
        //メソッド名：GetArrivalData()
        //引　数   ：なし
        //戻り値   ：全入荷データ
        //機　能   ：全入荷データの取得
        ///////////////////////////////
        public List<T_ArrivalDsp> GetArrivalData()
        {
            List<T_ArrivalDsp> arrival = new List<T_ArrivalDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_Arrivals
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID
                         where t1.ArFlag == 0
                         select new
                         {
                             t1.ArID,
                             t1.OrID,
                             t1.SoID,
                             t2.SoName,
                             t1.EmID,
                             t3.EmName,
                             t1.ClID,
                             t4.ClName,
                             
                             t1.ArDate,
                             t1.ArStateFlag,
                             t1.ArFlag,
                             t1.ArHidden,
                         };
                foreach (var p in tb)
                {
                    arrival.Add(new T_ArrivalDsp()
                    {
                        ArID = p.ArID,
                        OrID=p.OrID,
                        SoID = p.SoID,
                        SoName = p.SoName,
                        EmID = p.EmID,
                        EmName = p.EmName,
                        ClID = p.ClID,
                        ClName = p.ClName,
                        ArDate = p.ArDate,
                        ArStateFlag = p.ArStateFlag,
                        ArFlag = p.ArFlag,
                        ArHidden = p.ArHidden


                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return arrival;
        }
        ///////////////////////////////
        //メソッド名：GetArrivalHiddenData()
        //引　数   ：なし
        //戻り値   ：全入荷非表示データ
        //機　能   ：全入荷非表示データの取得
        ///////////////////////////////
        public List<T_ArrivalDsp> GetArrivalHiddenData()
        {
            List<T_ArrivalDsp> arrival = new List<T_ArrivalDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_Arrivals
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID
                         where t1.ArFlag == 2
                         select new
                         {
                             t1.ArID,
                             t1.OrID,
                             t1.SoID,
                             t2.SoName,
                             t1.EmID,
                             t3.EmName,
                             t1.ClID,
                             t4.ClName,

                             t1.ArDate,
                             t1.ArStateFlag,
                             t1.ArFlag,
                             t1.ArHidden,
                         };
                foreach (var p in tb)
                {
                    arrival.Add(new T_ArrivalDsp()
                    {
                        ArID = p.ArID,
                        OrID = p.OrID,
                        SoID = p.SoID,
                        SoName = p.SoName,
                        EmID = p.EmID,
                        EmName = p.EmName,
                        ClID = p.ClID,
                        ClName = p.ClName,
                        ArDate = p.ArDate,
                        ArStateFlag = p.ArStateFlag,
                        ArFlag = p.ArFlag,
                        ArHidden = p.ArHidden


                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return arrival;
        }

        ///////////////////////////////
        //メソッド名：GetOrderData() オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致入荷データ
        //機　能   ：条件一致入荷データの取得
        ///////////////////////////////
        public List<T_ArrivalDsp> GetOrderData(int flg, T_ArrivalDsp selectCondition)
        {
            List<T_ArrivalDsp> arrival = new List<T_ArrivalDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                if (flg == 1)
                {
                    var tb = from t1 in context.T_Arrivals
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ArID.ToString().Contains(selectCondition.ArID.ToString()) &&
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&

                             t1.ArFlag == selectCondition.ArFlag &&
                             t1.ArStateFlag == selectCondition.ArStateFlag &&
                             t1.ArHidden.Contains(selectCondition.ArHidden)
                             select new
                             {
                                 t1.ArID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,                                 
                                 t1.ArDate,
                                 t1.ArStateFlag,
                                 t1.ArFlag,
                                 t1.ArHidden,
                             };
                    foreach (var p in tb)
                    {
                        arrival.Add(new T_ArrivalDsp()
                        {
                            ArID=p.ArID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            
                            ArDate = p.ArDate,
                            ArStateFlag = p.ArStateFlag,
                            ArFlag = p.ArFlag,
                            ArHidden = p.ArHidden


                        });
                    }
                }
                if (flg == 2)
                {
                    var tb = from t1 in context.T_Arrivals
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ArID.ToString().Contains(selectCondition.ArID.ToString()) &&
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ArFlag == selectCondition.ArFlag &&
                             t1.ArStateFlag == selectCondition.ArStateFlag &&
                             t1.ArHidden.Contains(selectCondition.ArHidden)
                             select new
                             {
                                 t1.ArID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ArDate,
                                 t1.ArStateFlag,
                                 t1.ArFlag,
                                 t1.ArHidden,
                             };
                    foreach (var p in tb)
                    {
                        arrival.Add(new T_ArrivalDsp()
                        {
                            ArID = p.ArID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,

                            ArDate = p.ArDate,
                            ArStateFlag = p.ArStateFlag,
                            ArFlag = p.ArFlag,
                            ArHidden = p.ArHidden


                        });
                    }
                }
                if (flg == 3)
                {
                    var tb = from t1 in context.T_Arrivals
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ArID.ToString().Contains(selectCondition.ArID.ToString()) &&
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                             t1.ArFlag == selectCondition.ArFlag &&
                             t1.ArStateFlag == selectCondition.ArStateFlag &&
                             t1.ArHidden.Contains(selectCondition.ArHidden)
                             select new
                             {
                                 t1.ArID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ArDate,
                                 t1.ArStateFlag,
                                 t1.ArFlag,
                                 t1.ArHidden,
                             };
                    foreach (var p in tb)
                    {
                        arrival.Add(new T_ArrivalDsp()
                        {
                            ArID = p.ArID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,

                            ArDate = p.ArDate,
                            ArStateFlag = p.ArStateFlag,
                            ArFlag = p.ArFlag,
                            ArHidden = p.ArHidden


                        });
                    }
                }
                if (flg == 4)
                {
                    var tb = from t1 in context.T_Arrivals
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ArID.ToString().Contains(selectCondition.ArID.ToString()) &&
                             t1.ArFlag == selectCondition.ArFlag &&
                             t1.ArStateFlag == selectCondition.ArStateFlag &&
                             t1.ArHidden.Contains(selectCondition.ArHidden)
                             select new
                             {
                                 t1.ArID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ArDate,
                                 t1.ArStateFlag,
                                 t1.ArFlag,
                                 t1.ArHidden,
                             };
                    foreach (var p in tb)
                    {
                        arrival.Add(new T_ArrivalDsp()
                        {
                            ArID = p.ArID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,

                            ArDate = p.ArDate,
                            ArStateFlag = p.ArStateFlag,
                            ArFlag = p.ArFlag,
                            ArHidden = p.ArHidden


                        });
                    }
                }
                if (flg == 5)
                {
                    var tb = from t1 in context.T_Arrivals
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                             t1.ArFlag == selectCondition.ArFlag &&
                             t1.ArStateFlag == selectCondition.ArStateFlag &&
                             t1.ArHidden.Contains(selectCondition.ArHidden)
                             select new
                             {
                                 t1.ArID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ArDate,
                                 t1.ArStateFlag,
                                 t1.ArFlag,
                                 t1.ArHidden,
                             };
                    foreach (var p in tb)
                    {
                        arrival.Add(new T_ArrivalDsp()
                        {
                            ArID = p.ArID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,

                            ArDate = p.ArDate,
                            ArStateFlag = p.ArStateFlag,
                            ArFlag = p.ArFlag,
                            ArHidden = p.ArHidden


                        });
                    }
                }
                if (flg == 6)
                {
                    var tb = from t1 in context.T_Arrivals
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ArFlag == selectCondition.ArFlag &&
                             t1.ArStateFlag == selectCondition.ArStateFlag &&
                             t1.ArHidden.Contains(selectCondition.ArHidden)
                             select new
                             {
                                 t1.ArID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ArDate,
                                 t1.ArStateFlag,
                                 t1.ArFlag,
                                 t1.ArHidden,
                             };
                    foreach (var p in tb)
                    {
                        arrival.Add(new T_ArrivalDsp()
                        {
                            ArID = p.ArID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,

                            ArDate = p.ArDate,
                            ArStateFlag = p.ArStateFlag,
                            ArFlag = p.ArFlag,
                            ArHidden = p.ArHidden


                        });
                    }
                }
                if (flg == 7)
                {
                    var tb = from t1 in context.T_Arrivals
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                             t1.ArFlag == selectCondition.ArFlag &&
                             t1.ArStateFlag == selectCondition.ArStateFlag &&
                             t1.ArHidden.Contains(selectCondition.ArHidden)
                             select new
                             {
                                 t1.ArID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ArDate,
                                 t1.ArStateFlag,
                                 t1.ArFlag,
                                 t1.ArHidden,
                             };
                    foreach (var p in tb)
                    {
                        arrival.Add(new T_ArrivalDsp()
                        {
                            ArID = p.ArID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,

                            ArDate = p.ArDate,
                            ArStateFlag = p.ArStateFlag,
                            ArFlag = p.ArFlag,
                            ArHidden = p.ArHidden


                        });
                    }
                }
                if (flg == 8)
                {
                    var tb = from t1 in context.T_Arrivals
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ArFlag == selectCondition.ArFlag &&
                             t1.ArStateFlag == selectCondition.ArStateFlag &&
                             t1.ArHidden.Contains(selectCondition.ArHidden)
                             select new
                             {
                                 t1.ArID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ArDate,
                                 t1.ArStateFlag,
                                 t1.ArFlag,
                                 t1.ArHidden,
                             };
                    foreach (var p in tb)
                    {
                        arrival.Add(new T_ArrivalDsp()
                        {
                            ArID = p.ArID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,

                            ArDate = p.ArDate,
                            ArStateFlag = p.ArStateFlag,
                            ArFlag = p.ArFlag,
                            ArHidden = p.ArHidden


                        });
                    }
                }


                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return arrival;
        }
        ///////////////////////////////
        //メソッド名：GetOrderDateData() オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致入荷データ
        //機　能   ：条件一致入荷データの取得
        ///////////////////////////////
        public List<T_ArrivalDsp> GetOrderDateData(int flg, T_ArrivalDsp selectCondition, DateTime? startDay, DateTime? endDay)
        {
            List<T_ArrivalDsp> arrival = new List<T_ArrivalDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                if (flg == 1)
                {
                    var tb = from t1 in context.T_Arrivals
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ArID.ToString().Contains(selectCondition.ArID.ToString()) &&
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                             t1.ArDate >= startDay &&
                             t1.ArDate <= endDay&&

                             t1.ArFlag == selectCondition.ArFlag &&
                             t1.ArStateFlag == selectCondition.ArStateFlag &&
                             t1.ArHidden.Contains(selectCondition.ArHidden)
                             select new
                             {
                                 t1.ArID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ArDate,
                                 t1.ArStateFlag,
                                 t1.ArFlag,
                                 t1.ArHidden,
                             };
                    foreach (var p in tb)
                    {
                        arrival.Add(new T_ArrivalDsp()
                        {
                            ArID = p.ArID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,

                            ArDate = p.ArDate,
                            ArStateFlag = p.ArStateFlag,
                            ArFlag = p.ArFlag,
                            ArHidden = p.ArHidden


                        });
                    }
                }
                if (flg == 2)
                {
                    var tb = from t1 in context.T_Arrivals
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ArID.ToString().Contains(selectCondition.ArID.ToString()) &&
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                                                          t1.ArDate >= startDay &&
                             t1.ArDate <= endDay &&

                             t1.ArFlag == selectCondition.ArFlag &&
                             t1.ArStateFlag == selectCondition.ArStateFlag &&
                             t1.ArHidden.Contains(selectCondition.ArHidden)
                             select new
                             {
                                 t1.ArID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ArDate,
                                 t1.ArStateFlag,
                                 t1.ArFlag,
                                 t1.ArHidden,
                             };
                    foreach (var p in tb)
                    {
                        arrival.Add(new T_ArrivalDsp()
                        {
                            ArID = p.ArID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,

                            ArDate = p.ArDate,
                            ArStateFlag = p.ArStateFlag,
                            ArFlag = p.ArFlag,
                            ArHidden = p.ArHidden


                        });
                    }
                }
                if (flg == 3)
                {
                    var tb = from t1 in context.T_Arrivals
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ArID.ToString().Contains(selectCondition.ArID.ToString()) &&
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                             t1.ArFlag == selectCondition.ArFlag &&
                             t1.ArStateFlag == selectCondition.ArStateFlag &&
                             t1.ArHidden.Contains(selectCondition.ArHidden)&&
                             t1.ArDate >= startDay &&
                             t1.ArDate <= endDay 

                             select new
                             {
                                 t1.ArID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ArDate,
                                 t1.ArStateFlag,
                                 t1.ArFlag,
                                 t1.ArHidden,
                             };
                    foreach (var p in tb)
                    {
                        arrival.Add(new T_ArrivalDsp()
                        {
                            ArID = p.ArID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,

                            ArDate = p.ArDate,
                            ArStateFlag = p.ArStateFlag,
                            ArFlag = p.ArFlag,
                            ArHidden = p.ArHidden


                        });
                    }
                }
                if (flg == 4)
                {
                    var tb = from t1 in context.T_Arrivals
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ArID.ToString().Contains(selectCondition.ArID.ToString()) &&
                             t1.ArFlag == selectCondition.ArFlag &&
                             t1.ArStateFlag == selectCondition.ArStateFlag &&
                             t1.ArHidden.Contains(selectCondition.ArHidden) && 
                             t1.ArDate >= startDay &&
                             t1.ArDate <= endDay

                             select new
                             {
                                 t1.ArID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ArDate,
                                 t1.ArStateFlag,
                                 t1.ArFlag,
                                 t1.ArHidden,
                             };
                    foreach (var p in tb)
                    {
                        arrival.Add(new T_ArrivalDsp()
                        {
                            ArID = p.ArID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,

                            ArDate = p.ArDate,
                            ArStateFlag = p.ArStateFlag,
                            ArFlag = p.ArFlag,
                            ArHidden = p.ArHidden


                        });
                    }
                }
                if (flg == 5)
                {
                    var tb = from t1 in context.T_Arrivals
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                             t1.ArFlag == selectCondition.ArFlag &&
                             t1.ArStateFlag == selectCondition.ArStateFlag &&
                             t1.ArHidden.Contains(selectCondition.ArHidden) && 
                             t1.ArDate >= startDay &&
                             t1.ArDate <= endDay

                             select new
                             {
                                 t1.ArID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ArDate,
                                 t1.ArStateFlag,
                                 t1.ArFlag,
                                 t1.ArHidden,
                             };
                    foreach (var p in tb)
                    {
                        arrival.Add(new T_ArrivalDsp()
                        {
                            ArID = p.ArID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,

                            ArDate = p.ArDate,
                            ArStateFlag = p.ArStateFlag,
                            ArFlag = p.ArFlag,
                            ArHidden = p.ArHidden


                        });
                    }
                }
                if (flg == 6)
                {
                    var tb = from t1 in context.T_Arrivals
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ArFlag == selectCondition.ArFlag &&
                             t1.ArStateFlag == selectCondition.ArStateFlag &&
                             t1.ArHidden.Contains(selectCondition.ArHidden) &&
                             t1.ArDate >= startDay &&
                             t1.ArDate <= endDay

                             select new
                             {
                                 t1.ArID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ArDate,
                                 t1.ArStateFlag,
                                 t1.ArFlag,
                                 t1.ArHidden,
                             };
                    foreach (var p in tb)
                    {
                        arrival.Add(new T_ArrivalDsp()
                        {
                            ArID = p.ArID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,

                            ArDate = p.ArDate,
                            ArStateFlag = p.ArStateFlag,
                            ArFlag = p.ArFlag,
                            ArHidden = p.ArHidden


                        });
                    }
                }
                if (flg == 7)
                {
                    var tb = from t1 in context.T_Arrivals
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                             t1.ArFlag == selectCondition.ArFlag &&
                             t1.ArStateFlag == selectCondition.ArStateFlag &&
                             t1.ArHidden.Contains(selectCondition.ArHidden) && 
                             t1.ArDate >= startDay &&
                             t1.ArDate <= endDay

                             select new
                             {
                                 t1.ArID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ArDate,
                                 t1.ArStateFlag,
                                 t1.ArFlag,
                                 t1.ArHidden,
                             };
                    foreach (var p in tb)
                    {
                        arrival.Add(new T_ArrivalDsp()
                        {
                            ArID = p.ArID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,

                            ArDate = p.ArDate,
                            ArStateFlag = p.ArStateFlag,
                            ArFlag = p.ArFlag,
                            ArHidden = p.ArHidden


                        });
                    }
                }
                if (flg == 8)
                {
                    var tb = from t1 in context.T_Arrivals
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ArFlag == selectCondition.ArFlag &&
                             t1.ArStateFlag == selectCondition.ArStateFlag &&
                             t1.ArHidden.Contains(selectCondition.ArHidden) &&
                             t1.ArDate >= startDay &&
                             t1.ArDate <= endDay

                             select new
                             {
                                 t1.ArID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.ArDate,
                                 t1.ArStateFlag,
                                 t1.ArFlag,
                                 t1.ArHidden,
                             };
                    foreach (var p in tb)
                    {
                        arrival.Add(new T_ArrivalDsp()
                        {
                            ArID = p.ArID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,

                            ArDate = p.ArDate,
                            ArStateFlag = p.ArStateFlag,
                            ArFlag = p.ArFlag,
                            ArHidden = p.ArHidden


                        });
                    }
                }


                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return arrival;
        }


    }
}
