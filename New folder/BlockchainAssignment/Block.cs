using System;
using System.Security.Cryptography;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockchainAssignment
{
    class Block
    {
        // Define private variables
        private DateTime timestamp; // Time of block creation
        private int index, difficulty = 4; // Block index and difficulty
        
        // Define public variables
        public String prevHash, // Hash of the previous block
            hash, // Hash of the current block
            merkleRoot,  // Merkle root of the block's transaction list
            minerAddress; // Address of the miner who mined this block

        public List<Transaction> transactionList; // List of transactions in the block
        
        // Variables used for threading
        public Boolean useThreading = true;
        public string hashFin, hashFinTOne, hashFinTTwo;
        private bool firstThread = false, secondThread = false;
        public int tNonceOne = 0, tNonceTwo = 1;

        public long nonce; // Nonce used for mining
        public double reward; // Reward for mining the block
        
        // Constructor for the genesis block
        public Block()
        {
            timestamp = DateTime.Now;
            index = 0;
            transactionList = new List<Transaction>();
            
            // If threading is enabled, mine using threads
            if (useThreading == true)
            {
                this.mineThread();
                this.hash = this.hashFin;
            }
            // Otherwise, mine using a single thread
            else this.hash = this.NewHashCr();
        }

        // This constructor creates a new block object and sets its properties
        public Block(Block lastBlock, List<Transaction> TPool, string MinerAddress, int setting, string address)
        {
            // Initialize the transaction list, nonce, and timestamp properties
            this.transactionList = new List<Transaction>();
            this.nonce = 0;
            this.timestamp = DateTime.Now;

            // Set the block's difficulty, index, and prevHash properties based on the previous block's values
            this.difficulty = lastBlock.difficulty;
            this.difficultyAdjust(lastBlock.timestamp);
            this.index = lastBlock.index + 1;
            this.prevHash = lastBlock.hash;

            // Set the minerAddress property to the address of the miner who created this block
            this.minerAddress = MinerAddress;

            // Add a new reward transaction to the transaction pool
            TPool.Add(createRewardTransaction(TPool));

            // Mine the block using the transaction pool, setting, and address parameters
            this.mineSelection(TPool, setting, address);

            // Set the merkleRoot property of the block based on the transaction list
            this.merkleRoot = MerkleRoot(transactionList);

            // If the useThreading property is true, start a new thread to mine the block and set the hash property to the final hash
            if (useThreading == true)
            {
                this.mineThread();
                this.hash = this.hashFin;
            }
            // Otherwise, use the NewMineCr method to mine the block and set the hash property
            else
                this.hash = this.NewMineCr();
        }

        /* Hashes the entire Block object */
        public String CreateHash()
        {
            // Initialize the hash string and the SHA256 hasher
            String hash = String.Empty;
            SHA256 hasher = SHA256Managed.Create();

            /* Concatenate all of the blocks properties including nonce as to generate a new hash on each call */
            // Create a string containing the block's timestamp, index, prevHash, nonce, and merkleRoot properties
            String input = timestamp.ToString() + index + prevHash + nonce + merkleRoot;

            /* Apply the hash function to the block as represented by the string "input" */
            // Compute the SHA256 hash of the input string
            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes(input));

            /* Reformat to a string */
            // Convert the hash bytes to a hexadecimal string representation
            foreach (byte x in hashByte)
                hash += String.Format("{0:x2}", x);

            // Return the hash string
            return hash;
        }

        // Create a Hash which satisfies the difficulty level required for PoW
        public String Mine()
        {
            // Initialize the nonce to 0 and hash the block
            nonce = 0; // Initalise the nonce
            String hash = CreateHash(); // Hash the block

            // Create a string of zeros of length equal to the block's difficulty level
            String re = new string('0', difficulty); // A string for analysing the PoW requirement

            // Repeatedly increment the nonce and rehash the block until a hash is found that meets the difficulty requirement
            while (!hash.StartsWith(re)) // Check the resultant hash against the "re" string
            {
                nonce++; // Increment the nonce should the difficulty level not be satisfied
                hash = CreateHash(); // Rehash with the new nonce as to generate a different hash
            }

            // Return the hash that meets the difficulty requirement
            return hash; // Return the hash meeting the difficulty requirement
        }


        // Merkle Root Algorithm - Encodes transactions within a block into a single hash
        public static String MerkleRoot(List<Transaction> transactionList)
        {
            List<String> hashes = transactionList.Select(t => t.hash).ToList(); // Get list of transaction hashes for "combining"
            
            // Handle Blocks with
            if (hashes.Count == 0) // No transactions
            {
                return String.Empty;
            }
            if (hashes.Count == 1) // One transaction - hash with "self"
            {
                return HashCode.HashTools.combineHash(hashes[0], hashes[0]);
            }
            while (hashes.Count != 1) // Multiple transactions - Repeat until tree traversed
            {
                List<String> merkleLeaves = new List<String>(); // Keep track current "level" of the tree

                for (int i=0; i<hashes.Count; i+=2) // Step over neighbouring pair combining each
                {
                    if (i == hashes.Count - 1)
                    {
                        merkleLeaves.Add(HashCode.HashTools.combineHash(hashes[i], hashes[i])); // Handle odd number of leaves
                    }
                    else
                    {
                        merkleLeaves.Add(HashCode.HashTools.combineHash(hashes[i], hashes[i + 1])); // Hash neighbours leaves
                    }
                }
                hashes = merkleLeaves; // Update working "layer"
            }
            return hashes[0]; // Return  root node
        }

        // Create reward for incentivising the mining of block
        public Transaction createRewardTransaction(List<Transaction> transactions)
        {
            double fees = transactions.Aggregate(0.0, (acc, t) => acc + t.fee); // Sum all transaction fees
            return new Transaction("Mine Rewards", minerAddress, (reward + fees), 0, ""); // Issue reward as a transaction in the new block
        }

        /* Concatenate properties to output to the UI */
        public override string ToString()
        {
            return "[BLOCK START]"
                + "\nIndex: " + index
                + "\tTimestamp: " + timestamp
                + "\nPrevious Hash: " + prevHash
                + "\n-- PoW --"
                + "\nDifficulty Level: " + difficulty
                + "\nNonce: " + nonce
                + "\nHash: " + hash
                + "\n-- Rewards --"
                + "\nReward: " + reward
                + "\nMiners Address: " + minerAddress
                + "\n-- " + transactionList.Count + " Transactions --"
                +"\nMerkle Root: " + merkleRoot
                + "\n" + String.Join("\n", transactionList)
                + "\n[BLOCK END]";
        }

        //MultiThreading 
        public String NewHashCreate(int inNonce)
        {
            // Create a SHA256 hash object
            SHA256 hasher;
            hasher = SHA256Managed.Create();

            // Construct the input string by concatenating various properties of the block and the input nonce
            String input = this.index.ToString() + this.timestamp.ToString() + this.prevHash + inNonce + this.merkleRoot + this.reward.ToString();

            // Compute the hash of the input string
            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes((input)));

            // Convert the hash bytes to a hex string
            String hash = string.Empty;
            foreach (byte x in hashByte)
            {
                hash += String.Format("{0:x2}", x);
            }

            // Return the hex string representation of the hash
            return hash;
        }

        public string NewHashCr()
        {
            // Create a SHA256 hash object
            SHA256 hasher;
            hasher = SHA256Managed.Create();

            // Construct the input string by concatenating various properties of the block
            String input = this.index.ToString() + this.timestamp.ToString() + this.prevHash + this.nonce + this.merkleRoot + this.reward.ToString();

            // Compute the hash of the input string
            Byte[] hashByte = hasher.ComputeHash(Encoding.UTF8.GetBytes((input)));

            // Convert the hash bytes to a hex string
            String hash = string.Empty;
            foreach (byte x in hashByte)
            {
                hash += String.Format("{0:x2}", x);
            }

            // Return the hex string representation of the hash
            return hash;
        }


        private string NewMineCr()
        {
            //Initialize variables
            string hash = "";
            string diffString = new string('0', this.difficulty);

            //Loop until the hash starts with the required number of zeroes
            while (hash.StartsWith(diffString) == false)
            {
                //Generate a new hash and increment the nonce
                hash = this.NewHashCr();
                this.nonce++;
            }

            //Decrease the nonce since the correct hash has been found
            this.nonce--;

            //If the hash is null, throw an exception
            if (hash is null)
            {
                throw new IndexOutOfRangeException("No hash generated");
            }

            //Return the correct hash
            return hash;
        }

        public void mineThread()
        {
            //Create two threads for mining
            Thread threadski1 = new Thread(this.mineThreadOne), threadski2 = new Thread(this.mineThreadTwo); ;

            //Start the threads
            threadski1.Start();
            threadski2.Start();

            //Wait until both threads are done
            while (threadski1.IsAlive == true || threadski2.IsAlive == true) { Thread.Sleep(1); }

            //Choose the hash with the correct number of leading zeroes
            if (this.hashFinTTwo is null)
            {
                //Use the hash from the first thread
                this.nonce = this.tNonceOne;
                this.hashFin = this.hashFinTOne;
            }
            else
            {
                //Use the hash from the second thread
                this.nonce = this.tNonceTwo;
                this.hashFin = this.hashFinTTwo;
            }

            //If the final hash is null, throw an exception and print out relevant information
            if (this.hashFin is null)
            {
                Console.WriteLine(this.ToString());
                throw new Exception("hash NULL" +
                    " N Thread 1 = " + this.tNonceOne +
                    " N Thread 2 = " + this.tNonceTwo +
                    " val Nonce = " + this.nonce +
                    " finalHashThreadOne = " + this.hashFinTOne +
                    " finalHashThreadTwo = " + this.hashFinTTwo +
                    " NewHash = " + this.NewHashCr());
            }
        }


        public void mineThreadOne()
        {
            Stopwatch stopWatch = new Stopwatch(); // create a new stopwatch to measure elapsed time
            firstThread = false; // set firstThread flag to false
            stopWatch.Start(); // start the stopwatch
            Boolean boolCheck = false;
            String newHash, stringDifferent = new string('0', this.difficulty); // create a string of zeros of length "difficulty"

            // continue looping until boolCheck is true
            while (boolCheck == false)
            {
                newHash = NewHashCreate(this.tNonceOne); // generate a new hash using the current tNonceOne value
                if (newHash.StartsWith(stringDifferent) == true) // check if the hash starts with "difficulty" zeros
                {
                    boolCheck = true; // if it does, set boolCheck to true to exit the loop
                    this.hashFinTOne = newHash; // set the hashFinTOne value to the newly generated hash
                    Console.WriteLine("Index of block = " + this.index);
                    Console.WriteLine("Thread 1 finished - Thread 1 next: " + this.hashFinTOne);
                    firstThread = true; // set the firstThread flag to true

                    Console.WriteLine(tNonceOne);
                    stopWatch.Stop(); // stop the stopwatch
                    Console.WriteLine("Elapsed time of thread 1:");
                    Console.WriteLine(stopWatch.Elapsed); // print the elapsed time

                    return; // exit the method
                }
                else if (secondThread == true) // if secondThread flag is set to true
                {
                    Console.WriteLine("Thread 1 done - Thread 2 next: " + this.hashFinTTwo);
                    Thread.Sleep(1); // wait for a short time
                    return; // exit the method
                }
                else // if neither condition is met
                {
                    boolCheck = false; // set boolCheck to false to continue looping
                    this.tNonceOne += 2; // increment tNonceOne by 2 for next hash generation
                }
            }
            return; // exit the method
        }

        public void mineThreadTwo()
        {
            Stopwatch sw = new Stopwatch(); // create a new stopwatch to measure elapsed time
            secondThread = false; // set secondThread flag to false
            sw.Start(); // start the stopwatch
            Boolean check = false;
            String newHash, diffString = new string('0', this.difficulty); // create a string of zeros of length "difficulty"

            // continue looping until check is true
            while (check == false)
            {
                newHash = NewHashCreate(this.tNonceTwo); // generate a new hash using the current tNonceTwo value
                if (newHash.StartsWith(diffString) == true) // check if the hash starts with "difficulty" zeros
                {
                    check = true; // if it does, set check to true to exit the loop
                    this.hashFinTTwo = newHash; // set the hashFinTTwo value to the newly generated hash
                    Console.WriteLine("Index of Block = " + this.index);
                    Console.WriteLine("Thread 2 finished - Thread 2 next: " + this.hashFinTTwo);
                    secondThread = true; // set the secondThread flag to true

                    Console.WriteLine(this.tNonceTwo);
                    sw.Stop(); // stop the stopwatch
                    Console.WriteLine("Elapsed time of thread 2:");
                    Console.WriteLine(sw.Elapsed); // print the elapsed time

                    return; // exit the method
                }
                else if (firstThread == true) // if firstThread flag is set to true
                {
                    Console.WriteLine("Thread 2 done - Thread 1 next: " + this.hashFinTOne);
                    Thread.Sleep(1);
                    return;
                }
                else
                {
                    check = false;
                    this.tNonceTwo += 2;
                }
            }
            return;
        }

        public string ReturnString()
        {
            return ("\n\n\t\t[BLOCK START]"
                + "\nIndex: " + this.index
                + "\tTimestamp: " + this.timestamp
                + "\nPrevious Hash: " + this.prevHash
                + "\n\t\t-- PoW --"
                + "\nDifficulty Level: " + this.difficulty
                + "\nNonce: " + this.nonce
                + "\nHash: " + this.hash
                + "\n\t\t-- Rewards --"
                + "\nReward: " + this.reward
                + "\nMiners Address: " + this.minerAddress
                + "\n\t\t-- " + this.transactionList.Count + " Transactions --"
                + "\nMerkle Root: " + this.merkleRoot
                + "\n" + String.Join("\n", this.transactionList)
                + "\n\t\t[BLOCK END]");

        }


        //Difficulty changer
        public void difficultyAdjust(DateTime lastTime)
        {
            //Get the current UTC time and calculate the time difference between it and the last time
            DateTime startTime = DateTime.UtcNow;
            TimeSpan timeDiff = startTime - lastTime;

            //Check if the difficulty is too high and set it to a maximum of 4
            if (this.difficulty >= 6)
            {
                this.difficulty = 4;
                Console.WriteLine("Warning, High Difficulty set at: " + this.difficulty);
            }

            //Check if the difficulty is too low and set it to a minimum of 0
            else if (this.difficulty <= 0)
            {
                this.difficulty = 0;
                Console.WriteLine("Difficulty cannot be less than 0, set at: " + this.difficulty);
            }

            //If the time difference between the last block and the current time is less than 10 seconds, increase the difficulty by 1
            if (timeDiff < TimeSpan.FromSeconds(10))
            {
                this.difficulty++;
                Console.WriteLine("The time since the last block " + timeDiff);
                Console.WriteLine("Difficulty increased and set to: " + this.difficulty);
            }

            //If the time difference between the last block and the current time is more than 5 seconds, decrease the difficulty by 1
            else if (timeDiff > TimeSpan.FromSeconds(5))
            {
                difficulty--;
                Console.WriteLine("Time since last block- " + timeDiff);
                Console.WriteLine("Difficulty decreased to: " + this.difficulty);
            }
        }

        //Settings for mining
        public void mineSelection(List<Transaction> transactionPool, int selection, string address)
        {
            //Set the maximum number of transactions to mine to 5 and initialize the transaction to mine ID to 0
            int mx = 5, idToMine = 0;

            //Loop until either the maximum number of transactions to mine has been reached or there are no more transactions left in the pool
            while (transactionList.Count < mx && transactionPool.Count > 0)
            {
                //If the selection type is random, randomly select a transaction from the pool and add it to the transaction list to mine
                if (selection == 0)
                {
                    //Random     
                    Random rand = new Random();
                    idToMine = rand.Next(0, transactionPool.Count);
                    this.transactionList.Add(transactionPool.ElementAt(idToMine));
                }

                //If the selection type is altruistic, add the first 5 transactions from the pool to the transaction list to mine
                else if (selection == 1)
                {
                    //Altruistic
                    for (int x = 0; ((x < transactionPool.Count) && (x < mx)); x++)
                    {
                        this.transactionList.Add(transactionPool.ElementAt(x));
                    }
                }

                //If the selection type is by specified address, add transactions to the transaction list to mine if either the sender or recipient address matches the specified address
                else if (selection == 3)
                {
                    //By specified address
                    for (int y = 0; y < transactionPool.Count && (transactionList.Count < mx); y++)
                    {
                        if (transactionPool.ElementAt(y).senderAddress == address)
                        {
                            this.transactionList.Add(transactionPool.ElementAt(y));
                        }
                        else if (transactionPool.ElementAt(y).recipientAddress == address)
                        {
                            this.transactionList.Add(transactionPool.ElementAt(y));
                        }

                    }
                    Console.WriteLine("Cannot mine this address!");
                }

                //If the selection type is greedy, select the transaction with the highest fee 

                else if (selection == 2)
                {
                    //Greedy
                    for (int z = 0; ((z < transactionPool.Count)); z++)
                    {
                        if (transactionPool.ElementAt(z).fee > transactionPool.ElementAt(idToMine).fee)
                        {
                            idToMine = z;
                        }
                    }
                    this.transactionList.Add(transactionPool.ElementAt(idToMine));
                }
                else
                {
                    //If nothing is specified, default to altruistic
                    selection = 1;
                }
                transactionPool = transactionPool.Except(this.transactionList).ToList();
            }
        }




    }
}
