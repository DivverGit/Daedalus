using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Daedalus
{
    static class Program
    {
        public static UI DaedalusUI;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (UI MainForm = new UI())
            {
                DaedalusUI = MainForm;
                Application.Run(MainForm);
            }
            DaedalusUI = null;
        }
    }
}
