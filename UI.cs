using Daedalus.Controllers;
using Daedalus.Routines;
using Daedalus.Properties;
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
            hiSlot8,
            medSlot1,
            medSlot2,
            medSlot3,
            medSlot4,
            medSlot5,
            medSlot6,
            medSlot7,
            medSlot8,
            loSlot1,
            loSlot2,
            loSlot3,
            loSlot4,
            loSlot5,
            loSlot6,
            loSlot7,
            loSlot8
        }
        public void changeStatusLabel(statusLabels label, string value)
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
            else if (label == statusLabels.medSlot1) medSlot1ValueLabel.Text = value;
            else if (label == statusLabels.medSlot2) medSlot2ValueLabel.Text = value;
            else if (label == statusLabels.medSlot3) medSlot3ValueLabel.Text = value;
            else if (label == statusLabels.medSlot4) medSlot4ValueLabel.Text = value;
            else if (label == statusLabels.medSlot5) medSlot5ValueLabel.Text = value;
            else if (label == statusLabels.medSlot6) medSlot6ValueLabel.Text = value;
            else if (label == statusLabels.medSlot7) medSlot7ValueLabel.Text = value;
            else if (label == statusLabels.medSlot8) medSlot8ValueLabel.Text = value;
        }

        public void changeStatusLabelColour(statusLabels label, Color color)
        {
            if (label == statusLabels.shipName) shipNameValueLabel.ForeColor = color;
            else if (label == statusLabels.shield) shieldValueLabel.ForeColor = color;
            else if (label == statusLabels.armor) armorValueLabel.ForeColor = color;
            else if (label == statusLabels.hull) hullValueLabel.ForeColor = color;
            else if (label == statusLabels.hiSlot1) hiSlot1ValueLabel.ForeColor = color;
            else if (label == statusLabels.hiSlot2) hiSlot2ValueLabel.ForeColor = color;
            else if (label == statusLabels.hiSlot3) hiSlot3ValueLabel.ForeColor = color;
            else if (label == statusLabels.hiSlot4) hiSlot4ValueLabel.ForeColor = color;
            else if (label == statusLabels.hiSlot5) hiSlot5ValueLabel.ForeColor = color;
            else if (label == statusLabels.hiSlot6) hiSlot6ValueLabel.ForeColor = color;
            else if (label == statusLabels.hiSlot7) hiSlot7ValueLabel.ForeColor = color;
            else if (label == statusLabels.hiSlot8) hiSlot8ValueLabel.ForeColor = color;
            else if (label == statusLabels.medSlot1) medSlot1ValueLabel.ForeColor = color;
            else if (label == statusLabels.medSlot2) medSlot2ValueLabel.ForeColor = color;
            else if (label == statusLabels.medSlot3) medSlot3ValueLabel.ForeColor = color;
            else if (label == statusLabels.medSlot4) medSlot4ValueLabel.ForeColor = color;
            else if (label == statusLabels.medSlot5) medSlot5ValueLabel.ForeColor = color;
            else if (label == statusLabels.medSlot6) medSlot6ValueLabel.ForeColor = color;
            else if (label == statusLabels.medSlot7) medSlot7ValueLabel.ForeColor = color;
            else if (label == statusLabels.medSlot8) medSlot8ValueLabel.ForeColor = color;
        }

        // Misc functions
        public void newConsoleMessage(string input)
        {
            Console.Items.Add("(" + DateTime.Now.ToString("HH:mm:ss") + ") " + input);
            Console.SelectedIndex = (Console.Items.Count - 1);
        }
    }
}
