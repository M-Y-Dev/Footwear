using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Base
{
    public class Response<T>
    {
        public bool IsSuccessfull { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public T Data { get; set; }
    }
}
