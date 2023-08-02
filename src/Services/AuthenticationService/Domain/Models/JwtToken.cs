using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class JwtToken
    {
        public string Token { get; set; }
        public string ErrorMessage { get; set; }
    }
}