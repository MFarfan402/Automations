using System;
namespace APIAutomation.Model;

public class AllResponseRole
{
    public AllResponseRole()
    {
        Date = "";
        Parking = new List<Person>();
        Auditorium = new List<Person>();
    }

    public string Date { get; set; }
    public List<Person> Parking { get; set; }
    public List<Person> Auditorium { get; set; }
}


