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
    public partial class FormThemMoiDichVu : Form
    {
        static ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        int id = -1;
        List<string> tenDichVu = new List<string>();
        public FormThemMoiDichVu()
        {
            InitializeComponent();
        }

        private int CheckInfo()
        {
            if (txtThemMoi.Text == "" || txtidDichVu.Text == "")
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
            txtThemMoi.Text = "";
            txtidDichVu.Text = "";
        }

        private void buttonThemMoiLoaiHang_Click(object sender, EventArgs e)
        {

            if (CheckInfo() == 1)
            {
                if (tenDichVu.Contains(txtThemMoi.Text))
                {
                    MessageBox.Show("Dịch Vụ đã tồn tại !!!");
                }
                else
                {
                    DichVu dichVu = new DichVu(txtidDichVu.Text, txtThemMoi.Text);
                    client.NewDV_BE(JsonConvert.SerializeObject(dichVu));
                    MessageBox.Show("Thêm dịch vụ thành công");
                    FormThemMoiDichVu_Load(sender, e);
                    ClearTextBox();

                }
            }
        }

        private void FormThemMoiDichVu_Load(object sender, EventArgs e)
        {
            //List<DichVu> listTenDV = JsonConvert.DeserializeObject<List<DichVu>>(client.FrontEndGetListTenDV());
        }

        private void FormThemMoiDichVu_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormDichVu f = new FormDichVu();
            f.FormDichVu_Load_1(sender, e);
        }
    }
}
