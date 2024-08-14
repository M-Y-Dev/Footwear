using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footwear.Application.Base
{
    public class Response<T>
    {
        public bool ResponseIsSuccessfull { get; set; }
        public string ResponseMessage { get; set; }
        public int ResponseStatusCode { get; set; }
        public T? ResponseData { get; set; }
        public List<string>? ResponseErrors { get; set; }
        public Response()
        {
            ResponseIsSuccessfull = false;
            ResponseMessage = string.Empty;
            ResponseStatusCode = 0;
            ResponseData = default;
            ResponseErrors = new List<string>();
        }
    }

}
