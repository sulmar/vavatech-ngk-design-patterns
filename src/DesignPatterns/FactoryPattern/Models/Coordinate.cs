using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Models
{
	public class Coordinate
	{
		// Długość geograficzna	
		public double Longitude { get; }

		// Szerokość geograficzna
		public double Latitude { get; }

		public Coordinate(double lng, double lat)
		{
			this.Longitude = lng;
			this.Latitude = lat;
		}

		
	}
}
