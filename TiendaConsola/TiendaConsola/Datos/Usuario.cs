namespace TiendaConsola.Datos;

public class Usuario
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Rol { get; set; }

    public Usuario(string username, string password, string rol)
    {
        Username = username;
        Password = password;
        Rol = rol.ToUpper();
    }
}