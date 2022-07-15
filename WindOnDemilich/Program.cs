using System.Diagnostics;
using WindOnDemilich;

const string path = @"/Users/viniciusvatanabi/Downloads/dataset/large_scale/knapPI_3_5_1000_1";

Estatística.TempoMédio(Projeto.MétodoGulosoEx, path, 1);
Estatística.TempoMédio(Projeto.MétodoGulosoXd, path, 1);
Estatística.TempoMédio(Projeto.MétodoDinâmico, path, 1);

namespace WindOnDemilich
{
    public class Amostra
    {
        public int Index { get; set; }
        public double Tempo { get; set; }
        public int Valor { get; set; }
        public int Peso { get; set; }

        public Amostra(int valor, int peso)
        {
            Valor = valor;
            Peso = peso;
        }

        public Amostra(int index, double tempo)
        {
            Index = index;
            Tempo = tempo;
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
        public static double TempoMédio(Func<string, int> método, string caminho, uint repetições = 10, bool detalhar = true)
        {
            var cronômetro = new Stopwatch();
            var re = 0;
            var média = 0.0;
            Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/Resultados");
            File.WriteAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/Resultados/{método.Method.Name}.csv", $"Index,Tempo{Environment.NewLine}");
            var resultadoMétodo = 0;
            while (re < repetições)
            {
                cronômetro.Start();
                resultadoMétodo = método(caminho);
                cronômetro.Stop();
                var tempo = cronômetro.ElapsedMilliseconds;
                if (detalhar)
                {
                    Exibição.Imprimir($"{método.Method.Name} - {resultadoMétodo} - {tempo} ms", Tipo.Random);
                }
                SalvaEmArquivo(método.Method.Name, new Amostra(re, tempo));
                média += tempo;
                cronômetro.Reset();
                re++;
            }

            Exibição.Imprimir($"Tempo médio - {método.Method.Name}: {média / (float) repetições} ms", Tipo.Sucesso);
            Exibição.Imprimir($"Ideal (%) - {método.Method.Name}: {resultadoMétodo / (float) Projeto.MétodoDinâmico(caminho) * 100}%", Tipo.Sucesso);
            return média / (float)repetições;
        }
    }
    
    public static class Projeto
    {
        public static int MétodoDinâmico(string caminho)
        {
            var itens = (from line in File.ReadLines(caminho) let valor = line.TrimEnd().Split(' ')[0] let peso = line.TrimEnd().Split(' ')[1] select new Amostra(int.Parse(valor), int.Parse(peso))).ToList();

            var pesoMáximo = itens[0].Peso;
            itens.RemoveAt(0);
            itens.RemoveAt(itens.Count - 1);
            var quantidadeDeItens = itens.Count;

            var matrizDinâmica = new int[quantidadeDeItens+1, pesoMáximo+1];

            var ordem = new List<char>();

            foreach (var i in Enumerable.Range(0, quantidadeDeItens + 1))
            {
                foreach (var j in Enumerable.Range(0, pesoMáximo + 1))
                {
                    if (i == 0 || j == 0)
                    {
                        matrizDinâmica[i, j] = 0;
                        ordem.Add('a');
                    }
                    else if (itens[i - 1].Peso <= j)
                    {
                        matrizDinâmica[i, j] = Math.Max(itens[i - 1].Valor + matrizDinâmica[i - 1, j - itens[i - 1].Peso], matrizDinâmica[i - 1, j]);
                        ordem.Add('b');
                    }
                    else
                    {
                        matrizDinâmica[i, j] = matrizDinâmica[i - 1, j];
                        ordem.Add('c');
                    }
                }
            }

            File.WriteAllText("potato.txt", "");
            var contadorDeLinhas = 0;
            foreach (var matriz in ordem)
            {
                if (contadorDeLinhas == pesoMáximo + 1)
                {
                    contadorDeLinhas = 0;
                    File.AppendAllText("potato.txt", Environment.NewLine);
                }

                if (contadorDeLinhas == pesoMáximo)
                {
                    File.AppendAllText("potato.txt", $"{matriz}");
                }
                else
                {
                    File.AppendAllText("potato.txt", $"{matriz}, ");
                }

                contadorDeLinhas++;
                

            }

            return matrizDinâmica[quantidadeDeItens, pesoMáximo];
        }

        public static int MétodoGulosoEx(string caminho)
        {
            var itens = (from line in File.ReadLines(caminho) let valor = line.TrimEnd().Split(' ')[0] let peso = line.TrimEnd().Split(' ')[1] select new Amostra(int.Parse(valor), int.Parse(peso))).ToList();

            var pesoMáximo = itens[0].Peso;
            itens.RemoveAt(0);
            itens.RemoveAt(itens.Count - 1);
            
            var amostrasOrdenadas = itens.OrderBy(i => i.Peso).ThenByDescending(j => j.Valor);
            var pesoAtual = 0;
            var valorAtual = 0;
            foreach (var amostra in amostrasOrdenadas)
            {
                if (pesoAtual + amostra.Peso <= pesoMáximo)
                {
                    pesoAtual += amostra.Peso;
                    valorAtual += amostra.Valor;
                }
                else
                {
                    break;
                }
            }

            return valorAtual;
        }

        public static int MétodoGulosoXd(string caminho)
        {
            var itens = (from line in File.ReadLines(caminho) let valor = line.TrimEnd().Split(' ')[0] let peso = line.TrimEnd().Split(' ')[1] select new Amostra(int.Parse(valor), int.Parse(peso))).ToList();

            var pesoMáximo = itens[0].Peso;
            itens.RemoveAt(0);
            itens.RemoveAt(itens.Count - 1);

            var amostrasOrdenadas = itens.OrderByDescending(i => i.Valor / (float)i.Peso).ThenByDescending(j => j.Valor);
            var pesoAtual = 0;
            var valorAtual = 0;
            foreach (var amostra in amostrasOrdenadas)
            {
                if (pesoAtual + amostra.Peso <= pesoMáximo)
                {
                    pesoAtual += amostra.Peso;
                    valorAtual += amostra.Valor;
                }
                else
                {
                    break;
                }
            }

            return valorAtual;
        }
    }
}