using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Infrastracture.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public string ErrorMessage { get; set; }
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string message) : base(message)
        {
            ErrorMessage = message;
        }


    }
}