using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace SalesManagement_SysDev
{
    public partial class FormLogin : Form
    {
        //パスワードハッシュ用クラスのインスタンス化
        PasswordHash passwordHash = new PasswordHash();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btn_CleateDabase_Click(object sender, EventArgs e)
        {
            //データベースの生成を行います．
            //再度実行する場合には，必ずデータベースの削除をしてから実行してください．
            
            //役職マスタを生成するサンプル（1件目に管理者を追加する例）
            M_Position FirstPosition = new M_Position()
            {
                PoName = "管理者"
            };
            SalesManagement_DevContext context = new SalesManagement_DevContext();
            context.M_Positions.Add(FirstPosition);
            context.SaveChanges();
            context.Dispose();

            MessageBox.Show("テーブル作成完了");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //画面を閉じる
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            bool ret = false;

            //入力チェック
            ret = this.Check();
            if (ret == false)
            {
                return;
            }

            //承認
            ret = this.Authentjcate();
            if (ret)
            {
                MessageBox.Show("ログイン成功！");

            }
            else
            {
                MessageBox.Show("ユーザー名またはパスワードが間違っています。");
                return;
            }
            FormMain formMain = new FormMain();
            formMain.Show();
            this.Visible = false;
        }
        private bool Check()
        {
            //必要チェック
            if (textBoxEmID.Text == "")
            {
                MessageBox.Show("ユーザー名:入力してください。");
                return false;
            }
            if (textBoxEmPassword.Text == "")
            {
                MessageBox.Show("パスワード:入力してください。");
                return false;
            }

            //文字数チェック
            if (textBoxEmID.Text.Length > 6)
            {
                MessageBox.Show("ユーザー名:入力値に誤りがあります。");
                return false;
            }
            if (textBoxEmPassword.Text.Length > 10)
            {
                MessageBox.Show("パスワード:入力値に誤りがあります。");
                return false;
            }
            return true;
        }
        private bool Authentjcate()
        {
            SqlConnection con = new SqlConnection();

            try
            {
                //con.ConnectionString = "Data = Source=(local);Initial Catalog=TEST_DB;InteGrated Security=SSPI";
                //con.ConnectionString = "Data = Source=(local);User ID=user1;Password=pass;Inital Catalog=TEST_DB";

                SqlConnectionStringBuilder bilder = new SqlConnectionStringBuilder();

                bilder.DataSource = "(local)";
                bilder.InitialCatalog = "SalesManagement_SysDev";
                bilder.UserID = "user1";
                bilder.Password = "pass";

                Console.WriteLine(bilder.ConnectionString);
                con.ConnectionString = bilder.ConnectionString;

                con.Open();
                Console.WriteLine("接続完了");

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();

                SqlCommand cad = con.CreateCommand();

                cad.CommandText = "SELECT EmPassword FROM M_Employee WHERE EmID = e社員";
                cad.Parameters.Add("e社員", System.Data.SqlDbType.NVarChar, 6);
                cad.Parameters["e社員"].Value = textBoxEmID.Text;

                da.SelectCommand = cad;
                da.Fill(dt);

                if (dt.Rows.Count != 1)
                {
                    return false;
                }

                if (dt.Rows[0]["EmPassword"].ToString() != textBoxEmPassword.Text)
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("接続エラー");
                return false;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            formMain.Show();
            this.Visible = false;
        }

        private void btn_CleateDabase_Click_1(object sender, EventArgs e)
        {
            //データベースの生成を行います．
            //再度実行する場合には，必ずデータベースの削除をしてから実行してください．

            //役職マスタを生成するサンプル（1件目に管理者を追加する例）
            M_Position FirstPosition = new M_Position()
            {
                PoName = "管理者"
            };
            SalesManagement_DevContext context = new SalesManagement_DevContext();
            context.M_Positions.Add(FirstPosition);
            context.SaveChanges();
            context.Dispose();

            MessageBox.Show("テーブル作成完了");
        }
    }
}
