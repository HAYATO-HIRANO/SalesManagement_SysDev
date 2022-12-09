using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev.DbAccess
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

                Order.OrID = updShipment.OrID;
                Order.SoID = updShipment.SoID;
                Order.EmID = updShipment.EmID;
                Order.ClID = updShipment.ClID;
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
        //メソッド名：GetArIDData()
        //引　数   :出荷ID
        //戻り値   ：入荷IDの出荷データ
        //機　能   ：入荷IDの出荷情報取得
        ///////////////////////////////
        public T_Shipment GetArIDdata(int orID)
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
    }

}