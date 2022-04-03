using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangy_Models
{
    public class SuccessModelDTO
    {
        public int SuccessCode { get; set; }
        public string SuccessMessage { get; set; }
        public object Data { get; set; }
    }
}
