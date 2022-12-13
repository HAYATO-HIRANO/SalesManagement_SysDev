using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class ArrivalDetailDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckArDetailIDExistence()
        //引　数   ：入荷詳細ID
        //戻り値   ：True or False
        //機　能   ：一致する入荷詳細IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckArDetailIDExistence(int arDetailID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                //入荷詳細IDで一致するデータが存在するか
                flg = context.T_ArrivalDetails.Any(x => x.ArDetailID == arDetailID);
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：AddArDetailData()
        //引　数   ：入荷詳細データ
        //戻り値   ：True or False
        //機　能   ：入荷詳細データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddArDetailData(T_ArrivalDetail regArDetail)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_ArrivalDetails.Add(regArDetail);
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
        //メソッド名：GetArIDDetailData()
        //引　数   :入荷ID
        //戻り値   :入荷IDの全詳細データ
        //機　能   ：同じ入荷ID全ての受注詳細情報
        /////////////////////////////////////////
        public List<T_ArrivalDetail> GetArIDDetailData(int arID)
        {
            List<T_ArrivalDetail> arrivalDetail = new List<T_ArrivalDetail>();

            try
            {
                var context = new SalesManagement_DevContext();

                arrivalDetail = context.T_ArrivalDetails.Where(x => x.ArID == arID).ToList();

                context.SaveChanges();
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return arrivalDetail;
        }
        ///////////////////////////////
        //メソッド名：GetArDetailData()
        //引　数   ：なし
        //戻り値   ：全入荷詳細データ
        //機　能   ：全入荷詳細データの取得
        ///////////////////////////////
        //public List<T_ArrivalDetailDsp> GetArDetailData()
        //{
        //    List<T_ArrivalDetailDsp> ArDetail = new List<T_ArrivalDetailDsp>();

        //    try
        //    {
        //        var context = new SalesManagement_DevContext();

        //        var tb = from t1 in context.T_ArrivalDetails
        //                 join t2 in context.T_Syukkos
        //                 on t1.SyID equals t2.SyID
        //                 join t3 in context.M_Products
        //                 on t1.PrID equals t3.PrID
        //                 join t4 in context.T_OrderDetails
        //                 on t2.OrID equals t4.OrID
        //                 where t2.SyFlag == 0
        //                 select new
        //                 {
        //                     t1.SyID,
        //                     t1.ArDetailID,
        //                     t1.PrID,
        //                     t3.PrName,
        //                     t3.Price,
        //                     t1.SyQuantity,
        //                     t4.OrTotalPrice

        //                 };
        //        foreach (var p in tb)
        //        {
        //            ArDetail.Add(new T_ArrivalDetailDsp()
        //            {
        //                SyID = p.SyID,
        //                ArDetailID = p.ArDetailID,
        //                PrID = p.PrID,
        //                PrName = p.PrName,
        //                Price = p.Price,
        //                SyQuantity = p.SyQuantity,
        //                TotalPrice = p.OrTotalPrice
        //            });
        //        }
        //        context.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //    return ArDetail;
        //}

    }
}
