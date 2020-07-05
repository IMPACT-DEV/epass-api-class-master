using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace epass.modeles
{

    public class Pays
    {   [Key]
        public Guid Id { set; get; }
        public string Nom { set; get; }
        public int Indicatif { set; get; }
        public string CodePays { set; get; }

        //navigation
        public virtual ICollection<Ville> Ville { get; set; }
    }
}