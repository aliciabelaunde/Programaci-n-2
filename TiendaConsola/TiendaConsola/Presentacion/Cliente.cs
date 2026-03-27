using TiendaConsola.Datos;
using TiendaConsola.Negocio;

namespace TiendaConsola.Presentacion;

public class MenuCliente
{
    private Inventario _inventario;
    private Carrito _carrito;

    public MenuCliente(Inventario inventario)
    {
        _inventario = inventario;
        _carrito = new Carrito();
    }

    public void MostrarMenu(Usuario usuario)
    {
        Console.WriteLine($"\nBienvenido {usuario.Username} (CLIENTE)");

        _carrito.Vaciar();

        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n--- MENU CLIENTE ---");
            Console.WriteLine("1. Ver productos");
            Console.WriteLine("2. Agregar al carrito");
            Console.WriteLine("3. Ver carrito");
            Console.WriteLine("4. Eliminar del carrito");
            Console.WriteLine("5. Comprar");
            Console.WriteLine("0. Salir");

            string op = Console.ReadLine();

            if (op == "1")
                _inventario.MostrarInventario();

            else if (op == "2")
                AgregarAlCarrito();

            else if (op == "3")
                _carrito.MostrarCarrito();

            else if (op == "4")
                EliminarDelCarrito();

            else if (op == "5")
                Comprar();

            else if (op == "0")
            {
                Console.WriteLine("Cerrando sesión...");
                salir = true;
            }
            else
                Console.WriteLine("Opción inválida");
        }
    }

    private void AgregarAlCarrito()
    {
        _inventario.MostrarInventario();

        Console.Write("ID producto: ");
        int id = int.Parse(Console.ReadLine());

        Producto producto = _inventario.BuscarProducto(id);

        if (producto == null)
        {
            Console.WriteLine("Producto no existe");
            return;
        }

        Console.Write("Cantidad: ");
        int cantidad = int.Parse(Console.ReadLine());

        if (cantidad > producto.Stock)
        {
            Console.WriteLine("No hay suficiente stock");
            return;
        }

        _carrito.AgregarProducto(producto, cantidad);
    }

    private void EliminarDelCarrito()
    {
        if (_carrito.ObtenerItems().Count == 0)
        {
            Console.WriteLine("Carrito vacío");
            return;
        }

        _carrito.MostrarCarrito();

        Console.Write("ID producto: ");
        int id = int.Parse(Console.ReadLine());

        _carrito.EliminarProducto(id);
    }

    private void Comprar()
    {
        if (_carrito.ObtenerItems().Count == 0)
        {
            Console.WriteLine("Carrito vacío");
            return;
        }

        _carrito.MostrarCarrito();

        Console.Write("Confirmar compra (s/n): ");
        string op = Console.ReadLine().ToLower();

        if (op == "s")
        {
            foreach (ItemCarrito item in _carrito.ObtenerItems())
            {
                _inventario.DescontarStock(item.Producto.Id, item.Cantidad);
            }

            Console.WriteLine($"Total = {_carrito.CalcularTotal()}");
            Console.WriteLine("Compra realizada");

            _carrito.Vaciar();
        }
        else
        {
            Console.WriteLine("Compra cancelada");
        }
    }
}