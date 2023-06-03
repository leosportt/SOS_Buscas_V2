using Microsoft.AspNetCore.Mvc;
using SOS_Buscas_V2.Data;
using SOS_Buscas_V2.Models;
using SOS_Buscas_V2.Repositorio;

namespace SOS_Buscas_V2.Controllers
{
    public class CadastroController : Controller
    {

        //----------------------------------------------------------------------
        //Construtor para a injeção de dependencias da interface IUsuario
        private readonly IUsuario _usuario;
        public CadastroController(IUsuario usuario)
        {
            _usuario = usuario;
        }

        //----------------------------------------------------------------------
        //Metodo para carregar a pagina de Cadastro
        public IActionResult Index()
        {
            return View();
        }

        //----------------------------------------------------------------------
        //Metodo para Verificar e cadastrar o usuario no sistema salvando tudo no banco de dados
        [HttpPost]
        public IActionResult Cadastrar(UsuarioModel usuario)
        {
            List<UsuarioModel> users = _usuario.Listar(); 

            if(users != null && users.Any()) 
            {
                foreach(UsuarioModel user in users)  //Verifica se o usuário já existe no banco
                {
                    if(user.Email == usuario.Email)
                    {
                        return Json(new { Msg = "esse usuario já existe" });
                    }
                }
                _usuario.Criar(usuario); //Cria o usuário no banco
                return Json(new { Msg = "usuario criado com sucesso" });
            }
            _usuario.Criar(usuario);   //Cria o usuário no banco
            return Json(new { Msg = "usuario criado com sucesso" });
            
        }
    }
}
