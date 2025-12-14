

using System.Diagnostics.Contracts;
using groupby.Enums;

namespace groupby.Models
{
    public class Computer
    {
        public int ComputerId { get; set; }
       

        public VideoCard VideoCard { get; set; }
        public int Power { get; set; }
        public ICollection<GamingPlace> GamingPlaces { get; set; } = new List<GamingPlace>();
    }
}