using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itens.Enums
{
    public enum Tipos
    {
        [Display(Name = "Espada")]
        Espada = 1001,
        [Display(Name = "Arco")]
        Arco = 1002,
        [Display(Name = "Cajado")]
        Cajado = 1003,
        [Display(Name = "Escudo")]
        Escudo = 1004,
        [Display(Name = "Adaga")]
        Adaga = 1005,
        [Display(Name = "Elmo")]
        Elmo = 2001,
        [Display(Name = "Armadura")]
        Armadura = 2002,
        [Display(Name = "Perneira")]
        Perneira = 2003,
        [Display(Name = "Bota")]
        Bota = 2004,
        [Display(Name = "Anel")]
        Anel = 3001,
        [Display(Name = "Colar")]
        Colar = 3002,
        [Display(Name = "Brinco")]
        Brinco = 3003,
        [Display(Name = "Pulseira")]
        Pulseira = 3004,
        [Display(Name = "PocaoVida")]
        PocaoVida = 4001,
        [Display(Name = "PocaoDano")]
        PocaoDano = 4002,
        [Display(Name = "PocaoAcerto")]
        PocaoAcerto = 4003,
        [Display(Name = "PocaoDefesa")]
        PocaoDefesa = 4004,
    };

}
