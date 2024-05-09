using System;
namespace APIAutomation.Model;

public class ResponseRole
{
	public string PersonA { get; set; }
	public string PersonB { get; set; }
	public string Date { get; set; }

	public ResponseRole()
	{
		PersonA = "";
		PersonB = "";
        Date = "";

    }

    public ResponseRole(string personA, string personB, string date)
    {
        PersonA = personA;
        PersonB = personB;
        Date = date;
    }
}

