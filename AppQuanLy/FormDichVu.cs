using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppQuanLy.Models;
//using ControlzEx.Standard;
using Newtonsoft.Json;

namespace AppQuanLy
{
    public partial class FormDichVu : Form
    {
        static ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        int id = -1;
        List<string> idHTHS = new List<string>();
        List<string> idDichVu = new List<string>();
        List<string> theLoai = new List<string>();
        List<string> tenDichVu = new List<string>();
        public FormDichVu()
        {
            InitializeComponent();
        }

        
        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectRow = dgvDichVu.Rows[index];
                //comboBoxHTHS.Text = selectRow.Cells[0].Value.ToString().Trim();
                comboBoxTheLoai.Text = selectRow.Cells[1].Value.ToString().Trim();
                comboBoxDV.SelectedItem = selectRow.Cells[2].Value.ToString().Trim();
                txtTenDV.Text = selectRow.Cells[3].Value.ToString().Trim();
                txtDonGia.Text = selectRow.Cells[4].Value.ToString().Trim();
                id = int.Parse(selectRow.Cells[0].Value.ToString().Trim());

            }
            catch
            {

            }
        }
        private int CheckInfo()
        {
            if (txtTenDV.Text == "" || txtDonGia.Text == "")
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
            txtTenDV.Text = "";
            txtDonGia.Text = "";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckInfo() == 1)
            {
                if (tenDichVu.Contains(txtTenDV.Text))
                {
                    MessageBox.Show("Dịch Vụ đã thêm rồi !!!");
                }
                else
                {
                    DichVu_HT_HS dvhths = new DichVu_HT_HS(int.Parse(comboBoxHTHS.Text), comboBoxTheLoai.Text, comboBoxDV.Text, txtTenDV.Text, int.Parse(txtDonGia.Text));
                    client.AddDichVu_BE(JsonConvert.SerializeObject(dvhths));
                    MessageBox.Show("Thêm dịch vụ thành công");
                    FormDichVu_Load_1(sender, e);
                    ClearTextBox();

                }
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void FormDichVu_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cNW_N8_TTHT1DataSet.DichVu_HT_HS' table. You can move, or remove it, as needed.
            //this.dichVu_HT_HSTableAdapter.Fill(this.cNW_N8_TTHT1DataSet.DichVu_HT_HS);

            List<hotel> dsHotel = JsonConvert.DeserializeObject<List<hotel>>(client.GetListHotel_BE());
            List<homestay> dsHomestay = JsonConvert.DeserializeObject<List<homestay>>(client.GetListHomestay_BE());
            List<string> listID = new List<string>();
            List<DichVu> list = JsonConvert.DeserializeObject<List<DichVu>>(client.FrontEndGetListDV());
            List<DichVu_HT_HS> listTheLoai = JsonConvert.DeserializeObject<List<DichVu_HT_HS>>(client.FrontEndGetTheLoai());

            foreach (var it in dsHotel)
            {
                listID.Add(it.id.ToString());
            }

            foreach(var it in dsHomestay)
            {
                if (listID.Contains(it.id.ToString()))
                {

                }
                else
                {
                    listID.Add(it.id.ToString());
                }
            }
            comboBoxHTHS.DataSource = listID;
            foreach (var it in list)
            {
                idDichVu.Add(it.idDichVu);
            }
            comboBoxDV.DataSource = idDichVu.Distinct().ToList();

            foreach (var it in listTheLoai)
            {
                theLoai.Add(it.theLoai.ToString());
            }
            comboBoxTheLoai.DataSource = theLoai.Distinct().ToList();

            List<DichVu_HT_HS> listDVHTHS = JsonConvert.DeserializeObject<List<DichVu_HT_HS>>(client.GetDichVu_HTHS_BE());
            dgvDichVu.DataSource = listDVHTHS;

        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            FormThemMoiDichVu formThemMoiDichVu = new FormThemMoiDichVu();
            formThemMoiDichVu.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (id == -1)
            {
                MessageBox.Show("Chưa chọn dịch vụ để xoá ");
            }
            else
            {
                client.DeleteDichVu_BE(id, comboBoxTheLoai.Text, comboBoxDV.Text);
                FormDichVu_Load_1(sender, e);
                MessageBox.Show("Xoá thành công");
            }
        }

        private void comboBoxDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string maDV_select = comboBoxDV.Text.ToString();
            DichVu dv = JsonConvert.DeserializeObject<DichVu>(client.GetDichVuByID(maDV_select));

            txtTenDV.Text = dv.tenDichVu;

            //string tenDV = client.GetDichVu_HTHS_BE();
            //txtTenDV.Text = tenDV;
        }
    }
}
