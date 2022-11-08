using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    class PositionDataAccess
    {
        ///////////////////////////////
        //メソッド名：CheckPoIDExistence()
        //引　数   ：役職コード
        //戻り値   ：True or False
        //機　能   ：一致するスタッフコードの有無を確認
        //          ：一致データありの場合True
        //          ：一致データなしの場合False
        ///////////////////////////////
        public bool CheckPoIDExistence(int poID)
        {
            bool flg = false;
            try
            {
                var context = new SalesManagement_DevContext();
                //役職コードで一致するデータが存在するか
                flg = context.M_Positions.Any(x => x.PoID== poID);
                context.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return flg;
        }
        ///////////////////////////////
        //メソッド名：AddPositionData()
        //引　数   ：役職データ
        //戻り値   ：True or False
        //機　能   ：役職データの登録
        //          ：登録成功の場合True
        //          ：登録失敗の場合False
        ///////////////////////////////
        public bool AddPositionData(M_Position regPosition)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                context.M_Positions.Add(regPosition);
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
        //メソッド名：UpdatePositionData()
        //引　数   :役職データ
        //戻り値   ：True or False
        //機　能   ：役職データの更新
        //          ：更新成功の場合True
        //          ：更新失敗の場合False
        ///////////////////////////////
        public bool UpdatePositionData(M_Position updPosition)
        {
            try
            {
                var context = new SalesManagement_DevContext();
                var position = context.M_Positions.Single(x => x.PoID == updPosition.PoID);
                position.PoName = updPosition.PoName;
                position.PoFlag = updPosition.PoFlag;
                position.PoHidden = updPosition.PoHidden;

                context.SaveChanges();
                context.Dispose();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        ///////////////////////////////
        //メソッド名：GetPositionlData()
        //引　数   ：なし
        //戻り値   ：全社員データ
        //機　能   ：全社員データの取得
        ///////////////////////////////
        public List<M_Position> GetPositionData()
        {
            List<M_Position> positions = new List<M_Position>();

            try
            {
                var context = new SalesManagement_DevContext();
                positions = context.M_Positions.ToList();
                context.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return positions;
        }
        ///////////////////////////////
        //メソッド名：GetPositionlData()　オーバーロード
        //引　数   ：検索条件
        //戻り値   ：表示用役職データ
        //機　能   ：表示用役職データの取得
        ///////////////////////////////
        public List<M_Position>GetPositonData(M_Position position)
        {
            List<M_Position> positions = new List<M_Position>();
            try
            {
                var context = new SalesManagement_DevContext();
                positions = context.M_Positions.Where(x => x.PoID == position.PoID).ToList();
                context.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return positions;
        }
        ///////////////////////////////
        //メソッド名：GetPositionDspData()　
        //引　数   ：検索条件
        //戻り値   ：表示用役職所データ
        //機　能   ：表示用役職データの取得
        ///////////////////////////////
        
        public List<M_Position>GetPositionDspData()
        {
            List<M_Position> positions = new List<M_Position>();
            try
            {
                var context = new SalesManagement_DevContext();
                positions = context.M_Positions.Where(x => x.PoFlag == 2).ToList();
                context.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "例外エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return positions;
        }
    }
}
    