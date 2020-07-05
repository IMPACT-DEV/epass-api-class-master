

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace epass.modeles
{
    public class Devise
    {
        [Key]
        public Guid Id { set; get; }
        public string Libelle { set; get; }
        public string CodeIso {set;get;}
        public string Symbole { set; get; }
    }
}