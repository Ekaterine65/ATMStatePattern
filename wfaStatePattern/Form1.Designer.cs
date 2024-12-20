namespace wfaStatePattern
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnInsertPin = new Button();
            txtPin = new TextBox();
            txtAmount = new TextBox();
            txtReloadAmount = new TextBox();
            btnWithdraw = new Button();
            btnReloadCash = new Button();
            btnFixConnection = new Button();
            btnExit = new Button();
            lblStatus = new Label();
            lblMessage = new Label();
            SuspendLayout();
            // 
            // btnInsertPin
            // 
            btnInsertPin.Location = new Point(12, 166);
            btnInsertPin.Name = "btnInsertPin";
            btnInsertPin.Size = new Size(160, 76);
            btnInsertPin.TabIndex = 0;
            btnInsertPin.Text = "Ввести пин-код";
            btnInsertPin.UseVisualStyleBackColor = true;
            btnInsertPin.Click += btnInsertPin_Click;
            // 
            // txtPin
            // 
            txtPin.Location = new Point(12, 117);
            txtPin.Name = "txtPin";
            txtPin.Size = new Size(160, 27);
            txtPin.TabIndex = 1;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(204, 117);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(154, 27);
            txtAmount.TabIndex = 2;
            // 
            // txtReloadAmount
            // 
            txtReloadAmount.Location = new Point(397, 117);
            txtReloadAmount.Name = "txtReloadAmount";
            txtReloadAmount.Size = new Size(157, 27);
            txtReloadAmount.TabIndex = 3;
            // 
            // btnWithdraw
            // 
            btnWithdraw.Location = new Point(201, 166);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.Size = new Size(157, 76);
            btnWithdraw.TabIndex = 4;
            btnWithdraw.Text = "Снять введенную сумму";
            btnWithdraw.UseVisualStyleBackColor = true;
            btnWithdraw.Click += BtnWithdraw_Click;
            // 
            // btnReloadCash
            // 
            btnReloadCash.Location = new Point(397, 166);
            btnReloadCash.Name = "btnReloadCash";
            btnReloadCash.Size = new Size(157, 76);
            btnReloadCash.TabIndex = 5;
            btnReloadCash.Text = "Пополнить банкомат";
            btnReloadCash.UseVisualStyleBackColor = true;
            btnReloadCash.Click += BtnReloadCash_Click;
            // 
            // btnFixConnection
            // 
            btnFixConnection.Location = new Point(15, 283);
            btnFixConnection.Name = "btnFixConnection";
            btnFixConnection.Size = new Size(157, 76);
            btnFixConnection.TabIndex = 6;
            btnFixConnection.Text = "Восстановить связь";
            btnFixConnection.UseVisualStyleBackColor = true;
            btnFixConnection.Click += BtnFixConnection_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(204, 283);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(157, 76);
            btnExit.TabIndex = 7;
            btnExit.Text = "Завершить сеанс";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += BtnExit_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 26);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(83, 20);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "Состояние";
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(349, 17);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(259, 20);
            lblMessage.TabIndex = 9;
            lblMessage.Text = "Введите PIN-код для начала работы";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblMessage);
            Controls.Add(lblStatus);
            Controls.Add(btnExit);
            Controls.Add(btnFixConnection);
            Controls.Add(btnReloadCash);
            Controls.Add(btnWithdraw);
            Controls.Add(txtReloadAmount);
            Controls.Add(txtAmount);
            Controls.Add(txtPin);
            Controls.Add(btnInsertPin);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnInsertPin;
        private TextBox txtPin;
        private TextBox txtAmount;
        private TextBox txtReloadAmount;
        private Button btnWithdraw;
        private Button btnReloadCash;
        private Button btnFixConnection;
        private Button btnExit;
        private Label lblStatus;
        private Label lblMessage;
    }
}
