using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace URM_Unmanned_Ripping_Machine
{
    public partial class Notification : Form
    {
        public Notification(string message)
        {
            InitializeComponent();
            this.label1.Text = message;
        }

        private void closeFRM_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
