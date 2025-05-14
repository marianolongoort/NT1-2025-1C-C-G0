using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EstacionamientoMVC.C.Models
{
    public enum CodigoDeArea
    {
        [Display(Name = "Ciudad Autónoma de Buenos Aires [CABA] (11)")] _11_ = 11,
        [Display(Name = "ChacoResistencia [ Chaco] (362)")] _362_ = 362,
        [Display(Name = "ChubutRawson [ Chubut] (2804)")] _2804_ = 2804,
        [Display(Name = "NeuquénNeuquén [ Neuquén] (299)")] _299_ = 299,
        [Display(Name = "Río NegroViedma [Río Negro] (2920)")] _2920_ = 2920,
        [Display(Name = "Buenos AiresLa Plata [Buenos Aires] (221)")] _221_ = 221,
        [Display(Name = "CatamarcaSan Fernando del Valle de Catamarca [Catamarca] (383)")] _383_ = 383,
        [Display(Name = "CórdobaCórdoba [Córdoba] (351)")] _351_ = 351,
        [Display(Name = "CórdobaCórdoba [Córdoba] (3543)")] _3543_ = 3543,
        [Display(Name = "CorrientesCorrientes [Corrientes] (379)")] _379_ = 379,
        [Display(Name = "Entre RíosParaná [Entre Ríos] (343)")] _343_ = 343,
        [Display(Name = "FormosaFormosa [Formosa] (370)")] _370_ = 370,
        [Display(Name = "JujuySan Salvador de Jujuy [Jujuy] (388)")] _388_ = 388,
        [Display(Name = "La PampaSanta Rosa [La Pampa] (2954)")] _2954_ = 2954,
        [Display(Name = "La RiojaLa Rioja [La Rioja] (380)")] _380_ = 380,
        [Display(Name = "MendozaMendoza [Mendoza] (261)")] _261_ = 261,
        [Display(Name = "MisionesPosadas [Misiones] (376)")] _376_ = 376,
        [Display(Name = "SaltaSalta [Salta] (387)")] _387_ = 387,
        [Display(Name = "San JuanSan Juan [San Juan] (264)")] _264_ = 264,
        [Display(Name = "San LuisSan Luis [San Luis] (266)")] _266_ = 266,
        [Display(Name = "Santa CruzRío Gallegos [Santa Cruz] (2966)")] _2966_ = 2966,
        [Display(Name = "Santa FeSanta Fe [Santa Fe] (342)")] _342_ = 342,
        [Display(Name = "Santiago del EsteroSantiago del Estero [Santiago del Estero] (385)")] _385_ = 385,
        [Display(Name = "Tierra del FuegoUshuaia [Tierra del Fuego, Antártida e Islas del Atlántico Sur] (2901)")] _2901_ = 2901,
        [Display(Name = "TucumánSan Miguel de Tucumán [Tucumán] (381)")] _381_ = 381

    }
}
