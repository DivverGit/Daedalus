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
        public TabPage Combat;

        private void initTabPages()
        {
            General = tabControl1.TabPages[0];
            Station = tabControl1.TabPages[1];
            Space = tabControl1.TabPages[2];
            Combat = tabControl1.TabPages[3];

            showHideTabPage(General, true);
            showHideTabPage(Station, true);
            showHideTabPage(Space, true);
            showHideTabPage(Combat, true);
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
            else if (page == Combat)
            {
                if (hide) tabControl1.TabPages.Remove(Combat);
                else
                {
                    tabControl1.TabPages.Insert(0, Combat);
                }
            }
        }

        public void switchTabPage(TabPage page)
        {
            TabPage[] tabPages = { General, Station, Space, Combat };

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
        public enum statusLabels
        {
            shipName,
            shield,
            armor,
            hull,
            hiSlot1,
            hiSlot2,
            hiSlot3,
            hiSlot4,
            hiSlot5,
            hiSlot6,
            hiSlot7,
            hiSlot8
        }

        public void changeStationLabel(statusLabels label, string value)
        {
            if(label == statusLabels.shipName) shipNameValueLabel.Text = value;
            else if (label == statusLabels.shield) shieldValueLabel.Text = value;
            else if (label == statusLabels.armor) armorValueLabel.Text = value;
            else if (label == statusLabels.hull) hullValueLabel.Text = value;
            else if (label == statusLabels.hiSlot1) hiSlot1ValueLabel.Text = value;
            else if (label == statusLabels.hiSlot2) hiSlot2ValueLabel.Text = value;
            else if (label == statusLabels.hiSlot3) hiSlot3ValueLabel.Text = value;
            else if (label == statusLabels.hiSlot4) hiSlot4ValueLabel.Text = value;
            else if (label == statusLabels.hiSlot5) hiSlot5ValueLabel.Text = value;
            else if (label == statusLabels.hiSlot6) hiSlot6ValueLabel.Text = value;
            else if (label == statusLabels.hiSlot7) hiSlot7ValueLabel.Text = value;
            else if (label == statusLabels.hiSlot8) hiSlot8ValueLabel.Text = value;
        }

        // Misc functions
        public void newConsoleMessage(string input)
        {
            Console.Items.Add("(" + DateTime.Now.ToString("HH:mm:ss") + ") " + input);
            Console.SelectedIndex = (Console.Items.Count - 1);
        }

        private void undockButton_Click(object sender, EventArgs e)
        {
            m_RoutineController.activeRoutine = Routine.Station_Leave;
            r_Station_Leave.triggerLeaveStation();
        }
    }
}
