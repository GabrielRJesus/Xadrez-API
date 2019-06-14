using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xadrez.Model.Repository;

namespace Xadrez.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IJogadaRepository repository = new JogadaRepository();
        // GET api/values
        [HttpGet]
        public string Get(string pi, string pf, int peca)
        {
            if(repository.ValidaInicio(pi,pf,peca))
            {
                if (peca == 1)
                    return repository.ValidaPeao(pi, pf);
                if (peca == 2)
                    return repository.ValidaCavalo(pi, pf);
                if (peca == 3)
                    return repository.ValidaBispo(pi, pf);
                if (peca == 5)
                    return repository.ValidaTorre(pi, pf);
                if (peca == 9)
                    return repository.ValidaBispo(pi, pf).Equals("Posição Valida") || repository.ValidaTorre(pi, pf).Equals("Posição Valida") ? "Posição Valida" : "Posição Invalida";
                if (peca == 0)
                    return repository.ValidaRei(pi, pf);
                else
                    return "Peça Invalida";
                
            }
            return Inicial();
        }

        

        private string Inicial()
        {
            return "Essa é a API de Validação de movimentação de peças em um jogo de xadrez! \n " +
                   "Os valores das peças bem como os exemplos de movimentação foi tirado do site soxadrez. \n " +
                   "Segue a tabela de valores: \n " +
                   "Rei     - 0 \n " +
                   "Rainha  - 9 \n " +
                   "Torre   - 5 \n " +
                   "Bispo   - 3 \n " +
                   "Cavalo  - 2 \n " +
                   "Peão    - 1 \n " +
                   "Os Parametros para acesso da api são Posição Inicial, Posição Final, Peça. \n " +
                   "Ex: http://localhost:57365/api/values?pi=a7&pf=b8&peca=0  \n " +
                   "Ao digitar a entrada incorreta este texto é exibido novamente.";
        }

    }
}
