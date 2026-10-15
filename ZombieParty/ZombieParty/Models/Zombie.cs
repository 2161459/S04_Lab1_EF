using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZombieParty.Models
{
    public class Zombie
    {
        //Si erreur apres ajouter migration
        //[Key] indique que Id est la clé primaire, public int Id crée un identifiant numérique unique pour chaque zombie, et { get; set; } permet de lire et de modifier sa valeur.
        [Key]
        public int Id { get; set; }

        //Ce code impose un nom entre 5 et 20 caractères, un pointage entre 1 et 20 et une description facultative d'au maximum 255 caractères. ZombieTypeId relie le zombie à son type.
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} requires between {2} and {1} characters.")]
        public string Name { get; set; }

        // FACULTATIF on peut formellement identifier le champ lien sinon le champ de foreignKey sera auto généré dans la BD
        //Ajoutez l’annotation ForeignKey pour la clé étrangère ZombieTypeId. Dans ton projet ZombieParty, il permet de relier un Zombie à un ZombieType.
        [Display(Name = "Zombie Type")]
        [ForeignKey("ZombieType")]
        public int ZombieTypeId { get; set; }

        public ZombieType? ZombieType { get; set; }

        //Ce code impose un nom entre 5 et 20 caractères, un pointage entre 1 et 20 et une description facultative d'au maximum 255 caractères. ZombieTypeId relie le zombie à son type.
        [Range(1, 20,ErrorMessage = "{0} requires a value between {1} and {2}.")]
        public int Point { get; set; }

        //Une description facultative d'au maximum 255 caractères.
        [StringLength(255,ErrorMessage = "{0} cannot exceed {1} characters.")]
        public string? ShortDesc { get; set; }

        public List<HuntingLog> HuntingLogs { get; set; } = new();

    }
}
