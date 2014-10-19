using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kit.Server.Models
{
    // Models returned by MeController actions.
    public class GetViewModel
    {
        public string Hometown { get; set; }
        public string EyeColor { get; set; }
    }
}