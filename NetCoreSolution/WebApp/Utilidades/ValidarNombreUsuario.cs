using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Utilidades
{
    public class ValidarNombreUsuario : ValidationAttribute
    {
        private readonly string _usuario;

        public ValidarNombreUsuario(string usuario)
        {
            this._usuario = usuario;
        }

        public override bool IsValid(object value)
        {
            Boolean permitido = true;

            if(value.ToString().Contains(this._usuario))
                permitido = false;

            return permitido;
        }
    }
}
