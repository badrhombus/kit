using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kit.Server.Models
{
    [Serializable]
    public class Probe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Allele> Specificity { get; set; }
    }
}