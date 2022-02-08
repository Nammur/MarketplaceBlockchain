using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itens.Enums
{
    public enum Raridades
    {
        [Display(Name = "Normal")]
        Normal = 1,
        [Display(Name = "Incomum")]
        Incomum = 2,
        [Display(Name = "Epico")]
        Epico = 3,
        [Display(Name = "Lendario")]
        Lendario = 4,
        [Display(Name = "Unico")]
        Unico = 5,
    };
}
