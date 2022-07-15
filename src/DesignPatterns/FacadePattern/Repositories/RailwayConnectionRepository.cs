using FacadePattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern.Repositories
{
    public class RailwayConnectionRepository
    {
        public RailwayConnection Find(string from, string to, DateTime when)
        {
            return new RailwayConnection { From = from, To = to, When = when, Distance = 1000 };
        }
    }

   
}
