namespace TiendaConsola.Datos;

public class ItemCarrito
{
    public Producto Producto { get; set; }
    public int Cantidad { get; set; }

    public ItemCarrito(Producto producto, int cantidad)
    {
        Producto = producto;
        Cantidad = cantidad;
    }

    public double Subtotal()
    {
        return Producto.Precio * Cantidad;
    }

    public void Mostrar()
    {
        Console.WriteLine($"Nombre = {Producto.Nombre}");
        Console.WriteLine($"Cantidad = {Cantidad}");
        Console.WriteLine($"Precio = {Producto.Precio}");
        Console.WriteLine($"Subtotal = {Subtotal()}");
    }
}