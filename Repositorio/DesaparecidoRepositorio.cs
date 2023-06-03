using SOS_Buscas_V2.Data;
using SOS_Buscas_V2.Models;

namespace SOS_Buscas_V2.Repositorio
{

    public class DesaparecidoRepositorio : IDesaparecido
    {
        //------------------------------------------------------------------
        //Construtor para injetar o BancoContext

        private readonly BancoContext _bancoContext;
        public DesaparecidoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }


        //------------------------------------------------------------------
        //Salva os dados preenchidos no formulario no Banco de dados
        public DesaparecidoModel Criar(DesaparecidoModel desaparecido)
        {
            _bancoContext.Desaparecidos.Add(desaparecido);
            _bancoContext.SaveChanges();
            return desaparecido;
        }


        //------------------------------------------------------------------
        //Lista os dados da tabela Desaparecidos presente Banco de dados
        public List<DesaparecidoModel> Listar()
        {
            return _bancoContext.Desaparecidos.ToList();
        }


        //------------------------------------------------------------------
        //Lista os dados da tabela Desaparecidos presente Banco de dados que possuem o id informado a função

        public DesaparecidoModel ListarPorId(Guid id)
        {
            return _bancoContext.Desaparecidos.FirstOrDefault(o => o.Id == id);

        }
    }
}
