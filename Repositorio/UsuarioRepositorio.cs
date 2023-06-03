using SOS_Buscas_V2.Data;
using SOS_Buscas_V2.Models;

namespace SOS_Buscas_V2.Repositorio
{
    public class UsuarioRepositorio : IUsuario
    {
        //------------------------------------------------------------------
        //Construtor para injetar o BancoContext
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        //------------------------------------------------------------------
        //Salva os dados preenchidos no formulario no Banco de dados
        public UsuarioModel Criar(UsuarioModel usuario)
        {
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        //------------------------------------------------------------------
        //Lista os dados da tabela Usuarios presente Banco de dados
        public List<UsuarioModel> Listar()
        {
            return _bancoContext.Usuarios.ToList();
        }

        //------------------------------------------------------------------
        //Lista os dados da tabela Usuarios presente Banco de dados que possuem o Email informado a função
        public UsuarioModel VerificarLogin(string email)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper());
        }
    }
}
