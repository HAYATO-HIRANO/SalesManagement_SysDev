﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class SyukkoDetailDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckSyDetailIDExistence()
        //引　数   ：出庫詳細ID
        //戻り値   ：True or False
        //機　能   ：一致する出庫詳細IDの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckSyDetailIDExistence(int syDetailID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                //出庫詳細IDで一致するデータが存在するか
                flg = context.T_SyukkoDetails.Any(x => x.SyDetailID == syDetailID);
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return flg;
        }
                ///////////////////////////////
        //メソッド名：AddSyDetailData()
        //引　数   ：出庫詳細データ
        //戻り値   ：True or False
        //機　能   ：出庫詳細データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddSyDetailData(T_SyukkoDetail regSyDetail)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.T_SyukkoDetails.Add(regSyDetail);
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
        //メソッド名：GetSyIDDetailData()
        //引　数   :出庫ID
        //戻り値   :出庫IDの全詳細データ
        //機　能   ：同じ出庫ID全ての受注詳細情報
        /////////////////////////////////////////
        public List<T_SyukkoDetail> GetSyIDDetailData(int syID)
        {
            List<T_SyukkoDetail> syukkoDetail = new List<T_SyukkoDetail>();

            try
            {
                var context = new SalesManagement_DevContext();

                syukkoDetail = context.T_SyukkoDetails.Where(x => x.SyID == syID).ToList();

                context.SaveChanges();
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return syukkoDetail;
        }
        ///////////////////////////////
        //メソッド名：GetSyDetailData()
        //引　数   ：なし
        //戻り値   ：全出庫詳細データ
        //機　能   ：全出庫詳細データの取得
        ///////////////////////////////
        public List<T_SyukkoDetailDsp> GetSyDetailData()
        {
            List<T_SyukkoDetailDsp> syDetail = new List<T_SyukkoDetailDsp>();

            try
            {
                var context = new SalesManagement_DevContext();

                var tb = from t1 in context.T_SyukkoDetails
                         join t2 in context.T_Syukkos
                         on t1.SyID equals t2.SyID
                         join t3 in context.M_Products
                         on t1.PrID equals t3.PrID
                         where t2.SyFlag == 0
                         select new
                         {
                             t1.SyID,
                             t1.SyDetailID,
                             t1.PrID,
                             t3.PrName,
                             t3.Price,
                             t1.SyQuantity,

                         };
                foreach (var p in tb)
                {
                    syDetail.Add(new T_SyukkoDetailDsp()
                    {
                        SyID = p.SyID,
                        SyDetailID = p.SyDetailID,
                        PrID = p.PrID,
                        PrName = p.PrName,
                        Price = p.Price,
                        SyQuantity = p.SyQuantity,
                    });
                }
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return syDetail;
        }

    }
}