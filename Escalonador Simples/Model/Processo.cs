using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escalonador_Simples.Model
{
    internal class Processo
    {
        public int tempoServico;
        private int _chegada;
        private int _tempoServico;
        private int _tempoExecucao;
        private int _prioridade;
        private int _fim;
        private int _inicio;
        private int chegada;
        private int tempoExecucao;
        private int prioridade;
        private int fim;
        private int inicio;
        private int id;

        internal Processo(int c, int tE, int pr, int i)
        {
            _chegada = c;
            _tempoServico = tE;
            _tempoExecucao = tE;
            _prioridade = pr;
            _fim = 0;
            _inicio = 0;
            id = i;
            Reset();
        }

        internal Processo()
        {

        }


        public int Id { get => id; set => id = value; }
        public int Chegada { get => chegada; set => chegada = value; }
        public int TempoServico {  get => tempoServico;
            set {
                tempoExecucao = value;
                tempoServico = value;
            }
        }
        public int TempoExecucao { get => tempoExecucao; set => tempoExecucao = value; }
        public int Prioridade { get => prioridade; set => prioridade = value; }
        public int Inicio { get => inicio; set => inicio = value; }
        public int Fim { get => fim; set => fim = value; }

        public void Reset()
        {
            chegada = _chegada;
            tempoServico = _tempoServico;
            tempoExecucao = _tempoExecucao;
            prioridade = _prioridade;
            inicio = _inicio;
            fim = _fim;
        }
    }
}
