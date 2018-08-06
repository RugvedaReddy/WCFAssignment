using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace CLASScard
{
    [ServiceContract]
    interface IfirstCard
    {
        [OperationContract]
        [FaultContract(typeof(ArgumentException))]
        bool Authenticate(int no, DateTime expdate, int ccv,float transamt);
    }
}
