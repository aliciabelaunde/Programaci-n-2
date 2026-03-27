using TiendaConsola.Datos;

namespace TiendaConsola.Negocio;

public class GestorUsuarios
{
    private List<Usuario> Usuarios = new List<Usuario>();

    public GestorUsuarios()
    {
        AgregarUsuario("admin", "123", "ADMIN");
        AgregarUsuario("cliente", "123", "CLIENTE");
    }

    public void AgregarUsuario(string nombre, string contrasena, string rol)
    {
        Usuario nuevo = new Usuario(nombre, contrasena, rol);
        Usuarios.Add(nuevo);
    }

    public Usuario Autenticar(string nombre, string contrasena)
    {
        foreach (Usuario usuario in Usuarios)
        {
            if (usuario.Username == nombre && usuario.Password == contrasena)
            {
                return usuario;
            }
        }

        return null;
    }

    public void MostrarUsuarios()
    {
        Console.WriteLine("\nUsuarios");

        foreach (Usuario usuario in Usuarios)
        {
            Console.WriteLine($"Nombre = {usuario.Username}");
            Console.WriteLine($"Rol = {usuario.Rol}");
        }
    }

    public void EliminarUsuario(string nombre)
    {
        Usuario eliminar = null;

        foreach (Usuario usuario in Usuarios)
        {
            if (usuario.Username == nombre)
            {
                eliminar = usuario;
                break;
            }
        }

        if (eliminar != null)
        {
            Usuarios.Remove(eliminar);
            Console.WriteLine("Usuario eliminado");
        }
        else
        {
            Console.WriteLine("Usuario no encontrado");
        }
    }

    public void ActualizarUsuario(string nombre, string nuevaClave, string nuevoRol)
    {
        Usuario usuario = null;

        foreach (Usuario u in Usuarios)
        {
            if (u.Username == nombre)
            {
                usuario = u;
                break;
            }
        }

        if (usuario != null)
        {
            usuario.Password = nuevaClave;
            usuario.Rol = nuevoRol;
            Console.WriteLine("Usuario actualizado");
        }
        else
        {
            Console.WriteLine("Usuario no encontrado");
        }
    }
}