using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendasTestesFuncionais {
    public static class Gerador {


        public static String gerarCpf() {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            return semente;
        }

        public static String gerarNumero() {

            Random rnd = new Random();
            string rg = rnd.Next(100000000, 999999999).ToString();

            return rg;

        }

        public static String gerarEmail() {

            string result = Path.GetRandomFileName();

            return (result+"@CELULARDIRETO.COM.BR");

        }

        public static string gerarNumeroCelular()
        {
            Random number = new Random();
            var retorno = number.Next(988888888, 999999999).ToString();
            return ("21"+retorno);
        }


    }
}
