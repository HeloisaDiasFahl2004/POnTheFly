using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_POG_OnTheFly
{
    internal class PassagemVoo
    {
        public string IDPassagem { get; set; }
        public string IDVoo { get; set; }
        public DateTime DataUltimaOperacao { get; set; }
        public float Valor { get; set; }
        public char Situacao { get; set; }
        public PassagemVoo(string idPassagem, string idVoo, DateTime dataUltimaOperacao, float valor)
        {
            this.IDPassagem = idPassagem;
            this.IDVoo = idVoo;
            this.DataUltimaOperacao = dataUltimaOperacao;
            this.Valor = valor;
            this.Situacao = 'L'; // Livre,Reservada,Paga
        }
        public override string ToString()
        {
            return "\nDADOS PASSAGEM: \nID Passagem: " + IDPassagem + "\nID VOO: " + IDVoo + "\nData Última Operação: " + DataUltimaOperacao + "\nValor: " + Valor + "\nSituação: " + Situacao;
        }
        public string ObterDados()
        {
            return IDPassagem + IDVoo + DataUltimaOperacao + Valor + Situacao;
        }
    }
}
