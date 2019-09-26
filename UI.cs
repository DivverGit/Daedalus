using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Daedalus
{
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();
        }

        private void UI_Load(object sender, EventArgs e)
        {
            Daedalus Daedalus = new Daedalus(this);

            initTabPages();
        }

        public TabPage General;
        public TabPage Station;
        public TabPage Space;

        private void initTabPages()
        {
            General = tabControl1.TabPages[0];
            Station = tabControl1.TabPages[1];
            Space = tabControl1.TabPages[2];

            showHideTabPage(General, true);
            showHideTabPage(Station, true);
            showHideTabPage(Space, true);
        }

        private void showHideTabPage(TabPage page, bool hide)
        {
            if (page == General)
            {
                if(hide)    tabControl1.TabPages.Remove(General);
                else
                {
                    tabControl1.TabPages.Insert(0, General);
                }
            }
            else if (page == Station)
            {
                if (hide) tabControl1.TabPages.Remove(Station);
                else
                {
                    tabControl1.TabPages.Insert(0, Station);
                }
            }
            else if (page == Space)
            {
                if (hide) tabControl1.TabPages.Remove(Space);
                else
                {
                    tabControl1.TabPages.Insert(0, Space);
                }
            }
        }

        public void switchTabPage(TabPage page)
        {
            TabPage[] tabPages = { General, Station, Space };

            foreach(TabPage tabPage in tabPages)
            {
                if (tabPage != page) showHideTabPage(tabPage, true);
                else
                {
                    showHideTabPage(tabPage, false);
                }
            }
        }

        public void newConsoleMessage(string input)
        {
            Console.Items.Add("(" + DateTime.Now.ToString() + ") " + input);
            Console.SelectedIndex = (Console.Items.Count - 1);
        }
    }
}
