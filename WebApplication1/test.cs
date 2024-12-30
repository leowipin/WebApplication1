namespace WebApplication1
{
    public class Persona(string nombre)
    {
        public string Nombre { get; set; } = nombre;

        public void Saludar() => Console.WriteLine($"hola {Nombre}");
    
    }
}