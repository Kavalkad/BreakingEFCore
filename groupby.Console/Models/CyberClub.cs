using System;
using System.Collections.Generic;


namespace groupby.Models;

public class CyberClub
{
    public int CyberClubId { get; set; }
    public string? Name { get; set; }
    public string? City { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public ICollection<GamingPlace> Places { get; set; } = new List<GamingPlace>(); 

    
}
