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
using EVE.ISXEVE;
using Daedalus.Data;
using Daedalus.Functions;

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

            double newValue = Settings.Default.orbitRange;
            orbitTrackbar_Update(newValue);

            profileComboBox.SelectedIndex = 0;
        }

        // Labels
        public void changeStatusLabel(StatusLabel label, string value)
        {
            if(label == StatusLabel.shipName) shipNameValueLabel.Text = value;
            else if (label == StatusLabel.shield) shieldValueLabel.Text = value;
            else if (label == StatusLabel.armor) armorValueLabel.Text = value;
            else if (label == StatusLabel.hull) hullValueLabel.Text = value;
            else if (label == StatusLabel.hiSlot1) hiSlot1ValueLabel.Text = value;
            else if (label == StatusLabel.hiSlot2) hiSlot2ValueLabel.Text = value;
            else if (label == StatusLabel.hiSlot3) hiSlot3ValueLabel.Text = value;
            else if (label == StatusLabel.hiSlot4) hiSlot4ValueLabel.Text = value;
            else if (label == StatusLabel.hiSlot5) hiSlot5ValueLabel.Text = value;
            else if (label == StatusLabel.hiSlot6) hiSlot6ValueLabel.Text = value;
            else if (label == StatusLabel.hiSlot7) hiSlot7ValueLabel.Text = value;
            else if (label == StatusLabel.hiSlot8) hiSlot8ValueLabel.Text = value;
            else if (label == StatusLabel.medSlot1) medSlot1ValueLabel.Text = value;
            else if (label == StatusLabel.medSlot2) medSlot2ValueLabel.Text = value;
            else if (label == StatusLabel.medSlot3) medSlot3ValueLabel.Text = value;
            else if (label == StatusLabel.medSlot4) medSlot4ValueLabel.Text = value;
            else if (label == StatusLabel.medSlot5) medSlot5ValueLabel.Text = value;
            else if (label == StatusLabel.medSlot6) medSlot6ValueLabel.Text = value;
            else if (label == StatusLabel.medSlot7) medSlot7ValueLabel.Text = value;
            else if (label == StatusLabel.medSlot8) medSlot8ValueLabel.Text = value;
        }
        public void changeStatusLabelColour(StatusLabel label, Color color)
        {
            if (label == StatusLabel.shipName) shipNameValueLabel.ForeColor = color;
            else if (label == StatusLabel.shield) shieldValueLabel.ForeColor = color;
            else if (label == StatusLabel.armor) armorValueLabel.ForeColor = color;
            else if (label == StatusLabel.hull) hullValueLabel.ForeColor = color;
            else if (label == StatusLabel.hiSlot1) hiSlot1ValueLabel.ForeColor = color;
            else if (label == StatusLabel.hiSlot2) hiSlot2ValueLabel.ForeColor = color;
            else if (label == StatusLabel.hiSlot3) hiSlot3ValueLabel.ForeColor = color;
            else if (label == StatusLabel.hiSlot4) hiSlot4ValueLabel.ForeColor = color;
            else if (label == StatusLabel.hiSlot5) hiSlot5ValueLabel.ForeColor = color;
            else if (label == StatusLabel.hiSlot6) hiSlot6ValueLabel.ForeColor = color;
            else if (label == StatusLabel.hiSlot7) hiSlot7ValueLabel.ForeColor = color;
            else if (label == StatusLabel.hiSlot8) hiSlot8ValueLabel.ForeColor = color;
            else if (label == StatusLabel.medSlot1) medSlot1ValueLabel.ForeColor = color;
            else if (label == StatusLabel.medSlot2) medSlot2ValueLabel.ForeColor = color;
            else if (label == StatusLabel.medSlot3) medSlot3ValueLabel.ForeColor = color;
            else if (label == StatusLabel.medSlot4) medSlot4ValueLabel.ForeColor = color;
            else if (label == StatusLabel.medSlot5) medSlot5ValueLabel.ForeColor = color;
            else if (label == StatusLabel.medSlot6) medSlot6ValueLabel.ForeColor = color;
            else if (label == StatusLabel.medSlot7) medSlot7ValueLabel.ForeColor = color;
            else if (label == StatusLabel.medSlot8) medSlot8ValueLabel.ForeColor = color;
        }

        // Preferences
        public static double orbitRange;
        public static TargetingProfile selectedTargetingProfile = TargetingProfile.byDistance;
        private void orbitTrackbar_Scroll(object sender, EventArgs e)
        {
            double newValue = orbitTrackbar.Value;
            orbitTrackbar_Update(newValue);
        }
        private void orbitTrackbar_Update(double newValue)
        {
            orbitRange = newValue;
            orbitValueLabel.Text = newValue.ToString() + "m";
            Settings.Default.orbitRange = newValue;
            Settings.Default.Save();
        }
        private void profileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (profileComboBox.SelectedItem.ToString() == "by Class") selectedTargetingProfile = TargetingProfile.byClass;
            else if (profileComboBox.SelectedItem.ToString() == "by Distance") selectedTargetingProfile = TargetingProfile.byDistance;
        }

        // Log & Targets
        public void newConsoleMessage(string input)
        {
            Console.Items.Add("(" + DateTime.Now.ToString("HH:mm:ss") + ") " + input);
            Console.SelectedIndex = (Console.Items.Count - 1);
        }
        public void setTargetsList(List<EnemyNPC> targets)
        {
            targetsListBox.Items.Clear();
            foreach (EnemyNPC target in targets)
            {
                targetsListBox.Items.Add(target.entity.Name + " (" + target.shipClass + ") - " + target.distance.ToString("#") + "m - isPriority=" + target.isPriority.ToString());
            }
            targetsListBox.Refresh();
        }

        private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string toCopy = "";
            foreach(var line in Console.Items)
            {
                toCopy += line + "\n";
            }
            Clipboard.SetText(toCopy);
        }
    }
    public enum StatusLabel
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
    public enum TargetingProfile
    {
        byClass,
        byDistance
    }
}
