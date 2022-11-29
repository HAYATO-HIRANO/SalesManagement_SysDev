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

        ///////////////////////////////
        //メソッド名：UpdateOrderData()
        //引　数   :受注データ
        //戻り値   ：True or False
        //機　能   ：受注データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateOrderData(T_Order updOrder)
        {
            try
            {
                var context = new SalesManagement_DevContext();

                var Order = context.T_Orders.Single(x => x.OrID == updOrder.OrID);
                Order.SoID = updOrder.SoID;
                Order.EmID = updOrder.EmID;
                Order.ClID = updOrder.ClID;
                Order.ClCharge = updOrder.ClCharge;
                Order.OrDate = updOrder.OrDate;
                Order.OrStateFlag = updOrder.OrStateFlag;
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
        //メソッド名：GetOrderData()
        //引　数   ：なし
        //戻り値   ：全受注データ
        //機　能   ：全受注データの取得
        ///////////////////////////////
        public List<T_OrderDsp>GetOrderData()
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
                         where t1.OrFlag==0
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
                foreach(var p in tb)
                {
                    order.Add(new T_OrderDsp()
                    {
                        OrID=p.OrID,
                        SoID=p.SoID,
                        SoName=p.SoName,
                        EmID=p.EmID,
                        EmName=p.EmName,
                        ClID=p.ClID,
                        ClName=p.ClName,
                        ClCharge=p.ClCharge,
                        OrDate=p.OrDate,
                        OrStateFlag=p.OrStateFlag,
                        OrFlag=p.OrFlag,
                        OrHidden=p.OrHidden


                    });
                }
                context.Dispose();
            }
            catch(Exception ex)
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
        public List<T_OrderDsp> GetOrderData(T_OrderDsp selectCondition)
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
                         where 
                         t1.OrID==selectCondition.OrID&&
                         t1.SoID == selectCondition.SoID &&
                         t1.EmID==selectCondition.EmID&&
                         t1.ClID == selectCondition.ClID &&
                         t1.ClCharge.Contains(selectCondition.ClCharge)&&
                         t1.OrDate==selectCondition.OrDate&&
                         t1.OrFlag != 2
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
