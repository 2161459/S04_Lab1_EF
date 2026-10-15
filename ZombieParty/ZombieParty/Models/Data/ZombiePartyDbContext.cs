using Microsoft.EntityFrameworkCore;
using System.ComponentModel; //avoir ceci
using ZombieParty.Models;

namespace ZombieParty.Models.Data
{
    //Ce code sert à connecter ton application ASP.NET Core à ta base de données en utilisant Entity Framework Core.
    public class ZombiePartyDbContext : DbContext
    {
        public ZombiePartyDbContext(DbContextOptions<ZombiePartyDbContext> options) : base(options)
        {

        }
        // AJOUTE LES DBSETS ICI
        public DbSet<Zombie> Zombies { get; set; } //indique à Entity Framework Core que tu veux gérer les zombies dans une table appelée Zombies.
        public DbSet<ZombieType> ZombieTypes { get; set; }//Indique à Entity Framework Core que tu veux gérer les types de zombies dans une table appelée ZombieTypes.

        //DONC LA TABLE ZOMBIES ET ZOMBIETYPE SONT CREE
    }
}
