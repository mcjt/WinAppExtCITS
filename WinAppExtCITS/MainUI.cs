using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WinAppExtCITS.SHR;

namespace WinAppExtCITS
{
    public partial class MainUI : Form
    {
        Thread serverThread;

        public MainUI()
        {
            InitializeComponent();
            CitsConnect.onConnection = onConnectionChange;
            Logger.Init();
        }

        private int onConnectionChange(Boolean status)
        {
            if (status)
            {
                connectIcon.Image = global::WinAppExtCITS.Properties.Resources.success;
            }
            else
            {
                connectIcon.Image = global::WinAppExtCITS.Properties.Resources.error;
            }
            return 0;
        }

        private void start_Click(object sender, EventArgs e)
        {
            Spy.startSpy();
        }


        private void startServer()
        {
            CitsConnect.connectTo(serverUrl.Text);
        }

        private void stop_Click(object sender, EventArgs e)
        {
            Spy.stopSpy();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CitsConnect.stopAll();
            serverThread = new Thread(new ThreadStart(startServer));
            serverThread.Start();
        }
    }
}
