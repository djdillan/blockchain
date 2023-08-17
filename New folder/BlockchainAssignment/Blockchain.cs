using System.Collections.Generic; 
using System; 

namespace BlockchainAssignment
{
    class Blockchain
    {
        public List<Block> blocks; // List of block objects forming the blockchain
        private int transactionsPerBlock = 5; // Maximum number of transactions per block
        public List<Transaction> transactionPool = new List<Transaction>(); // List of pending transactions to be mined

        // Default Constructor - initialises the list of blocks and generates the genesis block
        public Blockchain()
        {
            // Initialise the blockchain with the Genesis Block
            blocks = new List<Block>()
            {
                new Block() // Create and append the Genesis Block
            };
        }

        // Method that returns the string representation of the block at the specified index
        public String GetBlockAsString(int index)
        {
            // Check if the block at the specified index exists
            if (index >= 0 && index < blocks.Count)
                return blocks[index].ToString(); // Return block as a string
            else
                return "No such block exists"; // Return error message
        }

        // Method that returns the most recently appended block in the blockchain
        public Block GetLastBlock()
        {
            return blocks[blocks.Count - 1]; // Return the last block in the chain
        }

        // Method that retrieves pending transactions and removes them from the transaction pool
        public List<Transaction> GetPendingTransactions()
        {
            // Determine the number of transactions to retrieve dependent on the number of pending transactions and the max specified
            int n = Math.Min(transactionsPerBlock, transactionPool.Count);

            // "Pull" transactions from the transaction pool and store them in a new list
            List<Transaction> transactions = transactionPool.GetRange(0, n);
            // Remove the extracted transactions from the pool
            transactionPool.RemoveRange(0, n);

            // Return the extracted transactions
            return transactions;
        }

        // Check validity of a blocks hash by recomputing the hash and comparing with the mined value
        public static bool ValidateHash(Block b)
        {
            String rehash = b.CreateHash();    // Recompute the hash for the block using the CreateHash() method of the block object
            return rehash.Equals(b.hash);      // Compare the re-computed hash with the original hash and return true if they match, false otherwise
        }

        public static bool ValidateMerkleRoot(Block b)
        {
            String reMerkle = Block.MerkleRoot(b.transactionList);   // Recalculate the Merkle root of the block using the MerkleRoot() method of the block object
            return reMerkle.Equals(b.merkleRoot);                    // Compare the re-calculated Merkle root with the original Merkle root and return true if they match, false otherwise
        }

        public double GetBalance(String address)
        {
            double balance = 0;     // Initialize the account balance to zero

            // Loop through all blocks and transactions to calculate the account balance
            foreach (Block b in blocks)
            {
                foreach (Transaction t in b.transactionList)
                {
                    if (t.recipientAddress.Equals(address))
                    {
                        balance += t.amount;   // Add the amount of the transaction to the account balance if the address is the recipient
                    }
                    if (t.senderAddress.Equals(address))
                    {
                        balance -= (t.amount + t.fee);  // Subtract the amount of the transaction plus the fee from the account balance if the address is the sender
                    }
                }
            }
            return balance;     // Return the final account balance
        }

        public override string ToString()
        {
            return String.Join("\n", blocks);   // Convert all blocks in the blockchain to a string representation and join them with a newline character
        }

    }
}
