using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class ChumonDetailDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckChDetailIDExistence()
        //引　数   ：注文詳細ID
        //戻り値   ：True or False
        //機　能   ：一致する注文詳細IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckChDetailIDExistence(int chDetailID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                //注文詳細IDで一致するデータが存在するか
                flg = context.T_ChumonDetails.Any(x => x.ChDetailID == chDetailID);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：AddChDetailData()
        //引　数   ：注文詳細データ
        //戻り値   ：True or False
        //機　能   ：注文詳細データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////

        public bool AddChDetailData(T_ChumonDetail regChDetail)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_ChumonDetails.Add(regChDetail);
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

        /////////////////////////////////////////
        //メソッド名：GetChIDDetailData()
        //引　数   注文ID
        //戻り値   :注文IDの全詳細データ
        //機　能   ：同じ注文ID全ての注文詳細情報
        /////////////////////////////////////////
        public List<T_ChumonDetail> GetChIDDetailData(int chID)
        {
            List<T_ChumonDetail> chumonDetail = new List<T_ChumonDetail>();

            try
            {
                var context = new SalesManagement_DevContext();

                chumonDetail = context.T_ChumonDetails.Where(x => x.ChID == chID).ToList();

                context.SaveChanges();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return chumonDetail;
        }

        ///////////////////////////////
        //メソッド名：GetChDetailData()
        //引　数   ：なし
        //戻り値   ：全注文詳細データ
        //機　能   ：全注文詳細データの取得
        ///////////////////////////////
        public List<T_ChumonDetailDsp> GetChDetailData()
        {
            List<T_ChumonDetailDsp> chDetail = new List<T_ChumonDetailDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_ChumonDetails
                         join t2 in context.T_Chumons
                         on t1.ChID equals t2.ChID
                         join t3 in context.M_Products
                          on t1.PrID equals t3.PrID
                         //join t4 in context.T_OrderDetails
                         //on t2.OrID equals t4.OrID
                         where t2.ChFlag == 0
                         select new
                         {
                             t1.ChID,
                             t1.ChDetailID,
                             t1.PrID,
                             t3.PrName,
                             t3.Price,
                             t1.ChQuantity,
                             ////t4.OrTotalPrice
                         };
                foreach (var p in tb)
                {
                    chDetail.Add(new T_ChumonDetailDsp()
                    {
                        ChID = p.ChID,
                        ChDetailID = p.ChDetailID,
                        PrID = p.PrID,
                        PrName = p.PrName,
                        Price = p.Price,
                        ChQuantity = p.ChQuantity,
                        TotalPrice = p.Price*p.ChQuantity,

                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return chDetail;
        }
        ///////////////////////////////
        //メソッド名：GetChDetailData() オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致注文詳細データ
        //機　能   ：条件一致注文詳細データの取得
        ///////////////////////////////
        public List<T_ChumonDetailDsp> GetChDetailData(int flg, T_ChumonDetailDsp selectCondition)
        {
            List<T_ChumonDetailDsp> chDetail = new List<T_ChumonDetailDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                if (flg == 1)
                {
                    var tb = from t1 in context.T_ChumonDetails
                             join t2 in context.T_Chumons
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             
                             where
                             t1.ChID.ToString().Contains(selectCondition.ChID.ToString()) &&
                             t1.ChDetailID.ToString().Contains(selectCondition.ChDetailID.ToString()) &&
                             t1.PrID.ToString().Contains(selectCondition.PrID.ToString()) &&

                             t2.ChFlag == 0
                             select new
                             {
                                 t1.ChID,
                                 t1.ChDetailID,
                                 t1.PrID,
                                 t3.PrName,
                                 t3.Price,
                                 t1.ChQuantity,
                                 //t4.OrTotalPrice
                             };
                    foreach (var p in tb)
                    {
                        chDetail.Add(new T_ChumonDetailDsp()
                        {
                            ChID = p.ChID,
                            ChDetailID = p.ChDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            ChQuantity = p.ChQuantity,
                            TotalPrice = p.Price*p.ChQuantity,
                        });
                    }
                }
                if (flg == 2)
                {
                    var tb = from t1 in context.T_ChumonDetails
                             join t2 in context.T_Chumons
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             
                             where
                             t1.ChID.ToString().Contains(selectCondition.ChID.ToString()) &&
                             t1.ChDetailID.ToString().Contains(selectCondition.ChDetailID.ToString()) &&
                             t2.ChFlag == 0
                             select new
                             {
                                 t1.ChID,
                                 t1.ChDetailID,
                                 t1.PrID,
                                 t3.PrName,
                                 t3.Price,
                                 t1.ChQuantity,
                                 //t4.OrTotalPrice
                             };
                    foreach (var p in tb)
                    {
                        chDetail.Add(new T_ChumonDetailDsp()
                        {
                            ChID = p.ChID,
                            ChDetailID = p.ChDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            ChQuantity = p.ChQuantity,
                            TotalPrice = p.Price*p.ChQuantity,
                        });
                    }
                }
                if (flg == 3)
                {
                    var tb = from t1 in context.T_ChumonDetails
                             join t2 in context.T_Chumons
                              on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             
                             where
                              t1.ChID.ToString().Contains(selectCondition.ChID.ToString()) &&
                              t1.PrID.ToString().Contains(selectCondition.PrID.ToString()) &&

                              t2.ChFlag == 0
                             select new
                             {
                                 t1.ChID,
                                 t1.ChDetailID,
                                 t1.PrID,
                                 t3.PrName,
                                 t3.Price,
                                 t1.ChQuantity,
                                 //t4.OrTotalPrice
                             };
                    foreach (var p in tb)
                    {
                        chDetail.Add(new T_ChumonDetailDsp()
                        {
                            ChID = p.ChID,
                            ChDetailID = p.ChDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            ChQuantity = p.ChQuantity,
                            TotalPrice = p.Price*p.ChQuantity,
                        });
                    }
                }
                if (flg == 4)
                {
                    var tb = from t1 in context.T_ChumonDetails
                             join t2 in context.T_Chumons
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             
                             where
                             t1.ChID.ToString().Contains(selectCondition.ChID.ToString()) &&
                             t2.ChFlag == 0
                             select new
                             {
                                 t1.ChID,
                                 t1.ChDetailID,
                                 t1.PrID,
                                 t3.PrName,
                                 t3.Price,
                                 t1.ChQuantity,
                                 //t4.OrTotalPrice
                             };
                    foreach (var p in tb)
                    {
                        chDetail.Add(new T_ChumonDetailDsp()
                        {
                            ChID = p.ChID,
                            ChDetailID = p.ChDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            ChQuantity = p.ChQuantity,
                            TotalPrice = p.Price*p.ChQuantity,
                        });
                    }
                }
                if (flg == 5)
                {
                    var tb = from t1 in context.T_ChumonDetails
                             join t2 in context.T_Chumons
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             
                             where
                             t1.ChDetailID.ToString().Contains(selectCondition.ChDetailID.ToString()) &&
                             t1.PrID.ToString().Contains(selectCondition.PrID.ToString()) &&
                             t2.ChFlag == 0
                             select new
                             {
                                 t1.ChID,
                                 t1.ChDetailID,
                                 t1.PrID,
                                 t3.PrName,
                                 t3.Price,
                                 t1.ChQuantity,
                                 //t4.OrTotalPrice
                             };
                    foreach (var p in tb)
                    {
                        chDetail.Add(new T_ChumonDetailDsp()
                        {
                            ChID = p.ChID,
                            ChDetailID = p.ChDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            ChQuantity = p.ChQuantity,
                            TotalPrice = p.Price*p.ChQuantity,
                        });
                    }
                }
                if (flg == 6)
                {
                    var tb = from t1 in context.T_ChumonDetails
                             join t2 in context.T_Chumons
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                            
                             where
                             t1.ChDetailID.ToString().Contains(selectCondition.ChID.ToString()) &&
                             t2.ChFlag == 0
                             select new
                             {
                                 t1.ChID,
                                 t1.ChDetailID,
                                 t1.PrID,
                                 t3.PrName,
                                 t3.Price,
                                 t1.ChQuantity,
                                 //t4.OrTotalPrice
                             };
                    foreach (var p in tb)
                    {
                        chDetail.Add(new T_ChumonDetailDsp()
                        {
                            ChID = p.ChID,
                            ChDetailID = p.ChDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            ChQuantity = p.ChQuantity,
                            TotalPrice = p.Price*p.ChQuantity
                        });
                    }
                }
                if (flg == 7)
                {
                    var tb = from t1 in context.T_ChumonDetails
                             join t2 in context.T_Chumons
                             on t1.ChID equals t2.ChID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             
                             where
                             t1.PrID.ToString().Contains(selectCondition.PrID.ToString()) &&
                             t2.ChFlag == 0
                             select new
                             {
                                 t1.ChID,
                                 t1.ChDetailID,
                                 t1.PrID,
                                 t3.PrName,
                                 t3.Price,
                                 t1.ChQuantity,
                                 //t4.OrTotalPrice
                             };
                    foreach (var p in tb)
                    {
                        chDetail.Add(new T_ChumonDetailDsp()
                        {
                            ChID = p.ChID,
                            ChDetailID = p.ChDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            ChQuantity = p.ChQuantity,
                            TotalPrice = p.Price*p.ChQuantity,
                        });
                    }
                }

                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return chDetail;
        }
        ///////////////////////////////
        //メソッド名：GetChIDDetailDspData()
        //引　数   ：なし
        //戻り値   ：同じ注文IDのデータグリッド詳細データ
        //機　能   ：同じ注文IDのデータグリッド表示用詳細データの取得
        ///////////////////////////////
        public List<T_ChumonDetailDsp> GetChIDDetailDspData(int chID)
        {
            List<T_ChumonDetailDsp> chDetail = new List<T_ChumonDetailDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_ChumonDetails
                         join t2 in context.T_Chumons
                         on t1.ChID equals t2.ChID
                         join t3 in context.M_Products
                          on t1.PrID equals t3.PrID
                         
                         where t1.ChID==chID && t2.ChFlag == 0
                         select new
                         {
                             t1.ChID,
                             t1.ChDetailID,
                             t1.PrID,
                             t3.PrName,
                             t3.Price,
                             t1.ChQuantity,
                             
                         };
                foreach (var p in tb)
                {
                    chDetail.Add(new T_ChumonDetailDsp()
                    {
                        ChID = p.ChID,
                        ChDetailID = p.ChDetailID,
                        PrID = p.PrID,
                        PrName = p.PrName,
                        Price = p.Price,
                        ChQuantity = p.ChQuantity,
                        TotalPrice = p.Price * p.ChQuantity,

                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return chDetail;
        }

    }
}
