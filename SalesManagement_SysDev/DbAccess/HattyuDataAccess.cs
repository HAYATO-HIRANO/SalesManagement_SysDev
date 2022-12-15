using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SalesManagement_SysDev
{
    class HattyuDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckHaIDExistence()
        //引　数   ：発注ID
        //戻り値   ：True or False
        //機　能   ：一致する発注IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckHaIDExistence(int haID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                //発注IDで一致するデータが存在するか
                flg = context.T_Hattyus.Any(x => x.HaID == haID);
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：AddHattyuData()
        //引　数   ：発注データ
        //戻り値   ：True or False
        //機　能   ：発注データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddHattyuData(T_Hattyu regHattyu)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_Hattyus.Add(regHattyu);
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
        //メソッド名：GetHaIDData()
        //引　数   :発注ID
        //戻り値   ：発注IDの発注データ
        //機　能   ：発注IDの発注情報取得
        ///////////////////////////////
        public T_Hattyu GetHaIDData(int haID)
        {
            T_Hattyu hattyu = new T_Hattyu();

            try
            {
                var context = new SalesManagement_DevContext();

                hattyu = context.T_Hattyus.Single(x => x.HaID == haID && x.HaFlag == 0);

                context.SaveChanges();
                context.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return hattyu;
        }
        ///////////////////////////////
        //メソッド名：UpdateStateFlag()
        //引　数   :発注ID
        //戻り値   ：True or False
        //機　能   ：入庫済みフラグの更新(0から1)
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateWaWarehouseFlag(int HaID)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var hattyu = context.T_Hattyus.Single(x => x.HaID == HaID );
                hattyu.WaWarehouseFlag = 1;

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
        //引　数   :発注情報(発注ID,非表示フラグ,非表示理由)
        //戻り値   ：True or False
        //機　能   ：発注管理フラグの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateHiddenFlag(T_Hattyu updHattyu)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var hattyu = context.T_Hattyus.Single(x => x.HaID == updHattyu.HaID);
                hattyu.HaFlag = updHattyu.HaFlag;
                hattyu.HaHidden = updHattyu.HaHidden;

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
        //メソッド名：GetHattyuData()
        //引　数   ：なし
        //戻り値   ：未発注データ
        //機　能   ：未発注データの取得
        ///////////////////////////////
        public List<T_HattyuDsp> GetHattyuData()
        {
            List<T_HattyuDsp> hattyu = new List<T_HattyuDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_Hattyus
                         join t2 in context.M_Makers
                         on t1.MaID equals t2.MaID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         
                         where t1.WaWarehouseFlag==0&&
                         t1.HaFlag==0
                         select new
                         {
                             t1.HaID,
                             t1.MaID,
                             t2.MaName,
                             t1.EmID,
                             t3.EmName,                            
                             t1.HaDate,
                             t1.WaWarehouseFlag,
                             t1.HaFlag,
                             t1.HaHidden,
                         };
                foreach (var p in tb)
                {
                    hattyu.Add(new T_HattyuDsp()
                    {
                        HaID = p.HaID,
                        MaID = p.MaID,
                        MaName = p.MaName,
                        EmID = p.EmID,
                        EmName = p.EmName,                     
                        HaDate = p.HaDate,
                        WaWarehouseFlag = p.WaWarehouseFlag,
                        HaFlag = p.HaFlag,
                        HaHidden = p.HaHidden
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return hattyu;
        }
        ///////////////////////////////
        //メソッド名：GetHattyuHiddenData()
        //引　数   ：なし
        //戻り値   ：非表示発注データ
        //機　能   ：非表示発注データの取得
        ///////////////////////////////
        public List<T_HattyuDsp> GetHattyuHiddenData()
        {
            List<T_HattyuDsp> hattyu = new List<T_HattyuDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_Hattyus
                         join t2 in context.M_Makers
                         on t1.MaID equals t2.MaID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID

                         where 
                         t1.HaFlag == 2
                         select new
                         {
                             t1.HaID,
                             t1.MaID,
                             t2.MaName,
                             t1.EmID,
                             t3.EmName,
                             t1.HaDate,
                             t1.WaWarehouseFlag,
                             t1.HaFlag,
                             t1.HaHidden,
                         };
                foreach (var p in tb)
                {
                    hattyu.Add(new T_HattyuDsp()
                    {
                        HaID = p.HaID,
                        MaID = p.MaID,
                        MaName = p.MaName,
                        EmID = p.EmID,
                        EmName = p.EmName,
                        HaDate = p.HaDate,
                        WaWarehouseFlag = p.WaWarehouseFlag,
                        HaFlag = p.HaFlag,
                        HaHidden = p.HaHidden
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return hattyu;
        }
        ///////////////////////////////
        //メソッド名：GetHattyuData()
        //引　数   ：検索条件
        //戻り値   ：条件一致発注データ
        //機　能   ：条件一致発注データの取得 
        ///////////////////////////////
        public List<T_HattyuDsp> GetHattyuData(int flg, T_HattyuDsp selectCondition)
        {
            List<T_HattyuDsp> hattyu = new List<T_HattyuDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                if (flg == 1)
                {
                    var tb = from t1 in context.T_Hattyus
                             join t2 in context.M_Makers
                             on t1.MaID equals t2.MaID
                             join t3 in context.M_Employees
                             on t1.EmID equals t3.EmID

                             where
                             t1.HaID.ToString().Contains(selectCondition.HaID.ToString()) &&
                             t1.MaID.ToString().Contains(selectCondition.MaID.ToString()) &&
                             t1.EmID.ToString().Contains(selectCondition.EmID.ToString()) &&
                             t1.WaWarehouseFlag == 0 &&
                             t1.HaFlag == 0
                             select new
                             {
                                 t1.HaID,
                                 t1.MaID,
                                 t2.MaName,
                                 t1.EmID,
                                 t3.EmName,
                                 t1.HaDate,
                                 t1.WaWarehouseFlag,
                                 t1.HaFlag,
                                 t1.HaHidden,
                             };
                    foreach (var p in tb)
                    {
                        hattyu.Add(new T_HattyuDsp()
                        {
                            HaID = p.HaID,
                            MaID = p.MaID,
                            MaName = p.MaName,
                            EmID = p.EmID,
                            EmName = p.EmName,
                            HaDate = p.HaDate,
                            WaWarehouseFlag = p.WaWarehouseFlag,
                            HaFlag = p.HaFlag,
                            HaHidden = p.HaHidden
                        });
                    }

                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return hattyu;
        }

    }
}
