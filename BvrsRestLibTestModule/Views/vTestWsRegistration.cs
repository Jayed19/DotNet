using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BvrsRestLibTestModule.Presenter;
using BvrsRestLibTestModule.Models;

namespace BvrsRestLibTestModule
{
    public partial class vTestWsRegistration : Form
    {
        WsSync wsn;
        public vTestWsRegistration()
        {
            InitializeComponent();
        }

        private void vTestWsRegistration_Load(object sender, EventArgs e)
        {
            wsn = new WsSync(this);
        }

        private void bRegister_Click(object sender, EventArgs e)
        {
            try
            {
                wsn.WSync();
            }
            catch (Exception ex)
            {
                TLog.Error(ex.Message, ex);
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
