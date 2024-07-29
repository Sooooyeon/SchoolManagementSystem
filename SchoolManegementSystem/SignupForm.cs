using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SchoolManegementSystem
{
    public partial class SignupForm : Form
    {
        // 접속 query
        string Conn = "Server=localhost;Database=student;Uid=root;Pwd=qwer1234;";

        public SignupForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            label2.Left = (this.ClientSize.Width - label2.Width) / 2;
            panel3.Left = (this.ClientSize.Width - panel3.Width) / 2;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void chbShowPW_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chbShowPW.Checked ? '\0' : '*';
            // \0은 마스킹 문자 없음을 의미
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("이름과 비밀번호를 모두 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                // DB에 데이터 삽입
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(Conn))
                    {
                        conn.Open();
                        string query = "INSERT INTO user (name, password) VALUES (@name, @password)";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("회원가입이 완료되었습니다.");
                            // 회원가입 성공 후 로그인 폼으로 이동
                            LoginForm loginForm = new LoginForm();
                            loginForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("회원가입에 실패했습니다. 다시 시도해주세요.");
                        }
                    }
                }
                catch
                {

                }
               
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Hide();

        }
    }
}
