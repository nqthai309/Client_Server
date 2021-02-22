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
    public partial class FormBooking : Form
    {
        static ServiceReference1.WebService1SoapClient client = new ServiceReference1.WebService1SoapClient();
        List<hotel_booking> hotel_bookings = null;
        List<homestay_booking> homestay_bookings = null;
        int idHotel = -1;
        int idHomestay = -1;
        string status_hotel = "";
        string status_homestay = "";
        public FormBooking()
        {
            InitializeComponent();
            
        }

        private void FormBooking_Load(object sender, EventArgs e)
        {
            hotel_bookings = JsonConvert.DeserializeObject<List<hotel_booking>>(client.GetListBooking_BE("hotel_bookings"));
            homestay_bookings = JsonConvert.DeserializeObject<List<homestay_booking>>(client.GetListBooking_BE("homestay_bookings"));
            dtHotelBooking.DataSource = hotel_bookings;
            dtHomestayBooking.DataSource = homestay_bookings;
        }

        private void cbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbHotel.Text != "Tất Cả")
            {
                hotel_bookings = JsonConvert.DeserializeObject<List<hotel_booking>>(client.GetListBookingOptional_BE("hotel_bookings", cbHotel.Text));
                
            }
            else
            {
                hotel_bookings = JsonConvert.DeserializeObject<List<hotel_booking>>(client.GetListBooking_BE("hotel_bookings"));
            }
            dtHotelBooking.DataSource = hotel_bookings;

        }

        private void cbHomestay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbHomestay.Text != "Tất Cả")
            {
                homestay_bookings = JsonConvert.DeserializeObject<List<homestay_booking>>(client.GetListBookingOptional_BE("homestay_bookings", cbHomestay.Text));
                
            }
            else
            {
                homestay_bookings = JsonConvert.DeserializeObject<List<homestay_booking>>(client.GetListBooking_BE("homestay_bookings"));
            }
            dtHomestayBooking.DataSource = homestay_bookings;

        }

        private void dtHotelBooking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectRow = dtHotelBooking.Rows[index];
                idHotel = int.Parse(selectRow.Cells[0].Value.ToString().Trim());
                status_hotel = selectRow.Cells[1].Value.ToString().Trim();
                if(status_hotel == "Xác Nhận")
                {
                    btnXacNhanHotel.Enabled = false;
                }
                else
                {
                    btnXacNhanHotel.Enabled = true;
                }
            }
            catch
            {

            }

            
        }

        private void dtHomestayBooking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectRow = dtHomestayBooking.Rows[index];
                idHomestay = int.Parse(selectRow.Cells[0].Value.ToString().Trim());
                status_homestay = selectRow.Cells[1].Value.ToString().Trim();
                if(status_homestay == "Xác Nhận")
                {
                    btnXacNhanHomestay.Enabled = false;
                }
                else
                {
                    btnXacNhanHomestay.Enabled = true;
                }
            }
            catch
            {

            }
        }

        private void btnXacNhanHotel_Click(object sender, EventArgs e)
        {
            if (idHotel != -1)
            {
                try
                {
                    client.ConfirmHotelBooking_BE(idHotel);
                    idHotel = -1;
                    hotel_bookings = JsonConvert.DeserializeObject<List<hotel_booking>>(client.GetListBookingOptional_BE("hotel_bookings", cbHotel.Text));
                    dtHotelBooking.DataSource = hotel_bookings;
                }
                catch
                {

                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn");
            }
            
        }

        private void btnXacNhanHomestay_Click(object sender, EventArgs e)
        {
            if (idHomestay != -1)
            {
                try
                {
                    client.ConfirmHomestayBooking_BE(idHomestay);
                    
                    idHomestay = -1;
                    homestay_bookings = JsonConvert.DeserializeObject<List<homestay_booking>>(client.GetListBookingOptional_BE("homestay_bookings", cbHomestay.Text));
                    dtHomestayBooking.DataSource = homestay_bookings;
                }
                catch
                {

                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn");
            }
            
        }
    }
}
