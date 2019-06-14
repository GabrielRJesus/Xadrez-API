using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xadrez.Model.Repository
{
    interface IJogadaRepository
    {
        bool ValidaLetra(string letra);
        bool ValidaNumero(string numero);
        int CalculaDiferenca(string ini, string fim);
        string ValidaRei(string pi, string pf);
        string ValidaTorre(string pi, string pf);
        string ValidaBispo(string pi, string pf);
        string ValidaCavalo(string pi, string pf);
        string ValidaPeao(string pi, string pf);
        bool ValidaInicio(string pi, string pf, int peca);

    }
}
