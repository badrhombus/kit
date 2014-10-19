using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kit.Contracts.Model
{
    public interface IFeature
    {
        string FeatureType { get; set; }
        int FeatureNumber { get; set; }
        int Start { get; set; }
        int End { get; set; }
    }
}
