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
            this.stationTabPage = new System.Windows.Forms.TabPage();
            this.spaceTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1004, 601);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Console
            // 
            this.Console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Console.FormattingEnabled = true;
            this.Console.ItemHeight = 16;
            this.Console.Location = new System.Drawing.Point(4, 4);
            this.Console.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(996, 393);
            this.Console.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.generalTabPage);
            this.tabControl1.Controls.Add(this.stationTabPage);
            this.tabControl1.Controls.Add(this.spaceTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 404);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(998, 194);
            this.tabControl1.TabIndex = 1;
            // 
            // generalTabPage
            // 
            this.generalTabPage.Location = new System.Drawing.Point(4, 25);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalTabPage.Size = new System.Drawing.Size(990, 165);
            this.generalTabPage.TabIndex = 0;
            this.generalTabPage.Text = "General";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // stationTabPage
            // 
            this.stationTabPage.Location = new System.Drawing.Point(4, 25);
            this.stationTabPage.Name = "stationTabPage";
            this.stationTabPage.Size = new System.Drawing.Size(990, 165);
            this.stationTabPage.TabIndex = 1;
            this.stationTabPage.Text = "Station";
            this.stationTabPage.UseVisualStyleBackColor = true;
            // 
            // spaceTabPage
            // 
            this.spaceTabPage.Location = new System.Drawing.Point(4, 25);
            this.spaceTabPage.Name = "spaceTabPage";
            this.spaceTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.spaceTabPage.Size = new System.Drawing.Size(990, 165);
            this.spaceTabPage.TabIndex = 2;
            this.spaceTabPage.Text = "Space";
            this.spaceTabPage.UseVisualStyleBackColor = true;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 601);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UI";
            this.Text = "UI";
            this.Load += new System.EventHandler(this.UI_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox Console;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.TabPage stationTabPage;
        private System.Windows.Forms.TabPage spaceTabPage;
    }
}