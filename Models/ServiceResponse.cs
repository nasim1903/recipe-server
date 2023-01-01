using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recipe_server.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}