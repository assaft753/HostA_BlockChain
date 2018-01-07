using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Clifton.Blockchain;

namespace HostA
{
    public class HostAServices : IHostAServices
    {
        public static Blockchain blockchain = new Blockchain();

        public List<AuditProofDetails> CheckAuditProof(string toProof)
        {
            var proof = blockchain.CheckAuditProof(toProof);
            List<AuditProofDetails> answer = new List<AuditProofDetails>();
            if (proof == null)
            {
                return null;
            }
            foreach (var p in proof)
            {
                answer.Add(new AuditProofDetails(p));
            }
            return answer;
        }

        public byte[] CreateTreeNode(string nodeName)
        {
            if (blockchain.NumOfLeafs >= 12)
                return null;
            Console.WriteLine(nodeName + " Added to the BlockChain");
            return blockchain.AddLeaf(nodeName);
        }
    }


    [DataContract]
    public class AuditProofDetails
    {
        [DataMember]
        public string Direction { get; set; }
        [DataMember]
        public byte[] Hash { get; set; }

        public AuditProofDetails(MerkleProofHash merkleProofHash)
        {
            Direction = merkleProofHash.Direction.ToString();
            Hash = merkleProofHash.Hash.Value;
        }
    }
}
