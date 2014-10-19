using System.Collections.Generic;

namespace Kit.Contracts.Model
{
    public interface IOligo
    {
        int OligoID { get; set; }
        string OligoName { get; set; }
        string OligoSequence { get; set; }
        List<IFeature> OligoFeatures { get; set; }
    }



}