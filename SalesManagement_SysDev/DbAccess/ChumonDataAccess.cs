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
        //メソッド名：AddChumonData()
        //引　数   ：注文データ
        //戻り値   ：True or False
        //機　能   ：受注データの登録
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
        //メソッド名：AddChumonDetailData()
        //引　数   ：注文詳細データ
        //戻り値   ：True or False
        //機　能   ：注文詳細データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddChumonDetailData(T_ChumonDetail regChumonDetail)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_ChumonDetails.Add(regChumonDetail);
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
        //メソッド名：UpdateChumonData()
        //引　数   :注文データ
        //戻り値   ：True or False
        //機　能   ：注文データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateChumonData(T_Chumon updChumon)
        {
            try
            {
                var context = new SalesManagement_DevContext();

                var Order = context.T_Chumons.Single(x => x.ChID == updChumon.ChID);
                Order.SoID = updChumon.SoID;
                Order.EmID = updChumon.EmID;
                Order.ClID = updChumon.ClID;
                Order.OrID = updChumon.OrID;
                Order.ChDate = updChumon.ChDate;
                Order.ChStateFlag = updChumon.ChStateFlag;
                Order.ChFlag = updChumon.ChFlag;
                Order.ChHidden = updChumon.ChHidden;


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
        //引　数   :注文ID
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
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID
                         where t1.ChFlag != 2
                         select new
                         {
                             t1.ChID,
                             t1.SoID,
                             t2.SoName,
                             t1.ClID,
                             t4.ClName,
                             t1.OrID,
                             t1.ChDate,
                             t1.ChStateFlag,
                             t1.ChFlag,
                             t1.ChHidden,
                         };
                foreach (var p in tb)
                {
                    chumon.Add(new T_ChumonDsp()
                    {
                        ChID=p.ChID,
                        SoID = p.SoID,
                        SoName = p.SoName,
                        ClID = p.ClID,
                        ClName = p.ClName,
                        OrID = p.OrID,
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
        //メソッド名：GetChumonData()
        //引　数   ：検索条件
        //戻り値   ：条件一致注文データ
        //機　能   ：条件一致注文データの取得
        ///////////////////////////////
        public List<T_ChumonDsp> GetChumonData(T_ChumonDsp selectCondition)
        {
            List<T_ChumonDsp> chumon = new List<T_ChumonDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_Chumons
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID
                         where
                         t1.ChID==selectCondition.ChID &&
                         t1.SoID == selectCondition.SoID &&
                         t1.EmID == selectCondition.EmID &&
                         t1.ClID == selectCondition.ClID &&
                         t1.OrID == selectCondition.OrID &&
                         t1.ChDate == selectCondition.ChDate &&
                         t1.ChFlag != 2
                         select new
                         {
                             t1.ChID,
                             t1.SoID,
                             t2.SoName,
                             t1.ClID,
                             t4.ClName,
                             t1.OrID,
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
                        SoID = p.SoID,
                        SoName = p.SoName,
                        ClID = p.ClID,
                        ClName = p.ClName,
                        OrID = p.OrID,
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
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ChID == selectCondition.ChID &&
                             t1.ClID == selectCondition.ClID &&
                             t1.OrID == selectCondition.OrID &&
                             t1.ChDate == selectCondition.ChDate &&
                             t1.ChFlag != 2
                             select new
                             {
                                 t1.ChID,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.OrID,
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
                            ClID = p.ClID,
                            ClName = p.ClName,
                            OrID = p.OrID,
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
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ChID == selectCondition.ChID &&
                             t1.ClID == selectCondition.ClID &&
                             //t1.OrID == selectCondition.OrID &&
                             t1.ChDate == selectCondition.ChDate &&
                             t1.ChFlag != 2
                             select new
                             {
                                 t1.ChID,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.OrID,
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
                            ClID = p.ClID,
                            ClName = p.ClName,
                            OrID = p.OrID,
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
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ChID == selectCondition.ChID &&
                             //t1.ClID == selectCondition.ClID &&
                             t1.OrID == selectCondition.OrID &&
                             t1.ChDate == selectCondition.ChDate &&
                             t1.ChFlag != 2
                             select new
                             {
                                 t1.ChID,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.OrID,
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
                            ClID = p.ClID,
                            ClName = p.ClName,
                            OrID = p.OrID,
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
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ChID == selectCondition.ChID &&
                             //t1.ClID == selectCondition.ClID &&
                             //t1.OrID == selectCondition.OrID &&
                             t1.ChDate == selectCondition.ChDate &&
                             t1.ChFlag != 2
                             select new
                             {
                                 t1.ChID,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.OrID,
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
                            ClID = p.ClID,
                            ClName = p.ClName,
                            OrID = p.OrID,
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
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             //t1.ChID == selectCondition.ChID &&
                             t1.ClID == selectCondition.ClID &&
                             t1.OrID == selectCondition.OrID &&
                             t1.ChDate == selectCondition.ChDate &&
                             t1.ChFlag != 2
                             select new
                             {
                                 t1.ChID,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.OrID,
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
                            ClID = p.ClID,
                            ClName = p.ClName,
                            OrID = p.OrID,
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
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             //t1.ChID == selectCondition.ChID &&
                             t1.ClID == selectCondition.ClID &&
                             //t1.OrID == selectCondition.OrID &&
                             t1.ChDate == selectCondition.ChDate &&
                             t1.ChFlag != 2
                             select new
                             {
                                 t1.ChID,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.OrID,
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
                            ClID = p.ClID,
                            ClName = p.ClName,
                            OrID = p.OrID,
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
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             //t1.ChID == selectCondition.ChID &&
                             //t1.ClID == selectCondition.ClID &&
                             t1.OrID == selectCondition.OrID &&
                             t1.ChDate == selectCondition.ChDate &&
                             t1.ChFlag != 2
                             select new
                             {
                                 t1.ChID,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.OrID,
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
                            ClID = p.ClID,
                            ClName = p.ClName,
                            OrID = p.OrID,
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
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             //t1.ChID == selectCondition.ChID &&
                             //t1.ClID == selectCondition.ClID &&
                             //t1.OrID == selectCondition.OrID &&
                             t1.ChDate == selectCondition.ChDate &&
                             t1.ChFlag != 2
                             select new
                             {
                                 t1.ChID,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.OrID,
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
                            ClID = p.ClID,
                            ClName = p.ClName,
                            OrID = p.OrID,
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
        //メソッド名：GetOrderDateData() オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致注文データ
        //機　能   ：条件一致注文データの取得
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
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ChID == selectCondition.ChID &&
                             t1.ClID == selectCondition.ClID &&
                             t1.OrID == selectCondition.OrID &&
                             t1.ChDate == selectCondition.ChDate &&
                             t1.ChFlag != 2
                             select new
                             {
                                 t1.ChID,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.OrID,
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
                            ClID = p.ClID,
                            ClName = p.ClName,
                            OrID = p.OrID,
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
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ChID == selectCondition.ChID &&
                             t1.ClID == selectCondition.ClID &&
                             //t1.OrID == selectCondition.OrID &&
                             t1.ChDate == selectCondition.ChDate &&
                             t1.ChFlag != 2
                             select new
                             {
                                 t1.ChID,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.OrID,
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
                            ClID = p.ClID,
                            ClName = p.ClName,
                            OrID = p.OrID,
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
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ChID == selectCondition.ChID &&
                             //t1.ClID == selectCondition.ClID &&
                             t1.OrID == selectCondition.OrID &&
                             t1.ChDate == selectCondition.ChDate &&
                             t1.ChFlag != 2
                             select new
                             {
                                 t1.ChID,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.OrID,
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
                            ClID = p.ClID,
                            ClName = p.ClName,
                            OrID = p.OrID,
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
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             t1.ChID == selectCondition.ChID &&
                             //t1.ClID == selectCondition.ClID &&
                             //t1.OrID == selectCondition.OrID &&
                             t1.ChDate == selectCondition.ChDate &&
                             t1.ChFlag != 2
                             select new
                             {
                                 t1.ChID,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.OrID,
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
                            ClID = p.ClID,
                            ClName = p.ClName,
                            OrID = p.OrID,
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
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             //t1.ChID == selectCondition.ChID &&
                             t1.ClID == selectCondition.ClID &&
                             t1.OrID == selectCondition.OrID &&
                             t1.ChDate == selectCondition.ChDate &&
                             t1.ChFlag != 2
                             select new
                             {
                                 t1.ChID,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.OrID,
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
                            ClID = p.ClID,
                            ClName = p.ClName,
                            OrID = p.OrID,
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
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             //t1.ChID == selectCondition.ChID &&
                             t1.ClID == selectCondition.ClID &&
                             //t1.OrID == selectCondition.OrID &&
                             t1.ChDate == selectCondition.ChDate &&
                             t1.ChFlag != 2
                             select new
                             {
                                 t1.ChID,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.OrID,
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
                            ClID = p.ClID,
                            ClName = p.ClName,
                            OrID = p.OrID,
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
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             //t1.ChID == selectCondition.ChID &&
                             //t1.ClID == selectCondition.ClID &&
                             t1.OrID == selectCondition.OrID &&
                             t1.ChDate == selectCondition.ChDate &&
                             t1.ChFlag != 2
                             select new
                             {
                                 t1.ChID,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.OrID,
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
                            ClID = p.ClID,
                            ClName = p.ClName,
                            OrID = p.OrID,
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
                             join t4 in context.M_Clients
                             on t1.ClID equals t4.ClID
                             where
                             //t1.ChID == selectCondition.ChID &&
                             //t1.ClID == selectCondition.ClID &&
                             //t1.OrID == selectCondition.OrID &&
                             t1.ChDate == selectCondition.ChDate &&
                             t1.ChFlag != 2
                             select new
                             {
                                 t1.ChID,
                                 t1.ClID,
                                 t4.ClName,
                                 t1.OrID,
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
                            ClID = p.ClID,
                            ClName = p.ClName,
                            OrID = p.OrID,
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
        //メソッド名：GetChumonHiddenData()
        //引　数   ：なし
        //戻り値   ：全非表示データ
        //機　能   ：全非表示データの取得
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
                             t1.SoID,
                             t2.SoName,
                             t1.EmID,
                             t3.EmName,
                             t1.ClID,
                             t4.ClName,
                             t1.OrID,
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
                        SoID = p.SoID,
                        SoName = p.SoName,
                        EmID = p.EmID,
                        EmName = p.EmName,
                        ClID = p.ClID,
                        ClName = p.ClName,
                        OrID = p.OrID,
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

    }
}
