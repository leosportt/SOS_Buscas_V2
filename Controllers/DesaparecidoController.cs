using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SOS_Buscas_V2.Helper;
using SOS_Buscas_V2.Models;
using SOS_Buscas_V2.Repositorio;

namespace SOS_Buscas_V2.Controllers
{
    public class DesaparecidoController : Controller
    {
        //----------------------------------------------------------------------
        // Construtor para injeção de dependencia das Interfaces IDesaparecido e ISessao
        private readonly IDesaparecido _iDesaparecido;
        private readonly ISessao _iSessao;
        private readonly string _caminhoImagem;
        public DesaparecidoController(IDesaparecido iDesaparecido, ISessao iSessao, IWebHostEnvironment caminhoImagem)
        {
            _iDesaparecido = iDesaparecido;
            _iSessao = iSessao;
            _caminhoImagem = caminhoImagem.WebRootPath;
        }

        //----------------------------------------------------------------------
        //Metodo para chamar a pagina de cadastro de desaparecidos
        public IActionResult Index()
        {
            return View();
        }


        private DesaparecidoModel _desaparecidos;
        public IActionResult EditarPage(Guid id)
        {
            DesaparecidoModel desaparecido = _iDesaparecido.ListarPorId(id);
            _desaparecidos = desaparecido;


            if(desaparecido != null ) 
            {
                return View(desaparecido);
            }
            return Json(new { Msg = "erro" });


        }

        public IActionResult CadastrarPage()
        {
            return View();
        }

        

        //----------------------------------------------------------------------
        //Metodo para verificar se o desaparecido já foi cadastrado e caso não tenha sido cadastrar o mesmo
        public IActionResult Cadastrar(DesaparecidoModel desaparecido, IFormFile foto)
        {
            
            
            
           


            string CaminhoDaImagem = _caminhoImagem + "\\Imagens\\";
            string nomeImagem = Guid.NewGuid().ToString() + "_" + foto.FileName;

            if (!Directory.Exists(CaminhoDaImagem))
            {
                Directory.CreateDirectory(CaminhoDaImagem);
            }

            using (var stream = System.IO.File.Create(CaminhoDaImagem + nomeImagem))
            {
                foto.CopyToAsync(stream);
            }

            desaparecido.CaminhoImagem = nomeImagem;

            //------------------------------------------------------------------
            // Informa para a DesaparecidoModel qual é o email do usuário que esta cadastrando o desaparecido
            UsuarioModel usuario = _iSessao.BuscarSessao();

            string EmailUsuario = usuario.Email;

            desaparecido.EmailUsuario = EmailUsuario;
            //------------------------------------------------------------------

            List<DesaparecidoModel> desaparecidos = _iDesaparecido.Listar();

            if (desaparecidos != null && desaparecidos.Any())
            {
                foreach (DesaparecidoModel missing in desaparecidos)  //Verifica se o desaparecido já foi cadastrado
                {
                    if (missing.Nome == desaparecido.Nome && missing.Sobrenome == desaparecido.Sobrenome)
                    {
                        return Json(new { Msg = "esse usuario já existe" });
                    }
                }
                _iDesaparecido.Criar(desaparecido);   //Cadastra o desaprecido no banco
                return Json(new { Msg = "criado" });
            }
            _iDesaparecido.Criar(desaparecido);    //Cadastrar o desaparecido no banco
            return Json(new { Msg = "criado" });
        }

        //------------------------------------------------------------------
        //Função que retorna os dados dos desaparecidos

        
        private List<DesaparecidoModel> _desaparecido;     //Variavel que recebe uma lista com os dados dos desaparecidos


        public IActionResult DesaparecidosPage()
        {
            List<DesaparecidoModel> desaparecidos = _iDesaparecido.Listar();
            _desaparecido = desaparecidos;

            foreach (DesaparecidoModel desaparecido in _desaparecido)      //Laço de repetição que cria os dados das colunas
            {
                List<DesaparecidoModel> dadosDesaparecido = _iDesaparecido.Listar();
                return View(dadosDesaparecido);
            }

            return View();

            
        }

        //------------------------------------------------------------------
        //Função que permite a edição dos dados do usuário
        public IActionResult Editar(Guid id)
        {
            DesaparecidoModel desaparecido = _iDesaparecido.ListarPorId(id);

            return View(desaparecido);
        }
    }
}
