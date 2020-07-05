using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace epass.modeles
{
    public class EventLog
    {
        [Key]
        public Guid Id { set; get; }
        public DateTime EventLogDate { set; get; }
        public string Event { set; get; }
        public Guid AdminId { set; get; }

        //navigation Admin
        [ForeignKey(nameof(AdminId))]
        public Admin Admin { set; get; }
    }

}