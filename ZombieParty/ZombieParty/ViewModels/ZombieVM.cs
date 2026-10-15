using Microsoft.AspNetCore.Mvc.Rendering;
using ZombieParty.Models;

namespace ZombieParty.ViewModels
{
    //Ce ViewModel permet de transmettre deux informations à la même vue : le zombie à créer et la liste des types de zombies disponibles.
    //Tu n'as donc plus besoin de ViewBag pour cette liste.
    public class ZombieVM
    {
        // Pour Upsert 1 zombie à la fois
        public Zombie Zombie { get; set; }


        public SelectList? ZombieTypeSelectList { get; set; }
    }
}

