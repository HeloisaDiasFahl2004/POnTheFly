using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_POG_OnTheFly
{
    internal class Venda
    {
        public string IDVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public string Passageiro { get; set; }// CPF do passageiro
        public float ValorTotal { get; set; }
        public Venda(string idVenda, DateTime dataVenda, string passageiro, float valorTotal)
        {
            this.IDVenda = idVenda;
            this.DataVenda = dataVenda;
            this.Passageiro = passageiro;
            this.ValorTotal = valorTotal;
        }
        public override string ToString()
        {
            return "\nDADOS VENDA: \nID Venda: " + IDVenda + "\nData Venda: " + DataVenda + "\nPassageiro: " + Passageiro + "\nValor Total: " + ValorTotal;
        }
        public string ObterDados()
        {
            return IDVenda + DataVenda + Passageiro + ValorTotal;
        }

    }
}
