using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatchworkMVC.Models
{
    public class Patchwork
    {
        public int PatchValue { get; set; }
        public int WorkValue { get; set;  }
        public List<string> Result { get; set; } = new();

    }
}
