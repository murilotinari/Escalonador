using Escalonador_Simples;
using Escalonador_Simples.Model;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Runtime.Serialization;


/*
int qtd = 0;

while (true)
{
    try
    {
        Console.Write("Digite quantos processos deseja inserir: ");
        qtd = Convert.ToInt32(Console.ReadLine());
        break;
    }
    catch
    {
        Console.WriteLine("Digita um número!");
    }        
}

Processo[] list = new Processo[qtd];

for (int i = 0; i < qtd; i++)
{
    Console.Clear();
    
    Console.WriteLine("Processo {0}: \n", i + 1);

    Console.Write("\nDigite seu tempo de chegada: ");
    int chegada = Convert.ToInt32(Console.ReadLine());

    Console.Write("\nDigite seu tempo de serviço: ");
    int tempoServico = Convert.ToInt32(Console.ReadLine());

    Console.Write("\nDigite sua prioridade: ");
    int prioridade = Convert.ToInt32(Console.ReadLine());

    int id = i + 1;

    Processo p = new Processo(chegada, tempoServico, prioridade, id);
    list[i] = p;
}

bool correto = false;
List<Processo> list_copy = new List<Processo>();

while (!correto)
{
    list_copy.Clear();
    foreach (Processo p in list)
    {
        p.Reset();
        list_copy.Add(p);
    }

    Console.Clear();
    Console.WriteLine("Escolha o algoritmo para escalonamento: ");
    Console.WriteLine("1 -> FCFS");
    Console.WriteLine("2 -> SJF");
    Console.WriteLine("3 -> Round Robin");
    Console.WriteLine("4 -> SRTF");
    Console.WriteLine("5 -> PRIOc");
    Console.WriteLine("6 -> PRIOp");

    string escolha = "";
    Console.Write("Entrada: ");
    escolha = Console.ReadLine();

    switch (escolha)
    {
        case "1":
            FCFS(list_copy);
            Console.ReadLine();
            break;
        case "2":
            SJF(list_copy);
            Console.ReadLine();
            break;
        case "3":
            RoundRobin(list_copy);
            Console.ReadLine();
            break;
        case "4":
            SRTF(list_copy);
            Console.ReadLine();
            break;
        case "5":
            PRIOc(list_copy);
            Console.ReadLine();
            break;
        case "6":
            PRIOp(list_copy);
            Console.ReadLine();
            break;
        default:
            Console.Write("Digite 0 para sair e 1 para escolher outro algoritmo: ");
            string saida = Console.ReadLine();
            if (saida == "0")
                correto = true;
            else
                correto = false;
            break;
    }

}
*/

internal class Program
{
    private static void Main(string[] args)
    {
        
        int qtd = 0;
        Escalonadores e = new Escalonadores();
        while (true)
        {
            try
            {
                Console.Write("Digite quantos processos deseja inserir: ");
                qtd = Convert.ToInt32(Console.ReadLine());
                break;
            }
            catch
            {
                Console.WriteLine("Digita um número!");
            }        
        }

        Processo[] list = new Processo[qtd];

        for (int i = 0; i < qtd; i++)
        {
            Console.Clear();
    
            Console.WriteLine("Processo {0}: \n", i + 1);

            Console.Write("\nDigite seu tempo de chegada: ");
            int chegada = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nDigite seu tempo de serviço: ");
            int tempoServico = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nDigite sua prioridade: ");
            int prioridade = Convert.ToInt32(Console.ReadLine());

            int id = i + 1;

            Processo p = new Processo(chegada, tempoServico, prioridade, id);
            list[i] = p;
        }

        bool correto = false;
        List<Processo> list_copy = new List<Processo>();

        while (!correto)
        {
            list_copy.Clear();
            foreach (Processo p in list)
            {
                p.Reset();
                list_copy.Add(p);
            }

            Console.Clear();
            Console.WriteLine("Escolha o algoritmo para escalonamento: ");
            Console.WriteLine("1 -> FCFS");
            Console.WriteLine("2 -> SJF");
            Console.WriteLine("3 -> Round Robin");
            Console.WriteLine("4 -> SRTF");
            Console.WriteLine("5 -> PRIOc");
            Console.WriteLine("6 -> PRIOp");

            string escolha = "";
            Console.Write("Entrada: ");
            escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    e.FCFS(list_copy);
                    Console.ReadLine();
                    break;
                case "2":
                    e.SJF(list_copy);
                    Console.ReadLine();
                    break;
                case "3":
                    e.RoundRobin(list_copy);
                    Console.ReadLine();
                    break;
                case "4":
                    e.SRTF(list_copy);
                    Console.ReadLine();
                    break;
                case "5":
                    e.PRIOc(list_copy);
                    Console.ReadLine();
                    break;
                case "6":
                    e.PRIOp(list_copy);
                    Console.ReadLine();
                    break;
                default:
                    Console.Write("Digite 0 para sair e 1 para escolher outro algoritmo: ");
                    string saida = Console.ReadLine();
                    if (saida == "0")
                        correto = true;
                    else
                        correto = false;
                    break;
            }

        }
        

        Console.ReadLine();
    }
}