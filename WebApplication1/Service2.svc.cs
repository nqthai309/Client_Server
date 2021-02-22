using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service2.svc or Service2.svc.cs at the Solution Explorer and start debugging.
    public class Service2 : IService2
    {
        Model1 context = new Model1();
        public void DoWork()
        {
        }
        public List<user> GetListUser_BE()
        {
            var model = context.users.Where(x => x.id != 0).ToList();
            return model;
        }

        public void DeleteUser_BE(int id_old, int id, string username, string password, int role_id, string email, string phone, string address, string full_name)
        {
            user acc = new user(id, username, password, role_id, full_name, email, phone, address);
            var result = context.users.Find(id_old);
            context.users.Remove(result);
            context.users.Add(acc);
            context.SaveChanges();
        }
    }
}
