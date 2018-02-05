using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Timers;
using System.Windows.Forms;


namespace MyTrayIcon
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*
        // Timer 
        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            Process[] processesTaskmgr = Process.GetProcessesByName("Taskmgr");
            Process[] processesNotepad = Process.GetProcessesByName("Notepad");

            if (processesNotepad.Length == 0 && processesTaskmgr.Length > 0)
            {
                foreach (Process process in processesTaskmgr)
                {
                    process.Kill();
                }
            }
        }
        */


        void NotepadExitedEvent(object sender, EventArgs e)
        {
            Process[] processesTaskmgr = Process.GetProcessesByName("Taskmgr");
            if (processesTaskmgr.Length > 0)
            {
                foreach (Process process in processesTaskmgr)
                {
                    process.Kill();
                }
            }
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Visible = false;
            ShowInTaskbar = false;

            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(1000, "Title", "Minimize test", ToolTipIcon.Info);

            /*
            // Timer to check
            Timer timer = new Timer
            {
                Interval = 1000
            };
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Start();
            */
            

            Process[] processesNotepad = Process.GetProcessesByName("Notepad");

            if (processesNotepad.Length > 0)
            {
                processesNotepad[0].EnableRaisingEvents = true;
                processesNotepad[0].Exited += new EventHandler(NotepadExitedEvent);
            }
            
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("Taskmgr");
            if (processes.Length > 0)
            {
                MessageBox.Show("Yes");
                foreach (Process process in processes)
                {

                    // process.Kill();
                } 
            }
            else
            {
                MessageBox.Show("No");
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("Taskmgr");
            if (processes.Length > 0)
            {
                MessageBox.Show("Yes");
                foreach (Process process in processes)
                {
                    // process.Kill();

                }
            }
            else
            {
                MessageBox.Show("No");
            }
        }
    }
}
