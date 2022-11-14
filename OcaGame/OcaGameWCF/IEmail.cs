﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OcaGameWCF
{
    [ServiceContract]
    internal interface IEmail
    {
        [OperationContract]
        int sendEmail(string email);
        [OperationContract]
        User GetUserFromEmail(string email);
        [OperationContract]
        bool UpdatePassword(User user);
    }
}
