using Escalonador_Simples.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escalonador_Simples
{
    internal class Escalonadores
    {
        public void FCFS(List<Processo> list)
        {
            Queue<Processo> fila = new Queue<Processo>();
            Processo atual = new Processo();
            Processo[] list_copy = new Processo[list.Count()];
            list.CopyTo(list_copy);
            int tempo = -1;

            while (true)
            {
                tempo++;
                foreach (Processo p in list.ToList())
                    if (p.Chegada == tempo)
                    {
                        fila.Enqueue(p);
                        list.Remove(p);
                    }

                atual.TempoExecucao = atual.TempoExecucao - 1;

                if (atual.TempoExecucao <= 0)
                {
                    atual.Fim = tempo;
                    if (fila.Count != 0)
                    {
                        atual = fila.Dequeue();
                        atual.Inicio = tempo;
                    }
                }

                if (fila.Count == 0 && atual.TempoExecucao == 0 && list.Count == 0)
                    break;



                Console.WriteLine("Processo = {0} t = {1}s", atual.Id, tempo);
            }

            Console.WriteLine("Processo = {0} t = {1}s", atual.Id, tempo);
            double tempoMedioExecucao = 0;
            double tempoMedioEspera = 0;
            foreach (Processo p in list_copy)
            {
                Console.WriteLine("Processo: " + p.Id + " Chegada: " + p.Chegada + " Fim: " + p.Fim);
                tempoMedioExecucao += p.Fim - p.Chegada;
                tempoMedioEspera += p.Inicio - p.Chegada;
            }

            Console.WriteLine("Tempo Médio de Execução: " + tempoMedioExecucao / list_copy.Count());
            Console.WriteLine("Tempo Médio de Espera: " + tempoMedioEspera / list_copy.Count());

        }

        public void SJF(List<Processo> list)
        {
            List<Processo> fila = new List<Processo>();
            Processo atual = new Processo();
            Processo[] list_copy = new Processo[list.Count()];
            list.CopyTo(list_copy);
            int tempo = -1;

            while (true)
            {
                tempo++;
                foreach (Processo p in list.ToList())
                    if (p.Chegada == tempo)
                    {
                        fila.Add(p);
                        list.Remove(p);
                    }

                atual.TempoExecucao = atual.TempoExecucao - 1;

                if (atual.TempoExecucao <= 0)
                {
                    atual.Fim = tempo;
                    if (fila.Count != 0)
                    {
                        Processo menor = new Processo();
                        menor.TempoExecucao = 10000000;
                        foreach (Processo p in fila)
                        {
                            if (p.TempoExecucao < menor.TempoExecucao)
                                menor = p;
                        }
                        fila.Remove(menor);
                        atual = menor;
                        atual.Inicio = tempo;
                    }
                }

                if (fila.Count == 0 && atual.TempoExecucao == 0 && list.Count == 0)
                    break;


                Console.WriteLine("Processo = {0} t = {1}s", atual.Id, tempo);
            }

            Console.WriteLine("Processo = {0} t = {1}s", atual.Id, tempo);

            double tempoMedioExecucao = 0;
            double tempoMedioEspera = 0;
            foreach (Processo p in list_copy)
            {
                Console.WriteLine("Processo: " + p.Id + " Chegada: " + p.Chegada + " Fim: " + p.Fim);
                tempoMedioExecucao += p.Fim - p.Chegada;
                tempoMedioEspera += p.Inicio - p.Chegada;
            }

            Console.WriteLine("Tempo Médio de Execução: " + tempoMedioExecucao / list_copy.Count());
            Console.WriteLine("Tempo Médio de Espera: " + tempoMedioEspera / list_copy.Count());
        }

        public void RoundRobin(List<Processo> list)
        {
            Queue<Processo> fila = new Queue<Processo>();
            Processo atual = new Processo();
            Processo[] list_copy = new Processo[list.Count()];
            list.CopyTo(list_copy);
            int tempo = -1;
            int troca = 0;

            while (true)
            {
                tempo++;

                foreach (Processo p in list.ToList())
                    if (p.Chegada == tempo)
                    {
                        fila.Enqueue(p);
                        list.Remove(p);
                    }

                atual.TempoExecucao = atual.TempoExecucao - 1;

                if (atual.TempoExecucao <= 0 || tempo == troca)
                {
                    if (atual.TempoExecucao <= 0 && fila.Count != 0)
                    {
                        if (atual.Id != 0 && tempo != troca)
                            troca++;

                        atual.Fim = tempo;
                        atual = fila.Dequeue();
                        atual.Inicio = tempo;
                    }
                    else if (atual.TempoExecucao != 0 || fila.Count != 0)
                    {
                        fila.Enqueue(atual);
                        atual = fila.Dequeue();
                        atual.Inicio = tempo;
                    }
                    troca += 2;
                }


                if (fila.Count == 0 && atual.TempoExecucao == 0 && list.Count == 0)
                {
                    atual.Fim = tempo;
                    break;
                }


                Console.WriteLine("Processo = {0} t = {1}s", atual.Id, tempo);
            }

            Console.WriteLine("Processo = {0} t = {1}s", atual.Id, tempo);
            double tempoMedioExecucao = 0;
            double tempoMedioEspera = 0;
            foreach (Processo p in list_copy)
            {
                Console.WriteLine("Processo: " + p.Id + " Chegada: " + p.Chegada + " Fim: " + p.Fim);
                tempoMedioExecucao += p.Fim - p.Chegada;
                tempoMedioEspera += p.Fim - (p.Chegada + p.tempoServico);
            }

            Console.WriteLine("Tempo Médio de Execução: " + tempoMedioExecucao / list_copy.Count());
            Console.WriteLine("Tempo Médio de Espera: " + tempoMedioEspera / list_copy.Count());

        }

        public void SRTF(List<Processo> list)
        {
            List<Processo> fila = new List<Processo>();
            Processo atual = new Processo();
            Processo[] list_copy = new Processo[list.Count()];
            list.CopyTo(list_copy);
            int tempo = -1;
            atual.TempoExecucao = 10000;
            atual.Id = -1;

            while (true)
            {
                tempo++;

                foreach (Processo p in list.ToList())
                    if (p.Chegada == tempo)
                    {
                        fila.Add(p);
                        list.Remove(p);
                    }

                atual.TempoExecucao = atual.TempoExecucao - 1;

                if (atual.TempoExecucao == 0)
                {
                    atual.Fim = tempo;
                    if (fila.Count == 0 && list.Count == 0)
                        break;

                    atual.TempoExecucao = 100000;
                    foreach (Processo p in fila.ToList())
                    {
                        if (p.TempoExecucao < atual.TempoExecucao)
                            atual = p;
                    }

                    fila.Remove(atual);
                }
                else
                {
                    if (atual.Id != -1)
                        fila.Add(atual);

                    foreach (Processo p in fila.ToList())
                    {
                        if (p.TempoExecucao < atual.TempoExecucao)
                            atual = p;
                    }

                    fila.Remove(atual);
                }



                Console.WriteLine("Processo = {0} t = {1}s", atual.Id, tempo);
            }

            Console.WriteLine("Processo = {0} t = {1}s", atual.Id, tempo);

            double tempoMedioExecucao = 0;
            double tempoMedioEspera = 0;
            foreach (Processo p in list_copy)
            {
                Console.WriteLine("Processo: " + p.Id + " Chegada: " + p.Chegada + " Fim: " + p.Fim);
                tempoMedioExecucao += p.Fim - p.Chegada;
                tempoMedioEspera += p.Fim - p.Chegada - p.TempoServico;
            }

            Console.WriteLine("Tempo Médio de Execução: " + tempoMedioExecucao / list_copy.Count());
            Console.WriteLine("Tempo Médio de Espera: " + tempoMedioEspera / list_copy.Count());

        }

        public void PRIOc(List<Processo> list)
        {
            List<Processo> fila = new List<Processo>();
            Processo atual = new Processo();
            Processo[] list_copy = new Processo[list.Count()];
            list.CopyTo(list_copy);
            int tempo = -1;
            atual.Prioridade = 0;

            while (true)
            {
                tempo++;
                foreach (Processo p in list.ToList())
                    if (p.Chegada == tempo)
                    {
                        fila.Add(p);
                        list.Remove(p);
                    }

                atual.TempoExecucao = atual.TempoExecucao - 1;

                if (atual.TempoExecucao <= 0)
                {
                    atual.Fim = tempo;
                    if (fila.Count != 0)
                    {
                        Processo maior = new Processo();
                        maior.Prioridade = 0;
                        foreach (Processo p in fila)
                        {
                            if (p.Prioridade > maior.Prioridade)
                                maior = p;
                        }
                        fila.Remove(maior);
                        atual = maior;
                        atual.Inicio = tempo;
                    }
                }

                if (fila.Count == 0 && atual.TempoExecucao == 0 && list.Count == 0)
                    break;


                Console.WriteLine("Processo = {0} t = {1}s", atual.Id, tempo);
            }

            Console.WriteLine("Processo = {0} t = {1}s", atual.Id, tempo);

            double tempoMedioExecucao = 0;
            double tempoMedioEspera = 0;
            foreach (Processo p in list_copy)
            {
                Console.WriteLine("Processo: " + p.Id + " Chegada: " + p.Chegada + " Fim: " + p.Fim);
                tempoMedioExecucao += p.Fim - p.Chegada;
                tempoMedioEspera += p.Inicio - p.Chegada;
            }

            Console.WriteLine("Tempo Médio de Execução: " + tempoMedioExecucao / list_copy.Count());
            Console.WriteLine("Tempo Médio de Espera: " + tempoMedioEspera / list_copy.Count());
        }


        public void PRIOp(List<Processo> list)
        {
            List<Processo> fila = new List<Processo>();
            Processo atual = new Processo();
            Processo[] list_copy = new Processo[list.Count()];
            list.CopyTo(list_copy);
            int tempo = -1;
            atual.Prioridade = 0;
            atual.Id = -1;

            while (true)
            {
                tempo++;

                foreach (Processo p in list.ToList())
                    if (p.Chegada == tempo)
                    {
                        fila.Add(p);
                        list.Remove(p);
                    }

                atual.TempoExecucao = atual.TempoExecucao - 1;

                if (atual.TempoExecucao == 0)
                {
                    atual.Fim = tempo;
                    if (fila.Count == 0 && list.Count == 0)
                        break;

                    atual.Prioridade = 0;
                    foreach (Processo p in fila.ToList())
                    {
                        if (p.Prioridade > atual.Prioridade)
                            atual = p;
                    }

                    fila.Remove(atual);
                }
                else
                {
                    if (atual.Id != -1)
                        fila.Add(atual);

                    foreach (Processo p in fila.ToList())
                    {
                        if (p.Prioridade > atual.Prioridade)
                            atual = p;
                    }

                    fila.Remove(atual);
                }



                Console.WriteLine("Processo = {0} t = {1}s", atual.Id, tempo);
            }

            Console.WriteLine("Processo = {0} t = {1}s", atual.Id, tempo);

            double tempoMedioExecucao = 0;
            double tempoMedioEspera = 0;
            foreach (Processo p in list_copy)
            {
                Console.WriteLine("Processo: " + p.Id + " Chegada: " + p.Chegada + " Fim: " + p.Fim);
                tempoMedioExecucao += p.Fim - p.Chegada;
                tempoMedioEspera += p.Fim - p.Chegada - p.TempoServico;
            }

            Console.WriteLine("Tempo Médio de Execução: " + tempoMedioExecucao / list_copy.Count());
            Console.WriteLine("Tempo Médio de Espera: " + tempoMedioEspera / list_copy.Count());
        }

    }
}
