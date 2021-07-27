using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BvrsRestLibTestModule.Models;

namespace BvrsRestLibTestModule.TestSamples
{
    internal static class TestScript
    {

        public static Counter GetCounter()
        {
            Counter _counter = new Models.Counter();

            _counter.ProductKey = "WV5L-Q2RB-9NXM";
            _counter.CountryId = "1018";
            _counter.DivisionId = "999";
            if (_counter.DivisionId.Equals(OFFICE.HQ.GetStringCode()))
            {
                _counter.DivisionId = OFFICE.HQ.ToString();
                _counter.ZilaId = OFFICE.HQ.ToString();
                _counter.UpazilaId = OFFICE.HQ.GetStringCode();
            }
            else
            {
                //_counter.ZilaId = "";
                //_counter.UpazilaId = "";
            }

            _counter.MachineMacId = "00FFA34728DF";
            _counter.MachineHddId = "WD-WCC3F6TCKZ9P";
            _counter.MahcineCpuId = "BFEBFBFF000306C3";
            _counter.ProductUuId = "9E0A0D00-E83F-11E4-BB78-8CDCD449352D";
            _counter.ProductName = "BVRS_Enrollment_System";
            _counter.CounterType = "Fixed";
            _counter.CounterId = "Ecs/0999/0001";


            return _counter;
        }
    }
}
