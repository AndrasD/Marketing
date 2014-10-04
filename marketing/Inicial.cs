using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace marketing
{
    public partial class InicialForm : Form
    {
        delegate void InicialShowCloseDelegate();
        delegate void StringParameterDelegate(string Text);

        public InicialForm()
        {
            InitializeComponent();
        }

        public void ShowInicialScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new InicialShowCloseDelegate(ShowInicialScreen));
                return;
            }
            this.Show();
            Application.Run(this);
        }

        /// <summary>
        /// Closes the SplashScreen
        /// </summary>
        public void CloseInicialScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new InicialShowCloseDelegate(CloseInicialScreen));
                return;
            }
            this.Close();
        }

        public void UdpateStatusText(string Text)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterDelegate(UdpateStatusText), new object[] { Text });
                return;
            }
            label1.Text = Text;
        }

    }
}