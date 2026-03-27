using TiendaConsola.Datos;
using TiendaConsola.Negocio;

namespace TiendaConsola.Presentacion;

public class MenuAdministrador
{
    private Inventario _inventario;
    private GestorUsuarios _gestorUsuarios;

    public MenuAdministrador(Inventario inventario, GestorUsuarios gestorUsuarios)
    {
        _inventario = inventario;
        _gestorUsuarios = gestorUsuarios;
    }

    public void MostrarMenu(Usuario usuario)
    {
        Console.WriteLine($"\nBienvenido {usuario.Username} (ADMIN)");

        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\n--- MENU ADMIN ---");
            Console.WriteLine("1. Ver productos");
            Console.WriteLine("2. Agregar producto");
            Console.WriteLine("3. Actualizar producto");
            Console.WriteLine("4. Eliminar producto");
            Console.WriteLine("5. Ver usuarios");
            Console.WriteLine("6. Agregar usuario");
            Console.WriteLine("7. Actualizar usuario");
            Console.WriteLine("8. Eliminar usuario");
            Console.WriteLine("0. Salir");

            string op = Console.ReadLine();

            if (op == "1")
                _inventario.MostrarInventario();

            else if (op == "2")
                AgregarProducto();

            else if (op == "3")
                ActualizarProducto();

            else if (op == "4")
                EliminarProducto();

            else if (op == "5")
                _gestorUsuarios.MostrarUsuarios();

            else if (op == "6")
                AgregarUsuario();

            else if (op == "7")
                ActualizarUsuario();

            else if (op == "8")
                EliminarUsuario();

            else if (op == "0")
            {
                Console.WriteLine("Cerrando sesión...");
                salir = true;
            }
            else
                Console.WriteLine("Opción inválida");
        }
    }

    private void AgregarProducto()
    {
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Precio: ");
        double precio = double.Parse(Console.ReadLine());

        Console.Write("Stock: ");
        int stock = int.Parse(Console.ReadLine());

        _inventario.AgregarProducto(nombre, precio, stock);
    }

    private void ActualizarProducto()
    {
        _inventario.MostrarInventario();

        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Nuevo nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Nuevo precio: ");
        double precio = double.Parse(Console.ReadLine());

        Console.Write("Nuevo stock: ");
        int stock = int.Parse(Console.ReadLine());

        _inventario.ActualizarProducto(id, nombre, precio, stock);
    }

    private void EliminarProducto()
    {
        _inventario.MostrarInventario();

        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());

        _inventario.EliminarProducto(id);
    }

    private void AgregarUsuario()
    {
        Console.Write("Usuario: ");
        string nombre = Console.ReadLine();

        Console.Write("Clave: ");
        string clave = Console.ReadLine();

        Console.Write("Rol (ADMIN / CLIENTE): ");
        string rol = Console.ReadLine();

        _gestorUsuarios.AgregarUsuario(nombre, clave, rol);
    }

    private void ActualizarUsuario()
    {
        Console.Write("Usuario: ");
        string nombre = Console.ReadLine();

        Console.Write("Nueva clave: ");
        string clave = Console.ReadLine();

        Console.Write("Nuevo rol: ");
        string rol = Console.ReadLine();

        _gestorUsuarios.ActualizarUsuario(nombre, clave, rol);
    }

    private void EliminarUsuario()
    {
        Console.Write("Usuario: ");
        string nombre = Console.ReadLine();

        _gestorUsuarios.EliminarUsuario(nombre);
    }
}