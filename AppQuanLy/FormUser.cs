using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppQuanLy.Models;
using Newtonsoft.Json;


namespace AppQuanLy
{
    public partial class FormUser : Form
    {
        static ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        List<string> userNames = new List<string>();
        int id = -1;
        public FormUser()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            var list = JsonConvert.DeserializeObject<List<user>>(client.GetListUser_BE());
            dtUser.DataSource = list;
            foreach(var it in list)
            {
                userNames.Add(it.username);
            }
        }

        private void dtUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectRow = dtUser.Rows[index];
                txtUsername.Text = selectRow.Cells[1].Value.ToString().Trim();
                txtPassword.Text = selectRow.Cells[2].Value.ToString().Trim();
                comboBoxRoleID.SelectedItem = selectRow.Cells[3].Value.ToString().Trim();
                txtFullname.Text = selectRow.Cells[4].Value.ToString().Trim();
                txtEmail.Text = selectRow.Cells[5].Value.ToString().Trim();
                txtPhone.Text = selectRow.Cells[6].Value.ToString().Trim();
                txtAddress.Text = selectRow.Cells[7].Value.ToString().Trim();
                id = int.Parse(selectRow.Cells[0].Value.ToString().Trim());

                //manv = selectRow.Cells[0].Value.ToString().Trim();
            }
            catch
            {

            }
        }
        private int CheckInfo()
        {
            if(txtUsername.Text == "" || txtPassword.Text == "" || txtPhone.Text == "" || txtFullname.Text == "" || txtEmail.Text == "" ||
                txtAddress.Text == "")
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        private void ClearTextBox()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtFullname.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(CheckInfo() == 1)
            {
                if (userNames.Contains(txtUsername.Text))
                {
                    MessageBox.Show("username bị trùng");
                }
                else
                {
                    user acc = new user(txtUsername.Text, txtPassword.Text, int.Parse(comboBoxRoleID.Text), txtFullname.Text, txtEmail.Text, txtPhone.Text, txtAddress.Text);
                    client.AddUser_BE(JsonConvert.SerializeObject(acc));
                
                    FormUser_Load(sender, e);
                    MessageBox.Show("Thêm Thành Công");
                    ClearTextBox();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(id == -1)
            {
                MessageBox.Show("Bạn chưa chọn user");
            }
            else
            {
                client.DeleteUser_BE(id);
                MessageBox.Show("Xoá thành công");
                FormUser_Load(sender, e);
                ClearTextBox();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(CheckInfo() == 1)
            {
                userNames.Remove(txtUsername.Text);
                if (userNames.Contains(txtUsername.Text))
                {
                    MessageBox.Show("Username bị trùng");
                }
                else
                {
                    user acc = new user(txtUsername.Text, txtPassword.Text, int.Parse(comboBoxRoleID.Text), txtFullname.Text, txtEmail.Text, txtPhone.Text, txtAddress.Text);
                    client.EditUser_BE(id, JsonConvert.SerializeObject(acc));
                    MessageBox.Show("Sửa thành công");
                    FormUser_Load(sender, e);
                    ClearTextBox();
                }
            }
        }
    }
}
