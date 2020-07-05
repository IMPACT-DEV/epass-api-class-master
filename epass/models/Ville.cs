
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace epass.modeles  
{
    public class Ville
    {   [Key]
        public Guid Id { set; get; }
        public string Nom { set; get; }
        //navigation
        public Guid PaysId { set; get; }

        [ForeignKey(nameof(PaysId))]
        public Pays Pays { set; get; }
    }
}