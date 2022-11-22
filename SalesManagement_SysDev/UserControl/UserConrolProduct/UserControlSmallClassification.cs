using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement_SysDev
{
    public partial class UserControlSmallClassification : UserControl
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp messageDsp = new MessageDsp();
        //入力形式チェック用クラスのインスタンス化
        DataInputFormCheck dataInputFormCheck = new DataInputFormCheck();
        //データベース小分類テーブルアクセス用クラスのインスタンス化
        SmallClassification smallClassification = new SmallClassification();
        //データベース大分類テーブルアクセス用クラスのインスタンス化
        MajorClassificationDataAccess majorClassification = new MajorClassificationDataAccess();
        //コンボボックス用の大分類データ
        private static List<M_MajorCassification> MajorCassifications;


        public UserControlSmallClassification()
        {
            InitializeComponent();
        }

        private void UserControlSmallClassification_Load(object sender, EventArgs e)
        {
            //コンボボックスの設定
            SetFormComboBox();

            //データグリッドビューの設定
            //SetFormDataGridView();

            ///////////////////////////////
            //メソッド名：SetFormComboBox()
            //引　数   ：なし
            //戻り値   ：なし
            //機　能   ：コンボボックスのデータ設定
            ///////////////////////////////            

        }

        private void SetFormComboBox()
        {
            //大分類データの取得
            MajorCassifications = majorClassification.GetMcData();
            comboBoxMcID.DataSource = MajorCassifications;
            comboBoxMcID.DisplayMember = "McName";
            comboBoxMcID.ValueMember = "McID";
            //コンボボックスを読み取り専用
            comboBoxMcID.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMcID.SelectedIndex = -1;
        }

        private void buttonResist_Click(object sender, EventArgs e)
        {
            // 妥当な小分類データを取得
            if (!GetValidDataAtRegistration())
                return;

            // 小分類情報作成
            var regSc = GenerateDataAtRegistration();

            // 小分類情報登録
            //RegistrationSc(regSc);

        }
        ///////////////////////////////
        //　4.6.1.1.1 妥当な顧客データ取得
        //メソッド名：GetValidDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：true or false
        //機　能   ：入力データの形式チェック
        //          ：エラーがない場合True
        //          ：エラーがある場合False
        ///////////////////////////////
        private bool GetValidDataAtRegistration()
        {
            //大分類が未選択
            if (comboBoxMcID.SelectedIndex == -1)
            {
                MessageBox.Show("大分類が選択されていません","入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxMcID.Focus();
                return false;
            }
                     
            //小分類IDの適否
            if (!String.IsNullOrEmpty(textBoxScID.Text.Trim()))
            {
                //顧客IDは入力不要です
                MessageBox.Show("小分類IDは入力不要です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxScID.Focus();
                return false;
            }

            //小分類名の適否
            if (!String.IsNullOrEmpty(textBoxScName.Text.Trim()))
            {
                if(textBoxScName.TextLength > 50)
                {
                    //小分類名は50文字以下です
                    MessageBox.Show("小分類名は50文字以下です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxScName.Focus();
                    return false;
                }
            }
            else
            {
                //小分類名が入力されていません
                MessageBox.Show("小分類名が入力されていません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxScName.Focus();
                return false;
            }

            //フラグの適否
            if (checkBoxScFlag.CheckState == CheckState.Indeterminate)
            {
                MessageBox.Show("非表示フラグが不確定の状態です", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxScFlag.Focus();
                return false;
            }
            if(checkBoxScFlag.Checked == true)
            {
                MessageBox.Show("非表示フラグがチェックされています", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkBoxScFlag.Focus();
                return false;
            }

            //非表示理由の適否
            if (!String.IsNullOrEmpty(textBoxScHidden.Text.Trim()))
            {
                MessageBox.Show("非表示理由は登録できません", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxScHidden.Focus();
                return false;
            }

            return true;
        }

        ///////////////////////////////
        //　4.6.1.1.2 小分類情報作成
        //メソッド名：GenerateDataAtRegistration()
        //引　数   ：なし
        //戻り値   ：小分類登録情報
        //機　能   ：登録データのセット
        ///////////////////////////////
        private M_SmallClassification GenerateDataAtRegistration()
        {
            int ScFlag = 0;
            if(checkBoxScFlag.Checked == true)
            {
                ScFlag = 2;
            }

            return new M_SmallClassification
            {
                McID = int.Parse(comboBoxMcID.SelectedValue.ToString()),
                ScName = textBoxScName.Text.Trim(),
                ScFlag = ScFlag,
                ScHidden = textBoxScHidden.Text.Trim()
            };
        }

        ///////////////////////////////
        //　4.6.1.1.3 小分類情報登録
        //メソッド名：RegistrationSc
        //引　数   ：小分類情報
        //戻り値   ：なし
        //機　能   ：小分類情報の登録
        ///////////////////////////////
        private void RegistrationSc(M_SmallClassification regSc)
        {
            //登録確認メッセージ
            //DialogResult result = 
        }

    }
}
