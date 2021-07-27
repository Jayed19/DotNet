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
    internal class WsRegistration
    {
        private vTestWsRegistration m_View = new vTestWsRegistration();
        RESTManager m_Rest = new RESTManager();
        public WsRegistration(vTestWsRegistration view)
        {
            m_View = view;
        }

        internal void Register()
        {
            try
            {
                // 0. Prepare WS data

                // 0.0 Get from test class
                Counter counter = TestSamples.TestScript.GetCounter();
                // 0.1. Get from view

                // 1. Consume library
                m_Rest.RegisterCounter(counter);
            }
            catch (Exception ex)
            {
                TLog.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
