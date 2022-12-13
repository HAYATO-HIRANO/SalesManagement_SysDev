using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class SyukkoDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckSyIDExistence()
        //引　数   ：出庫ID
        //戻り値   ：True or False
        //機　能   ：一致する出庫IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckSyIDExistence(int syID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                //出庫IDで一致するデータが存在するか
                flg = context.T_Syukkos.Any(x => x.SyID == syID);
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：AddSyukkoData()
        //引　数   ：出庫データ
        //戻り値   ：True or False
        //機　能   ：出庫データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddSyukkoData(T_Syukko regSy)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_Syukkos.Add(regSy);
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
        //メソッド名：GetSyIDData()
        //引　数   :出庫ID
        //戻り値   ：出庫IDの出庫データ
        //機　能   ：出庫IDの出庫情報取得
        ///////////////////////////////
        public T_Syukko GetSyIDData(int syID)
        {
            T_Syukko syukko = new T_Syukko();

            try
            {
                var context = new SalesManagement_DevContext();

                syukko = context.T_Syukkos.Single(x => x.SyID == syID && x.SyFlag == 0);

                context.SaveChanges();
                context.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return syukko;
        }

        ///////////////////////////////
        //メソッド名：UpdateStateFlag()
        //引　数   :出庫ID
        //戻り値   ：True or False
        //機　能   ：出庫状態フラグの更新(0から1)
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateStateFlag(int syID)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var Syukko = context.T_Syukkos.Single(x => x.SyID == syID && x.SyFlag == 0);
                Syukko.SyStateFlag = 1;

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
        //引　数   :出庫情報(出庫ID,非表示フラグ,非表示理由)
        //戻り値   ：True or False
        //機　能   ：出庫管理フラグの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateHiddenFlag(T_Syukko updSyukko)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var Syukko = context.T_Syukkos.Single(x => x.SyID == updSyukko.SyID);
                Syukko.SyFlag = updSyukko.SyFlag;
                Syukko.SyHidden = updSyukko.SyHidden;

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
        //メソッド名：GetSyukkoData()
        //引　数   ：なし
        //戻り値   ：全出庫データ
        //機　能   ：全出庫データの取得
        ///////////////////////////////
        public List<T_SyukkoDsp> GetSyukkoData()
        {
            List<T_SyukkoDsp> syukko = new List<T_SyukkoDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_Syukkos
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID
                         where t1.SyFlag == 0
                         select new
                         {
                             t1.SyID,
                             t1.OrID,
                             t1.SoID,
                             t2.SoName,
                             t1.EmID,
                             t3.EmName,
                             t1.ClID,
                             t4.ClName,                    
                             t1.SyDate,
                             t1.SyStateFlag,
                             t1.SyFlag,
                             t1.SyHidden,
                         };
                foreach (var p in tb)
                {
                    syukko.Add(new T_SyukkoDsp()
                    {
                        OrID = p.OrID,
                        SoID = p.SoID,
                        SoName = p.SoName,
                        EmID = p.EmID,
                        EmName = p.EmName,
                        ClID = p.ClID,
                        ClName = p.ClName,
                        SyDate = p.SyDate,
                        SyStateFlag = p.SyStateFlag,
                        SyFlag = p.SyFlag,
                        SyHidden = p.SyHidden


                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return syukko;
        }
        ///////////////////////////////
        //メソッド名：GetSyukkoHiddenData()
        //引　数   ：なし
        //戻り値   ：全非表示データ
        //機　能   :非表示データの取得
        ///////////////////////////////
        public List<T_SyukkoDsp> GetSyukkoHiddenData()
        {
            List<T_SyukkoDsp> syukko = new List<T_SyukkoDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_Syukkos
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         join t3 in context.M_Employees
                         on t1.EmID equals t3.EmID
                         join t4 in context.M_Clients
                         on t1.ClID equals t4.ClID
                         where t1.SyFlag == 2
                         select new
                         {
                             t1.SyID,
                             t1.OrID,
                             t1.SoID,
                             t2.SoName,
                             t1.EmID,
                             t3.EmName,
                             t1.ClID,
                             t4.ClName,
                             t1.SyDate,
                             t1.SyStateFlag,
                             t1.SyFlag,
                             t1.SyHidden,
                         };
                foreach (var p in tb)
                {
                    syukko.Add(new T_SyukkoDsp()
                    {
                        OrID = p.OrID,
                        SoID = p.SoID,
                        SoName = p.SoName,
                        EmID = p.EmID,
                        EmName = p.EmName,
                        ClID = p.ClID,
                        ClName = p.ClName,
                        SyDate = p.SyDate,
                        SyStateFlag = p.SyStateFlag,
                        SyFlag = p.SyFlag,
                        SyHidden = p.SyHidden


                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return syukko;
        }

    }
}
