using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HostA
{
    [ServiceContract]
    public interface IHostAServices
    {
        [OperationContract]
        Byte[] CreateTreeNode(String nodeName);

        [OperationContract]
        List<AuditProofDetails> CheckAuditProof(string toProof);

    }
}
