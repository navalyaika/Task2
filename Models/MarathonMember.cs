using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Task2.Models
{
    public class MarathonMember
    {
        [ValidateNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "не указано имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "не указан гендер")]
        public char Gender { get; set; }

        [RegularExpression(@"^[0-9]*$")]
        [Required(ErrorMessage = "не указан возраст")]
        public int Age { get; set; }

        [RegularExpression(@"^[0-9]*$")]
        [Required(ErrorMessage = "не указан опыт")]
        public int Experience { get; set; }

        [RegularExpression(@"^[А-Я]+[а-я\s]*$")]
        [Required(ErrorMessage = "не указан город проживания")]
        public string CityOfResidence { get; set; }
    }
}
