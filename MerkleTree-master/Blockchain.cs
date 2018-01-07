using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clifton.Blockchain
{
    public class Blockchain
    {
        public List<MerkleTree> Trees { get; set; }
        public int NumOfLeafs { get; set; }
        private int counter;
        public Blockchain()
        {
            this.Trees = new List<MerkleTree>()
            {
                new MerkleTree(),
                new MerkleTree(),
                new MerkleTree()
            };
            this.NumOfLeafs = 0;
            counter = 0;
        }

        public byte[] AddLeaf(string tran)
        {

            int numberOfTree = NumOfLeafs / 4;
            byte[] hash = null;
            NumOfLeafs++;
            counter++;
            if (Trees[numberOfTree] == null)
            {
                Trees[numberOfTree] = new MerkleTree();
            }
            Trees[numberOfTree].AppendLeaf(new MerkleNode(MerkleHash.Create(tran)));
            if (counter == 4)
            {
                hash = Trees[numberOfTree].BuildTree().Value;
                counter = 0;
            }
            return hash;
        }

        public List<MerkleProofHash> CheckAuditProof(string buffer)
        {
            List<MerkleProofHash> proof;
            foreach (var t in Trees)
            {
                proof = t.AuditProof(MerkleHash.Create(buffer));
                if (proof.Count > 0)
                {
                    return proof;
                }
            }
            return null;
        }

    }
}
