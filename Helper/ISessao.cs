using SOS_Buscas_V2.Models;

namespace SOS_Buscas_V2.Helper
{
    //----------------------------------------------------------------------
    //Metodos que permitem a criação, busca e finalização de sessão no site
    public interface ISessao
    {
        void CriarSessao(UsuarioModel usuario); //Cria uma sessão
        void ApagarSessao(); //finaliza a sessão
        UsuarioModel BuscarSessao(); //Busca os dados do usuário logado na sessão
        

    }
}
