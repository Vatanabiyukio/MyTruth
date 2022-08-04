using System.Diagnostics;
using FlameOnDemilich;

var path = "/Users/viniciusvatanabi/Downloads/binpacking-instancias/input";
Estatística.TempoMédio(Projeto.FirstFit, path, 1, false);
Estatística.TempoMédio(Projeto.NextFit, path, 1, false);
Estatística.TempoMédio(Projeto.BestFit, path, 1, false);

namespace FlameOnDemilich
{
    public class Amostra
    {
        public int Index { get; set; }
        public double Tempo { get; set; }
        public int Valor { get; set; }

        public Amostra(int index, double tempo)
        {
            Index = index;
            Tempo = tempo;
        }
        
        public Amostra(int index, double tempo, int valor)
        {
            Index = index;
            Tempo = tempo;
            Valor = valor;
        }
    }
    
    internal enum Tipo
    {
        Solicitação,
        Sucesso,
        Aviso,
        Erro,
        Desconhecido,
        Falha,
        Opção,
        Random
    }
    
    internal static class Exibição
    {
        public static void Imprimir(string texto, Tipo modo = Tipo.Desconhecido, ConsoleColor txt = ConsoleColor.DarkGreen)
        {
            const ConsoleColor colchete = ConsoleColor.DarkCyan;
            const ConsoleColor solicitação = ConsoleColor.Cyan;
            const ConsoleColor sucesso = ConsoleColor.Green;
            const ConsoleColor aviso = ConsoleColor.Yellow;
            const ConsoleColor erro = ConsoleColor.Red;
            const ConsoleColor desconhecido = ConsoleColor.DarkBlue;
            const ConsoleColor falha = ConsoleColor.Magenta;

            if (modo == Tipo.Random)
            {
                var values = Enum.GetValues(typeof(Tipo));
                var random = new Random();
                modo = (Tipo)(values.GetValue(random.Next(values.Length - 2)) ?? Tipo.Desconhecido);
            }
            
            switch (modo)
            {
                case Tipo.Solicitação:
                    Console.ForegroundColor = colchete;
                    Console.Write('[');
                    Console.ForegroundColor = solicitação;
                    Console.Write(" * ");
                    Console.ForegroundColor = colchete;
                    Console.Write("] ");
                    Console.ForegroundColor = txt;
                    Console.Write($"{texto}\n");
                    Console.ResetColor();
                    break;
                case Tipo.Sucesso:
                    Console.ForegroundColor = colchete;
                    Console.Write('[');
                    Console.ForegroundColor = sucesso;
                    Console.Write(" ✔︎");
                    Console.ForegroundColor = colchete;
                    Console.Write("] ");
                    Console.ForegroundColor = txt;
                    Console.Write($"{texto}\n");
                    Console.ResetColor();
                    break;
                case Tipo.Aviso:
                    Console.ForegroundColor = colchete;
                    Console.Write('[');
                    Console.ForegroundColor = aviso;
                    Console.Write(" ! ");
                    Console.ForegroundColor = colchete;
                    Console.Write("] ");
                    Console.ForegroundColor = txt;
                    Console.Write($"{texto}\n");
                    Console.ResetColor();
                    break;
                case Tipo.Erro:
                    Console.ForegroundColor = colchete;
                    Console.Write('[');
                    Console.ForegroundColor = erro;
                    Console.Write(" ✘︎");
                    Console.ForegroundColor = colchete;
                    Console.Write("] ");
                    Console.ForegroundColor = txt;
                    Console.Write($"{texto}\n");
                    Console.ResetColor();
                    break;
                case Tipo.Desconhecido:
                    Console.ForegroundColor = colchete;
                    Console.Write('[');
                    Console.ForegroundColor = desconhecido;
                    Console.Write(" @ ");
                    Console.ForegroundColor = colchete;
                    Console.Write("] ");
                    Console.ForegroundColor = txt;
                    Console.Write($"{texto}\n");
                    Console.ResetColor();
                    break;
                case Tipo.Falha:
                    Console.ForegroundColor = colchete;
                    Console.Write('[');
                    Console.ForegroundColor = falha;
                    Console.Write(" ⌘ ");
                    Console.ForegroundColor = colchete;
                    Console.Write("] ");
                    Console.ForegroundColor = txt;
                    Console.Write($"{texto}\n");
                    Console.ResetColor();
                    break;
                case Tipo.Opção:
                    Console.ForegroundColor = colchete;
                    Console.Write("  ⸠-- ");
                    Console.ForegroundColor = txt;
                    Console.Write($"{texto}\n");
                    Console.ResetColor();
                    break;
                case Tipo.Random:
                default:
                    throw new ArgumentOutOfRangeException(nameof(modo), modo, null);
            }
        }
    }

    internal static class Estatística
    {
        private static void SalvaEmArquivo(string nome, Amostra amostra)
        {
            File.AppendAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/Resultados/{nome}.csv", $"{amostra.Index},{amostra.Tempo}{Environment.NewLine}");
        }
        public static void TempoMédio(Func<string, int> método, string caminho, uint repetições = 10, bool detalhar = true, bool potato = false)
        {
            var cronômetro = new Stopwatch();
            var re = 0;
            var média = 0.0;
            // Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/Resultados2");
            foreach (var arq in Directory.GetFiles(caminho))
            {
                // File.WriteAllText(
                //     $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/Resultados2/{Path.GetFileName(arq).Split('.')[0]}_{método.Method.Name}.csv",
                //     $"Index,Tempo{Environment.NewLine}");
                var resultadoMétodo = 0;
                while (re < repetições)
                {
                    cronômetro.Start();
                    resultadoMétodo = método(arq);
                    cronômetro.Stop();
                    var tempo = cronômetro.ElapsedTicks;
                    if (detalhar)
                    {
                        Exibição.Imprimir($"{método.Method.Name} - {resultadoMétodo} - {tempo} ticks", Tipo.Random);
                    }

                    // SalvaEmArquivo($"{Path.GetFileName(arq).Split('.')[0]}_{método.Method.Name}", new Amostra(re, tempo));
                    média += tempo;
                    cronômetro.Reset();
                    re++;
                }

                // Exibição.Imprimir($"Tempo médio - {Path.GetFileName(arq).Split('.')[0]}_{método.Method.Name}: {média / (float)repetições} ticks",
                //     Tipo.Sucesso);
                if (potato)
                {
                    Console.WriteLine(resultadoMétodo);
                }
                re = 0;
                média = 0.0;
            }

            // Exibição.Imprimir($"Ideal (%) - {método.Method.Name}: {resultadoMétodo / (float) Projeto.MétodoDinâmico(caminho) * 100}%", Tipo.Sucesso);
            // return média / (float)repetições;
        }
    }

    public static class Projeto
    {
        public static int NextFit(string caminho)
        {
            var pesos = File.ReadAllLines(caminho).Select(int.Parse).ToList();
            var capacidadeMáxima = pesos[1];

            foreach (var _ in Enumerable.Range(0, 2))
            {
                pesos.RemoveAt(0);
            }
            
            var quantidadePacotes = 0;
            var capacidadeRemanescente = capacidadeMáxima;

            foreach (var peso in pesos)
            {
                if (peso > capacidadeRemanescente)
                {
                    quantidadePacotes++;
                    capacidadeRemanescente = capacidadeMáxima - peso;
                }
                else
                    capacidadeRemanescente -= peso;
            }
            return quantidadePacotes;
        }
        
        public static int FirstFit(string caminho)
        {
            var pesos = File.ReadAllLines(caminho).Select(int.Parse).ToList();
            var capacidadeMáxima = pesos[1];

            foreach (var _ in Enumerable.Range(0, 2))
            {
                pesos.RemoveAt(0);
            }
            
            var quantidadePacotes = 0;
            var capacidadeRemanescente = new int[pesos.Count];
 
            foreach (var peso in pesos)
            {
                int j;
                for (j = 0; j < quantidadePacotes; j++)
                {
                    if (capacidadeRemanescente[j] < peso) continue;
                    capacidadeRemanescente[j] -= peso;
                    break;
                }
                
                if (j != quantidadePacotes) continue;
                capacidadeRemanescente[quantidadePacotes] = capacidadeMáxima - peso;
                quantidadePacotes++;
            }
            return quantidadePacotes;
        }

        public static int BestFit(string caminho)
        {
            var pesos = File.ReadAllLines(caminho).Select(int.Parse).ToList();
            var capacidadeMáxima = pesos[1];

            foreach (var _ in Enumerable.Range(0, 2))
            {
                pesos.RemoveAt(0);
            }
            
            var quantidadePacotes = 0;
            var capacidadeRemanescente = new int[pesos.Count];
 
            foreach (var peso in pesos)
            {
                int j;
                int min = capacidadeMáxima + 1, bi = 0;
 
                for (j = 0; j < quantidadePacotes; j++)
                {
                    if (capacidadeRemanescente[j] < peso || capacidadeRemanescente[j] - peso >= min) continue;
                    bi = j;
                    min = capacidadeRemanescente[j] - peso;
                }
                
                if (min == capacidadeMáxima + 1) {
                    capacidadeRemanescente[quantidadePacotes] = capacidadeMáxima - peso;
                    quantidadePacotes++;
                }

                else
                {
                    capacidadeRemanescente[bi] -= peso;
                }
            }
            return quantidadePacotes;
        }
    }
}