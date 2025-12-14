using groupby.Enums;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace groupby.Models
{
    public class GamingPlace
    {
        public int GamingPlaceId { get; set; }

        public int CyberClubId { get; set; }
        public CyberClub? CyberClub { get; set; }

        public int ComputerId { get; set; }
        public Computer? Computer { get; set; }

        public decimal Price { get; set; }
        public bool IsOrdered { get; set; }
        public Seat Seat { get; set; }
    }
}