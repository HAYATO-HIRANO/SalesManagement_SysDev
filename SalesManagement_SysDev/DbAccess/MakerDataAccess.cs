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

        public M_Maker GetMakerIDData(int maID)
        {
            M_Maker maker = new M_Maker();
            try
            {
                var context = new SalesManagement_DevContext();
                maker = context.M_Makers.Single(x => x.MaID == maID && x.MaFlag == 0);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return maker;
        }


        ///////////////////////////////
        //メソッド名：GetMakerData()
        //引　数   ：なし
        //戻り値   ：全メーカデータ
        //機　能   ：全メーカデータの取得
        ///////////////////////////////


        public List<M_MakerDsp> GetMakerData()
        {
            List<M_MakerDsp> maker = new List<M_MakerDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                // tbはIEnumerable型

                var tb = from t1 in context.M_Makers
                         //join t2 in context.M_SalesOffices
                         //on t1.MaID equals t2.MaID
                         where t1.MaFlag != 2
                         select new
                         {
                             t1.MaID,
                             t1.MaName,
                             t1.MaAdress,
                             t1.MaFAX,
                             t1.MaPhone,
                             t1.MaPostal,
                             t1.MaFlag,
                             t1.MaHidden
                         };

                foreach (var p in tb)
                {
                    maker.Add(new M_MakerDsp()
                    {
                        MaID = p.MaID,
                        MaName = p.MaName,
                        MaPhone = p.MaPhone,
                        MaAdress = p.MaAdress,
                        MaPostal = p.MaPostal,
                        MaFAX = p.MaFAX,
                        MaFlag = p.MaFlag,
                        MaHidden = p.MaHidden
                    });

                }

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

        public List<M_MakerDsp> GetMakerData(int flg, M_MakerDsp selectCondition)
        {
            List<M_MakerDsp> maker = new List<M_MakerDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                // tbはIEnumerable型

                if (flg == 1)
                {
                    var tb = from t1 in context.M_Makers
                                 //join t2 in context.M_SalesOffices
                                 //on t1.MaID equals t2.MaID
                             where

                             t1.MaID.ToString().Contains(selectCondition.MaID.ToString()) &&
                             t1.MaName.Contains(selectCondition.MaName) &&
                             t1.MaPhone.Contains(selectCondition.MaPhone) &&
                             t1.MaPostal.Contains(selectCondition.MaPostal) &&
                             t1.MaFAX.Contains(selectCondition.MaFAX) &&
                             t1.MaAdress.Contains(selectCondition.MaAdress) &&
                             t1.MaFlag == selectCondition.MaFlag &&
                             t1.MaHidden.Contains(selectCondition.MaHidden)

                             select new
                             {
                                 t1.MaID,
                                 t1.MaName,
                                 t1.MaAdress,
                                 t1.MaFAX,
                                 t1.MaPhone,
                                 t1.MaPostal,
                                 t1.MaFlag,
                                 t1.MaHidden
                             };

                    foreach (var p in tb)
                    {
                        maker.Add(new M_MakerDsp()
                        {
                            MaID = p.MaID,
                            MaName = p.MaName,
                            MaPhone = p.MaPhone,
                            MaAdress = p.MaAdress,
                            MaPostal = p.MaPostal,
                            MaFAX = p.MaFAX,
                            MaFlag = p.MaFlag,
                            MaHidden = p.MaHidden
                        });

                    }
                }
                    if (flg == 2)
                    {
                        var tb = from t1 in context.M_Makers
                                     //join t2 in context.M_SalesOffices
                                     //on t1.MaID equals t2.MaID
                                 where 
                             t1.MaID.ToString().Contains(selectCondition.MaID.ToString()) &&
                             t1.MaName.Contains(selectCondition.MaName) &&
                             t1.MaPhone.Contains(selectCondition.MaPhone) &&
                             t1.MaPostal.Contains(selectCondition.MaPostal) &&
                             t1.MaFAX.Contains(selectCondition.MaFAX) &&
                             t1.MaAdress.Contains(selectCondition.MaAdress) &&
                             t1.MaFlag == selectCondition.MaFlag &&
                             t1.MaHidden.Contains(selectCondition.MaHidden)
                                 select new
                                 {
                                     t1.MaID,
                                     t1.MaName,
                                     t1.MaAdress,
                                     t1.MaFAX,
                                     t1.MaPhone,
                                     t1.MaPostal,
                                     t1.MaFlag,
                                     t1.MaHidden
                                 };

                        foreach (var p in tb)
                        {
                            maker.Add(new M_MakerDsp()
                            {
                                MaID = p.MaID,
                                MaName = p.MaName,
                                MaPhone = p.MaPhone,
                                MaAdress = p.MaAdress,
                                MaPostal = p.MaPostal,
                                MaFAX = p.MaFAX,
                                MaFlag = p.MaFlag,
                                MaHidden = p.MaHidden
                            });

                        }
                    }

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
            List<M_Maker> maker = null;
            try
            {
                var context = new SalesManagement_DevContext();
                maker = context.M_Makers.Where(x =>x.MaFlag ==0).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return maker;

        }
        ///////////////////////////////
        //メソッド名：GetClientHiddenData()
        //引　数   ：なし
        //戻り値   ：非表示データ
        //機　能   ：非表示データの取得
        ///////////////////////////////


        public List<M_MakerDsp> GetMakerHiddenData()
        {
            List<M_MakerDsp> maker = new List<M_MakerDsp>();

            try
            {
                var context = new SalesManagement_DevContext();
                // tbはIEnumerable型

                var tb = from t1 in context.M_Makers
                         where t1.MaFlag == 2
                         select new
                         {
                             t1.MaID,
                             t1.MaName,
                             t1.MaAdress,
                             t1.MaFAX,
                             t1.MaPhone,
                             t1.MaPostal,
                             t1.MaFlag,
                             t1.MaHidden
                         };

                foreach (var p in tb)
                {
                    maker.Add(new M_MakerDsp()
                    {
                        MaID = p.MaID,
                        MaName = p.MaName,
                        MaPhone = p.MaPhone,
                        MaAdress = p.MaAdress,
                        MaPostal = p.MaPostal,
                        MaFAX = p.MaFAX,
                        MaFlag = p.MaFlag,
                        MaHidden = p.MaHidden
                    });

                }

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
