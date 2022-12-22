using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SalesManagement_SysDev
{
    class ShipmentDetailDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckShDetailIDExistence()
        //引　数   ：出荷詳細ID
        //戻り値   ：True or False
        //機　能   ：一致する出荷詳細IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckShDetailIDExistence(int shDetailID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                flg = context.T_ShipmentDetails.Any(x => x.ShDetailID == shDetailID);
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：AddShipmentDetailData()
        //引　数   ：出荷詳細データ
        //戻り値   ：True or False
        //機　能   ：出荷詳細データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddShipmentDetailData(T_ShipmentDetail regShipmentDetail)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_ShipmentDetails.Add(regShipmentDetail);
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
        //メソッド名：GetShIDDetailData()
        //引　数   :出荷ID
        //戻り値   :出荷IDの全詳細データ
        //機　能   ：同じ出荷ID全ての受注詳細情報
        /////////////////////////////////////////
        public List<T_ShipmentDetail> GetShIDDetailData(int shID)
        {
            List<T_ShipmentDetail> shipmentDetail = new List<T_ShipmentDetail>();

            try
            {
                var context = new SalesManagement_DevContext();

                shipmentDetail = context.T_ShipmentDetails.Where(x => x.ShID == shID).ToList();

                context.SaveChanges();
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return shipmentDetail;
        }
        ///////////////////////////////
        //メソッド名：GetArDetailData()
        //引　数   ：なし
        //戻り値   ：全出荷詳細データ
        //機　能   ：全出荷詳細データの取得
        ///////////////////////////////
        public List<T_ShipmentDetailDsp> GetArDetailData()
        {
            List<T_ShipmentDetailDsp> shDetail = new List<T_ShipmentDetailDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_ShipmentDetails
                         join t2 in context.T_Shipments
                         on t1.ShID equals t2.ShID
                         join t3 in context.M_Products
                         on t1.PrID equals t3.PrID
                         join t4 in context.T_OrderDetails
                         on t2.OrID equals t4.OrID
                         where t2.ShFlag == 0
                         select new
                         {
                             t1.ShID,
                             t1.ShDetailID,
                             t1.PrID,
                             t3.PrName,
                             t3.Price,
                             t1.ShDquantity,
                             t4.OrTotalPrice

                         };
                foreach (var p in tb)
                {
                    shDetail.Add(new T_ShipmentDetailDsp()
                    {
                        ShID = p.ShID,
                        ShDetailID = p.ShDetailID,
                        PrID = p.PrID,
                        PrName = p.PrName,
                        Price = p.Price,
                        ShDquantity = p.ShDquantity,
                        TotalPrice = p.OrTotalPrice
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return shDetail;
        }
        ///////////////////////////////
        //メソッド名：GetArDetailHiddenData()
        //引　数   ：なし
        //戻り値   ：全出荷非表示詳細データ
        //機　能   ：全出荷非表示詳細データの取得
        ///////////////////////////////
        public List<T_ShipmentDetailDsp> GetArDetailHiddenData()
        {
            List<T_ShipmentDetailDsp> shDetail = new List<T_ShipmentDetailDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_ShipmentDetails
                         join t2 in context.T_Shipments
                         on t1.ShID equals t2.ShID
                         join t3 in context.M_Products
                         on t1.PrID equals t3.PrID
                         join t4 in context.T_OrderDetails
                         on t2.OrID equals t4.OrID
                         where t2.ShFlag == 2
                         select new
                         {
                             t1.ShID,
                             t1.ShDetailID,
                             t1.PrID,
                             t3.PrName,
                             t3.Price,
                             t1.ShDquantity,
                             t4.OrTotalPrice

                         };
                foreach (var p in tb)
                {
                    shDetail.Add(new T_ShipmentDetailDsp()
                    {
                        ShID = p.ShID,
                        ShDetailID = p.ShDetailID,
                        PrID = p.PrID,
                        PrName = p.PrName,
                        Price = p.Price,
                        ShDquantity = p.ShDquantity,
                        TotalPrice = p.OrTotalPrice
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return shDetail;
        }
        ///////////////////////////////
        //メソッド名：GetArDetailData() オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致出荷詳細データ
        //機　能   ：条件一致出荷詳細データの取得
        ///////////////////////////////
        public List<T_ShipmentDetailDsp> GetShDetailData(int flg, T_ShipmentDetailDsp selectCondition)
        {
            List<T_ShipmentDetailDsp> shDetail = new List<T_ShipmentDetailDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                if (flg == 1)
                {
                    var tb = from t1 in context.T_ShipmentDetails
                             join t2 in context.T_Shipments
                             on t1.ShID equals t2.ShID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             join t4 in context.T_OrderDetails
                             on t2.OrID equals t4.OrID
                             where
                             t1.ShID.ToString().Contains(selectCondition.ShID.ToString()) &&
                             t1.ShDetailID.ToString().Contains(selectCondition.ShDetailID.ToString()) &&
                             t1.PrID.ToString().Contains(selectCondition.PrID.ToString()) &&
                             t2.ShFlag == 0
                             select new
                             {
                                 t1.ShID,
                                 t1.ShDetailID,
                                 t1.PrID,
                                 t3.PrName,
                                 t3.Price,
                                 t1.ShDquantity,
                                 t4.OrTotalPrice

                             };
                    foreach (var p in tb)
                    {
                        shDetail.Add(new T_ShipmentDetailDsp()
                        {
                            ShID = p.ShID,
                            ShDetailID = p.ShDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            ShDquantity = p.ShDquantity,
                            TotalPrice = p.OrTotalPrice
                        });
                    }

                }
                if (flg == 2)
                {
                    var tb = from t1 in context.T_ShipmentDetails
                             join t2 in context.T_Shipments
                             on t1.ShID equals t2.ShID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             join t4 in context.T_OrderDetails
                             on t2.OrID equals t4.OrID
                             where
                             t1.ShID.ToString().Contains(selectCondition.ShID.ToString()) &&
                             t1.ShDetailID.ToString().Contains(selectCondition.ShDetailID.ToString()) &&
                             t2.ShFlag == 0
                             select new
                             {
                                 t1.ShID,
                                 t1.ShDetailID,
                                 t1.PrID,
                                 t3.PrName,
                                 t3.Price,
                                 t1.ShDquantity,
                                 t4.OrTotalPrice

                             };
                    foreach (var p in tb)
                    {
                        shDetail.Add(new T_ShipmentDetailDsp()
                        {
                            ShID = p.ShID,
                            ShDetailID = p.ShDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            ShDquantity = p.ShDquantity,
                            TotalPrice = p.OrTotalPrice
                        });
                    }

                }
                if (flg == 3)
                {
                    var tb = from t1 in context.T_ShipmentDetails
                             join t2 in context.T_Shipments
                             on t1.ShID equals t2.ShID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             join t4 in context.T_OrderDetails
                             on t2.OrID equals t4.OrID
                             where
                              t1.ShID.ToString().Contains(selectCondition.ShID.ToString()) &&
                             t1.PrID.ToString().Contains(selectCondition.PrID.ToString()) &&
                             t2.ShFlag == 0
                             select new
                             {
                                 t1.ShID,
                                 t1.ShDetailID,
                                 t1.PrID,
                                 t3.PrName,
                                 t3.Price,
                                 t1.ShDquantity,
                                 t4.OrTotalPrice

                             };
                    foreach (var p in tb)
                    {
                        shDetail.Add(new T_ShipmentDetailDsp()
                        {
                            ShID = p.ShID,
                            ShDetailID = p.ShDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            ShDquantity = p.ShDquantity,
                            TotalPrice = p.OrTotalPrice
                        });
                    }

                }
                if (flg == 4)
                {
                    var tb = from t1 in context.T_ShipmentDetails
                             join t2 in context.T_Shipments
                             on t1.ShID equals t2.ShID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             join t4 in context.T_OrderDetails
                             on t2.OrID equals t4.OrID
                             where
                              t1.ShID.ToString().Contains(selectCondition.ShID.ToString()) &&
                              t2.ShFlag == 0
                             select new
                             {
                                 t1.ShID,
                                 t1.ShDetailID,
                                 t1.PrID,
                                 t3.PrName,
                                 t3.Price,
                                 t1.ShDquantity,
                                 t4.OrTotalPrice

                             };
                    foreach (var p in tb)
                    {
                        shDetail.Add(new T_ShipmentDetailDsp()
                        {
                            ShID = p.ShID,
                            ShDetailID = p.ShDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            ShDquantity = p.ShDquantity,
                            TotalPrice = p.OrTotalPrice
                        });
                    }

                }
                if (flg == 5)
                {
                    var tb = from t1 in context.T_ShipmentDetails
                             join t2 in context.T_Shipments
                             on t1.ShID equals t2.ShID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             join t4 in context.T_OrderDetails
                             on t2.OrID equals t4.OrID
                             where
                              t1.ShDetailID.ToString().Contains(selectCondition.ShDetailID.ToString()) &&
                             t1.PrID.ToString().Contains(selectCondition.PrID.ToString()) &&
                             t2.ShFlag == 0
                             select new
                             {
                                 t1.ShID,
                                 t1.ShDetailID,
                                 t1.PrID,
                                 t3.PrName,
                                 t3.Price,
                                 t1.ShDquantity,
                                 t4.OrTotalPrice

                             };
                    foreach (var p in tb)
                    {
                        shDetail.Add(new T_ShipmentDetailDsp()
                        {
                            ShID = p.ShID,
                            ShDetailID = p.ShDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            ShDquantity = p.ShDquantity,
                            TotalPrice = p.OrTotalPrice
                        });
                    }

                }
                if (flg == 6)
                {
                    var tb = from t1 in context.T_ShipmentDetails
                             join t2 in context.T_Shipments
                             on t1.ShID equals t2.ShID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             join t4 in context.T_OrderDetails
                             on t2.OrID equals t4.OrID
                             where
                              t1.ShDetailID.ToString().Contains(selectCondition.ShDetailID.ToString()) &&
                              t2.ShFlag == 0
                             select new
                             {
                                 t1.ShID,
                                 t1.ShDetailID,
                                 t1.PrID,
                                 t3.PrName,
                                 t3.Price,
                                 t1.ShDquantity,
                                 t4.OrTotalPrice

                             };
                    foreach (var p in tb)
                    {
                        shDetail.Add(new T_ShipmentDetailDsp()
                        {
                            ShID = p.ShID,
                            ShDetailID = p.ShDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            ShDquantity = p.ShDquantity,
                            TotalPrice = p.OrTotalPrice
                        });
                    }

                }
                if (flg == 7)
                {
                    var tb = from t1 in context.T_ShipmentDetails
                             join t2 in context.T_Shipments
                             on t1.ShID equals t2.ShID
                             join t3 in context.M_Products
                             on t1.PrID equals t3.PrID
                             join t4 in context.T_OrderDetails
                             on t2.OrID equals t4.OrID
                             where
                              t1.PrID.ToString().Contains(selectCondition.PrID.ToString()) &&
                             t2.ShFlag == 0
                             select new
                             {
                                 t1.ShID,
                                 t1.ShDetailID,
                                 t1.PrID,
                                 t3.PrName,
                                 t3.Price,
                                 t1.ShDquantity,
                                 t4.OrTotalPrice

                             };
                    foreach (var p in tb)
                    {
                        shDetail.Add(new T_ShipmentDetailDsp()
                        {
                            ShID = p.ShID,
                            ShDetailID = p.ShDetailID,
                            PrID = p.PrID,
                            PrName = p.PrName,
                            Price = p.Price,
                            ShDquantity = p.ShDquantity,
                            TotalPrice = p.OrTotalPrice
                        });
                    }

                }

                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return shDetail;

        }
        ///////////////////////////////
        //メソッド名：GetShIDDetailDspData()
        //引　数   ：なし
        //戻り値   ：出荷詳細データ
        //機　能   ：同じ出荷ID出荷詳細データの取得
        ///////////////////////////////
        public List<T_ShipmentDetailDsp> GetShIDDetailDspData(int shID)
        {
            List<T_ShipmentDetailDsp> ShDetail = new List<T_ShipmentDetailDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_ShipmentDetails
                         join t2 in context.T_Shipments
                         on t1.ShID equals t2.ShID
                         join t3 in context.M_Products
                         on t1.PrID equals t3.PrID
                         join t4 in context.T_OrderDetails
                         on t2.OrID equals t4.OrID
                         where t1.ShID == shID
                         select new
                         {
                             t1.ShID,
                             t1.ShDetailID,
                             t1.PrID,
                             t3.PrName,
                             t3.Price,
                             t1.ShDquantity,
                             t4.OrTotalPrice

                         };
                foreach (var p in tb)
                {
                    ShDetail.Add(new T_ShipmentDetailDsp()
                    {
                        ShID = p.ShID,
                        ShDetailID = p.ShDetailID,
                        PrID = p.PrID,
                        PrName = p.PrName,
                        Price = p.Price,
                        ShDquantity = p.ShDquantity,
                        TotalPrice = p.OrTotalPrice
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return ShDetail;
        }

    }
}
