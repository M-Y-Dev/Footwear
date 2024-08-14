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
        public int StatusCode { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }
        public Response()
        {
            IsSuccessfull = false;
            Message = string.Empty;
            StatusCode = 0;
            Data = default;
            Errors = new List<string>();
        }
    }

}
