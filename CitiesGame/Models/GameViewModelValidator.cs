using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CitiesGame.Models.Interfaces;
using CitiesGame.Models.Entities;
using CitiesGame.Models.DI;

namespace CitiesGame.Models
{
    public class GameViewModelValidator
    {
        static IRepository<City> db = (IRepository<City>)new CustomDependencyResolver()
            .GetService(typeof(IRepository<City>));

        public List<ValidationResult> ValidationResults { get; set; } 
            = new List<ValidationResult>();

        private string city;        

        public IEnumerable<ValidationResult> ValidationSummury(GameViewModel gameViewModel)
        {
            city = gameViewModel.City.Trim();

            CityNameNotEmpty();
            CityContainsLettersOnly();

            if (!ValidationResults.Any() && Game.Items.Any())
            {
                ValidLastLetter();
                CityHasUsed();
                ValidCityName();
            }

            return ValidationResults;
        }

        private void ValidCityName()
        {
            if (!db.Contains(city))
            {
                ValidationResults.Add(new ValidationResult("Такого города нет в базе."));
            }
        }

        private void CityHasUsed()
        {
            bool hasUsed = Game.Items.Any(i => string.Equals(i.City, city,
                StringComparison.InvariantCultureIgnoreCase));

            if(hasUsed)
            {
                ValidationResults.Add(new ValidationResult($"Город {city}" +
                    $" ранее был назван."));
            }
        }

        private void ValidLastLetter()
        {
            char lastLetter = Game.Items.LastOrDefault()
                .City.ToUpper().Last(c => c != 'Ь');

            if(lastLetter == 'Й' || lastLetter == 'Ё')
            {
                lastLetter = lastLetter == 'Й' ? 'И' : 'Е'; 
            }

            if(city.First() != lastLetter)
            {
                ValidationResults.Add(new ValidationResult($"Название" +
                    $" города должно начинаться с буквы {lastLetter}."));
            }
        }

        private void CityContainsLettersOnly()
        {
            if (!city.All(char.IsLetter))
            {
                ValidationResults.Add(new ValidationResult($"Название города " +
                    $"должно содержать только буквенные символы."));
            }
        }

        private void CityNameNotEmpty()
        {
            if (string.IsNullOrEmpty(city))
            {
                ValidationResults.Add(new ValidationResult("Поле \"Город\" не может" +
                    " быть пустым."));
            }
        }
    }
}