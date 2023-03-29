using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autocad_wf_layer_add_29_03_2023
{
   public class Layer_Data
    {
        string _name;
        public string Name 
        {
            get { return _name; } 
            set { _name = value.Trim(); }
        }
        public bool IsOn { get; set; }
        public bool IsFrozen { get; set; }
        public bool IsValid
        {
            get
            {
                return string.IsNullOrEmpty(Name);
            }
        }
    }
}
