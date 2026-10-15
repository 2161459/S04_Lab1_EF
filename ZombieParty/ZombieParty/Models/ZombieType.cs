using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class ZombieType
    {
        //Ajoutez l'annotation pour en faire une clé primaire explicite (Key)
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Type Name")]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "{0} has to be filled.")]
        [StringLength(10, MinimumLength = 5,ErrorMessage = "{0} requires between {2} and {1} characters.")]
        public string TypeName { get; set; }

        [Range(2, 5,ErrorMessage = "{0} requires a value between {1} and {2}.")]
        public int Point { get; set; }

        [ValidateNever] //Empêche la validation MVC de demander une liste de zombies lors de la création d'un type. La liste reste disponible pour la relation Entity Framework.
        public List<Zombie> Zombies { get; set; } = new();
    }
}
