using Microsoft.AspNetCore.Mvc;
using SOS_Buscas_V2.Models;
using SOS_Buscas_V2.Repositorio;
using System.Diagnostics;

namespace SOS_Buscas_V2.Controllers
{

    //----------------------------------------------------------------------
    //Construtor que injeta a interface IDesaparecido
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDesaparecido _iDesaparecido;
        public HomeController(ILogger<HomeController> logger, IDesaparecido desaparecido)
        {
            _logger = logger;
            _iDesaparecido = desaparecido;
        }

        //------------------------------------------------------------------
        //Função que retorna os dados dos desaparecidos

        
        private List<DesaparecidoModel> _desaparecido;         //Variavel que recebe uma lista com os dados dos desaparecidos
        public IActionResult Index()
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

        public IActionResult Precaucoes()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}