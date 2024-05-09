using System;
using APIAutomation.Interfaces;
using APIAutomation.Model;

namespace APIAutomation.Repository;

public class RepositoryRoleSoundConsole : IRoleSoundConsole
{
	public RepositoryRoleSoundConsole() {}

    public ResponseRole GetTodayRole()
    {
        return new ResponseRole("Abi", "Abihud");
    }
}

