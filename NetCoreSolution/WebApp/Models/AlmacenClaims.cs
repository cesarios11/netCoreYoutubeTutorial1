using NLog.Fluent;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;

namespace WebApp.Models
{
    //TODO: Claims: Son un par de valores que se pueden usar para tomar decisiones de control de acceso.
    //Por ejemplo: Permitir que un usuario pueda editar los detalles de los amigos.
    //Los claims sirven para hacer verificaciones de autorizacion(Autorización basado en claims)
    //Sirven para gestionar decisiones de control de acceso, quien puede borrar un rol, o editar un rol o este tipo de operaciones
    public static class AlmacenClaims
    {
        public static List<Claim> todosLosClaims = new List<Claim>()
        {
            //TODO:Tanto el tipo como el valor es el mismo en este caso.
            new Claim("Crear Rol", "Crear Rol"),
            new Claim("Editar Rol", "Editar Rol"),
            new Claim("Borrar Rol", "Borrar Rol")
        };
    }
}
