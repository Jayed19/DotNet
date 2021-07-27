using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BvrsRestLibTestModule.Models;

namespace BvrsRestLibTestModule.TestSamples
{
    internal static class TestWSync
    {

        public static WSyncmodel GetWSList()
        {
            WSyncmodel _GetWSList = new Models.WSyncmodel();

            _GetWSList.upoID = "2245";




            return _GetWSList;
        }
    }
}
