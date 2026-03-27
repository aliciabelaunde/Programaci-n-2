namespace TiendaConsola.Datos;

public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }

    public Producto(int id, string nombre, double precio, int stock)
    {
        Id = id;
        Nombre = nombre;
        Precio = precio;
        Stock = stock;
    }

    public void Mostrar()
    {
        Console.WriteLine($"Id = {Id}");
        Console.WriteLine($"Nombre = {Nombre}");
        Console.WriteLine($"Precio = {Precio}");
        Console.WriteLine($"Stock = {Stock}");
    }
}