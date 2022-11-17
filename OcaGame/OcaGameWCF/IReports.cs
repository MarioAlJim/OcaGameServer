using OcaDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OcaGameWCF
{
    [ServiceContract]
    internal interface IReports
    {
        [OperationContract]
        List<Reports> getReports();
    }

    [DataContract]
    public class Reports
    {
        [DataMember]
        public int IdReport { get; set; }
        [DataMember]
        public string typeReport { get; set; }
        [DataMember]
        public Nullable<int> IdUser { get; set; }
        [DataMember]
        public virtual Users Users { get; set; }
    }
}
