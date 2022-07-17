using System.Diagnostics;
using FlameOnDemilich;

Projeto.Teste();

namespace FlameOnDemilich
{
    public class Pacote
    {
        private List<int> _itens = new();
        private List<int> _itensRejeitados = new();

        public int Id => GetHashCode();
        public int PesoMáximo { get; }

        public List<int> Itens
        {
            get => _itens;
            set
            {
                var interruptor = true;
                foreach (var i in value)
                {
                    if (interruptor)
                    {
                        if (Adicionável(i))
                        {
                            _itens.Add(i);
                            continue;
                        }

                        interruptor = false;
                    }
                    _itensRejeitados.Add(i);
                }
            }
        }

        public List<int> ItensRejeitados => _itensRejeitados;

        public int PesoDisponível => PesoMáximo - Itens.Sum();

        public bool Cheio => PesoDisponível >= PesoMáximo;

        public bool Adicionável(int value)
        {
            return PesoDisponível - value >= 0;
        }

            public Pacote()
        {
        }

        public Pacote(int pesoMáximo)
        {
            PesoMáximo = pesoMáximo;
        }

        public Pacote(int pesoMáximo, List<int> itens)
        {
            PesoMáximo = pesoMáximo;
            Itens = itens;
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
        // private static void SalvaEmArquivo(string nome, Amostra amostra)
        // {
        //     File.AppendAllText($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/Resultados/{nome}.csv", $"{Amostra.Index},{amostra.Tempo}{Environment.NewLine}");
        // }
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
                // SalvaEmArquivo(método.Method.Name, new Amostra(re, tempo));
                média += tempo;
                cronômetro.Reset();
                re++;
            }

            Exibição.Imprimir($"Tempo médio - {método.Method.Name}: {média / (float) repetições} ms", Tipo.Sucesso);
            // Exibição.Imprimir($"Ideal (%) - {método.Method.Name}: {resultadoMétodo / (float) Projeto.MétodoDinâmico(caminho) * 100}%", Tipo.Sucesso);
            return média / (float)repetições;
        }
    }

    public static class Projeto
    {
        public static void Teste()
        {
            var arquivo = File.ReadAllLines("/Users/viniciusvatanabi/Downloads/binpacking-instancias/input/Waescher_TEST0005.txt").Select(int.Parse).ToList();
            arquivo.RemoveAt(0);
            var pesoMáximo = arquivo[0];
            arquivo.RemoveAt(0);
            var girafa = new List<Pacote>();
            var contador = 0;
            girafa.Add(new Pacote(pesoMáximo, arquivo));
            contador++;
            while (true)
            {
                var contador1 = 0;
                foreach (var pacote in girafa.Where(g => !g.Cheio))
                {
                    if (pacote.Adicionável(girafa[^1].ItensRejeitados.First()))
                    {
                        contador1++;
                        pacote.Itens = new List<int> { girafa[^1].ItensRejeitados.First() };
                    }
                }

                if (contador1 == 0)
                {
                    girafa.Add(new Pacote(pesoMáximo, arquivo));
                    contador++;
                }
                if (girafa[^1].ItensRejeitados.Count != 0)
                {
                    arquivo = girafa.Last().ItensRejeitados;
                }
                else
                {
                    break;
                }
            }
            Exibição.Imprimir(contador.ToString(), Tipo.Sucesso);
        }
    }
}