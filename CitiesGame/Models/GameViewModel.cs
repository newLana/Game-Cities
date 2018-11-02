using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CitiesGame.Models
{
    public class GameViewModel:IValidatableObject
    {
        public List<GameItem> Items { get; set; }

        public string Author { get; set; }

        public string City { get; set; }         

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new GameViewModelValidator();
            return validator.ValidationSummury(this);
        }
    }
}