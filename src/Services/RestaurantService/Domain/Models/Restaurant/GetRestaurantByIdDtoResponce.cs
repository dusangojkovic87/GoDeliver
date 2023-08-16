using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Models.Restaurant
{
    public class GetRestaurantByIdDtoResponce
    {
        public Domain.Entities.Restaurant restaurant { get; set; }
        public bool isNullable { get; set; }
    }
}