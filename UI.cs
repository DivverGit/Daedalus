using Daedalus.Controllers;
using Daedalus.Routines;
using Daedalus.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Daedalus.Data;

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

            double newValue = Settings.Default.movementRange;
            orbitTrackbar_Update(newValue);

            movementComboBox.SelectedIndex = Settings.Default.movementIndex;
            propulsionComboBox.SelectedIndex = Settings.Default.propulsionIndex;
            targetingComboBox.SelectedIndex = Settings.Default.targetingIndex;
            //d_ESI.QueryESI(17609, QueryType.byTypeid);
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
        public static TargetingProfile selectedTargetingProfile = TargetingProfile.byDistance;
        private void orbitTrackbar_Scroll(object sender, EventArgs e)
        {
            double newValue = orbitTrackbar.Value;
            orbitTrackbar_Update(newValue);
        }
        private void orbitTrackbar_Update(double newValue)
        {
            orbitTrackbar.Value = Convert.ToInt32(newValue);
            orbitValueLabel.Text = newValue.ToString() + "m";
            Settings.Default.movementRange = newValue;
            Settings.Default.Save();
        }
        private void movementComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (movementComboBox.SelectedIndex == 0) Settings.Default.movementIndex = 0;
            else if (movementComboBox.SelectedIndex == 1) Settings.Default.movementIndex = 1;
            Settings.Default.Save();
        }
        private void propulsionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (propulsionComboBox.SelectedIndex == 0) Settings.Default.propulsionIndex = 0;
            else if (propulsionComboBox.SelectedIndex == 1) Settings.Default.propulsionIndex = 1;
            Settings.Default.Save();
        }
        private void targetingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (targetingComboBox.SelectedIndex == 0)
            {
                selectedTargetingProfile = TargetingProfile.byClass;
                Settings.Default.targetingIndex = 0;
            }
            else if (targetingComboBox.SelectedIndex == 1)
            {
                selectedTargetingProfile = TargetingProfile.byDistance;
                Settings.Default.targetingIndex = 1;
            }
            Settings.Default.Save();
        }

        // Log & Targets
        public void newConsoleMessage(string input)
        {
            //Console.Items.Add("(" + DateTime.Now.ToString("HH:mm:ss") + ") " + input);
            Console.Items.Add(input);
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
