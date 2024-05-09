using System;
using APIAutomation.Interfaces;
using APIAutomation.Model;
using Newtonsoft.Json;

namespace APIAutomation.Repository;

public class RepositoryRoleSoundConsole : IRoleSoundConsole
{
	public RepositoryRoleSoundConsole() {}

    public ResponseRole GetTodayRole()
    {
        try
        {
            string fileName = "Source/RoleSound.json";
            string json = File.ReadAllText(fileName);

            ResponseRole[]? roles = JsonConvert.DeserializeObject<ResponseRole[]>(json);

            DateTime dateTimeUTC = DateTime.UtcNow;
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            DateTime dateTimeWithTimeZone = TimeZoneInfo.ConvertTimeFromUtc(dateTimeUTC, timeZone);

            DayOfWeek dayOfWeek = dateTimeWithTimeZone.DayOfWeek;

            if (dayOfWeek == DayOfWeek.Thursday)
            {
                string actualDate = dateTimeWithTimeZone.ToString("dd/MM/yyyy");
                return ObtainRolePerDay(roles, actualDate);
            }
            else if (dayOfWeek == DayOfWeek.Saturday)
            {
                string tomorrowDate = dateTimeWithTimeZone.AddDays(1).ToString("dd/MM/yyyy");
                return ObtainRolePerDay(roles, tomorrowDate);
            }
            else
                return new ResponseRole();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file. {ex.Message}");
            return new ResponseRole();
        }
    }

    private static ResponseRole ObtainRolePerDay(ResponseRole[] roles, string date)
    {
        foreach (ResponseRole role in roles)
        {
            if (role.Date.Equals(date))
            {
                return new ResponseRole(role.PersonA, role.PersonB, role.Date);
            }
        }
        return new ResponseRole();
    }
}

