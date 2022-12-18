using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SalesManagement_SysDev
{
    class OrderDetailDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckOrDetailIDExistence()
        //引　数   ：受注詳細ID
        //戻り値   ：True or False
        //機　能   ：一致する受注詳細IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckOrDetailIDExistence(int orDetailID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                //受注詳細IDで一致するデータが存在するか
                flg = context.T_OrderDetails.Any(x => x.OrDetailID == orDetailID);
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：AddOrderDetailData()
        //引　数   ：受注詳細データ
        //戻り値   ：True or False
        //機　能   ：受注詳細データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddOrderDetailData(T_OrderDetail regOrderDetail)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_OrderDetails.Add(regOrderDetail);
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
        //メソッド名：GetOrIDDetailData()
        //引　数   :受注ID
        //戻り値   ：確定用受注詳細データ
        //機　能   ：同じ受注ID全ての受注詳細情報
        /////////////////////////////////////////
        public List<T_OrderDetail> GetOrIDDetailData(int orID)
        {
            List<T_OrderDetail> orderDetail = new List<T_OrderDetail>();

            try
            {
                var context = new SalesManagement_DevContext();

                orderDetail = context.T_OrderDetails.Where(x => x.OrID == orID).ToList();

                context.SaveChanges();
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return orderDetail;
        }
        ///////////////////////////////
        //メソッド名：UpdateOrderDetailData()
        //引　数   :受注詳細データ
        //戻り値   ：True or False
        //機　能   ：受注詳細データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateOrderDetailData(T_OrderDetail updOrderDetail)
        {
            try
            {
                var context = new SalesManagement_DevContext();

                var OrderDetail = context.T_OrderDetails.Single(x => x.OrDetailID == updOrderDetail.OrDetailID);
                OrderDetail.OrID = updOrderDetail.OrID;
                OrderDetail.PrID = updOrderDetail.PrID;
                OrderDetail.OrQuantity = updOrderDetail.OrQuantity;
                OrderDetail.OrTotalPrice = updOrderDetail.OrTotalPrice;




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
        //メソッド名：DeleteDetailData()
        //引　数   ：受注詳細データ
        //戻り値   ：True or False
        //機　能   ：受注詳細データの削除
        //          ：削除成功の場合True
        //          ：削除失敗の場合False
        ///////////////////////////////
        public bool DeleteOrDetailData(int delOrDetailID)
        {
            try
            {

                var context = new SalesManagement_DevContext();
                var OrDetail = context.T_OrderDetails.Single(x => x.OrDetailID == delOrDetailID);
                context.T_OrderDetails.Remove(OrDetail);
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
        //メソッド名：GetOrDetailData()
        //引　数   ：なし
        //戻り値   ：全受注詳細データ
        //機　能   ：全受注詳細データの取得
        ///////////////////////////////
        public List<T_OrderDetailDsp> GetOrDetailData()
        {
            List<T_OrderDetailDsp> orDetail = new List<T_OrderDetailDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_OrderDetails
                         join t2 in context.T_Orders
                         on t1.OrID equals t2.OrID
                         join t3 in context.M_Products
                         on t1.PrID equals t3.PrID
                         where t2.OrFlag == 0
                         select new
                         {
                             t1.OrID,
                             t1.OrDetailID,
                             t1.PrID,
                             t3.PrName,
                             t3.Price,
                             t1.OrQuantity,
                             t1.OrTotalPrice,
                         };
                foreach (var p in tb)
                {
                    orDetail.Add(new T_OrderDetailDsp()
                    {
                        OrID = p.OrID,
                        OrDetailID = p.OrDetailID,
                        PrID = p.PrID,
                        PrName = p.PrName,
                        Price = p.Price,
                        OrQuantity = p.OrQuantity,
                        OrTotalPrice = p.OrTotalPrice,


                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return orDetail;
        }
        ///////////////////////////////
        //メソッド名：GetOrIDDetailDspData()
        //引　数   ：受注ID
        //戻り値   ：同じ受注IDのデータグリッド詳細データ
        //機　能   ：同じ受注IDのデータグリッド表示用詳細データの取得
        ///////////////////////////////
        public List<T_OrderDetailDsp> GetOrIDDetailDspData(int orID)
        {
            List<T_OrderDetailDsp> orDetail = new List<T_OrderDetailDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_OrderDetails
                         join t2 in context.T_Orders
                         on t1.OrID equals t2.OrID
                         join t3 in context.M_Products
                         on t1.PrID equals t3.PrID
                         where t1.OrID == orID 
                         select new
                         {
                             t1.OrID,
                             t1.OrDetailID,
                             t1.PrID,
                             t3.PrName,
                             t3.Price,
                             t1.OrQuantity,
                             t1.OrTotalPrice,
                         };
                foreach (var p in tb)
                {
                    orDetail.Add(new T_OrderDetailDsp()
                    {
                        OrID = p.OrID,
                        OrDetailID = p.OrDetailID,
                        PrID = p.PrID,
                        PrName = p.PrName,
                        Price = p.Price,
                        OrQuantity = p.OrQuantity,
                        OrTotalPrice = p.OrTotalPrice,


                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return orDetail;
        }
        ///////////////////////////////
        //メソッド名：GetOrDetailData() オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致受注詳細データ
        //機　能   ：条件一致受注詳細データの取得
        ///////////////////////////////
        public List<T_OrderDetailDsp> GetOrDetailData(int flg, T_OrderDetailDsp selectCondition)
        {
            List<T_OrderDetailDsp> orDetail = new List<T_OrderDetailDsp>();

            try
            {

                var context = new SalesManagement_DevContext();
                if (flg == 1)
                {
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.M_Products
                             on t1.PrID equals t2.PrID

                             where
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.OrDetailID.ToString().Contains(selectCondition.OrDetailID.ToString()) &&
                             t1.PrID.ToString().Contains(selectCondition.PrID.ToString())

                             select new
                             {
                                 t1.OrID,
                                 t1.OrDetailID,
                                 t1.PrID,
                                 t2.PrName,
                                 t2.Price,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice

                             };
                    foreach (var p in tb)
                    {
                        orDetail.Add(new T_OrderDetailDsp()
                        {
                            OrID = p.OrID,
                            OrDetailID = p.OrDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice

                        });
                    }

                }
                if (flg == 2)
                {
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.M_Products
                             on t1.PrID equals t2.PrID

                             where
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.OrDetailID.ToString().Contains(selectCondition.OrDetailID.ToString())

                             select new
                             {
                                 t1.OrID,
                                 t1.OrDetailID,
                                 t1.PrID,
                                 t2.PrName,
                                 t2.Price,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice

                             };
                    foreach (var p in tb)
                    {
                        orDetail.Add(new T_OrderDetailDsp()
                        {
                            OrID = p.OrID,
                            OrDetailID = p.OrDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice

                        });
                    }

                }
                if (flg == 3)
                {
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.M_Products
                             on t1.PrID equals t2.PrID

                             where
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString()) &&
                             t1.PrID.ToString().Contains(selectCondition.PrID.ToString())

                             select new
                             {
                                 t1.OrID,
                                 t1.OrDetailID,
                                 t1.PrID,
                                 t2.PrName,
                                 t2.Price,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice

                             };
                    foreach (var p in tb)
                    {
                        orDetail.Add(new T_OrderDetailDsp()
                        {
                            OrID = p.OrID,
                            OrDetailID = p.OrDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice

                        });
                    }

                }
                if (flg == 4)
                {
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.M_Products
                             on t1.PrID equals t2.PrID

                             where
                             t1.OrID.ToString().Contains(selectCondition.OrID.ToString())


                             select new
                             {
                                 t1.OrID,
                                 t1.OrDetailID,
                                 t1.PrID,
                                 t2.PrName,
                                 t2.Price,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice

                             };
                    foreach (var p in tb)
                    {
                        orDetail.Add(new T_OrderDetailDsp()
                        {
                            OrID = p.OrID,
                            OrDetailID = p.OrDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice

                        });
                    }

                }
                if (flg == 5)
                {
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.M_Products
                             on t1.PrID equals t2.PrID

                             where
                             t1.OrDetailID.ToString().Contains(selectCondition.OrDetailID.ToString()) &&
                             t1.PrID.ToString().Contains(selectCondition.PrID.ToString())

                             select new
                             {
                                 t1.OrID,
                                 t1.OrDetailID,
                                 t1.PrID,
                                 t2.PrName,
                                 t2.Price,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice

                             };
                    foreach (var p in tb)
                    {
                        orDetail.Add(new T_OrderDetailDsp()
                        {
                            OrID = p.OrID,
                            OrDetailID = p.OrDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice

                        });
                    }

                }
                if (flg == 6)
                {
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.M_Products
                             on t1.PrID equals t2.PrID

                             where
                             t1.OrDetailID.ToString().Contains(selectCondition.OrDetailID.ToString())

                             select new
                             {
                                 t1.OrID,
                                 t1.OrDetailID,
                                 t1.PrID,
                                 t2.PrName,
                                 t2.Price,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice

                             };
                    foreach (var p in tb)
                    {
                        orDetail.Add(new T_OrderDetailDsp()
                        {
                            OrID = p.OrID,
                            OrDetailID = p.OrDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice

                        });
                    }

                }
                if (flg == 7)
                {
                    var tb = from t1 in context.T_OrderDetails
                             join t2 in context.M_Products
                             on t1.PrID equals t2.PrID

                             where
                             t1.PrID.ToString().Contains(selectCondition.PrID.ToString())

                             select new
                             {
                                 t1.OrID,
                                 t1.OrDetailID,
                                 t1.PrID,
                                 t2.PrName,
                                 t2.Price,
                                 t1.OrQuantity,
                                 t1.OrTotalPrice

                             };
                    foreach (var p in tb)
                    {
                        orDetail.Add(new T_OrderDetailDsp()
                        {
                            OrID = p.OrID,
                            OrDetailID = p.OrDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            OrQuantity = p.OrQuantity,
                            OrTotalPrice = p.OrTotalPrice

                        });
                    }

                }

                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return orDetail;

        }

    }
}
