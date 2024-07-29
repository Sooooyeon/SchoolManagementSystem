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

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if(txtName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("이름과 비밀번호를 모두 입력해주세요.");
            }
            else
            {
                // DB에서조회
            }
        }

        private void chbShowPW_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chbShowPW.Checked ? '\0' : '*';
            // \0은 마스킹 문자 없음을 의미
        }
    }
}
