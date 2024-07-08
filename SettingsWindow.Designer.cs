namespace ControlAguaPotable
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            tableLayoutPanel1 = new TableLayoutPanel();
            biggestLabel = new Label();
            mediumLabel = new Label();
            mediumSmallLabel = new Label();
            smallestLabel = new Label();
            priceBiggestLabel = new Label();
            priceMediumLabel = new Label();
            priceMediumSmallLabel = new Label();
            priceSmallestLabel = new Label();
            exchangeRateLabel = new Label();
            litersLabel = new Label();
            biggest = new NumericUpDown();
            medium = new NumericUpDown();
            mediumSmall = new NumericUpDown();
            smallest = new NumericUpDown();
            priceBiggest = new NumericUpDown();
            priceMedium = new NumericUpDown();
            priceMediumSmall = new NumericUpDown();
            priceSmallest = new NumericUpDown();
            exchangeRate = new NumericUpDown();
            liters = new NumericUpDown();
            tableLayoutPanel2 = new TableLayoutPanel();
            clnBtn = new Button();
            okBtn = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)biggest).BeginInit();
            ((System.ComponentModel.ISupportInitialize)medium).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mediumSmall).BeginInit();
            ((System.ComponentModel.ISupportInitialize)smallest).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceBiggest).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceMedium).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceMediumSmall).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priceSmallest).BeginInit();
            ((System.ComponentModel.ISupportInitialize)exchangeRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)liters).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.58997F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.41003F));
            tableLayoutPanel1.Controls.Add(biggestLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(mediumLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(mediumSmallLabel, 0, 2);
            tableLayoutPanel1.Controls.Add(smallestLabel, 0, 3);
            tableLayoutPanel1.Controls.Add(priceBiggestLabel, 0, 4);
            tableLayoutPanel1.Controls.Add(priceMediumLabel, 0, 5);
            tableLayoutPanel1.Controls.Add(priceMediumSmallLabel, 0, 6);
            tableLayoutPanel1.Controls.Add(priceSmallestLabel, 0, 7);
            tableLayoutPanel1.Controls.Add(exchangeRateLabel, 0, 8);
            tableLayoutPanel1.Controls.Add(litersLabel, 0, 9);
            tableLayoutPanel1.Controls.Add(biggest, 1, 0);
            tableLayoutPanel1.Controls.Add(medium, 1, 1);
            tableLayoutPanel1.Controls.Add(mediumSmall, 1, 2);
            tableLayoutPanel1.Controls.Add(smallest, 1, 3);
            tableLayoutPanel1.Controls.Add(priceBiggest, 1, 4);
            tableLayoutPanel1.Controls.Add(priceMedium, 1, 5);
            tableLayoutPanel1.Controls.Add(priceMediumSmall, 1, 6);
            tableLayoutPanel1.Controls.Add(priceSmallest, 1, 7);
            tableLayoutPanel1.Controls.Add(exchangeRate, 1, 8);
            tableLayoutPanel1.Controls.Add(liters, 1, 9);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(678, 472);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // biggestLabel
            // 
            biggestLabel.Anchor = AnchorStyles.Right;
            biggestLabel.AutoSize = true;
            biggestLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            biggestLabel.Location = new Point(97, 9);
            biggestLabel.Name = "biggestLabel";
            biggestLabel.Size = new Size(243, 28);
            biggestLabel.TabIndex = 0;
            biggestLabel.Text = "Botellón mas grande (L):";
            // 
            // mediumLabel
            // 
            mediumLabel.Anchor = AnchorStyles.Right;
            mediumLabel.AutoSize = true;
            mediumLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            mediumLabel.Location = new Point(125, 56);
            mediumLabel.Name = "mediumLabel";
            mediumLabel.Size = new Size(215, 28);
            mediumLabel.TabIndex = 1;
            mediumLabel.Text = "Botellón mediano (L):";
            // 
            // mediumSmallLabel
            // 
            mediumSmallLabel.Anchor = AnchorStyles.Right;
            mediumSmallLabel.AutoSize = true;
            mediumSmallLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            mediumSmallLabel.Location = new Point(35, 103);
            mediumSmallLabel.Name = "mediumSmallLabel";
            mediumSmallLabel.Size = new Size(305, 28);
            mediumSmallLabel.TabIndex = 2;
            mediumSmallLabel.Text = "Botellón mediano-pequeño (L):";
            // 
            // smallestLabel
            // 
            smallestLabel.Anchor = AnchorStyles.Right;
            smallestLabel.AutoSize = true;
            smallestLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            smallestLabel.Location = new Point(81, 150);
            smallestLabel.Name = "smallestLabel";
            smallestLabel.Size = new Size(259, 28);
            smallestLabel.TabIndex = 3;
            smallestLabel.Text = "Botellón mas pequeño (L):";
            // 
            // priceBiggestLabel
            // 
            priceBiggestLabel.Anchor = AnchorStyles.Right;
            priceBiggestLabel.AutoSize = true;
            priceBiggestLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            priceBiggestLabel.Location = new Point(3, 197);
            priceBiggestLabel.Name = "priceBiggestLabel";
            priceBiggestLabel.Size = new Size(337, 28);
            priceBiggestLabel.TabIndex = 4;
            priceBiggestLabel.Text = "Precio botellón mas grande (USD):";
            // 
            // priceMediumLabel
            // 
            priceMediumLabel.Anchor = AnchorStyles.Right;
            priceMediumLabel.AutoSize = true;
            priceMediumLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            priceMediumLabel.Location = new Point(31, 244);
            priceMediumLabel.Name = "priceMediumLabel";
            priceMediumLabel.Size = new Size(309, 28);
            priceMediumLabel.TabIndex = 5;
            priceMediumLabel.Text = "Precio botellón mediano (USD):";
            // 
            // priceMediumSmallLabel
            // 
            priceMediumSmallLabel.Anchor = AnchorStyles.Right;
            priceMediumSmallLabel.AutoSize = true;
            priceMediumSmallLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            priceMediumSmallLabel.Location = new Point(75, 291);
            priceMediumSmallLabel.Name = "priceMediumSmallLabel";
            priceMediumSmallLabel.Size = new Size(265, 28);
            priceMediumSmallLabel.TabIndex = 6;
            priceMediumSmallLabel.Text = "Precio botellón m-p (USD):";
            // 
            // priceSmallestLabel
            // 
            priceSmallestLabel.Anchor = AnchorStyles.Right;
            priceSmallestLabel.AutoSize = true;
            priceSmallestLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            priceSmallestLabel.Location = new Point(46, 329);
            priceSmallestLabel.Name = "priceSmallestLabel";
            priceSmallestLabel.Size = new Size(294, 47);
            priceSmallestLabel.TabIndex = 7;
            priceSmallestLabel.Text = "Precio botellón mas pequeño (USD):";
            // 
            // exchangeRateLabel
            // 
            exchangeRateLabel.Anchor = AnchorStyles.Right;
            exchangeRateLabel.AutoSize = true;
            exchangeRateLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            exchangeRateLabel.Location = new Point(178, 385);
            exchangeRateLabel.Name = "exchangeRateLabel";
            exchangeRateLabel.Size = new Size(162, 28);
            exchangeRateLabel.TabIndex = 8;
            exchangeRateLabel.Text = "Tasa de cambio:";
            // 
            // litersLabel
            // 
            litersLabel.Anchor = AnchorStyles.Right;
            litersLabel.AutoSize = true;
            litersLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            litersLabel.Location = new Point(270, 433);
            litersLabel.Name = "litersLabel";
            litersLabel.Size = new Size(70, 28);
            litersLabel.TabIndex = 9;
            litersLabel.Text = "Litros:";
            // 
            // biggest
            // 
            biggest.Anchor = AnchorStyles.Left;
            biggest.DecimalPlaces = 3;
            biggest.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            biggest.Location = new Point(346, 6);
            biggest.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            biggest.Name = "biggest";
            biggest.Size = new Size(229, 34);
            biggest.TabIndex = 10;
            biggest.TextAlign = HorizontalAlignment.Center;
            // 
            // medium
            // 
            medium.Anchor = AnchorStyles.Left;
            medium.DecimalPlaces = 3;
            medium.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            medium.Location = new Point(346, 53);
            medium.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            medium.Name = "medium";
            medium.Size = new Size(229, 34);
            medium.TabIndex = 11;
            medium.TextAlign = HorizontalAlignment.Center;
            // 
            // mediumSmall
            // 
            mediumSmall.Anchor = AnchorStyles.Left;
            mediumSmall.DecimalPlaces = 3;
            mediumSmall.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            mediumSmall.Location = new Point(346, 100);
            mediumSmall.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            mediumSmall.Name = "mediumSmall";
            mediumSmall.Size = new Size(229, 34);
            mediumSmall.TabIndex = 12;
            mediumSmall.TextAlign = HorizontalAlignment.Center;
            // 
            // smallest
            // 
            smallest.Anchor = AnchorStyles.Left;
            smallest.DecimalPlaces = 3;
            smallest.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            smallest.Location = new Point(346, 147);
            smallest.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            smallest.Name = "smallest";
            smallest.Size = new Size(229, 34);
            smallest.TabIndex = 13;
            smallest.TextAlign = HorizontalAlignment.Center;
            // 
            // priceBiggest
            // 
            priceBiggest.Anchor = AnchorStyles.Left;
            priceBiggest.DecimalPlaces = 3;
            priceBiggest.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            priceBiggest.Location = new Point(346, 194);
            priceBiggest.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            priceBiggest.Name = "priceBiggest";
            priceBiggest.Size = new Size(229, 34);
            priceBiggest.TabIndex = 14;
            priceBiggest.TextAlign = HorizontalAlignment.Center;
            // 
            // priceMedium
            // 
            priceMedium.Anchor = AnchorStyles.Left;
            priceMedium.DecimalPlaces = 3;
            priceMedium.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            priceMedium.Location = new Point(346, 241);
            priceMedium.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            priceMedium.Name = "priceMedium";
            priceMedium.Size = new Size(229, 34);
            priceMedium.TabIndex = 15;
            priceMedium.TextAlign = HorizontalAlignment.Center;
            // 
            // priceMediumSmall
            // 
            priceMediumSmall.Anchor = AnchorStyles.Left;
            priceMediumSmall.DecimalPlaces = 3;
            priceMediumSmall.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            priceMediumSmall.Location = new Point(346, 288);
            priceMediumSmall.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            priceMediumSmall.Name = "priceMediumSmall";
            priceMediumSmall.Size = new Size(229, 34);
            priceMediumSmall.TabIndex = 16;
            priceMediumSmall.TextAlign = HorizontalAlignment.Center;
            // 
            // priceSmallest
            // 
            priceSmallest.Anchor = AnchorStyles.Left;
            priceSmallest.DecimalPlaces = 3;
            priceSmallest.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            priceSmallest.Location = new Point(346, 335);
            priceSmallest.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            priceSmallest.Name = "priceSmallest";
            priceSmallest.Size = new Size(229, 34);
            priceSmallest.TabIndex = 17;
            priceSmallest.TextAlign = HorizontalAlignment.Center;
            // 
            // exchangeRate
            // 
            exchangeRate.Anchor = AnchorStyles.Left;
            exchangeRate.DecimalPlaces = 3;
            exchangeRate.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            exchangeRate.Location = new Point(346, 382);
            exchangeRate.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            exchangeRate.Name = "exchangeRate";
            exchangeRate.Size = new Size(229, 34);
            exchangeRate.TabIndex = 18;
            exchangeRate.TextAlign = HorizontalAlignment.Center;
            // 
            // liters
            // 
            liters.Anchor = AnchorStyles.Left;
            liters.DecimalPlaces = 3;
            liters.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            liters.Location = new Point(346, 430);
            liters.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            liters.Name = "liters";
            liters.Size = new Size(229, 34);
            liters.TabIndex = 19;
            liters.TextAlign = HorizontalAlignment.Center;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(clnBtn, 0, 0);
            tableLayoutPanel2.Controls.Add(okBtn, 1, 0);
            tableLayoutPanel2.Location = new Point(12, 522);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(678, 88);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // clnBtn
            // 
            clnBtn.BackColor = SystemColors.ActiveCaption;
            clnBtn.Dock = DockStyle.Fill;
            clnBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            clnBtn.Location = new Point(3, 3);
            clnBtn.Name = "clnBtn";
            clnBtn.Size = new Size(333, 82);
            clnBtn.TabIndex = 0;
            clnBtn.Text = "Limpiar";
            clnBtn.UseVisualStyleBackColor = false;
            // 
            // okBtn
            // 
            okBtn.BackColor = SystemColors.ActiveCaption;
            okBtn.Dock = DockStyle.Fill;
            okBtn.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold);
            okBtn.Location = new Point(342, 3);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(333, 82);
            okBtn.TabIndex = 1;
            okBtn.Text = "Aceptar";
            okBtn.UseVisualStyleBackColor = false;
            // 
            // SettingsWindow
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 630);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MaximumSize = new Size(720, 677);
            MinimumSize = new Size(720, 677);
            Name = "SettingsWindow";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuración App";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)biggest).EndInit();
            ((System.ComponentModel.ISupportInitialize)medium).EndInit();
            ((System.ComponentModel.ISupportInitialize)mediumSmall).EndInit();
            ((System.ComponentModel.ISupportInitialize)smallest).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceBiggest).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceMedium).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceMediumSmall).EndInit();
            ((System.ComponentModel.ISupportInitialize)priceSmallest).EndInit();
            ((System.ComponentModel.ISupportInitialize)exchangeRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)liters).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label biggestLabel;
        private Label mediumLabel;
        private Label mediumSmallLabel;
        private Label smallestLabel;
        private Label priceBiggestLabel;
        private Label priceMediumLabel;
        private Label priceMediumSmallLabel;
        private Label priceSmallestLabel;
        private Label exchangeRateLabel;
        private Label litersLabel;
        private NumericUpDown biggest;
        private NumericUpDown medium;
        private NumericUpDown mediumSmall;
        private NumericUpDown smallest;
        private NumericUpDown priceBiggest;
        private NumericUpDown priceMedium;
        private NumericUpDown priceMediumSmall;
        private NumericUpDown priceSmallest;
        private NumericUpDown exchangeRate;
        private NumericUpDown liters;
        private TableLayoutPanel tableLayoutPanel2;
        private Button clnBtn;
        private Button okBtn;
    }
}