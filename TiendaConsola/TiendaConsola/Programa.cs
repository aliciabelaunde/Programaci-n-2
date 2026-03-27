using TiendaConsola.Datos;
using TiendaConsola.Negocio;
using TiendaConsola.Presentacion;

Inventario inventario = new Inventario();
GestorUsuarios gestorUsuarios = new GestorUsuarios();

Login login = new Login(gestorUsuarios);
MenuAdministrador menuAdmin = new MenuAdministrador(inventario, gestorUsuarios);
MenuCliente menuCliente = new MenuCliente(inventario);

while (true)
{
    Usuario usuario = null;

    while (usuario == null)
    {
        usuario = login.IniciarSesion();
    }

    if (usuario.Rol == "ADMIN")
        menuAdmin.MostrarMenu(usuario);
    else
        menuCliente.MostrarMenu(usuario);
}