using Proyecto_Imprenta_Grupo6.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;
namespace Proyecto_Imprenta_Grupo6.Pages.MisUsuarios
{
        partial class Usuarios
        {
            [Inject] private IUsuarioServicio _usuarioServicio { get; set; }
            private IEnumerable<Usuario> listaUsuarios { get; set; }

            protected override async Task OnInitializedAsync()
            {
                listaUsuarios = await _usuarioServicio.GetLista();
            }

        }
    }
