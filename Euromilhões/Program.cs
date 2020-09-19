using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Euromilhoes
{
    class Program
    { 
        static void Main(string[] args)
        {
            int totalNum = 5;
            int totalEstrelas = 2;

  
            // Pedir ao utilizador para inserir os númereos e estrelas
             List<int> numeros= LerInseridos(totalNum, "número", 50);


             List<int> estrelas =  LerInseridos(totalEstrelas, "estrela", 12);


            //Atribuir números inseridos pelo utilizador á class euromilhões

            Euromilhoes euromilhoes = new Euromilhoes();

            EuromilhosEstrelaseNumeros euromilhosInserido = new EuromilhosEstrelaseNumeros();

            euromilhosInserido.Numeros = numeros;
            euromilhosInserido.Estrelas = estrelas;

            euromilhoes.EuromilhosInserido = euromilhosInserido;


            //Calcular números sorteados 


            EuromilhosEstrelaseNumeros euromilhosSorteado = new EuromilhosEstrelaseNumeros();

            euromilhosSorteado.Numeros = SorteiaNumerosSemReptir(5, 1, 51);
            euromilhosSorteado.Estrelas = SorteiaNumerosSemReptir(2, 1, 13);

            euromilhoes.EuromilhosSorteado = euromilhosSorteado;


            // Verificar se acertou na chave

            EuromilhosEstrelaseNumeros NumerosEstrelasIguas = new EuromilhosEstrelaseNumeros();

                             // Números 

            NumerosEstrelasIguas.Numeros = new List<int>() { };
            for (int i = 0; i < euromilhoes.EuromilhosInserido.Numeros.Count; i++)
            {

                for (int j = 0; j < euromilhoes.EuromilhosSorteado.Numeros.Count; j++)
                {


                    if (euromilhoes.EuromilhosInserido.Numeros[i] == euromilhoes.EuromilhosSorteado.Numeros[j])
                    {
                        NumerosEstrelasIguas.Numeros.Add(euromilhoes.EuromilhosInserido.Numeros[i]);
                    }
                }
            }


                           // Estrelas 
            NumerosEstrelasIguas.Estrelas = new List<int>() { };
            for (int i = 0; i < euromilhoes.EuromilhosInserido.Estrelas.Count; i++)
            {

                for (int j = 0; j < euromilhoes.EuromilhosSorteado.Estrelas.Count; j++)
                {


                    if (euromilhoes.EuromilhosInserido.Estrelas[i] == euromilhoes.EuromilhosSorteado.Estrelas[j])
                    {
                        NumerosEstrelasIguas.Estrelas.Add(euromilhoes.EuromilhosInserido.Estrelas[i]);
                    }
                }
            }

            euromilhoes.NumerosEstrelasIguas = NumerosEstrelasIguas;

            // Escrever por ordem crescente os números inseridos pelo utilizador

            Console.WriteLine("Chave Inserida "+ String.Join("; ", euromilhoes.EuromilhosInserido.Numeros) + "   " + String.Join("; ", euromilhoes.EuromilhosInserido.Estrelas));

            // Escrever por ordem crescente os números sorteados

            Console.WriteLine("Chave Sorteada " + String.Join("; ", euromilhoes.EuromilhosSorteado.Numeros) + "   " + String.Join("; ", euromilhoes.EuromilhosSorteado.Estrelas));


            // Verificar os números e estrelas acertadas 

            Console.WriteLine("Acertou no número: " + String.Join("; ", euromilhoes.NumerosEstrelasIguas.Numeros));

            Console.WriteLine("Acertou na estrela: " + String.Join("; ", euromilhoes.NumerosEstrelasIguas.Estrelas));

            // Verificar se ganhou ou prémio ou não 

            if (euromilhoes.NumerosEstrelasIguas.Numeros.Count == 5 && euromilhoes.NumerosEstrelasIguas.Estrelas.Count ==2)
            {
                Console.WriteLine(
                    "Acertou no euromilhoes");

            } else
            {
                Console.WriteLine(
                  "Não acertou no euromilhões! Tente novamente.");
            }

            Console.ReadKey();
        }

        private static List<int> SorteiaNumerosSemReptir(int quantidade, int minimo, int maximo)
        {
            // Validações dos argumentos
            if (quantidade < 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");
            else if (quantidade > maximo + 1 - minimo)
                throw new ArgumentException("Quantidade deve ser menor do que a diferença entre máximo e mínimo.");
            else if (maximo <= minimo)
                throw new ArgumentException("Máximo deve ser maior do que mínimo.");

            List<int> numerosSorteados = new List<int>();
            Random rnd = new Random();


            while (numerosSorteados.Count < quantidade)
            {
                int numeroSorteado = rnd.Next(minimo, maximo);

                // Número já foi sorteado? Então sorteamos novamente até o número não ter sido sorteado ainda.
                while (numerosSorteados.Contains(numeroSorteado))
                    numeroSorteado = rnd.Next(minimo, maximo);

                numerosSorteados.Add(numeroSorteado);
            }

            return numerosSorteados.OrderBy(i => i).ToList();           
        }

        public static bool ValDuplicados(List<int> num, int numero)
        {
            for (int i = 0; i < num.Count; i++)
            {
               
                    if (num[i] == numero)
                    {
                        return true;
                    }
                
            }
            return false;
        }


        public static List<int> LerInseridos(int qauntidade, string tipo, int maximo)
        {
            int i = 0;
            List<int> numeros = new List<int>();
            while (i < qauntidade)
            {

                Console.WriteLine("insira um número para o tipo "+ tipo);
                var numero = int.Parse(Console.ReadLine());


                bool existemNumDuplicados = ValDuplicados(numeros, numero);
               
                if (numero < 1)
                {
                    Console.WriteLine("O número inserido para o tipo " + tipo+" é inferior a 1");
                }
                else if (numero > maximo)
                {
                    Console.WriteLine("O número inserido para o tipo " + tipo + " é superior a " +maximo);
                }
                   

                else
                if (existemNumDuplicados)
                {

                    Console.WriteLine("Já inseriru o número " + numero + " para o tipo " + tipo+". Inseria um numero diferente");
                }
                else
                {
                    numeros.Add(numero);
                    i++;
                }

            }

            return numeros.OrderBy(j => j).ToList();
        }

    }
}
