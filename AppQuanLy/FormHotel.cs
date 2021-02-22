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
    public partial class FormHotel : Form
    {
        static ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        int id = -1;
        List<string> locationList = new List<string>();
        List<string> hotelNames = new List<string>();
        public FormHotel()
        {
            InitializeComponent();
        }

        private void FormHotel_Load(object sender, EventArgs e)
        {
            List<hotel> list = JsonConvert.DeserializeObject<List<hotel>>(client.GetListHotel_BE());
            List<location> listLocation = JsonConvert.DeserializeObject<List<location>>(client.FrontEndGetListLocation());
            dtHotel.DataSource = list;
            foreach(var it in list)
            {
                hotelNames.Add(it.hotel_name);
            }
            foreach(var it in listLocation)
            {
                locationList.Add(it.id.ToString());
            }
            comboBoxLocation.DataSource = locationList;
        }

        private void dtHotel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectRow = dtHotel.Rows[index];
                comboBoxLocation.Text = selectRow.Cells[1].Value.ToString().Trim();
                txtHotelName.Text = selectRow.Cells[2].Value.ToString().Trim();
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
        private int CheckInfo()
        {
            if (txtHotelName.Text == "" || txtDes.Text == "" || txtInfo.Text == "" || txtPrice.Text == "" || txtSellPrice.Text == "")
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
            txtHotelName.Text = "";
            txtDes.Text = "";
            txtInfo.Text = "";
            txtPrice.Text = "";
            txtSellPrice.Text = "";
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(CheckInfo() == 1)
            {
                if (hotelNames.Contains(txtHotelName.Text))
                {
                    MessageBox.Show("Tên Hotel bị trùng");
                }
                else
                {
                    hotel hotels = new hotel(int.Parse(comboBoxLocation.Text), txtHotelName.Text, "/Content/img/Group 70.png", "/Content/img/hotel-detail.jpg", "/Content/img/Group 68.png", txtDes.Text, txtInfo.Text,
                        int.Parse(txtPrice.Text), int.Parse(txtSellPrice.Text));
                    client.AddHotel_BE(JsonConvert.SerializeObject(hotels));
                    MessageBox.Show("Thêm thành công");
                    FormHotel_Load(sender, e);
                    ClearTextBox();

                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(CheckInfo() == 1)
            {
                hotelNames.Remove(txtHotelName.Text);
                if (hotelNames.Contains(txtHotelName.Text))
                {
                    MessageBox.Show("Tên hotel bị trùng");
                }
                else
                {
                    hotel hotels = new hotel(int.Parse(comboBoxLocation.Text), txtHotelName.Text, "/Content/img/Group 70.png", "/Content/img/hotel-detail.jpg", "/Content/img/Group 69.png", txtDes.Text, txtInfo.Text,
                        int.Parse(txtPrice.Text), int.Parse(txtSellPrice.Text));
                    client.EditHotel_BE(id, JsonConvert.SerializeObject(hotels));
                    MessageBox.Show("Sửa thành công");
                    FormHotel_Load(sender, e);
                    ClearTextBox();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(id == -1)
            {
                MessageBox.Show("Chưa chọn hotel để xoá ");

            }
            else
            {
                client.DeleteHotel_BE(id);
                MessageBox.Show("Xoá thành công");
                FormHotel_Load(sender, e);
                ClearTextBox();
            }
        }
    }
}
