namespace ControlAguaPotable
{
    partial class PaymentMethodWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentMethodWindow));
            tableLayoutPanel1 = new TableLayoutPanel();
            Income = new GroupBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            moneyLabel = new Label();
            money = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            bsNumeric = new NumericUpDown();
            dollarsNumeric = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            withdrawal = new GroupBox();
            tableLayoutPanel6 = new TableLayoutPanel();
            withdrawalLabel = new Label();
            withdrawalMoney = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            bsWithdrawalNumeric = new NumericUpDown();
            dollarsWithdrawalNumeric = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            clnBtn = new Button();
            acceptBtn = new Button();
            tableLayoutPanel7 = new TableLayoutPanel();
            cashCheckBox = new CheckBox();
            bankCheckBox = new CheckBox();
            tableLayoutPanel8 = new TableLayoutPanel();
            cashCheckBox2 = new CheckBox();
            bankCheckBox2 = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            Income.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bsNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dollarsNumeric).BeginInit();
            withdrawal.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bsWithdrawalNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dollarsWithdrawalNumeric).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(Income, 0, 0);
            tableLayoutPanel1.Controls.Add(withdrawal, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(618, 460);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // Income
            // 
            Income.Controls.Add(tableLayoutPanel7);
            Income.Controls.Add(tableLayoutPanel5);
            Income.Controls.Add(tableLayoutPanel3);
            Income.Dock = DockStyle.Fill;
            Income.Location = new Point(3, 3);
            Income.Name = "Income";
            Income.Size = new Size(612, 224);
            Income.TabIndex = 0;
            Income.TabStop = false;
            Income.Text = "Entrada:";
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.Anchor = AnchorStyles.Right;
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(moneyLabel, 0, 0);
            tableLayoutPanel5.Controls.Add(money, 0, 1);
            tableLayoutPanel5.Location = new Point(367, 58);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(236, 125);
            tableLayoutPanel5.TabIndex = 1;
            // 
            // moneyLabel
            // 
            moneyLabel.Anchor = AnchorStyles.None;
            moneyLabel.AutoSize = true;
            moneyLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            moneyLabel.ForeColor = Color.Red;
            moneyLabel.Location = new Point(19, 15);
            moneyLabel.Name = "moneyLabel";
            moneyLabel.Size = new Size(197, 31);
            moneyLabel.TabIndex = 0;
            moneyLabel.Text = "Monto (Bs/USD):";
            // 
            // money
            // 
            money.Anchor = AnchorStyles.None;
            money.AutoSize = true;
            money.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            money.Location = new Point(93, 78);
            money.Name = "money";
            money.Size = new Size(50, 31);
            money.TabIndex = 1;
            money.Text = "0/0";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.Anchor = AnchorStyles.Left;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(bsNumeric, 1, 0);
            tableLayoutPanel3.Controls.Add(dollarsNumeric, 1, 1);
            tableLayoutPanel3.Controls.Add(label1, 0, 0);
            tableLayoutPanel3.Controls.Add(label2, 0, 1);
            tableLayoutPanel3.Location = new Point(9, 58);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel3.Size = new Size(341, 125);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // bsNumeric
            // 
            bsNumeric.Anchor = AnchorStyles.Left;
            bsNumeric.DecimalPlaces = 2;
            bsNumeric.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            bsNumeric.Location = new Point(173, 14);
            bsNumeric.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            bsNumeric.Name = "bsNumeric";
            bsNumeric.Size = new Size(154, 34);
            bsNumeric.TabIndex = 3;
            bsNumeric.TextAlign = HorizontalAlignment.Center;
            bsNumeric.ValueChanged += bsNumeric_ValueChanged;
            // 
            // dollarsNumeric
            // 
            dollarsNumeric.Anchor = AnchorStyles.Left;
            dollarsNumeric.DecimalPlaces = 2;
            dollarsNumeric.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            dollarsNumeric.Location = new Point(173, 76);
            dollarsNumeric.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            dollarsNumeric.Name = "dollarsNumeric";
            dollarsNumeric.Size = new Size(154, 34);
            dollarsNumeric.TabIndex = 4;
            dollarsNumeric.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(68, 17);
            label1.Name = "label1";
            label1.Size = new Size(34, 28);
            label1.TabIndex = 6;
            label1.Text = "Bs";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(43, 79);
            label2.Name = "label2";
            label2.Size = new Size(84, 28);
            label2.TabIndex = 7;
            label2.Text = "Dólares";
            // 
            // withdrawal
            // 
            withdrawal.Controls.Add(tableLayoutPanel8);
            withdrawal.Controls.Add(tableLayoutPanel6);
            withdrawal.Controls.Add(tableLayoutPanel4);
            withdrawal.Dock = DockStyle.Fill;
            withdrawal.Location = new Point(3, 233);
            withdrawal.Name = "withdrawal";
            withdrawal.Size = new Size(612, 224);
            withdrawal.TabIndex = 1;
            withdrawal.TabStop = false;
            withdrawal.Text = "Salida:";
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.Anchor = AnchorStyles.Right;
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(withdrawalLabel, 0, 0);
            tableLayoutPanel6.Controls.Add(withdrawalMoney, 0, 1);
            tableLayoutPanel6.Location = new Point(367, 55);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(236, 125);
            tableLayoutPanel6.TabIndex = 1;
            // 
            // withdrawalLabel
            // 
            withdrawalLabel.Anchor = AnchorStyles.None;
            withdrawalLabel.AutoSize = true;
            withdrawalLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            withdrawalLabel.ForeColor = Color.Red;
            withdrawalLabel.Location = new Point(21, 15);
            withdrawalLabel.Name = "withdrawalLabel";
            withdrawalLabel.Size = new Size(194, 31);
            withdrawalLabel.TabIndex = 0;
            withdrawalLabel.Text = "Vuelto (Bs/USD):";
            // 
            // withdrawalMoney
            // 
            withdrawalMoney.Anchor = AnchorStyles.None;
            withdrawalMoney.AutoSize = true;
            withdrawalMoney.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            withdrawalMoney.Location = new Point(93, 78);
            withdrawalMoney.Name = "withdrawalMoney";
            withdrawalMoney.Size = new Size(50, 31);
            withdrawalMoney.TabIndex = 1;
            withdrawalMoney.Text = "0/0";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.Anchor = AnchorStyles.Left;
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(bsWithdrawalNumeric, 1, 0);
            tableLayoutPanel4.Controls.Add(dollarsWithdrawalNumeric, 1, 1);
            tableLayoutPanel4.Controls.Add(label4, 0, 0);
            tableLayoutPanel4.Controls.Add(label5, 0, 1);
            tableLayoutPanel4.Location = new Point(9, 55);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel4.Size = new Size(341, 125);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // bsWithdrawalNumeric
            // 
            bsWithdrawalNumeric.Anchor = AnchorStyles.Left;
            bsWithdrawalNumeric.DecimalPlaces = 2;
            bsWithdrawalNumeric.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            bsWithdrawalNumeric.Location = new Point(173, 14);
            bsWithdrawalNumeric.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            bsWithdrawalNumeric.Name = "bsWithdrawalNumeric";
            bsWithdrawalNumeric.Size = new Size(154, 34);
            bsWithdrawalNumeric.TabIndex = 3;
            bsWithdrawalNumeric.TextAlign = HorizontalAlignment.Center;
            bsWithdrawalNumeric.ValueChanged += bsWithdrawalNumeric_ValueChanged;
            // 
            // dollarsWithdrawalNumeric
            // 
            dollarsWithdrawalNumeric.Anchor = AnchorStyles.Left;
            dollarsWithdrawalNumeric.DecimalPlaces = 2;
            dollarsWithdrawalNumeric.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            dollarsWithdrawalNumeric.Location = new Point(173, 76);
            dollarsWithdrawalNumeric.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            dollarsWithdrawalNumeric.Name = "dollarsWithdrawalNumeric";
            dollarsWithdrawalNumeric.Size = new Size(154, 34);
            dollarsWithdrawalNumeric.TabIndex = 4;
            dollarsWithdrawalNumeric.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(68, 17);
            label4.Name = "label4";
            label4.Size = new Size(34, 28);
            label4.TabIndex = 6;
            label4.Text = "Bs";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(43, 79);
            label5.Name = "label5";
            label5.Size = new Size(84, 28);
            label5.TabIndex = 7;
            label5.Text = "Dólares";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Bottom;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(clnBtn, 0, 0);
            tableLayoutPanel2.Controls.Add(acceptBtn, 1, 0);
            tableLayoutPanel2.Location = new Point(12, 521);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(594, 97);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // clnBtn
            // 
            clnBtn.BackColor = SystemColors.ActiveCaption;
            clnBtn.Dock = DockStyle.Fill;
            clnBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            clnBtn.Location = new Point(3, 3);
            clnBtn.Name = "clnBtn";
            clnBtn.Size = new Size(291, 91);
            clnBtn.TabIndex = 0;
            clnBtn.Text = "Limpiar";
            clnBtn.UseVisualStyleBackColor = false;
            // 
            // acceptBtn
            // 
            acceptBtn.BackColor = SystemColors.ActiveCaption;
            acceptBtn.Dock = DockStyle.Fill;
            acceptBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            acceptBtn.Location = new Point(300, 3);
            acceptBtn.Name = "acceptBtn";
            acceptBtn.Size = new Size(291, 91);
            acceptBtn.TabIndex = 1;
            acceptBtn.Text = "Aceptar";
            acceptBtn.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Controls.Add(cashCheckBox, 0, 0);
            tableLayoutPanel7.Controls.Add(bankCheckBox, 1, 0);
            tableLayoutPanel7.Location = new Point(122, 21);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Size = new Size(384, 31);
            tableLayoutPanel7.TabIndex = 2;
            // 
            // cashCheckBox
            // 
            cashCheckBox.Anchor = AnchorStyles.None;
            cashCheckBox.AutoSize = true;
            cashCheckBox.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            cashCheckBox.Location = new Point(36, 3);
            cashCheckBox.Name = "cashCheckBox";
            cashCheckBox.Size = new Size(119, 25);
            cashCheckBox.TabIndex = 0;
            cashCheckBox.Text = "Efectivo Bs";
            cashCheckBox.UseVisualStyleBackColor = true;
            // 
            // bankCheckBox
            // 
            bankCheckBox.Anchor = AnchorStyles.None;
            bankCheckBox.AutoSize = true;
            bankCheckBox.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            bankCheckBox.Location = new Point(211, 3);
            bankCheckBox.Name = "bankCheckBox";
            bankCheckBox.Size = new Size(154, 25);
            bankCheckBox.TabIndex = 1;
            bankCheckBox.Text = "Tranferencia Bs";
            bankCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Controls.Add(cashCheckBox2, 0, 0);
            tableLayoutPanel8.Controls.Add(bankCheckBox2, 1, 0);
            tableLayoutPanel8.Location = new Point(122, 18);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Size = new Size(384, 31);
            tableLayoutPanel8.TabIndex = 3;
            // 
            // cashCheckBox2
            // 
            cashCheckBox2.Anchor = AnchorStyles.None;
            cashCheckBox2.AutoSize = true;
            cashCheckBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            cashCheckBox2.Location = new Point(36, 3);
            cashCheckBox2.Name = "cashCheckBox2";
            cashCheckBox2.Size = new Size(119, 25);
            cashCheckBox2.TabIndex = 0;
            cashCheckBox2.Text = "Efectivo Bs";
            cashCheckBox2.UseVisualStyleBackColor = true;
            // 
            // bankCheckBox2
            // 
            bankCheckBox2.Anchor = AnchorStyles.None;
            bankCheckBox2.AutoSize = true;
            bankCheckBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            bankCheckBox2.Location = new Point(211, 3);
            bankCheckBox2.Name = "bankCheckBox2";
            bankCheckBox2.Size = new Size(154, 25);
            bankCheckBox2.TabIndex = 1;
            bankCheckBox2.Text = "Tranferencia Bs";
            bankCheckBox2.UseVisualStyleBackColor = true;
            // 
            // PaymentMethodWindow
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(618, 630);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MaximumSize = new Size(636, 677);
            MinimumSize = new Size(636, 677);
            Name = "PaymentMethodWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Método de pago";
            tableLayoutPanel1.ResumeLayout(false);
            Income.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bsNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)dollarsNumeric).EndInit();
            withdrawal.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bsWithdrawalNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)dollarsWithdrawalNumeric).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox Income;
        private GroupBox withdrawal;
        private TableLayoutPanel tableLayoutPanel2;
        private Button clnBtn;
        private Button acceptBtn;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private NumericUpDown bsNumeric;
        private NumericUpDown dollarsNumeric;
        private NumericUpDown bsWithdrawalNumeric;
        private NumericUpDown dollarsWithdrawalNumeric;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
        private Label moneyLabel;
        private Label money;
        private Label withdrawalLabel;
        private Label withdrawalMoney;
        private Label label1;
        private Label label2;
        private Label label4;
        private Label label5;
        private TableLayoutPanel tableLayoutPanel7;
        private CheckBox cashCheckBox;
        private CheckBox bankCheckBox;
        private TableLayoutPanel tableLayoutPanel8;
        private CheckBox cashCheckBox2;
        private CheckBox bankCheckBox2;
    }
}