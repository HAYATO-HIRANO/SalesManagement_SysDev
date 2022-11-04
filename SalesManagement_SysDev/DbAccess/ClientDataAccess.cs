using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace SalesManagement_SysDev
{
    class ClientDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckStaffCDExistence()
        //引　数   ：スタッフコード
        //戻り値   ：True or False
        //機　能   ：一致するスタッフコードの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckClIDExistence(int clID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                //スタッフCDで一致するデータが存在するか
                flg = context.M_Clients.Any(x => x.ClID == clID);
                context.Dispose();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：AddClientData()
        //引　数   ：スタッフデータ
        //戻り値   ：True or False
        //機　能   ：顧客データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddClientData(M_Client regClient)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.M_Clients.Add(regClient);
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
        //メソッド名：UpdateClientData()
        //引　数   :顧客データ
        //戻り値   ：True or False
        //機　能   ：顧客データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateClientData(M_Client updClient)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var Client = context.M_Clients.Single(x => x.ClID == updClient.ClID);

                Client.ClName = updClient.ClName;
                Client.ClAddress = updClient.ClAddress;
                Client.ClPhone = updClient.ClPhone;
                Client.ClPostal = updClient.ClPostal;
                Client.ClFAX = updClient.ClFAX;
                Client.ClFlag = updClient.ClFlag;
                Client.ClHidden = updClient.ClHidden;

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
        //メソッド名：GetClientData()
        //引　数   ：なし
        //戻り値   ：全顧客データ
        //機　能   ：全顧客データの取得
        ///////////////////////////////

        //途中
        public List<M_ClientDsp> GetClientData()
        {
            List<M_ClientDsp> client = new List<M_ClientDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                // tbはIEnumerable型
                var tb = from t1 in context.M_Clients
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         select new
                         {
                             t1.ClID,
                             t1.ClName,
                             t1.SoID,
                             t2.SoName,
                             t1.ClAddress,
                             t1.ClPhone,
                             t1.ClPostal,
                             t1.ClFAX,
                             t1.ClFlag,
                             t1.ClHidden
                         };
                foreach (var p in tb)
                {
                    client.Add(new M_ClientDsp()
                    {
                        ClID = p.ClID,
                        SoID = p.SoID,
                        ClName = p.ClName,
                        ClAddress = p.ClAddress,
                        ClPhone = p.ClPhone,
                        ClFAX = p.ClFAX,
                        ClPostal = p.ClPostal,
                        ClFlag = p.ClFlag,
                        ClHidden = p.ClHidden,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return client;
        }
        ///////////////////////////////
        //メソッド名：GetStaffData() オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致スタッフデータ
        //機　能   ：条件一致スタッフデータの取得
        ///////////////////////////////
        public List<M_ClientDsp> GetStaffData(M_ClientDsp selectCondition)
        {
            List<M_ClientDsp> client = new List<M_ClientDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.M_Clients
                         join t2 in context.M_SalesOffices
                         on t1.SoID equals t2.SoID
                         where t1.ClID.ToString().Contains(selectCondition.ClID.ToString()) &&
                         t1.SoID.ToString().Contains(selectCondition.SoID.ToString()) &&
                         t1.ClName.Contains(selectCondition.ClName)
                         select new
                         {
                             t1.ClID,
                             t1.ClName,
                             t1.SoID,
                             t2.SoName,
                             t1.ClAddress,
                             t1.ClPhone,
                             t1.ClPostal,
                             t1.ClFAX,
                             t1.ClFlag,
                             t1.ClHidden

                         };

                foreach(var p in tb)
                {
                    client.Add(new M_ClientDsp()
                    {
                        ClID = p.ClID,
                        SoID = p.SoID,
                        ClName = p.ClName,
                        ClAddress = p.ClAddress,
                        ClPhone = p.ClPhone,
                        ClFAX = p.ClFAX,
                        ClPostal = p.ClPostal,
                        ClFlag = p.ClFlag,
                        ClHidden = p.ClHidden,

                    });
                }
                context.Dispose();



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return client;


        }
    }
}
