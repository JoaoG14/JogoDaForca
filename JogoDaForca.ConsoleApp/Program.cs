namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] palavras = ObterListaDePalavras();
            string palavraEscolhida = SelecionarPalavraAleatoria(palavras);
            char[] letrasEncontradas = InicializarLetrasEncontradas(palavraEscolhida);

            int quantidadeDeErros = 0;
            bool jogadorGanhou = false;
            bool jogadorPerdeu = false;

            do
            {
                ExibirInterface(quantidadeDeErros, letrasEncontradas);

                char chute = ObterLetraDoJogador();

                bool letraFoiEncontrada = VerificarLetraNaPalavra(palavraEscolhida, chute, letrasEncontradas);

                if (!letraFoiEncontrada)
                {
                    quantidadeDeErros++;
                }

                jogadorGanhou = VerificarVitoria(palavraEscolhida, letrasEncontradas);
                jogadorPerdeu = quantidadeDeErros > 5;

                if (jogadorGanhou)
                {
                    ExibirMensagemVitoria(palavraEscolhida);
                }

                Console.ReadLine();
            } while (!jogadorGanhou && !jogadorPerdeu);

            if (jogadorPerdeu)
            {
                ExibirMensagemDerrota(palavraEscolhida);
            }
        }

        static string[] ObterListaDePalavras()
        {
            return new string[] {
                "ABACATE", "ABACAXI", "ACEROLA", "ACAI", "ARACA",
                "ABACATE", "BACABA", "BACURI", "BANANA", "CAJA",
                "CAJU", "CARAMBOLA", "CUPUACU", "GRAVIOLA", "GOIABA",
                "JABUTICABA", "JENIPAPO", "MACA", "MANGABA", "MANGA",
                "MARACUJA", "MURICI", "PEQUI", "PITANGA", "PITAYA",
                "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA"
            };
        }

        static string SelecionarPalavraAleatoria(string[] palavras)
        {
            Random geradorDeNumeros = new Random();
            int indiceEscolhido = geradorDeNumeros.Next(palavras.Length);
            return palavras[indiceEscolhido];
        }

        static char[] InicializarLetrasEncontradas(string palavra)
        {
            char[] letrasEncontradas = new char[palavra.Length];

            for (int i = 0; i < letrasEncontradas.Length; i++)
            {
                letrasEncontradas[i] = '_';
            }

            return letrasEncontradas;
        }

        static void ExibirInterface(int quantidadeDeErros, char[] letrasEncontradas)
        {
            string cabecaDoDesenho = quantidadeDeErros >= 1 ? " O " : "";
            string troncoDoDesenho = quantidadeDeErros >= 2 ? "X" : "";
            string troncoInferiorDoDesenho = quantidadeDeErros >= 2 ? "X" : "";
            string bracoEsquerdoDoDesenho = quantidadeDeErros >= 3 ? "/" : " ";
            string bracoDireitoDoDesenho = quantidadeDeErros >= 4 ? "\\" : "";
            string pernasDoDesenho = quantidadeDeErros >= 5 ? "/ \\" : "";

            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("Jogo da Forca");
            Console.WriteLine(" ___________        ");
            Console.WriteLine(" |/        |        ");
            Console.WriteLine(" |        {0}       ", cabecaDoDesenho);
            Console.WriteLine(" |        {0}{1}{2} ", bracoEsquerdoDoDesenho, troncoDoDesenho, bracoDireitoDoDesenho);
            Console.WriteLine(" |         {0}       ", troncoInferiorDoDesenho);
            Console.WriteLine(" |        {0}       ", pernasDoDesenho);
            Console.WriteLine(" |                  ");
            Console.WriteLine(" |                  ");
            Console.WriteLine("_|____              ");
            Console.WriteLine("----------------------");
            Console.WriteLine("Erros: " + quantidadeDeErros);
            Console.WriteLine("----------------------");
            Console.WriteLine("Palavra Escolhida: " + String.Join(" ", letrasEncontradas));
            Console.WriteLine("----------------------");
        }

        static char ObterLetraDoJogador()
        {
            bool entradaValida = false;
            char letraEscolhida = ' ';

            while (!entradaValida)
            {
                Console.WriteLine("Digite uma letra:");
                string entradaInicial = Console.ReadLine().ToUpper();

                if (entradaInicial.Length == 1)
                {
                    letraEscolhida = entradaInicial[0];
                    entradaValida = true;
                }
                else
                {
                    Console.WriteLine("Digite apenas uma letra!");
                }
            }

            return letraEscolhida;
        }

        static bool VerificarLetraNaPalavra(string palavra, char letra, char[] letrasEncontradas)
        {
            bool letraFoiEncontrada = false;

            for (int i = 0; i < palavra.Length; i++)
            {
                if (letra == palavra[i])
                {
                    letrasEncontradas[i] = letra;
                    letraFoiEncontrada = true;
                }
            }

            return letraFoiEncontrada;
        }

        static bool VerificarVitoria(string palavraEscolhida, char[] letrasEncontradas)
        {
            string palavraEncontradaCompleta = String.Join("", letrasEncontradas);
            return palavraEscolhida == palavraEncontradaCompleta;
        }

        static void ExibirMensagemVitoria(string palavraEscolhida)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Parabéns, você acertou a palavra! {palavraEscolhida}");
            Console.WriteLine("------------------------------------------------");
        }

        static void ExibirMensagemDerrota(string palavraEscolhida)
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Você perdeu! A palavra era: {palavraEscolhida}");
            Console.WriteLine("------------------------------------------------");
        }
    }
}