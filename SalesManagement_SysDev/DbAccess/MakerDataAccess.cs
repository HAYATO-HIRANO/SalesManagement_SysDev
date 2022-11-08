using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev//.DbAccess
{
    class MakerDataAccess
    {

        //////////////////////////////
        //メソッド名：CheckMakerCDExistence()
        //引　数   ：商品メーカーID、商品メーカー名
        //戻り値   ：True or False
        //機　能   ：一致する商品メーカコードの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////

        public bool CheckMakerCDExistence(int maID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                flg = context.M_Makers.Any(x => x.MaID == maID);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：SelectMakerExistenceCheck()
        //引　数   ：商品メーカID、商品メーカ名
        //戻り値   ：True or False
        //機　能   ：部分一致する商品メーカコード、商品メーカ名の有無を確認
        //          ：部分一致データありの場合True
        //          ：部分一致データなしの場合False
        ///////////////////////////////

        public bool SelectMakerExistenceCheck(int maID, string maName)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                flg = context.M_Makers.Any(x => x.MaID == maID && x.MaName.Contains(maName));
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：AddMakerData()
        //引　数   ：商品メーカデータ
        //戻り値   ：True or False
        //機　能   ：商品メーカデータの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////

        public bool AddMakerData(M_Maker regMeker)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.M_Makers.Add(regMeker);
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

        public bool UpdateMakerData(M_Maker updMaker)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var maker = context.M_Makers.Single(x => x.MaID == updMaker.MaID);
                maker.MaName = updMaker.MaName;
                maker.MaAdress = updMaker.MaAdress;
                maker.MaPhone = updMaker.MaPhone;
                maker.MaPostal = updMaker.MaPostal;
                maker.MaFAX = updMaker.MaFAX;
                maker.MaFlag = updMaker.MaFlag;
                maker.MaHidden = updMaker.MaHidden;

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
        //メソッド名：GetMakerData()
        //引　数   ：なし
        //戻り値   ：商品メーカデータ
        //機　能   ：商品メーカデータの取得
        ///////////////////////////////

        public List<M_Maker> GetMakerData()
        {
            List<M_Maker> maker = new List<M_Maker>();
            try
            {
                var context = new SalesManagement_DevContext();
                maker = context.M_Makers.ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return maker;
        }

        ///////////////////////////////
        //メソッド名：GetMakerData()　オーバーロード
        //引　数   ：検索条件
        //戻り値   ：条件一致商品メーカデータ
        //機　能   ：条件一致商品メーカデータの取得
        ///////////////////////////////

        public List<M_Maker> GetMakerData(M_Maker selectCondition)
        {
            List<M_Maker> maker = new List<M_Maker>();
            try
            {
                var context = new SalesManagement_DevContext();
                maker = context.M_Makers.Where(x => x.MaID == selectCondition.MaID && x.MaName.Contains(selectCondition.MaName)).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return maker;
        }

        ///////////////////////////////
        //メソッド名：GetMakerDspData()
        //引　数   ：なし
        //戻り値   ：表示用商品メーカデータ
        //機　能   ：表示用商品メーカデータの取得
        ///////////////////////////////

        public List<M_Maker> GetMakerDspData()
        {
            List<M_Maker> maker = new List<M_Maker>();
            try
            {
                var context = new SalesManagement_DevContext();
                maker = context.M_Makers.Where(x => x.MaFlag ==2).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return maker;

        }

    }
}
