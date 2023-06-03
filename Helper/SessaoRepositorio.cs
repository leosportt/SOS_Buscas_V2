using Newtonsoft.Json;
using SOS_Buscas_V2.Models;
using SOS_Buscas_V2.Repositorio;

namespace SOS_Buscas_V2.Helper
{
    public class SessaoRepositorio : ISessao
    {
        //---------------------------------------------------
        // Injeção de dependencia da Interface IHttpContextAccessor

        private readonly IHttpContextAccessor _httpContext;
        public SessaoRepositorio(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        //---------------------------------------------------
        //Criação da sessão do usuario
        
        public void CriarSessao(UsuarioModel usuario)
        {
            string user = JsonConvert.SerializeObject(usuario);

            _httpContext.HttpContext.Session.SetString("Logado", user);
        }


        //----------------------------------------------------------------------
        //Buscas os dados do usuário logado na sessão tais como email, nome, sobrenome, etc
        public UsuarioModel BuscarSessao()
        {
            string sessaoUser = _httpContext.HttpContext.Session.GetString("Logado");

            if (string.IsNullOrEmpty(sessaoUser)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUser);
        }

        //----------------------------------------------------------------------
        //Finaliza a sessão do usuário
        public void ApagarSessao()
        {
            _httpContext.HttpContext.Session.Remove("Logado");
        }

        
    }
}
