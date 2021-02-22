using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService2" in both code and config file together.
    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        List<user> GetListUser_BE();

        [OperationContract]
        void DeleteUser_BE(int id_old, int id, string username, string password, int role_id, string email, string phone, string address, string full_name);
    }
}
