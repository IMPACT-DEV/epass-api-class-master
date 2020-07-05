
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace epass.modeles
{
    public class Operation
    {
        [Key]
        public Guid Id { set; get; }
        public string Libelle { set; get; }
        public int TypeOperationId { set; get; }
        public DateTime OperationDate { set; get; }
        public DateTime OperationValeurDate { set; get; }
        public string Source { set; get; }
        public string Destination { set; get; }
        public decimal Montant { set; get; }
        public Guid AdminId { set; get; }


        //navigation Admin
        [ForeignKey(nameof(AdminId))]
        public Admin Admin { set; get; }

        //navigation TypeOperationId1
        [ForeignKey(nameof(TypeOperationId))]
        public TypeOperation TypeOperation { set; get; }


    }
}