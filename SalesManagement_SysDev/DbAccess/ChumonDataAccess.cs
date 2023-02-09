using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SalesManagement_SysDev
{
    class ChumonDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckChIDExistence()
        //引　数   ：注文ID
        //戻り値   ：True or False
        //機　能   ：一致する注文IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckChIDExistence(int chID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                //注文IDで一致するデータが存在するか
                flg = context.T_Chumons.Any(x => x.ChID == chID);
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：CheckChIDExistence()
        //引　数   ：注文ID
        //戻り値   ：True or False
        //機　能   ：一致する注文IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckChIDHidden(int chID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                //注文IDで一致するデータが存在するか
                flg = context.T_Chumons.Any(x => x.ChID == chID&&x.ChFlag==0);
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：AddChumonData()
        //引　数   ：注文データ
        //戻り値   ：True or False
        //機　能   ：入荷データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddChumonData(T_Chumon regChumon)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_Chumons.Add(regChumon);
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
        //メソッド名：GetChIDData()
        //引　数   :注文ID
        //戻り値   ：注文IDの注文データ
        //機　能   ：注文IDの注文情報取得
        ///////////////////////////////
        public T_Chumon GetChIDData(int chID)
        {
            T_Chumon chumon = new T_Chumon();

            try
            {
                var context = new SalesManagement_DevContext();

                chumon = context.T_Chumons.Single(x => x.ChID == chID && x.ChFlag == 0);

                context.SaveChanges();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return chumon;

        }
        ///////////////////////////////
        //メソッド名：GetOrIDData()
        //引　数   :受注ID
        //戻り値   ：受注IDの注文データ
        //機　能   ：受注IDの注文情報取得
        ///////////////////////////////
        public T_Chumon GetOrIDData(int orID)
        {
            T_Chumon chumon = new T_Chumon();

            try
            {
                var context = new SalesManagement_DevContext();

                chumon = context.T_Chumons.Single(x => x.OrID == orID && x.ChFlag == 0);

                context.SaveChanges();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return chumon;
        }

        ///////////////////////////////
        //メソッド名：UpdateChumonData()
        //引　数   :注文ID
        //戻り値   ：True or False
        //機　能   ：注文状態フラグの更新(0から1)
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateChumonData(int ChID)
        {
            try
            {
                var context = new SalesManagement_DevContext();

                var chumon = context.T_Chumons.Single(x => x.ChID == ChID && x.ChFlag == 0);
                chumon.EmID = FormMain.loginEmID;
                chumon.ChStateFlag = 1;

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
        //引　数   :注文情報(注文ID,非表示フラグ,非表示理由)
        //戻り値   ：True or False
        //機　能   ：注文管理フラグの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateHiddenFlag(T_Chumon updChumon)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var chumon = context.T_Chumons.Single(x => x.ChID == updChumon.ChID);
                chumon.ChFlag = updChumon.ChFlag;
                chumon.ChHidden = updChumon.ChHidden;

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
        //メソッド名：GetChumonData()
        //引　数   ：なし
        //戻り値   ：全注文データ
        //機　能   ：全注文データの取得
        ///////////////////////////////
        public List<T_ChumonDsp> GetChumonData()
        {
            List<T_ChumonDsp> chumon = new List<T_ChumonDsp>();
            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_Chumons
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                          on t1.ClID equals t4.ClID
                         where t1.ChFlag == 0
                         select new
                         {
                             t1.ChID,
                             t1.OrID,
                             t1.SoID,
                             t2.SoName,
                             t1.EmID,
                             t3.EmName,
                             t1.ClID,
                             t4.ClName,
                             t1.ChDate,
                             t1.ChStateFlag,
                             t1.ChFlag,
                             t1.ChHidden,
                         };
                foreach (var p in tb)
                {
                    chumon.Add(new T_ChumonDsp()
                    {
                        ChID = p.ChID,
                        OrID = p.OrID,
                        SoID = p.SoID,
                        SoName = p.SoName,
                        EmID = p.EmID,
                        EmName = p.EmName,
                        ClID = p.ClID,
                        ClName = p.ClName,
                        ChDate = p.ChDate,
                        ChStateFlag = p.ChStateFlag,
                        ChFlag = p.ChFlag,
                        ChHidden = p.ChHidden
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return chumon;
        }

        ///////////////////////////////
        //メソッド名：GetChumonHiddenData()
        //引　数   ：なし
        //戻り値   ：全注文非表示データ
        //機　能   ：全注文非表示データの取得
        ///////////////////////////////
        public List<T_ChumonDsp> GetChumonHiddenData()
        {
            List<T_ChumonDsp> chumon = new List<T_ChumonDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_Chumons
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                          on t1.ClID equals t4.ClID
                         where t1.ChFlag == 2
                         select new
                         {
                             t1.ChID,
                             t1.OrID,
                             t1.SoID,
                             t2.SoName,
                             t1.EmID,
                             t3.EmName,
                             t1.ClID,
                             t4.ClName,

                             t1.ChDate,
                             t1.ChStateFlag,
                             t1.ChFlag,
                             t1.ChHidden,
                         };
                foreach (var p in tb)
                {
                    chumon.Add(new T_ChumonDsp()
                    {
                        ChID = p.ChID,
                        OrID = p.OrID,
                        SoID = p.SoID,
                        SoName = p.SoName,
                        EmID = p.EmID,
                        EmName = p.EmName,
                        ClID = p.ClID,
                        ClName = p.ClName,
                        ChDate = p.ChDate,
                        ChStateFlag = p.ChStateFlag,
                        ChFlag = p.ChFlag,
                        ChHidden = p.ChHidden
                    });
                   
                }
                context.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return chumon;
        }

        ///////////////////////////////
        //メソッド名：GetChumonData() オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致注文データ
        //機　能   ：条件一致注文データの取得
        ///////////////////////////////
        public List<T_ChumonDsp> GetChumonData(int flg, T_ChumonDsp selectCondition)
        {
            List<T_ChumonDsp> chumon = new List<T_ChumonDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                if (flg == 1)
                {
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                              on t1.ClID equals t4.ClID
                             where
                             t1.ChID.ToString().Contains(selectCondition.ChID.ToString()) &&
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&

                              t1.ChFlag == selectCondition.ChFlag &&
                             t1.ChStateFlag == selectCondition.ChStateFlag &&
                             t1.ChHidden.Contains(selectCondition.ChHidden)
                             select new
                             {
                                 t1.ChID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,

                                 t1.ChDate,
                                 t1.ChStateFlag,
                                 t1.ChFlag,
                                 t1.ChHidden,
                             };
                    foreach (var p in tb)
                    {
                        chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ChDate = p.ChDate,
                            ChStateFlag = p.ChStateFlag,
                            ChFlag = p.ChFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                }
                if (flg == 2)
                {
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                              on t1.ClID equals t4.ClID
                             where
                             t1.ChID.ToString().Contains(selectCondition.ChID.ToString()) &&
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ChFlag == selectCondition.ChFlag &&
                             t1.ChStateFlag == selectCondition.ChStateFlag &&
                             t1.ChHidden.Contains(selectCondition.ChHidden)
                             select new
                             {
                                 t1.ChID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,

                                 t1.ChDate,
                                 t1.ChStateFlag,
                                 t1.ChFlag,
                                 t1.ChHidden,
                             };
                    foreach (var p in tb)
                    {
                        chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ChDate = p.ChDate,
                            ChStateFlag = p.ChStateFlag,
                            ChFlag = p.ChFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                }
                if (flg == 3)
                {
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                              on t1.ClID equals t4.ClID
                             where
                             t1.ChID.ToString().Contains(selectCondition.ChID.ToString()) &&
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                             t1.ChFlag == selectCondition.ChFlag &&
                             t1.ChStateFlag == selectCondition.ChStateFlag &&
                             t1.ChHidden.Contains(selectCondition.ChHidden)
                             select new
                             {
                                 t1.ChID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,

                                 t1.ChDate,
                                 t1.ChStateFlag,
                                 t1.ChFlag,
                                 t1.ChHidden,
                             };
                    foreach (var p in tb)
                    {
                        chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ChDate = p.ChDate,
                            ChStateFlag = p.ChStateFlag,
                            ChFlag = p.ChFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                }
                if (flg == 4)
                {
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ChID.ToString().Contains(selectCondition.ChID.ToString()) &&
                             t1.ChFlag == selectCondition.ChFlag &&
                             t1.ChStateFlag == selectCondition.ChStateFlag &&
                             t1.ChHidden.Contains(selectCondition.ChHidden)
                             select new
                             {
                                 t1.ChID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,

                                 t1.ChDate,
                                 t1.ChStateFlag,
                                 t1.ChFlag,
                                 t1.ChHidden,
                             };
                    foreach (var p in tb)
                    {
                        chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ChDate = p.ChDate,
                            ChStateFlag = p.ChStateFlag,
                            ChFlag = p.ChFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                }
                if (flg == 5)
                {
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                             t1.ChFlag == selectCondition.ChFlag &&
                             t1.ChStateFlag == selectCondition.ChStateFlag &&
                             t1.ChHidden.Contains(selectCondition.ChHidden)
                             select new
                             {
                                 t1.ChID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,

                                 t1.ChDate,
                                 t1.ChStateFlag,
                                 t1.ChFlag,
                                 t1.ChHidden,
                             };
                    foreach (var p in tb)
                    {
                        chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ChDate = p.ChDate,
                            ChStateFlag = p.ChStateFlag,
                            ChFlag = p.ChFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                }

                if (flg == 6)
                {
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ChFlag == selectCondition.ChFlag &&
                             t1.ChStateFlag == selectCondition.ChStateFlag &&
                             t1.ChHidden.Contains(selectCondition.ChHidden)
                             select new
                             {
                                 t1.ChID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,

                                 t1.ChDate,
                                 t1.ChStateFlag,
                                 t1.ChFlag,
                                 t1.ChHidden,
                             };
                    foreach (var p in tb)
                    {
                        chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ChDate = p.ChDate,
                            ChStateFlag = p.ChStateFlag,
                            ChFlag = p.ChFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                }
                if (flg == 7)
                {
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                             t1.ChFlag == selectCondition.ChFlag &&
                             t1.ChStateFlag == selectCondition.ChStateFlag &&
                             t1.ChHidden.Contains(selectCondition.ChHidden)
                             select new
                             {
                                 t1.ChID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,

                                 t1.ChDate,
                                 t1.ChStateFlag,
                                 t1.ChFlag,
                                 t1.ChHidden,
                             };
                    foreach (var p in tb)
                    {
                        chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ChDate = p.ChDate,
                            ChStateFlag = p.ChStateFlag,
                            ChFlag = p.ChFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                }
                if (flg == 8)
                {
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ChFlag == selectCondition.ChFlag &&
                             t1.ChStateFlag == selectCondition.ChStateFlag &&
                             t1.ChHidden.Contains(selectCondition.ChHidden)
                             select new
                             {
                                 t1.ChID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,

                                 t1.ChDate,
                                 t1.ChStateFlag,
                                 t1.ChFlag,
                                 t1.ChHidden,
                             };
                    foreach (var p in tb)
                    {
                        chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ChDate = p.ChDate,
                            ChStateFlag = p.ChStateFlag,
                            ChFlag = p.ChFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                }

                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return chumon;
        }
        ///////////////////////////////
        //メソッド名：GetChumonDateData() オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致入荷データ
        //機　能   ：条件一致入荷データの取得
        /////////////////////////////// 
        public List<T_ChumonDsp> GetChumonDateData(int flg, T_ChumonDsp selectCondition, DateTime? startDay, DateTime? endDay)
        {
            List<T_ChumonDsp> chumon = new List<T_ChumonDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                if (flg == 1)
                {
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                              on t1.ClID equals t4.ClID
                             where
                             t1.ChID.ToString().Contains(selectCondition.ChID.ToString()) &&
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                             t1.ChDate >= startDay &&
                             t1.ChDate <= endDay &&

                              t1.ChFlag == selectCondition.ChFlag &&
                             t1.ChStateFlag == selectCondition.ChStateFlag &&
                             t1.ChHidden.Contains(selectCondition.ChHidden)
                             select new
                             {
                                 t1.ChID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,

                                 t1.ChDate,
                                 t1.ChStateFlag,
                                 t1.ChFlag,
                                 t1.ChHidden,
                             };
                    foreach (var p in tb)
                    {
                        chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ChDate = p.ChDate,
                            ChStateFlag = p.ChStateFlag,
                            ChFlag = p.ChFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                }
                if (flg == 2)
                {
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                              on t1.ClID equals t4.ClID
                             where
                             t1.ChID.ToString().Contains(selectCondition.ChID.ToString()) &&
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ChDate >= startDay &&
                             t1.ChDate <= endDay &&

                             t1.ChFlag == selectCondition.ChFlag &&
                             t1.ChStateFlag == selectCondition.ChStateFlag &&
                             t1.ChHidden.Contains(selectCondition.ChHidden)
                             select new
                             {
                                 t1.ChID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,

                                 t1.ChDate,
                                 t1.ChStateFlag,
                                 t1.ChFlag,
                                 t1.ChHidden,
                             };
                    foreach (var p in tb)
                    {
                        chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ChDate = p.ChDate,
                            ChStateFlag = p.ChStateFlag,
                            ChFlag = p.ChFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                }
                if (flg == 3)
                {
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                              on t1.ClID equals t4.ClID
                             where
                             t1.ChID.ToString().Contains(selectCondition.ChID.ToString()) &&
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                             t1.ChFlag == selectCondition.ChFlag &&
                             t1.ChStateFlag == selectCondition.ChStateFlag &&
                             t1.ChHidden.Contains(selectCondition.ChHidden)&&
                             t1.ChDate >= startDay &&
                             t1.ChDate <= endDay 
                             select new
                             {
                                 t1.ChID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,

                                 t1.ChDate,
                                 t1.ChStateFlag,
                                 t1.ChFlag,
                                 t1.ChHidden,
                             };
                    foreach (var p in tb)
                    {
                        chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ChDate = p.ChDate,
                            ChStateFlag = p.ChStateFlag,
                            ChFlag = p.ChFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                }
                if (flg == 4)
                {
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                              on t1.ClID equals t4.ClID
                             where
                             t1.ChID.ToString().Contains(selectCondition.ChID.ToString()) &&
                             t1.ChFlag == selectCondition.ChFlag &&
                             t1.ChStateFlag == selectCondition.ChStateFlag &&
                             t1.ChHidden.Contains(selectCondition.ChHidden)&&
                             t1.ChDate >= startDay &&
                             t1.ChDate <= endDay 
                             select new
                             {
                                 t1.ChID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,

                                 t1.ChDate,
                                 t1.ChStateFlag,
                                 t1.ChFlag,
                                 t1.ChHidden,
                             };
                    foreach (var p in tb)
                    {
                        chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ChDate = p.ChDate,
                            ChStateFlag = p.ChStateFlag,
                            ChFlag = p.ChFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                }
                if (flg == 5)
                {
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                             t1.ChFlag == selectCondition.ChFlag &&
                             t1.ChStateFlag == selectCondition.ChStateFlag &&
                             t1.ChHidden.Contains(selectCondition.ChHidden)&&
                             t1.ChDate >= startDay &&
                             t1.ChDate <= endDay 
                             select new
                             {
                                 t1.ChID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,

                                 t1.ChDate,
                                 t1.ChStateFlag,
                                 t1.ChFlag,
                                 t1.ChHidden,
                             };
                    foreach (var p in tb)
                    {
                        chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ChDate = p.ChDate,
                            ChStateFlag = p.ChStateFlag,
                            ChFlag = p.ChFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                }

                if (flg == 6)
                {
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                              on t1.ClID equals t4.ClID
                             where
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.ChFlag == selectCondition.ChFlag &&
                             t1.ChStateFlag == selectCondition.ChStateFlag &&
                             t1.ChHidden.Contains(selectCondition.ChHidden)&&
                             t1.ChDate >= startDay &&
                             t1.ChDate <= endDay 
                             select new
                             {
                                 t1.ChID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,

                                 t1.ChDate,
                                 t1.ChStateFlag,
                                 t1.ChFlag,
                                 t1.ChHidden,
                             };
                    foreach (var p in tb)
                    {
                        chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ChDate = p.ChDate,
                            ChStateFlag = p.ChStateFlag,
                            ChFlag = p.ChFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                }
                if (flg == 7)
                {
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                              on t1.ClID equals t4.ClID
                             where
                             t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                             t1.ChFlag == selectCondition.ChFlag &&
                             t1.ChStateFlag == selectCondition.ChStateFlag &&
                             t1.ChHidden.Contains(selectCondition.ChHidden)&&
                             t1.ChDate >= startDay &&
                             t1.ChDate <= endDay 
                             select new
                             {
                                 t1.ChID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,

                                 t1.ChDate,
                                 t1.ChStateFlag,
                                 t1.ChFlag,
                                 t1.ChHidden,
                             };
                    foreach (var p in tb)
                    {
                        chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ChDate = p.ChDate,
                            ChStateFlag = p.ChStateFlag,
                            ChFlag = p.ChFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                }
                if (flg == 8)
                {
                    var tb = from t1 in context.T_Chumons
                             join t2 in context.M_SalesOffices
                             on t1.SoID equals t2.SoID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID
                             join t4 in context.M_Clients
                              on t1.ClID equals t4.ClID
                             where
                             t1.ChFlag == selectCondition.ChFlag &&
                             t1.ChStateFlag == selectCondition.ChStateFlag &&
                             t1.ChHidden.Contains(selectCondition.ChHidden)&&
                             t1.ChDate >= startDay &&
                             t1.ChDate <= endDay 
                             select new
                             {
                                 t1.ChID,
                                 t1.OrID,
                                 t1.SoID,
                                 t2.SoName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.ClID,
                                 t4.ClName,

                                 t1.ChDate,
                                 t1.ChStateFlag,
                                 t1.ChFlag,
                                 t1.ChHidden,
                             };
                    foreach (var p in tb)
                    {
                        chumon.Add(new T_ChumonDsp()
                        {
                            ChID = p.ChID,
                            OrID = p.OrID,
                            SoID = p.SoID,
                            SoName = p.SoName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            ClID = p.ClID,
                            ClName = p.ClName,
                            ChDate = p.ChDate,
                            ChStateFlag = p.ChStateFlag,
                            ChFlag = p.ChFlag,
                            ChHidden = p.ChHidden
                        });
                    }
                }

                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return chumon;
        }

    }
}
