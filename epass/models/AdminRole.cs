
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace epass.modeles {
    public class AdminRole
    {
        [Key]
        public Guid Id { set; get; }
        public Guid AdminId { set; get; }
        public Guid RoleId { set; get; }
        public string Valeur { set; get; }

        //navigation Admin
        [ForeignKey(nameof(AdminId))]
        public Admin Admin { set; get; }



        //navigation Role
        [ForeignKey(nameof(RoleId))]
        public Role Role { set; get; }
        
    }
}
