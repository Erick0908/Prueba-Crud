using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ErickPrueba.Models.ViewModels
{
    public class PersonaViewModel
    {
            public int Id { get; set; }
            [Required]
            [StringLength(60)]
            [Display(Name ="Nombre")]
            public string Nombre { get; set; }
            [Required]
            [DataType(DataType.Date)]
            [Display(Name ="Fecha de nacimiento")]
            [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
            public DateTime FechaDeNacimiento { get; set; }

        
    }
}