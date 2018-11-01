using CitiesGame.DAL.Interfaces;
using CitiesGame.DAL.Repositories;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System;

namespace CitiesGame.Models
{
    public class GameViewModel:IValidatableObject
    {
        static IRepository<CitiesGame.DAL.Entities.City> db;

        static GameViewModel()
        {
           db = new CityRepository();
        }   

        public List<GameItem> Items { get; set; }

        public string Author { get; set; }

        public string City { get; set; }         

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            City = City.Trim();
            if (string.IsNullOrEmpty(City))
            {
                yield return new ValidationResult("Поле \"Город\" не может быть пустым.");
            }
            else if(!City.All(char.IsLetter))
            {
                yield return new ValidationResult($"Название города должно содержать только буквенные символы.");
            }
            else
            {                
                if (Game.Items.Any())
                {
                    GameItem gameItem = Game.Items.FirstOrDefault(i => string.Equals(i.City, City, StringComparison.InvariantCultureIgnoreCase));
                    if(gameItem != null)
                    {
                        yield return new ValidationResult($"Город {gameItem.City} ранее был назван игроком {gameItem.Author}");
                    }
                    char lastLetter = Game.Items.Last().City.ToUpper().Last(c => c != 'Ь');
                    if (!City.ToUpper().StartsWith((lastLetter == 'Й') ? "И" : ((lastLetter == 'Ё') ? "Е" : lastLetter.ToString())))
                    {
                        yield return new ValidationResult($"Название города должно начинаться с буквы {lastLetter}.");
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