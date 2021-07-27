using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BvrsRestLibTestModule.Views;
using BvrsRestLibTestModule.TestSamples;
using BvrsRestLibTestModule.Models;
using BvrsRestLibTestModule.Services;

namespace BvrsRestLibTestModule.Presenter
{   
    internal class WsSync
    {
        private vTestWsRegistration m2_View = new vTestWsRegistration();//Design Form
        RESTManagerWSync m2_Rest = new RESTManagerWSync();//Rest Service For Workstation Sync
        public WsSync(vTestWsRegistration view)
        {
            m2_View = view;
        }

        internal void WSync()
        {
            try
            {
                // 0. Prepare WS data

                // 0.0 Get from test class
                WSyncmodel wSyncmodel = TestSamples.TestWSync.GetWSList();
                // 0.1. Get from view

                // 1. Consume library
                m2_Rest.WSsyncMethod(wSyncmodel);
            }
            catch (Exception ex)
            {
                TLog.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
