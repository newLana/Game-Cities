using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CitiesGame.DAL.Entities;
using CitiesGame.DAL.Interfaces;
using CitiesGame.DAL.Repositories;

namespace CitiesGame.Models
{
    public class GameViewModelValidator
    {
        static IRepository<City> db;

        static GameViewModelValidator()
        {
            db = new CityRepository();
        }

        public IEnumerable<ValidationResult> ValidationSummury(GameViewModel gameViewModel)
        {
            string City = gameViewModel.City.Trim();

            if (string.IsNullOrEmpty(City))
            {
                yield return new ValidationResult("Поле \"Город\" не может быть пустым.");
            }
            else if (!City.All(char.IsLetter))
            {
                yield return new ValidationResult($"Название города должно содержать только буквенные символы.");
            }
            else
            {
                if (Game.Items.Any())
                {
                    GameItem gameItem = Game.Items.FirstOrDefault(i => string.Equals(i.City, City,
                        StringComparison.InvariantCultureIgnoreCase));

                    char lastLetter = Game.Items.LastOrDefault().City.ToUpper().Last(c => c != 'Ь');

                    if (!City.ToUpper().StartsWith((lastLetter == 'Й') ? "И" : ((lastLetter == 'Ё') ? "Е" : lastLetter.ToString())))
                    {
                        yield return new ValidationResult($"Название города должно начинаться с буквы {lastLetter}.");
                    }
                    else if (gameItem != null)
                    {
                        yield return new ValidationResult($"Город {gameItem.City} ранее был назван игроком {gameItem.Author}");
                    }
                }
                if (!db.Contains(City))
                {
                    yield return new ValidationResult("Такого города нет в базе.");
                }
            }
        }
    }
}