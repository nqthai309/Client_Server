using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppQuanLy
{
    public partial class FormQuanTri : Form
    {
        
        public FormQuanTri()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            txtUsername.Text = FormDangNhap.acc.username;
            txtFullName.Text = FormDangNhap.acc.full_name;
            txtAddress.Text = FormDangNhap.acc.address;
        }
        private void AddForm(Form f)
        {
            f.MdiParent = this;
            groupBox3.Controls.Add(f);
            f.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            groupBox3.Controls.Clear();
            FormUser f = new FormUser();
            AddForm(f);
        }

        private void btnHotel_Click(object sender, EventArgs e)
        {
            groupBox3.Controls.Clear();
            FormHotel f = new FormHotel();
            AddForm(f);
        }

        private void btnHomestay_Click(object sender, EventArgs e)
        {
            groupBox3.Controls.Clear();
            FormHomestay f = new FormHomestay();
            AddForm(f);
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            groupBox3.Controls.Clear();
            FormBooking f = new FormBooking();
            AddForm(f);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDangNhap f = new FormDangNhap();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox3.Controls.Clear();
            FormDichVu f = new FormDichVu();
            AddForm(f);
        }
    }
}
