namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    public partial class user
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        public int role_id { get; set; }

        [StringLength(255)]
        public string full_name { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string phone { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        public user(int id, string username, string password, int role_id, string full_name, string email, string phone, string address)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.role_id = role_id;
            this.full_name = full_name;
            this.email = email;
            this.phone = phone;
            this.address = address;
        }
    }

}
