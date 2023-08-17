using System.Text;
using System;
using System.Security.Cryptography;

namespace BlockchainAssignment
{
    class Transaction
    {
        DateTime timestamp; // store the time of creation for this transaction
        public String senderAddress, recipientAddress; // store public key addresses of the sender and recipient
        public double amount, fee; // store quantities transferred and the fee charged
        public String hash, signature; // attributes for verifying the validity of the transaction

        public Transaction(String from, String to, double amount, double fee, String privateKey)
        {
            timestamp = DateTime.Now; // set the current time as the timestamp

            senderAddress = from; // store the public key address of the sender
            recipientAddress = to; // store the public key address of the recipient

            this.amount = amount; // store the amount transferred
            this.fee = fee; // store the fee charged

            hash = CreateHash(); // create a hash for the transaction attributes
            signature = Wallet.Wallet.CreateSignature(from, privateKey, hash); // sign the hash with the sender's private key to ensure validity
        }

        public String CreateHash()
        {
            String hash = String.Empty;
            SHA256 hasher = SHA256Managed.Create(); // create a SHA256 hasher

            String input = timestamp + senderAddress + recipientAddress + amount + fee; // concatenate all transaction properties

            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes(input)); // apply the hash function to the concatenated string

            foreach (byte x in hashByte)
                hash += String.Format("{0:x2}", x); // reformat the hash byte array as a string

            return hash; // return the hash as a string
        }

        public override string ToString()
        {
            return "  [TRANSACTION START]"
                + "\n  Timestamp: " + timestamp // display the timestamp
                + "\n  -- Verification --"
                + "\n  Hash: " + hash // display the hash of the transaction attributes
                + "\n  Signature: " + signature // display the signature of the hash
                + "\n  -- Quantities --"
                + "\n  Transferred: " + amount + " Assignment Coin" // display the amount transferred
                + "\t  Fee: " + fee // display the fee charged
                + "\n  -- Participants --"
                + "\n  Sender: " + senderAddress // display the public key address of the sender
                + "\n  Reciever: " + recipientAddress // display the public key address of the recipient
                + "\n  [TRANSACTION END]";
        }
    }
}

