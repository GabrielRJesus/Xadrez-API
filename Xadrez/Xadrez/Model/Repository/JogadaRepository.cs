using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xadrez.Model.Repository
{
    public class JogadaRepository : IJogadaRepository
    {
        public string ValidaPeao(string pi, string pf)
        {
            int ini, fim;
            ini = Convert.ToInt32(pi.Substring(1, 1));
            fim = Convert.ToInt32(pf.Substring(1, 1));
            if (pi.Substring(0, 1).Equals(pf.Substring(0, 1)) && (fim - ini) <= 2)
                return "Posição Valida";
            if ((CalculaDiferenca(pi.Substring(0, 1), pf.Substring(0, 1)) == 1 ||
                CalculaDiferenca(pi.Substring(0, 1), pf.Substring(0, 1)) == -1)
                && (fim - ini) == 1)
                return "Posição Valida";
            return "Posição invalida";
        }

        public string ValidaCavalo(string pi, string pf)
        {
            int ini, fim;
            ini = Convert.ToInt32(pi.Substring(1, 1));
            fim = Convert.ToInt32(pf.Substring(1, 1));
            if (ini != fim || CalculaDiferenca(pi.Substring(0, 1), pf.Substring(0, 1)) != 0)
            {
                if ((CalculaDiferenca(pi.Substring(0, 1), pf.Substring(0, 1)) == 2 || CalculaDiferenca(pi.Substring(0, 1), pf.Substring(0, 1)) == -2)
                    && ((fim - ini) == 1 || (fim - ini) == -1))
                    return "Posição Valida";
                if ((CalculaDiferenca(pi.Substring(0, 1), pf.Substring(0, 1)) == 1 || CalculaDiferenca(pi.Substring(0, 1), pf.Substring(0, 1)) == -1)
                    && ((fim - ini) == 2 || (fim - ini) == -2))
                    return "Posição Valida";
            }
            return "Posição Invalida!";
        }

        public string ValidaBispo(string pi, string pf)
        {
            int ini, fim;
            ini = Convert.ToInt32(pi.Substring(1, 1));
            fim = Convert.ToInt32(pf.Substring(1, 1));
            if ((((fim - ini) * -1) == CalculaDiferenca(pi.Substring(0, 1), pf.Substring(0, 1))) ||
                ((fim - ini) == CalculaDiferenca(pi.Substring(0, 1), pf.Substring(0, 1))))
            {
                return "Posição Valida";
            }
            return "Posição Invalida";
        }

        public string ValidaTorre(string pi, string pf)
        {
            int ini, fim;
            ini = Convert.ToInt32(pi.Substring(1, 1));
            fim = Convert.ToInt32(pf.Substring(1, 1));
            if (pi.Substring(0, 1).Equals(pf.Substring(0, 1)) || ini == fim)
                return "Posição Valida";
            return "Posição Invalida";
        }

        public string ValidaRei(string pi, string pf)
        {
            int ini, fim;
            ini = Convert.ToInt32(pi.Substring(1, 1));
            fim = Convert.ToInt32(pf.Substring(1, 1));
            if(CalculaDiferenca(pi.Substring(0, 1), pf.Substring(0, 1)) == 0){
                if(fim - ini == 1 || fim - ini == -1)
                    return "Posição Valida";
                return "Posição Invalida";
            }
            else
            {
                if(CalculaDiferenca(pi.Substring(0, 1), pf.Substring(0, 1)) == 1 || CalculaDiferenca(pi.Substring(0, 1), pf.Substring(0, 1)) == -1)
                {
                    if(fim - ini == 1 || fim - ini == -1)
                        return "Posição Valida";
                    if(fim == ini)
                        return "Posição Valida";
                }
                return "Posição Invalida";
            }
        }

        public bool ValidaLetra(string letra)
        {
            string[] alfabeto = { "a", "b", "c", "d", "e", "f", "g", "h" };
            foreach (var item in alfabeto)
            {
                if (item.Equals(letra.ToLower()))
                    return true;
            }
            return false;
        }

        public bool ValidaNumero(string numero)
        {
            string[] numeral = { "1", "2", "3", "4", "5", "6", "7", "8" };
            foreach (var item in numeral)
            {
                if (item.Equals(numero))
                    return true;
            }
            return false;
        }

        public int CalculaDiferenca(string ini, string fim)
        {
            int a = 0, b = 0;
            string[] alfabeto = { "a", "b", "c", "d", "e", "f", "g", "h" };
            for (int i = 0; i < alfabeto.Length; i++)
            {
                if (alfabeto.ElementAt(i).Equals(ini.ToLower()))
                    a = i + 1;
                if (alfabeto.ElementAt(i).Equals(fim.ToLower()))
                    b = i + 1;
            }
            return b - a;
        }

        public bool ValidaInicio(string pi, string pf, int peca)
        {
            if (!String.IsNullOrEmpty(pi) && !String.IsNullOrEmpty(pf) && peca >= 0 && peca < 10)
            {
                if(pi.Length==2 && pf.Length == 2)
                {
                    if (ValidaLetra(pi.Substring(0, 1)) && ValidaLetra(pf.Substring(0, 1))
                        && ValidaNumero(pi.Substring(1, 1)) && ValidaNumero(pf.Substring(1, 1)))
                    {
                        return true;
                    }
                }
                
            }
            return false;
        }
    }
}
