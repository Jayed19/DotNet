using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BvrsRestLibTestModule.Views
{
    public partial class vMain : Form
    {
        public vMain()
        {
            InitializeComponent();
        }

        private void bRegisterWs_Click(object sender, EventArgs e)
        {
            vTestWsRegistration ws = new BvrsRestLibTestModule.vTestWsRegistration();
            ws.ShowDialog();
        }
    }
}
