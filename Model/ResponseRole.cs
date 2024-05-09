using System;
namespace APIAutomation.Model;

public class ResponseRole
{
	public string PersonA { get; set; }
	public string PersonB { get; set; }

	public ResponseRole()
	{
		PersonA = "";
		PersonB = "";
	}

    public ResponseRole(string personA, string personB)
    {
        PersonA = personA;
        PersonB = personB;
    }
}

