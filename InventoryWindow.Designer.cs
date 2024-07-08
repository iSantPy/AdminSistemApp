namespace ControlAguaPotable
{
    partial class InventoryWindow
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InventoryWindow));
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            dataGridView = new DataGridView();
            tableLayoutPanel3 = new TableLayoutPanel();
            searchBtn = new Button();
            searchTextBox = new TextBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            groupBox1 = new GroupBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            descriptionTextBox = new TextBox();
            stockNumericUpDown = new NumericUpDown();
            priceNumericUpDown = new NumericUpDown();
            label4 = new Label();
            idNumericUpDown = new NumericUpDown();
            tableLayoutPanel6 = new TableLayoutPanel();
            insertBtn = new Button();
            updateBtn = new Button();
            deleteBtn = new Button();
            clnBtn = new Button();
            toolTip1 = new ToolTip(components);
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)stockNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)idNumericUpDown).BeginInit();
            tableLayoutPanel6.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.4545441F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.5454559F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1198, 716);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(dataGridView, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(415, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10.2564106F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 89.74359F));
            tableLayoutPanel2.Size = new Size(780, 710);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(3, 75);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView.Size = new Size(774, 632);
            dataGridView.TabIndex = 0;
            dataGridView.CellClick += dataGridView_CellClick;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.5685215F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 86.43148F));
            tableLayoutPanel3.Controls.Add(searchBtn, 0, 0);
            tableLayoutPanel3.Controls.Add(searchTextBox, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(774, 66);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // searchBtn
            // 
            searchBtn.Dock = DockStyle.Fill;
            searchBtn.Image = Properties.Resources.lupa;
            searchBtn.Location = new Point(3, 3);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(99, 60);
            searchBtn.TabIndex = 0;
            toolTip1.SetToolTip(searchBtn, "Buscar");
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            searchTextBox.Location = new Point(108, 16);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(663, 34);
            searchTextBox.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel6, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 53.94366F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 46.05634F));
            tableLayoutPanel4.Size = new Size(406, 710);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel5);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(400, 377);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Item:";
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.64804F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53.3519554F));
            tableLayoutPanel5.Controls.Add(label1, 0, 0);
            tableLayoutPanel5.Controls.Add(label2, 0, 1);
            tableLayoutPanel5.Controls.Add(label3, 0, 2);
            tableLayoutPanel5.Controls.Add(descriptionTextBox, 1, 0);
            tableLayoutPanel5.Controls.Add(stockNumericUpDown, 1, 1);
            tableLayoutPanel5.Controls.Add(priceNumericUpDown, 1, 2);
            tableLayoutPanel5.Controls.Add(label4, 0, 3);
            tableLayoutPanel5.Controls.Add(idNumericUpDown, 1, 3);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 30);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 4;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel5.Size = new Size(394, 344);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(27, 29);
            label1.Name = "label1";
            label1.Size = new Size(128, 28);
            label1.TabIndex = 0;
            label1.Text = "Descripción:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(56, 115);
            label2.Name = "label2";
            label2.Size = new Size(70, 28);
            label2.TabIndex = 1;
            label2.Text = "Stock:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(11, 201);
            label3.Name = "label3";
            label3.Size = new Size(161, 28);
            label3.TabIndex = 2;
            label3.Text = "Precio U. (USD):";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            descriptionTextBox.Location = new Point(186, 3);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(205, 80);
            descriptionTextBox.TabIndex = 3;
            // 
            // stockNumericUpDown
            // 
            stockNumericUpDown.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            stockNumericUpDown.Location = new Point(186, 112);
            stockNumericUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            stockNumericUpDown.Name = "stockNumericUpDown";
            stockNumericUpDown.Size = new Size(205, 34);
            stockNumericUpDown.TabIndex = 4;
            stockNumericUpDown.TextAlign = HorizontalAlignment.Center;
            // 
            // priceNumericUpDown
            // 
            priceNumericUpDown.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            priceNumericUpDown.DecimalPlaces = 3;
            priceNumericUpDown.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            priceNumericUpDown.Location = new Point(186, 198);
            priceNumericUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            priceNumericUpDown.Name = "priceNumericUpDown";
            priceNumericUpDown.Size = new Size(205, 34);
            priceNumericUpDown.TabIndex = 5;
            priceNumericUpDown.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(74, 287);
            label4.Name = "label4";
            label4.Size = new Size(35, 28);
            label4.TabIndex = 6;
            label4.Text = "Id:";
            // 
            // idNumericUpDown
            // 
            idNumericUpDown.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            idNumericUpDown.Enabled = false;
            idNumericUpDown.Location = new Point(186, 284);
            idNumericUpDown.Name = "idNumericUpDown";
            idNumericUpDown.ReadOnly = true;
            idNumericUpDown.Size = new Size(205, 34);
            idNumericUpDown.TabIndex = 7;
            idNumericUpDown.TextAlign = HorizontalAlignment.Center;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(insertBtn, 0, 0);
            tableLayoutPanel6.Controls.Add(updateBtn, 0, 1);
            tableLayoutPanel6.Controls.Add(deleteBtn, 0, 2);
            tableLayoutPanel6.Controls.Add(clnBtn, 0, 3);
            tableLayoutPanel6.Location = new Point(3, 407);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 4;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel6.Size = new Size(400, 278);
            tableLayoutPanel6.TabIndex = 1;
            // 
            // insertBtn
            // 
            insertBtn.Anchor = AnchorStyles.None;
            insertBtn.BackColor = SystemColors.ActiveCaption;
            insertBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            insertBtn.Location = new Point(111, 3);
            insertBtn.Name = "insertBtn";
            insertBtn.Size = new Size(178, 63);
            insertBtn.TabIndex = 0;
            insertBtn.Text = "Insertar";
            insertBtn.UseVisualStyleBackColor = false;
            insertBtn.Click += insertBtn_Click;
            // 
            // updateBtn
            // 
            updateBtn.Anchor = AnchorStyles.None;
            updateBtn.BackColor = SystemColors.ActiveCaption;
            updateBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            updateBtn.Location = new Point(111, 72);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(178, 63);
            updateBtn.TabIndex = 1;
            updateBtn.Text = "Actualizar";
            updateBtn.UseVisualStyleBackColor = false;
            updateBtn.Click += updateBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Anchor = AnchorStyles.None;
            deleteBtn.BackColor = SystemColors.ActiveCaption;
            deleteBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            deleteBtn.Location = new Point(111, 141);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(178, 63);
            deleteBtn.TabIndex = 2;
            deleteBtn.Text = "Eliminar";
            deleteBtn.UseVisualStyleBackColor = false;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // clnBtn
            // 
            clnBtn.Anchor = AnchorStyles.None;
            clnBtn.BackColor = SystemColors.ActiveCaption;
            clnBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            clnBtn.Location = new Point(111, 210);
            clnBtn.Name = "clnBtn";
            clnBtn.Size = new Size(178, 65);
            clnBtn.TabIndex = 3;
            clnBtn.Text = "Limpiar";
            clnBtn.UseVisualStyleBackColor = false;
            clnBtn.Click += clnBtn_Click;
            // 
            // InventoryWindow
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1198, 716);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MaximumSize = new Size(1216, 763);
            MinimumSize = new Size(1216, 763);
            Name = "InventoryWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventario de items";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)stockNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)idNumericUpDown).EndInit();
            tableLayoutPanel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private DataGridView dataGridView;
        private TableLayoutPanel tableLayoutPanel3;
        private Button searchBtn;
        private TextBox searchTextBox;
        private TableLayoutPanel tableLayoutPanel4;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox descriptionTextBox;
        private NumericUpDown stockNumericUpDown;
        private NumericUpDown priceNumericUpDown;
        private TableLayoutPanel tableLayoutPanel6;
        private Button insertBtn;
        private Button updateBtn;
        private Button deleteBtn;
        private Button clnBtn;
        private Label label4;
        private NumericUpDown idNumericUpDown;
        private ToolTip toolTip1;
    }
}