using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class SalesOfficeDataAccess
    {

        ///////////////////////////////
        //メソッド名：CheckSalesOfficeCDExistence()
        //引　数   ：営業所ID
        //戻り値   ：True or False
        //機　能   ：一致する営業所IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckSalesOfficeCDExistence(int soID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                flg = context.M_SalesOffices.Any(x => x.SoID == soID);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }

        ///////////////////////////////
        //メソッド名：AddSalesOfficeData()
        //引　数   ：営業所データ
        //戻り値   ：True or False
        //機　能   ：営業所データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddSalesOfficeData(M_SalesOffice regSo)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.M_SalesOffices.Add(regSo);
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
        //メソッド名：UpdateSalesOfficeData()
        //引　数   ：営業所データ
        //戻り値   ：True or False
        //機　能   ：営業所データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdateSalesOfficeData(M_SalesOffice updSo)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var SalesOffice = context.M_SalesOffices.Single(x => x.SoID == updSo.SoID);
                SalesOffice.SoName = updSo.SoName;
                SalesOffice.SoAddress = SalesOffice.SoAddress;
                SalesOffice.SoPhone = updSo.SoPhone;
                SalesOffice.SoPostal = updSo.SoPostal;
                SalesOffice.SoFAX = updSo.SoFAX;
                SalesOffice.SoFlag = updSo.SoFlag;
                SalesOffice.SoHidden = updSo.SoHidden;

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
        //メソッド名： GetSalesOfficeData()
        //引　数   :なし
        //戻り値   :営業所データ
        //機　能   :営業所データの取得
        //////////////////////////////
        public List<M_SalesOfficeDsp> GetSalesOfficeData()
        {
            List<M_SalesOfficeDsp> salesOffices = new List<M_SalesOfficeDsp>();
            try
            {
               var context = new SalesManagement_DevContext();
               var tb = context.M_SalesOffices.Where(x => x.SoFlag != 2).ToList();
                foreach (var p in tb)
                {
                    salesOffices.Add(new M_SalesOfficeDsp()
                    {
                        SoID = p.SoID,
                        SoName = p.SoName,
                        SoPhone = p.SoPhone,
                        SoFAX = p.SoFAX,
                        SoPostal = p.SoPostal,
                        SoAddress = p.SoAddress,
                        SoFlag = p.SoFlag,
                        SoHidden = p.SoHidden
                    });

                }
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return salesOffices;
        }
        ///////////////////////////////
        //メソッド名： GetSalesOfficeHiddenData()
        //引　数   :なし
        //戻り値   :非表示営業所データ
        //機　能   :非表示営業所データの取得
        //////////////////////////////
        public List<M_SalesOfficeDsp> GetSalesOfficeHiddenData()
        {
            List<M_SalesOfficeDsp> salesOffices = new List<M_SalesOfficeDsp>();
            try
            {
                var context = new SalesManagement_DevContext();
                var tb = context.M_SalesOffices.Where(x => x.SoFlag == 2).ToList();
                foreach (var p in tb)
                {
                    salesOffices.Add(new M_SalesOfficeDsp()
                    {
                        SoID = p.SoID,
                        SoName = p.SoName,
                        SoPhone = p.SoPhone,
                        SoFAX = p.SoFAX,
                        SoPostal = p.SoPostal,
                        SoAddress = p.SoAddress,
                        SoFlag = p.SoFlag,
                        SoHidden = p.SoHidden
                    });

                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return salesOffices;
        }

        ///////////////////////////////
        //メソッド名：GetSalesOfficeData()　オーバーロード
        //引　数   ：フラグ,検索条件
        //戻り値   ：条件一致営業所データ
        //機　能   ：条件一致営業所データの取得
        ///////////////////////////////
        public List<M_SalesOfficeDsp> GetSalesOfficeData(int flg, M_SalesOfficeDsp selectCondition)
        {
            List<M_SalesOfficeDsp> salesOffice = new List<M_SalesOfficeDsp>();
            try
            {
                var context = new SalesManagement_DevContext();
                if (flg == 1)
                {
                    var tb = context.M_SalesOffices.Where
                        (x => x.SoID.ToString().Contains(selectCondition.SoID.ToString()) &&
                                     x.SoName.Contains(selectCondition.SoName) &&
                                     x.SoPhone.Contains(selectCondition.SoPhone) &&
                                     x.SoFAX.Contains(selectCondition.SoFAX) &&
                                     x.SoPostal.Contains(selectCondition.SoPostal) &&
                                     x.SoAddress.Contains(selectCondition.SoAddress) &&
                                     x.SoFlag == selectCondition.SoFlag &&                                     
                                     x.SoHidden.Contains(selectCondition.SoHidden)).ToList();                       
                    foreach (var p in tb)
                    {
                        salesOffice.Add(new M_SalesOfficeDsp()
                        {
                            SoID = p.SoID,
                            SoName = p.SoName,
                            SoPhone = p.SoPhone,
                            SoFAX = p.SoFAX,
                            SoPostal = p.SoPostal,
                            SoAddress = p.SoAddress,
                            SoFlag = p.SoFlag,
                            SoHidden = p.SoHidden
                        });
                        
                    }
                    
                }
                else if (flg == 2)
                {
                    var tb = context.M_SalesOffices.Where
                               (x => x.SoName.Contains(selectCondition.SoName) &&
                                     x.SoPhone.Contains(selectCondition.SoPhone) &&
                                     x.SoFAX.Contains(selectCondition.SoFAX) &&
                                     x.SoPostal.Contains(selectCondition.SoPostal) &&
                                     x.SoAddress.Contains(selectCondition.SoAddress) &&
                                     x.SoFlag == selectCondition.SoFlag&&                    
                                     x.SoHidden.Contains(selectCondition.SoHidden)).ToList();                       
                    foreach (var p in tb)
                    {
                        salesOffice.Add(new M_SalesOfficeDsp()
                        {
                            SoID = p.SoID,
                            SoName = p.SoName,
                            SoPhone = p.SoPhone,
                            SoFAX = p.SoFAX,
                            SoPostal = p.SoPostal,
                            SoAddress = p.SoAddress,
                            SoFlag = p.SoFlag,
                            SoHidden = p.SoHidden
                        });
                       
                    }
                    
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return salesOffice;
        }

        ///////////////////////////////
        //メソッド名：GetSalesOfficeDspData()　
        //引　数   ：なし
        //戻り値   ：表示用営業所データ
        //機　能   ：表示用営業所データの取得
        ///////////////////////////////

        public List<M_SalesOffice> GetSalesOfficeDspData()
        {
            List<M_SalesOffice> salesOffices = null;
            try
            {
                var context = new SalesManagement_DevContext();
                salesOffices = context.M_SalesOffices.Where(x => x.SoFlag == 0).ToList();
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return salesOffices;
        }
    }
}
