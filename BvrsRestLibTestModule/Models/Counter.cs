using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvrsRestLibTestModule.Models
{
    [Serializable]
    public class Counter
    {
        public string ProductKey { get; set; }
        public string MachineMacId { get; set; }
        public string MachineHddId { get; set; }
        public string MahcineCpuId { get; set; }
        public string ProductUuId { get; set; }
        public string ProductName { get; set; }
        public string PublicKey { get; set; }
        public byte[] PublicKeyEncodedByte { get; set; }
        public string Signature { get; set; }
        public string Hash256 { get; set; }
        public string ExpiryDate { get; set; }
        public string CountryId { get; set; }
        public string DivisionId { get; set; }
        public string ZilaId { get; set; }
        public string UpazilaId { get; set; }
        public string CounterType { get; set; }
        public string CounterId { get; set; }
    }
}
