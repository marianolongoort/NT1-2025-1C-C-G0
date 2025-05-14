using EstacionamientoMVC.C.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamientoMVC.C.Models
{
    public class Rol : IdentityRole<int>
    {
        public Rol() : base(){}

        public Rol(string rolName) : base(rolName){}

        [Display(Name = Alias.RolName)]
        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        public override string NormalizedName { 
            get => base.NormalizedName; 
            set => base.NormalizedName = value; 
        }
        
    }
}
