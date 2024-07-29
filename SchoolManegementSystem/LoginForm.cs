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
    public partial class LoginForm : Form
    {
        // 접속 query
        string Conn = "Server=localhost;Database=student;Uid=root;Pwd=qwer1234;";

        public LoginForm()
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("이름과 비밀번호를 모두 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // DB에서 검색
                using (MySqlConnection conn = new MySqlConnection(Conn))
                {
                    try
                    {
                        conn.Open();
                        string selectData = "SELECT COUNT(*) FROM user WHERE name = @name AND password = @password";
                        MySqlCommand cmd = new MySqlCommand(selectData, conn);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                        if (userCount > 0)
                        {
                            MessageBox.Show("로그인 성공!", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // 로그인 성공 후 다른 폼으로 이동 등의 로직 추가
                        }
                        else
                        {
                            MessageBox.Show("이름 또는 비밀번호가 잘못되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("오류가 발생했습니다: " + ex.Message);
                    }
                }
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            SignupForm signupForm = new SignupForm();
            signupForm.ShowDialog();
            this.Hide();
        }

        private void chbShowPW_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chbShowPW.Checked ? '\0' : '*';
            // \0은 마스킹 문자 없음을 의미
        }


    }
}
