namespace BlockchainAssignment
{
    partial class BlockchainApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.output = new System.Windows.Forms.RichTextBox();
            this.printBlock = new System.Windows.Forms.Button();
            this.blockNo = new System.Windows.Forms.TextBox();
            this.generateWallet = new System.Windows.Forms.Button();
            this.publicKeyLabel = new System.Windows.Forms.Label();
            this.privateKeyLabel = new System.Windows.Forms.Label();
            this.publicKey = new System.Windows.Forms.TextBox();
            this.privateKey = new System.Windows.Forms.TextBox();
            this.validateKeys = new System.Windows.Forms.Button();
            this.createTransaction = new System.Windows.Forms.Button();
            this.fee = new System.Windows.Forms.TextBox();
            this.amount = new System.Windows.Forms.TextBox();
            this.feeLabel = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.reciever = new System.Windows.Forms.TextBox();
            this.recieverKeyLabel = new System.Windows.Forms.Label();
            this.newBlock = new System.Windows.Forms.Button();
            this.printBlockchain = new System.Windows.Forms.Button();
            this.readPendingTransactions = new System.Windows.Forms.Button();
            this.validate = new System.Windows.Forms.Button();
            this.checkBalance = new System.Windows.Forms.Button();
            this.currentWalletLabel = new System.Windows.Forms.Label();
            this.transactionLabel = new System.Windows.Forms.Label();
            this.blocksLabel = new System.Windows.Forms.Label();
            this.validationLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.addressToMine = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.SystemColors.InfoText;
            this.output.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.output.Location = new System.Drawing.Point(24, 23);
            this.output.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(916, 523);
            this.output.TabIndex = 0;
            this.output.Text = "";
            // 
            // printBlock
            // 
            this.printBlock.Location = new System.Drawing.Point(954, 123);
            this.printBlock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.printBlock.Name = "printBlock";
            this.printBlock.Size = new System.Drawing.Size(132, 48);
            this.printBlock.TabIndex = 1;
            this.printBlock.Text = "Block #";
            this.printBlock.UseVisualStyleBackColor = true;
            this.printBlock.Click += new System.EventHandler(this.PrintBlock_Click);
            // 
            // blockNo
            // 
            this.blockNo.Location = new System.Drawing.Point(1094, 131);
            this.blockNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.blockNo.Name = "blockNo";
            this.blockNo.Size = new System.Drawing.Size(44, 31);
            this.blockNo.TabIndex = 2;
            // 
            // generateWallet
            // 
            this.generateWallet.Location = new System.Drawing.Point(26, 602);
            this.generateWallet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.generateWallet.Name = "generateWallet";
            this.generateWallet.Size = new System.Drawing.Size(158, 106);
            this.generateWallet.TabIndex = 3;
            this.generateWallet.Text = "Generate New Wallet";
            this.generateWallet.UseVisualStyleBackColor = true;
            this.generateWallet.Click += new System.EventHandler(this.GenerateWallet_Click);
            // 
            // publicKeyLabel
            // 
            this.publicKeyLabel.AutoSize = true;
            this.publicKeyLabel.Location = new System.Drawing.Point(202, 627);
            this.publicKeyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.publicKeyLabel.Name = "publicKeyLabel";
            this.publicKeyLabel.Size = new System.Drawing.Size(114, 25);
            this.publicKeyLabel.TabIndex = 4;
            this.publicKeyLabel.Text = "Public Key";
            // 
            // privateKeyLabel
            // 
            this.privateKeyLabel.AutoSize = true;
            this.privateKeyLabel.Location = new System.Drawing.Point(194, 671);
            this.privateKeyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.privateKeyLabel.Name = "privateKeyLabel";
            this.privateKeyLabel.Size = new System.Drawing.Size(122, 25);
            this.privateKeyLabel.TabIndex = 5;
            this.privateKeyLabel.Text = "Private Key";
            // 
            // publicKey
            // 
            this.publicKey.Location = new System.Drawing.Point(314, 619);
            this.publicKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.publicKey.Name = "publicKey";
            this.publicKey.Size = new System.Drawing.Size(374, 31);
            this.publicKey.TabIndex = 6;
            // 
            // privateKey
            // 
            this.privateKey.Location = new System.Drawing.Point(314, 665);
            this.privateKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.privateKey.Name = "privateKey";
            this.privateKey.Size = new System.Drawing.Size(374, 31);
            this.privateKey.TabIndex = 7;
            // 
            // validateKeys
            // 
            this.validateKeys.Location = new System.Drawing.Point(700, 619);
            this.validateKeys.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.validateKeys.Name = "validateKeys";
            this.validateKeys.Size = new System.Drawing.Size(174, 42);
            this.validateKeys.TabIndex = 8;
            this.validateKeys.Text = "Validate Keys";
            this.validateKeys.UseVisualStyleBackColor = true;
            this.validateKeys.Click += new System.EventHandler(this.ValidateKeys_Click);
            // 
            // createTransaction
            // 
            this.createTransaction.Location = new System.Drawing.Point(959, 448);
            this.createTransaction.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.createTransaction.Name = "createTransaction";
            this.createTransaction.Size = new System.Drawing.Size(390, 50);
            this.createTransaction.TabIndex = 9;
            this.createTransaction.Text = "Create Transaction";
            this.createTransaction.UseVisualStyleBackColor = true;
            this.createTransaction.Click += new System.EventHandler(this.CreateTransaction_Click);
            // 
            // fee
            // 
            this.fee.Location = new System.Drawing.Point(1266, 362);
            this.fee.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fee.Name = "fee";
            this.fee.Size = new System.Drawing.Size(68, 31);
            this.fee.TabIndex = 13;
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(1120, 362);
            this.amount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(68, 31);
            this.amount.TabIndex = 12;
            // 
            // feeLabel
            // 
            this.feeLabel.AutoSize = true;
            this.feeLabel.Location = new System.Drawing.Point(1209, 365);
            this.feeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.feeLabel.Name = "feeLabel";
            this.feeLabel.Size = new System.Drawing.Size(49, 25);
            this.feeLabel.TabIndex = 11;
            this.feeLabel.Text = "Fee";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(1028, 362);
            this.amountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(85, 25);
            this.amountLabel.TabIndex = 10;
            this.amountLabel.Text = "Amount";
            // 
            // reciever
            // 
            this.reciever.Location = new System.Drawing.Point(1120, 401);
            this.reciever.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reciever.Name = "reciever";
            this.reciever.Size = new System.Drawing.Size(226, 31);
            this.reciever.TabIndex = 15;
            // 
            // recieverKeyLabel
            // 
            this.recieverKeyLabel.AutoSize = true;
            this.recieverKeyLabel.Location = new System.Drawing.Point(973, 407);
            this.recieverKeyLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.recieverKeyLabel.Name = "recieverKeyLabel";
            this.recieverKeyLabel.Size = new System.Drawing.Size(140, 25);
            this.recieverKeyLabel.TabIndex = 14;
            this.recieverKeyLabel.Text = "Reciever Key";
            // 
            // newBlock
            // 
            this.newBlock.Location = new System.Drawing.Point(956, 63);
            this.newBlock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.newBlock.Name = "newBlock";
            this.newBlock.Size = new System.Drawing.Size(392, 50);
            this.newBlock.TabIndex = 16;
            this.newBlock.Text = "Generate New Block";
            this.newBlock.UseVisualStyleBackColor = true;
            this.newBlock.Click += new System.EventHandler(this.NewBlock_Click);
            // 
            // printBlockchain
            // 
            this.printBlockchain.Location = new System.Drawing.Point(1150, 123);
            this.printBlockchain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.printBlockchain.Name = "printBlockchain";
            this.printBlockchain.Size = new System.Drawing.Size(198, 48);
            this.printBlockchain.TabIndex = 17;
            this.printBlockchain.Text = "Entire Chain";
            this.printBlockchain.UseVisualStyleBackColor = true;
            this.printBlockchain.Click += new System.EventHandler(this.ReadAll_Click);
            // 
            // readPendingTransactions
            // 
            this.readPendingTransactions.Location = new System.Drawing.Point(956, 517);
            this.readPendingTransactions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.readPendingTransactions.Name = "readPendingTransactions";
            this.readPendingTransactions.Size = new System.Drawing.Size(390, 48);
            this.readPendingTransactions.TabIndex = 18;
            this.readPendingTransactions.Text = "Read Pending Transactions";
            this.readPendingTransactions.UseVisualStyleBackColor = true;
            this.readPendingTransactions.Click += new System.EventHandler(this.PrintPendingTransactions_Click);
            // 
            // validate
            // 
            this.validate.Location = new System.Drawing.Point(942, 616);
            this.validate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.validate.Name = "validate";
            this.validate.Size = new System.Drawing.Size(392, 88);
            this.validate.TabIndex = 19;
            this.validate.Text = "Full Blockchain Validation";
            this.validate.UseVisualStyleBackColor = true;
            this.validate.Click += new System.EventHandler(this.Validate_Click);
            // 
            // checkBalance
            // 
            this.checkBalance.Location = new System.Drawing.Point(700, 658);
            this.checkBalance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBalance.Name = "checkBalance";
            this.checkBalance.Size = new System.Drawing.Size(174, 46);
            this.checkBalance.TabIndex = 20;
            this.checkBalance.Text = "Check Balance";
            this.checkBalance.UseVisualStyleBackColor = true;
            this.checkBalance.Click += new System.EventHandler(this.CheckBalance_Click);
            // 
            // currentWalletLabel
            // 
            this.currentWalletLabel.AutoSize = true;
            this.currentWalletLabel.Location = new System.Drawing.Point(22, 573);
            this.currentWalletLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentWalletLabel.Name = "currentWalletLabel";
            this.currentWalletLabel.Size = new System.Drawing.Size(149, 25);
            this.currentWalletLabel.TabIndex = 22;
            this.currentWalletLabel.Text = "Current Wallet";
            // 
            // transactionLabel
            // 
            this.transactionLabel.AutoSize = true;
            this.transactionLabel.Location = new System.Drawing.Point(977, 333);
            this.transactionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.transactionLabel.Name = "transactionLabel";
            this.transactionLabel.Size = new System.Drawing.Size(136, 25);
            this.transactionLabel.TabIndex = 23;
            this.transactionLabel.Text = "Transactions";
            // 
            // blocksLabel
            // 
            this.blocksLabel.AutoSize = true;
            this.blocksLabel.Location = new System.Drawing.Point(954, 23);
            this.blocksLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.blocksLabel.Name = "blocksLabel";
            this.blocksLabel.Size = new System.Drawing.Size(76, 25);
            this.blocksLabel.TabIndex = 24;
            this.blocksLabel.Text = "Blocks";
            // 
            // validationLabel
            // 
            this.validationLabel.AutoSize = true;
            this.validationLabel.Location = new System.Drawing.Point(959, 587);
            this.validationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.validationLabel.Name = "validationLabel";
            this.validationLabel.Size = new System.Drawing.Size(107, 25);
            this.validationLabel.TabIndex = 25;
            this.validationLabel.Text = "Validation";
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "None";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Random",
            "Altruistic",
            "Greedy",
            "By Address"});
            this.comboBox1.Location = new System.Drawing.Point(964, 216);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(380, 33);
            this.comboBox1.TabIndex = 26;
            this.comboBox1.Text = "Mining Preference";
            this.comboBox1.ValueMember = "None";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // addressToMine
            // 
            this.addressToMine.Location = new System.Drawing.Point(959, 270);
            this.addressToMine.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.addressToMine.Name = "addressToMine";
            this.addressToMine.Size = new System.Drawing.Size(380, 31);
            this.addressToMine.TabIndex = 27;
            this.addressToMine.Text = "Specific address";
            this.addressToMine.TextChanged += new System.EventHandler(this.addressFind_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(962, 175);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 25);
            this.label1.TabIndex = 28;
            this.label1.Text = "Mining preference";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // BlockchainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1408, 728);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addressToMine);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.validationLabel);
            this.Controls.Add(this.blocksLabel);
            this.Controls.Add(this.transactionLabel);
            this.Controls.Add(this.currentWalletLabel);
            this.Controls.Add(this.checkBalance);
            this.Controls.Add(this.validate);
            this.Controls.Add(this.readPendingTransactions);
            this.Controls.Add(this.printBlockchain);
            this.Controls.Add(this.newBlock);
            this.Controls.Add(this.reciever);
            this.Controls.Add(this.recieverKeyLabel);
            this.Controls.Add(this.fee);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.feeLabel);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.createTransaction);
            this.Controls.Add(this.validateKeys);
            this.Controls.Add(this.privateKey);
            this.Controls.Add(this.publicKey);
            this.Controls.Add(this.privateKeyLabel);
            this.Controls.Add(this.publicKeyLabel);
            this.Controls.Add(this.generateWallet);
            this.Controls.Add(this.blockNo);
            this.Controls.Add(this.printBlock);
            this.Controls.Add(this.output);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "BlockchainApp";
            this.Text = "Blockchain App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.Button printBlock;
        private System.Windows.Forms.TextBox blockNo;
        private System.Windows.Forms.Button generateWallet;
        private System.Windows.Forms.Label publicKeyLabel;
        private System.Windows.Forms.Label privateKeyLabel;
        private System.Windows.Forms.TextBox publicKey;
        private System.Windows.Forms.TextBox privateKey;
        private System.Windows.Forms.Button validateKeys;
        private System.Windows.Forms.Button createTransaction;
        private System.Windows.Forms.TextBox fee;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.Label feeLabel;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.TextBox reciever;
        private System.Windows.Forms.Label recieverKeyLabel;
        private System.Windows.Forms.Button newBlock;
        private System.Windows.Forms.Button printBlockchain;
        private System.Windows.Forms.Button readPendingTransactions;
        private System.Windows.Forms.Button validate;
        private System.Windows.Forms.Button checkBalance;
        private System.Windows.Forms.Label currentWalletLabel;
        private System.Windows.Forms.Label transactionLabel;
        private System.Windows.Forms.Label blocksLabel;
        private System.Windows.Forms.Label validationLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox addressToMine;
        private System.Windows.Forms.Label label1;
    }
}

