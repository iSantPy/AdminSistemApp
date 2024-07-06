namespace ControlAguaPotable
{
    partial class CustomizeWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizeWindow));
            tableLayoutPanel1 = new TableLayoutPanel();
            precioTotal = new NumericUpDown();
            precioUnitario = new NumericUpDown();
            litros = new NumericUpDown();
            presentacion = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            cantidad = new NumericUpDown();
            tableLayoutPanel2 = new TableLayoutPanel();
            clnBtn = new Button();
            acceptBtn = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)precioTotal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)precioUnitario).BeginInit();
            ((System.ComponentModel.ISupportInitialize)litros).BeginInit();
            ((System.ComponentModel.ISupportInitialize)presentacion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cantidad).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(precioTotal, 1, 4);
            tableLayoutPanel1.Controls.Add(precioUnitario, 1, 3);
            tableLayoutPanel1.Controls.Add(litros, 1, 2);
            tableLayoutPanel1.Controls.Add(presentacion, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(cantidad, 1, 0);
            tableLayoutPanel1.Location = new Point(16, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(593, 464);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // precioTotal
            // 
            precioTotal.Anchor = AnchorStyles.Left;
            precioTotal.DecimalPlaces = 2;
            precioTotal.Enabled = false;
            precioTotal.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            precioTotal.Location = new Point(299, 399);
            precioTotal.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            precioTotal.Name = "precioTotal";
            precioTotal.ReadOnly = true;
            precioTotal.Size = new Size(150, 34);
            precioTotal.TabIndex = 13;
            precioTotal.TextAlign = HorizontalAlignment.Center;
            // 
            // precioUnitario
            // 
            precioUnitario.Anchor = AnchorStyles.Left;
            precioUnitario.DecimalPlaces = 2;
            precioUnitario.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            precioUnitario.Location = new Point(299, 305);
            precioUnitario.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            precioUnitario.Name = "precioUnitario";
            precioUnitario.Size = new Size(150, 34);
            precioUnitario.TabIndex = 12;
            precioUnitario.TextAlign = HorizontalAlignment.Center;
            // 
            // litros
            // 
            litros.Anchor = AnchorStyles.Left;
            litros.DecimalPlaces = 2;
            litros.Enabled = false;
            litros.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            litros.Location = new Point(299, 213);
            litros.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            litros.Name = "litros";
            litros.ReadOnly = true;
            litros.Size = new Size(150, 34);
            litros.TabIndex = 11;
            litros.TextAlign = HorizontalAlignment.Center;
            // 
            // presentacion
            // 
            presentacion.Anchor = AnchorStyles.Left;
            presentacion.DecimalPlaces = 2;
            presentacion.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            presentacion.Location = new Point(299, 121);
            presentacion.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            presentacion.Name = "presentacion";
            presentacion.Size = new Size(150, 34);
            presentacion.TabIndex = 10;
            presentacion.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(192, 32);
            label1.Name = "label1";
            label1.Size = new Size(101, 28);
            label1.TabIndex = 0;
            label1.Text = "Cantidad:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(154, 124);
            label2.Name = "label2";
            label2.Size = new Size(139, 28);
            label2.TabIndex = 1;
            label2.Text = "Presentación:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(170, 216);
            label3.Name = "label3";
            label3.Size = new Size(123, 28);
            label3.TabIndex = 2;
            label3.Text = "Total Litros:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(74, 308);
            label4.Name = "label4";
            label4.Size = new Size(219, 28);
            label4.TabIndex = 3;
            label4.Text = "Precio Unitario (USD):";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(164, 402);
            label5.Name = "label5";
            label5.Size = new Size(129, 28);
            label5.TabIndex = 4;
            label5.Text = "Precio Total:";
            // 
            // cantidad
            // 
            cantidad.Anchor = AnchorStyles.Left;
            cantidad.Location = new Point(299, 29);
            cantidad.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            cantidad.Name = "cantidad";
            cantidad.Size = new Size(150, 34);
            cantidad.TabIndex = 5;
            cantidad.TextAlign = HorizontalAlignment.Center;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(clnBtn, 0, 0);
            tableLayoutPanel2.Controls.Add(acceptBtn, 1, 0);
            tableLayoutPanel2.Location = new Point(16, 511);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(593, 86);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // clnBtn
            // 
            clnBtn.BackColor = SystemColors.ActiveCaption;
            clnBtn.Dock = DockStyle.Fill;
            clnBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            clnBtn.Location = new Point(3, 3);
            clnBtn.Name = "clnBtn";
            clnBtn.Size = new Size(290, 80);
            clnBtn.TabIndex = 0;
            clnBtn.Text = "Limpiar";
            clnBtn.UseVisualStyleBackColor = false;
            // 
            // acceptBtn
            // 
            acceptBtn.BackColor = SystemColors.ActiveCaption;
            acceptBtn.Dock = DockStyle.Fill;
            acceptBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            acceptBtn.Location = new Point(299, 3);
            acceptBtn.Name = "acceptBtn";
            acceptBtn.Size = new Size(291, 80);
            acceptBtn.TabIndex = 1;
            acceptBtn.Text = "Aceptar";
            acceptBtn.UseVisualStyleBackColor = false;
            // 
            // CustomizeWindow
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(623, 630);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MaximumSize = new Size(641, 677);
            MinimumSize = new Size(641, 677);
            Name = "CustomizeWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pedido personalizado";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)precioTotal).EndInit();
            ((System.ComponentModel.ISupportInitialize)precioUnitario).EndInit();
            ((System.ComponentModel.ISupportInitialize)litros).EndInit();
            ((System.ComponentModel.ISupportInitialize)presentacion).EndInit();
            ((System.ComponentModel.ISupportInitialize)cantidad).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private NumericUpDown precioTotal;
        private NumericUpDown precioUnitario;
        private NumericUpDown litros;
        private NumericUpDown presentacion;
        private NumericUpDown cantidad;
        private TableLayoutPanel tableLayoutPanel2;
        private Button clnBtn;
        private Button acceptBtn;
    }
}