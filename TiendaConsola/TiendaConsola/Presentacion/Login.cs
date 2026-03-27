using TiendaConsola.Datos;
using TiendaConsola.Negocio;

namespace TiendaConsola.Presentacion;

public class Login
{
    private GestorUsuarios _gestorUsuarios;

    public Login(GestorUsuarios gestorUsuarios)
    {
        _gestorUsuarios = gestorUsuarios;
    }

    public Usuario IniciarSesion()
    {
        Console.WriteLine("\n--- LOGIN ---");

        Console.Write("Usuario: ");
        string nombre = Console.ReadLine();

        Console.Write("Contraseña: ");
        string clave = Console.ReadLine();

        Usuario usuario = _gestorUsuarios.Autenticar(nombre, clave);

        if (usuario == null)
        {
            Console.WriteLine("Datos incorrectos");
        }
        else
        {
            Console.WriteLine($"Bienvenido {usuario.Username} ({usuario.Rol})");
        }

        return usuario;
    }
}