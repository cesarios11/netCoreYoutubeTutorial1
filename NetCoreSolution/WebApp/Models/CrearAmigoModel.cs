using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApp.Models
{
    public class CrearAmigoModel
    {
        //TODO: Se crean las validaciones para cada uno de los campos del modelo        
        [Required(ErrorMessage = "*Obligatorio"), MaxLength(20, ErrorMessage = "*Máximo 20 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "*Obligatorio"), MaxLength(50, ErrorMessage = "*Máximo 50 caracteres")]
        [Display(Name = "Correo electronico")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "*Formato invalido")]
        public string Email { get; set; }

        public string ProfilePictureUrl { get; set; }

        [Required(ErrorMessage = "*Debe seleccionar una ciudad")]
        public Provincia? Ciudad { get; set; }

        public IFormFile Foto { get; set; }
    }
}
