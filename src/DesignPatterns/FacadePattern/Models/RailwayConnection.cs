using System;

namespace FacadePattern.Models
{
    public class RailwayConnection
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime When { get; set; }
        public int Distance { get; set; }
    }

   
}
