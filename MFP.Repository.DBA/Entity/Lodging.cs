using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MFP.Repository.DBA.Entity
{
    public class Lodging
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public decimal MilesFromNearestAirport { get; set; }

        [InverseProperty("PrimaryContactFor")]
        public virtual Person PrimaryContact { get; set; }

        [InverseProperty("SecondaryContactFor")]
        public virtual Person SecondaryContact { get; set; }
    }
}
