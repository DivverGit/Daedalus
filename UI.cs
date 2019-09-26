using Daedalus.Modules;
using Daedalus.Routines;
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

        // Tab functions
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

        // Label functions
        public enum stationLabels
        {
            shipName,
            shield,
            armor,
            hull
        }

        public void changeStationLabel(stationLabels label, string value)
        {
            if(label == stationLabels.shipName) shipNameValueLabel.Text = value;
            else if (label == stationLabels.shield) shieldValueLabel.Text = value;
            else if (label == stationLabels.armor) armorValueLabel.Text = value;
            else if (label == stationLabels.hull) hullValueLabel.Text = value;
        }

        // Misc functions
        public void newConsoleMessage(string input)
        {
            Console.Items.Add("(" + DateTime.Now.ToString() + ") " + input);
            Console.SelectedIndex = (Console.Items.Count - 1);
        }

        private void undockButton_Click(object sender, EventArgs e)
        {
            m_RoutineController.activeRoutine = Routine.Station_Leave;
            r_Station_Leave.triggerLeaveStation();
        }
    }
}
