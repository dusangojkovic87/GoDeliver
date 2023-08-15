using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using MediatR;

namespace Application.Commands.Restaurant
{
    public class AddRestaurantCommand : IRequest<AddRestaurantDto>
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public string PostalCode { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public DateTime OpeningTime { get; set; }

        public DateTime ClosingTime { get; set; }


    }
}