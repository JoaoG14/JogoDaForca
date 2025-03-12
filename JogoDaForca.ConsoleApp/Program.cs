namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] palavras = {
                "ABACATE",
                "ABACAXI",
                "ACEROLA",
                "ACAI",
                "ARACA",
                "ABACATE",
                "BACABA",
                "BACURI",
                "BANANA",
                "CAJA",
                "CAJU",
                "CARAMBOLA",
                "CUPUACU",
                "GRAVIOLA",
                "GOIABA",
                "JABUTICABA",
                "JENIPAPO",
                "MACA",
                "MANGABA",
                "MANGA",
                "MARACUJA",
                "MURICI",
                "PEQUI",
                "PITANGA",
                "PITAYA",
                "SAPOTI",
                "TANGERINA",
                "UMBU",
                "UVA",
                "UVAIA"
            };

            Random geradorDeNumeros= new Random();

            int indiceEscolhido = geradorDeNumeros.Next(palavras.Length);

            string palavraEscolhida = palavras[indiceEscolhido];

            char[] letrasEncontradas = new char[palavraEscolhida.Length];

            for (int caractereAtual = 0; caractereAtual < letrasEncontradas.Length; caractereAtual++)
            {
                letrasEncontradas[caractereAtual] = '_';
            }

            int quantidadeDeErros = 0;
            bool jogadoraGanhou = false;
            bool jogadorPerdeu = false;

            do 
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
                Console.WriteLine("Digite uma letra:");
                string entradaInicial = Console.ReadLine().ToUpper();

                if (entradaInicial.Length > 1)
                {
                    Console.WriteLine("Digite apenas uma letra!");
                    continue;
                }


                char chute = entradaInicial[0];

                bool letraFoiEncontrada = false;

                for (int contadorCaracteres = 0; contadorCaracteres < palavraEscolhida.Length; contadorCaracteres++)
                {
                    char caractereAtual = palavraEscolhida[contadorCaracteres];

                    if (chute == caractereAtual)
                    {
                        letrasEncontradas[contadorCaracteres] = caractereAtual;
                        letraFoiEncontrada = true;
                    } 

                }

                if (letraFoiEncontrada == false)
                {
                    quantidadeDeErros++;
                }

                string palavraEncontradaCompleta = String.Join("", letrasEncontradas);

                if (palavraEscolhida == palavraEncontradaCompleta)
                {
                    jogadoraGanhou = true;
                    Console.WriteLine("------------------------------------------------");
                    Console.WriteLine($"Parabéns, você acertou a palavra! {palavraEscolhida}");
                    Console.WriteLine("------------------------------------------------");
                }

                jogadorPerdeu = quantidadeDeErros > 5;

                Console.ReadLine(); 
            } while (jogadoraGanhou != true && jogadorPerdeu != true);
        }
    }
}
