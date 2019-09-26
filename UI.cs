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
        }

        public void NewConsoleMessage(string input)
        {
            Console.Items.Add(input);
            Console.SelectedIndex = (Console.Items.Count - 1);
        }
    }
}
