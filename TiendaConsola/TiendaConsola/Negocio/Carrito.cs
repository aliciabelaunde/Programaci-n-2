using TiendaConsola.Datos;

namespace TiendaConsola.Negocio;

public class Carrito
{
    private List<ItemCarrito> Items = new List<ItemCarrito>();

    public void AgregarProducto(Producto producto, int cantidad)
    {
        if (producto == null || cantidad <= 0)
        {
            Console.WriteLine("Datos inválidos");
            return;
        }

        foreach (ItemCarrito item in Items)
        {
            if (item.Producto.Id == producto.Id)
            {
                item.Cantidad += cantidad;
                Console.WriteLine("Cantidad actualizada en carrito");
                return;
            }
        }

        Items.Add(new ItemCarrito(producto, cantidad));
        Console.WriteLine("Producto agregado al carrito");
    }

    public void EliminarProducto(int idProducto)
    {
        ItemCarrito eliminar = null;

        foreach (ItemCarrito item in Items)
        {
            if (item.Producto.Id == idProducto)
            {
                eliminar = item;
                break;
            }
        }

        if (eliminar != null)
        {
            Items.Remove(eliminar);
            Console.WriteLine("Producto eliminado del carrito");
        }
        else
        {
            Console.WriteLine("Producto no encontrado");
        }
    }

    public double CalcularTotal()
    {
        double total = 0;

        foreach (ItemCarrito item in Items)
        {
            total += item.Subtotal();
        }

        return total;
    }

    public void Vaciar()
    {
        Items.Clear();
    }

    public List<ItemCarrito> ObtenerItems()
    {
        return Items;
    }

    public void MostrarCarrito()
    {
        Console.WriteLine("\n---- CARRITO ----");

        if (Items.Count == 0)
        {
            Console.WriteLine("Carrito vacío");
            return;
        }

        foreach (ItemCarrito item in Items)
        {
            item.Mostrar();
            Console.WriteLine("--------------");
        }

        Console.WriteLine($"\nTotal = {CalcularTotal()}");
    }
}