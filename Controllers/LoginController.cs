using Microsoft.AspNetCore.Mvc;
using SOS_Buscas_V2.Helper;
using SOS_Buscas_V2.Models;
using SOS_Buscas_V2.Repositorio;

namespace SOS_Buscas_V2.Controllers
{
    public class LoginController : Controller
    {
        //----------------------------------------------------------------------
        //Construtor para a injeção de dependencias das interfaces IUsuario e ISessao
        private readonly IUsuario _usuario;
        private readonly ISessao _sessao;
        public LoginController(IUsuario usuario, ISessao sessao)
        {
            _usuario = usuario;
            _sessao = sessao;   
        }

        //----------------------------------------------------------------------
        //Metodo para chamar a pagina de login com a verificação para caso o usuário já esteja logado
        public IActionResult Index()
        {
            if (_sessao.BuscarSessao() != null) return Json(new { Msg = "Você já esta logadoo" });
            return View();
        }

        //----------------------------------------------------------------------
        //Loga o usuário no site iniciando a sessão
        public IActionResult VerificarLogin(UsuarioModel usuario)
        {
            UsuarioModel usuarios = _usuario.VerificarLogin(usuario.Email);

            if (usuarios != null && usuarios.VerificarSenha(usuario.Senha))
            {
                _sessao.CriarSessao(usuario);

               

                return Json(new { Msg = "Logado com sucesso"}); 
                    
                    
            }

            return Json(new { Msg = "erro"});
        }
    }
}
