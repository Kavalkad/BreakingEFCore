using System;
using System.Collections.Generic;
using groupby.Enums;
namespace groupby.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    public int CyberClubId { get; set; }
    public CyberClub? CyberClub { get; set; }
    public string? Name { get; set; }
    public int Salary { get; set; }
    public Position Position { get; set; }


}
