using AppQuanLy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace AppQuanLy
{
    public partial class FormHomestay : Form
    {
        static ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        int id = -1;
        List<string> locationList = new List<string>();
        List<string> homestayNames = new List<string>();
        public FormHomestay()
        {
            InitializeComponent();
        }
        private int CheckInfo()
        {
            if (txtHomestayName.Text == "" || txtDes.Text == "" || txtInfo.Text == "" || txtPrice.Text == "" || txtSellPrice.Text == "")
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
            txtHomestayName.Text = "";
            txtDes.Text = "";
            txtInfo.Text = "";
            txtPrice.Text = "";
            txtSellPrice.Text = "";

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckInfo() == 1)
            {
                homestayNames.Remove(txtHomestayName.Text);
                if (homestayNames.Contains(txtHomestayName.Text))
                {
                    MessageBox.Show("Tên hotel bị trùng");
                }
                else
                {
                    homestay homestays = new homestay(int.Parse(comboBoxLocation.Text), txtHomestayName.Text, txtInfo.Text, "/Content/img/Group 70.png", "/Content/img/hotel-detail.jpg", "/Content/img/Group 69.png", txtDes.Text,
                        int.Parse(txtPrice.Text), int.Parse(txtSellPrice.Text));
                    client.EditHomestay_BE(id, JsonConvert.SerializeObject(homestays));
                    MessageBox.Show("Sửa thành công");
                    FormHomestay_Load(sender, e);
                    ClearTextBox();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckInfo() == 1)
            {
                if (homestayNames.Contains(txtHomestayName.Text))
                {
                    MessageBox.Show("Tên Homestay bị trùng");
                }
                else
                {
                    homestay homestays = new homestay(int.Parse(comboBoxLocation.Text), txtHomestayName.Text,  "/Content/img/Group 70.png", "/Content/img/hotel-detail.jpg", "/Content/img/Group 69.png", txtDes.Text, txtInfo.Text,
                        int.Parse(txtPrice.Text), int.Parse(txtSellPrice.Text));
                    client.AddHomestay_BE(JsonConvert.SerializeObject(homestays));
                    MessageBox.Show("Thêm thành công");
                    FormHomestay_Load(sender, e);
                    ClearTextBox();

                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (id == -1)
            {
                MessageBox.Show("Chưa chọn hotel để xoá ");

            }
            else
            {
                client.DeleteHomestay_BE(id);
                FormHomestay_Load(sender, e);
                MessageBox.Show("Xoá thành công");
            }
        }

        private void dtHotel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectRow = dtHomestay.Rows[index];
                comboBoxLocation.Text = selectRow.Cells[1].Value.ToString().Trim();
                txtHomestayName.Text = selectRow.Cells[2].Value.ToString().Trim();
                comboBoxLocation.SelectedItem = selectRow.Cells[3].Value.ToString().Trim();
                txtDes.Text = selectRow.Cells[6].Value.ToString().Trim();
                txtInfo.Text = selectRow.Cells[7].Value.ToString().Trim();
                txtPrice.Text = selectRow.Cells[8].Value.ToString().Trim();
                txtSellPrice.Text = selectRow.Cells[9].Value.ToString().Trim();
                id = int.Parse(selectRow.Cells[0].Value.ToString().Trim());

                //manv = selectRow.Cells[0].Value.ToString().Trim();
            }
            catch
            {

            }
        }

        private void FormHomestay_Load(object sender, EventArgs e)
        {
            List<homestay> homestayList = JsonConvert.DeserializeObject<List<homestay>>(client.GetListHomestay_BE());
            List<location> listLocation = JsonConvert.DeserializeObject<List<location>>(client.FrontEndGetListLocation());
            foreach (var it in listLocation)
            {
                locationList.Add(it.id.ToString());
            }
            comboBoxLocation.DataSource = locationList;
            foreach(var it in homestayList)
            {
                homestayNames.Add(it.homestay_name);
            }
            dtHomestay.DataSource = homestayList;
        }
    }
}
