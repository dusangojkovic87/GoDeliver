using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public string Details { get; set; }
    }
}