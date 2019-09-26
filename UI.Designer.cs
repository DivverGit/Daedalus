namespace Daedalus
{
    partial class UI
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Console = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.stationTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.shipNameLabel = new System.Windows.Forms.Label();
            this.shipNameValueLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.undockButton = new System.Windows.Forms.Button();
            this.spaceTabPage = new System.Windows.Forms.TabPage();
            this.shieldLabel = new System.Windows.Forms.Label();
            this.armorLabel = new System.Windows.Forms.Label();
            this.hullLabel = new System.Windows.Forms.Label();
            this.shieldValueLabel = new System.Windows.Forms.Label();
            this.armorValueLabel = new System.Windows.Forms.Label();
            this.hullValueLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.generalTabPage.SuspendLayout();
            this.stationTabPage.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Console, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1086, 768);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Console
            // 
            this.Console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Console.FormattingEnabled = true;
            this.Console.ItemHeight = 16;
            this.Console.Location = new System.Drawing.Point(4, 4);
            this.Console.Margin = new System.Windows.Forms.Padding(4);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(1078, 560);
            this.Console.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.generalTabPage);
            this.tabControl1.Controls.Add(this.stationTabPage);
            this.tabControl1.Controls.Add(this.spaceTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 571);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1080, 194);
            this.tabControl1.TabIndex = 1;
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.tableLayoutPanel2);
            this.generalTabPage.Location = new System.Drawing.Point(4, 25);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalTabPage.Size = new System.Drawing.Size(1072, 165);
            this.generalTabPage.TabIndex = 0;
            this.generalTabPage.Text = "General";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1066, 159);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // stationTabPage
            // 
            this.stationTabPage.Controls.Add(this.tableLayoutPanel3);
            this.stationTabPage.Location = new System.Drawing.Point(4, 25);
            this.stationTabPage.Name = "stationTabPage";
            this.stationTabPage.Size = new System.Drawing.Size(1072, 165);
            this.stationTabPage.TabIndex = 1;
            this.stationTabPage.Text = "Station";
            this.stationTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.shipNameLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.shipNameValueLabel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.flowLayoutPanel1, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.shieldLabel, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.armorLabel, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.hullLabel, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.shieldValueLabel, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.armorValueLabel, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.hullValueLabel, 1, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1072, 165);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // shipNameLabel
            // 
            this.shipNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.shipNameLabel.AutoSize = true;
            this.shipNameLabel.Location = new System.Drawing.Point(57, 4);
            this.shipNameLabel.Name = "shipNameLabel";
            this.shipNameLabel.Size = new System.Drawing.Size(40, 17);
            this.shipNameLabel.TabIndex = 0;
            this.shipNameLabel.Text = "Ship:";
            // 
            // shipNameValueLabel
            // 
            this.shipNameValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.shipNameValueLabel.AutoSize = true;
            this.shipNameValueLabel.Location = new System.Drawing.Point(103, 4);
            this.shipNameValueLabel.Name = "shipNameValueLabel";
            this.shipNameValueLabel.Size = new System.Drawing.Size(71, 17);
            this.shipNameValueLabel.TabIndex = 1;
            this.shipNameValueLabel.Text = "undefined";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.undockButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(103, 103);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(966, 100);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // undockButton
            // 
            this.undockButton.Location = new System.Drawing.Point(3, 3);
            this.undockButton.Name = "undockButton";
            this.undockButton.Size = new System.Drawing.Size(75, 23);
            this.undockButton.TabIndex = 0;
            this.undockButton.Text = "Undock";
            this.undockButton.UseVisualStyleBackColor = true;
            this.undockButton.Click += new System.EventHandler(this.undockButton_Click);
            // 
            // spaceTabPage
            // 
            this.spaceTabPage.Location = new System.Drawing.Point(4, 25);
            this.spaceTabPage.Name = "spaceTabPage";
            this.spaceTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.spaceTabPage.Size = new System.Drawing.Size(1072, 165);
            this.spaceTabPage.TabIndex = 2;
            this.spaceTabPage.Text = "Space";
            this.spaceTabPage.UseVisualStyleBackColor = true;
            // 
            // shieldLabel
            // 
            this.shieldLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.shieldLabel.AutoSize = true;
            this.shieldLabel.Location = new System.Drawing.Point(46, 29);
            this.shieldLabel.Name = "shieldLabel";
            this.shieldLabel.Size = new System.Drawing.Size(51, 17);
            this.shieldLabel.TabIndex = 3;
            this.shieldLabel.Text = "Shield:";
            // 
            // armorLabel
            // 
            this.armorLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.armorLabel.AutoSize = true;
            this.armorLabel.Location = new System.Drawing.Point(47, 54);
            this.armorLabel.Name = "armorLabel";
            this.armorLabel.Size = new System.Drawing.Size(50, 17);
            this.armorLabel.TabIndex = 4;
            this.armorLabel.Text = "Armor:";
            // 
            // hullLabel
            // 
            this.hullLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.hullLabel.AutoSize = true;
            this.hullLabel.Location = new System.Drawing.Point(61, 79);
            this.hullLabel.Name = "hullLabel";
            this.hullLabel.Size = new System.Drawing.Size(36, 17);
            this.hullLabel.TabIndex = 5;
            this.hullLabel.Text = "Hull:";
            // 
            // shieldValueLabel
            // 
            this.shieldValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.shieldValueLabel.AutoSize = true;
            this.shieldValueLabel.Location = new System.Drawing.Point(103, 29);
            this.shieldValueLabel.Name = "shieldValueLabel";
            this.shieldValueLabel.Size = new System.Drawing.Size(71, 17);
            this.shieldValueLabel.TabIndex = 6;
            this.shieldValueLabel.Text = "undefined";
            // 
            // armorValueLabel
            // 
            this.armorValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.armorValueLabel.AutoSize = true;
            this.armorValueLabel.Location = new System.Drawing.Point(103, 54);
            this.armorValueLabel.Name = "armorValueLabel";
            this.armorValueLabel.Size = new System.Drawing.Size(71, 17);
            this.armorValueLabel.TabIndex = 7;
            this.armorValueLabel.Text = "undefined";
            // 
            // hullValueLabel
            // 
            this.hullValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hullValueLabel.AutoSize = true;
            this.hullValueLabel.Location = new System.Drawing.Point(103, 79);
            this.hullValueLabel.Name = "hullValueLabel";
            this.hullValueLabel.Size = new System.Drawing.Size(71, 17);
            this.hullValueLabel.TabIndex = 8;
            this.hullValueLabel.Text = "undefined";
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 768);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UI";
            this.Text = "UI";
            this.Load += new System.EventHandler(this.UI_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            this.stationTabPage.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox Console;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.TabPage stationTabPage;
        private System.Windows.Forms.TabPage spaceTabPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label shipNameLabel;
        private System.Windows.Forms.Label shipNameValueLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button undockButton;
        private System.Windows.Forms.Label shieldLabel;
        private System.Windows.Forms.Label armorLabel;
        private System.Windows.Forms.Label hullLabel;
        private System.Windows.Forms.Label shieldValueLabel;
        private System.Windows.Forms.Label armorValueLabel;
        private System.Windows.Forms.Label hullValueLabel;
    }
}