using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ServiceResponse<T>
    {
        public T MyProperty { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
        public List<Character> Data { get; internal set; }
    }
}