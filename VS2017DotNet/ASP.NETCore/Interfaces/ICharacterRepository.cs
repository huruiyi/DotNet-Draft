using ASP.NETCore.Models;
using System.Collections.Generic;

namespace ASP.NETCore.Interfaces
{
    public interface ICharacterRepository
    {
        IEnumerable<Character> ListAll();

        void Add(Character character);
    }
}