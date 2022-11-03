using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OcaGameWCF
{
    [ServiceContract]
    public interface IAuthentication
    {
        [OperationContract]
        User login(string userName, string password);
    }

    [DataContract]
    public class User
    {
        [DataMember]
        public int IdUser { get; set; }
        [DataMember]
        public string Nickname { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public Nullable<bool> Valid { get; set; }
        [DataMember]
        public Nullable<int> Experience { get; set; }
        [DataMember]
        public Nullable<bool> Online { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}
