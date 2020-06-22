using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ErickPrueba.Models.ViewModels
{
    public class ListPersonaViewModel
    {
        public int Id { get; set;}
        public string Nombre { get; set; }
        public DateTime FechaDeNacimiento { get; set; }

    }
}