using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class ShipmentDataAccess
    {
        ///////////////////////////////
        //メソッド名：AddShipmentData()
        //引　数   ：出荷データ
        //戻り値   ：True or False
        //機　能   ：受注データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddShipmentData(T_Shipment regShipment)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_Shipments.Add(regShipment);
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
        //メソッド名：UpdateShipmentData()
        //引　数   :出荷データ
        //戻り値   ：True or False
        //機　能   ：出荷データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateShipmentData(T_Shipment updShipment)
        {
            try
            {
                var context = new SalesManagement_DevContext();

                var Order = context.T_Shipments.Single(x => x.ShID == updShipment.ShID);
                
                Order.SoID = updShipment.SoID;
                Order.EmID = updShipment.EmID;
                Order.ClID = updShipment.ClID;
                Order.OrID = updShipment.OrID;
                Order.ShFinishDate = updShipment.ShFinishDate;
                Order.ShStateFlag = updShipment.ShStateFlag;
                Order.ShFlag = updShipment.ShFlag;
                Order.ShHidden = updShipment.ShHidden;


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
        //メソッド名：GetShIDData()
        //引　数   :出荷ID
        //戻り値   ：入荷IDの出荷データ
        //機　能   ：入荷IDの出荷情報取得
        ///////////////////////////////
        public T_Shipment GetShIDData(int ShID)
        {
            T_Shipment shipment = new T_Shipment();

            try
            {
                var context = new SalesManagement_DevContext();

                shipment = context.T_Shipments.Single(x => x.ShID == ShID && x.ShFlag == 0);

                context.SaveChanges();
                context.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return shipment;
        }
        ///////////////////////////////
        //メソッド名：GetOrIDData()
        //引　数   :受注ID
        //戻り値   ：受注IDの出荷データ
        //機　能   ：受注IDの出荷情報取得
        ///////////////////////////////
        public T_Shipment GetOrIDData(int orID)
        {
            T_Shipment shipment = new T_Shipment();

            try
            {
                var context = new SalesManagement_DevContext();

                shipment = context.T_Shipments.Single(x => x.OrID == orID && x.ShFlag == 0);

                context.SaveChanges();
                context.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return shipment;
        }

        ///////////////////////////////
        //メソッド名：GetShipmentnData()
        //引　数   ：なし
        //戻り値   ：全出荷データ
        //機　能   ：全出荷データの取得
        ///////////////////////////////
        public List<T_ShipmentDsp> GetShipmentData()
        {
            List<T_ShipmentDsp> shipment = new List<T_ShipmentDsp>();
            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_Shipments
                         join t2 in context.M_Clients
                         on t1.ClID equals t2.ClID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_SalesOffices
                         on t1.SoID equals t4.SoID
                         where t1.ShFlag != 2
                         select new
                         {
                             t1.ShID,
                             t1.SoID,
                             t4.SoName,
                             t1.EmID,
                             t3.EmName,
                             t1.ClID,
                             t2.ClName,
                             t1.OrID,
                             t1.ShFinishDate,
                             t1.ShStateFlag,
                             t1.ShFlag,
                             t1.ShHidden,
                         };
                foreach (var p in tb)
                {
                    shipment.Add(new T_ShipmentDsp()
                    {
                        ShID = p.ShID,
                        SoID = p.SoID,
                        SoName = p.SoName,
                        EmID = p.EmID,
                        EmName = p.EmName,
                        ClID = p.ClID,
                        ClName = p.ClName,
                        OrID = p.OrID,
                        ShDate = p.ShFinishDate,
                        ShStateFlag = p.ShStateFlag,
                        ShFlag = p.ShFlag,
                        ShHidden = p.ShHidden
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return shipment;
        }

        ///////////////////////////////
        //メソッド名：GetShipmentData()
        //引　数   ：検索条件
        //戻り値   ：条件一致出荷データ
        //機　能   ：条件一致出荷データの取得
        ///////////////////////////////
        public List<T_ShipmentDsp> GetShipmentData(T_ShipmentDsp selectCondition)
        {
            List<T_ShipmentDsp> shipment = new List<T_ShipmentDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_Shipments
                         join t2 in context.M_Clients
                         on t1.ClID equals t2.ClID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_SalesOffices
                         on t1.SoID equals t4.SoID
                         where
                          t1.ShID == selectCondition.ShID &&
                         t1.SoID == selectCondition.SoID &&
                         t1.EmID == selectCondition.EmID &&
                         t1.ClID == selectCondition.ClID &&
                         t1.OrID == selectCondition.OrID &&
                         t1.ShFinishDate == selectCondition.ShDate &&
                         t1.ShFlag != 2
                         select new
                         {
                             t1.ShID,
                             t1.SoID,
                             t4.SoName,
                             t1.EmID,
                             t3.EmName,
                             t1.ClID,
                             t2.ClName,
                             t1.OrID,
                             t1.ShFinishDate,
                             t1.ShStateFlag,
                             t1.ShFlag,
                             t1.ShHidden,
                         };
                foreach (var p in tb)
                {
                    shipment.Add(new T_ShipmentDsp()
                    {
                        ShID = p.ShID,
                        SoID = p.SoID,
                        SoName = p.SoName,
                        EmID = p.EmID,
                        EmName = p.EmName,
                        ClID = p.ClID,
                        ClName = p.ClName,
                        OrID = p.OrID,
                        ShDate = p.ShFinishDate,
                        ShStateFlag = p.ShStateFlag,
                        ShFlag = p.ShFlag,
                        ShHidden = p.ShHidden
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return shipment;
        }

        ///////////////////////////////
        //メソッド名：GetShipmentHiddenData()
        //引　数   ：なし
        //戻り値   ：全非表示データ
        //機　能   ：全非表示データの取得
        public List<T_ShipmentDsp> GetShipmentHiddenData(T_ShipmentDsp selectCondition)
        {
            List<T_ShipmentDsp> shipment = new List<T_ShipmentDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_Shipments
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID
                         where t1.ShFlag == 2
                         select new
                         {
                             t1.ShID,
                             t1.SoID,
                             t2.SoName,
                             t1.EmID,
                             t3.EmName,
                             t1.ClID,
                             t4.ClName,
                             t1.OrID,
                             t1.ShFinishDate,
                             t1.ShStateFlag,
                             t1.ShFlag,
                             t1.ShHidden,
                         };
                foreach (var p in tb)
                {
                    shipment.Add(new T_ShipmentDsp()
                    {
                        ShID = p.ShID,
                        SoID = p.SoID,
                        SoName = p.SoName,
                        EmID = p.EmID,
                        EmName = p.EmName,
                        ClID = p.ClID,
                        ClName = p.ClName,
                        OrID = p.OrID,
                        ShDate = p.ShFinishDate,
                        ShStateFlag = p.ShStateFlag,
                        ShFlag = p.ShFlag,
                        ShHidden = p.ShHidden
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return shipment;
        }


    }

}

