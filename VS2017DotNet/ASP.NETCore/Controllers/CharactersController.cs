using ASP.NETCore.Interfaces;
using ASP.NETCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ASP.NETCore.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ICharacterRepository _characterRepository;

        public CharactersController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        // GET: /Characters/
        public IActionResult Index()
        {
            PopulateCharactersIfNoneExist();
            var characters = _characterRepository.ListAll();

            return View(characters);
        }

        private void PopulateCharactersIfNoneExist()
        {
            if (!_characterRepository.ListAll().Any())
            {
                _characterRepository.Add(new Character("Darth Maul"));
                _characterRepository.Add(new Character("Darth Vader"));
                _characterRepository.Add(new Character("Yoda"));
                _characterRepository.Add(new Character("Mace Windu"));
            }
        }
    }
}