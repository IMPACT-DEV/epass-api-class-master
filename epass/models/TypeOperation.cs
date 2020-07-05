using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace epass.modeles
{
    public class TypeOperation
    {
        [Key]
        public int Id {set;get;}
        public string Libelle {set;get;}
    }
}