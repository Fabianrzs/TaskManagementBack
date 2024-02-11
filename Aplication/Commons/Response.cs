using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Base
{
    public class Response<TEntity>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public TEntity Data { get; set; }
        public Response()
        {
            
        }
        public Response(TEntity data)
        {
            Data = data;
            Success = true;
            Message = string.Empty;
        }
        public Response(TEntity data, string message)
        {
            Data = data;
            Message = message;
            Success = true;
        }

        public Response(string message)
        {
            Message = message;
            Success = false;
        }
    }
}
