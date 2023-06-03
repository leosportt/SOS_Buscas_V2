using SOS_Buscas_V2.Models;

namespace SOS_Buscas_V2.Repositorio
{
    public interface IUsuario
    {
        //------------------------------------------------------------------
        //Contratos do CRUD Usuários

        UsuarioModel VerificarLogin(string email);
        
        List<UsuarioModel> Listar();

        UsuarioModel Criar(UsuarioModel usuario);
    }
}
