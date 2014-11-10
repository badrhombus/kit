using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Kit.Server.Models
{
    [Serializable]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Lot> Lots { get; set; }
    }

    [Serializable]
    public class Lot
    {
        public int Id { get; set; }
        public string Catalog { get; set; }
        public LotState State { get; set; }
        //public virtual List<KitPool> Lots { get; set; }
    }

    [Serializable]
    public enum LotState
    {
        Design,
        Troubleshooting,
        Manufacture,
        Shipping,
        Backordered,
        Expired
    }

    [Serializable]
    public class KitPool
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string KitName { get; set; }
        public virtual List<KitConjugation> KitConjugations { get; set; }
    }

    [Serializable]
    public class KitConjugation
    {
        public int Id { get; set; }
        public string ProbeName { get; set; }
        public int Bead { get; set; }
    }

   

    

}