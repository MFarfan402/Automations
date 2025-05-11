using System;
using APIAutomation.Interfaces;
using APIAutomation.Model;
using Newtonsoft.Json;

namespace APIAutomation.Repository;

public class AllRolesRepository : IAllRoles
{
    public AllRolesRepository(){}

    public AllResponseRole GetTodayRole()
    {
        try
        {
            string fileName = "Source/Roles.json";
            string json = File.ReadAllText(fileName);

            AllResponseRole[]? roles = JsonConvert.DeserializeObject<AllResponseRole[]>(json);

            DateTime dateTimeUTC = DateTime.UtcNow;
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            DateTime dateTimeWithTimeZone = TimeZoneInfo.ConvertTimeFromUtc(dateTimeUTC, timeZone);

            DayOfWeek dayOfWeek = dateTimeWithTimeZone.DayOfWeek;

            if (dayOfWeek == DayOfWeek.Friday && roles is not null)
            {
                string actualDate = dateTimeWithTimeZone.ToString("dd/MM/yyyy");
                return ObtainRolePerDay(roles, actualDate);
            }
            else if (dayOfWeek == DayOfWeek.Saturday && roles is not null)
            {
                string tomorrowDate = dateTimeWithTimeZone.AddDays(1).ToString("dd/MM/yyyy");
                return ObtainRolePerDay(roles, tomorrowDate);
            }
            else
                return new AllResponseRole();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file. {ex.Message}");
            return new AllResponseRole();
        }
    }

    private static AllResponseRole ObtainRolePerDay(AllResponseRole[] roles, string date)
    {
        foreach (AllResponseRole role in roles)
        {
            if (role.Date.Equals(date))
            {
                AllResponseRole response = new();
                response.Date = role.Date;
                response.Auditorium = role.Auditorium;
                response.Parking = role.Parking;
                return response;
            }
        }
        return new AllResponseRole();
    }
}