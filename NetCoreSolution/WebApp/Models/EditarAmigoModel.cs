namespace WebApp.Models
{
    //TODO: La clase EditarAmigoModel hereda de CrearAmigoModel
    //con esto se evita tener que volver a escribir las mismas propiedades que tiene la otra clase
    //de la cual se hereda y que se necesitan en esta nueva clase EditarAmigoModel
    public class EditarAmigoModel : CrearAmigoModel
    {
        public int Id { get; set; }
        public string rutaFotoLocalExistente { get; set; }        
    }
}
