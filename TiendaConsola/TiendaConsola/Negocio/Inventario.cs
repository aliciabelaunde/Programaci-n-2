using TiendaConsola.Datos;

namespace TiendaConsola.Negocio;

public class Inventario
{
    private List<Producto> Productos = new List<Producto>();
    private int contadorId = 1;

    public Inventario()
    {
        AgregarProducto("Manzana", 2.5, 100);
        AgregarProducto("Leche", 3.0, 50);
    }

    public void AgregarProducto(string nombre, double precio, int stock)
    {
        Producto nuevo = new Producto(contadorId, nombre, precio, stock);
        Productos.Add(nuevo);
        contadorId++;
    }

    public void MostrarInventario()
    {
        Console.WriteLine("\n---- INVENTARIO ----");

        if (Productos.Count == 0)
        {
            Console.WriteLine("No hay productos");
            return;
        }

        foreach (Producto producto in Productos)
        {
            producto.Mostrar();
        }
    }

    public Producto BuscarProducto(int id)
    {
        foreach (Producto producto in Productos)
        {
            if (producto.Id == id)
                return producto;
        }

        return null;
    }

    public void EliminarProducto(int id)
    {
        Producto productoEliminar = null;

        foreach (Producto producto in Productos)
        {
            if (producto.Id == id)
            {
                productoEliminar = producto;
                break;
            }
        }

        if (productoEliminar != null)
        {
            Productos.Remove(productoEliminar);
            Console.WriteLine("Producto eliminado");
        }
        else
        {
            Console.WriteLine("Producto no encontrado");
        }
    }

    public void ActualizarProducto(int id, string nombre, double precio, int stock)
    {
        Producto producto = BuscarProducto(id);

        if (producto != null)
        {
            producto.Nombre = nombre;
            producto.Precio = precio;
            producto.Stock = stock;
            Console.WriteLine("Producto actualizado");
        }
        else
        {
            Console.WriteLine("Producto no encontrado");
        }
    }

    public void DescontarStock(int id, int cantidad)
    {
        Producto producto = BuscarProducto(id);

        if (producto != null && producto.Stock >= cantidad)
        {
            producto.Stock -= cantidad;
        }
        else
        {
            Console.WriteLine($"Error con producto ID {id}");
        }
    }
}