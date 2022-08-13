using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;
using Proyecto_Imprenta_Grupo6.Data;
using Proyecto_Imprenta_Grupo6.Interfaces;

namespace Proyecto_Imprenta_Grupo6.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly MySQLConfiguracion _configuracion;
        private IUsuarioRepositorio usuarioRepositorio;

        public UsuarioServicio(MySQLConfiguracion configuracion)
        {
            _configuracion = configuracion;
            usuarioRepositorio = new UsuarioRepositorio(configuracion.CadenaConexion);
        }

        public async Task<bool> Actualizar(Usuario usuario)
        {
            return await usuarioRepositorio.Actualizar(usuario);
        }

        public async Task<bool> Eliminar(Usuario usuario)
        {
            return await usuarioRepositorio.Eliminar(usuario);
        }

        public async Task<IEnumerable<Usuario>> GetLista()
        {
            return await usuarioRepositorio.GetLista();
        }

        public async Task<Usuario> GetPorCodigo(string codigo)
        {
            return await usuarioRepositorio.GetPorCodigo(codigo);
        }

        public async Task<bool> Nuevo(Usuario usuario)
        {
            return await usuarioRepositorio.Nuevo(usuario);
        }
    }
}
