using Daedalus.Resources;
using Daedalus.Resources.Structures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            //new FileInfo(@"D:\Testdir\test.txt").Directory.Create();
            Directory.CreateDirectory(Path.GetDirectoryName(@"D:\Testdir\test.txt"));
            //Directory.CreateDirectory(@"D:\Testdir\test.txt");

            return;
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
