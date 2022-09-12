using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_POG_OnTheFly
{
    internal class ItemVenda
    {
        public string IDItemVenda { get; set; }
        public string IDPassagem { get; set; }
        public float ValorUnitario { get; set; }

        public ItemVenda(string idItemVenda, string idPassagem, float valorUnitario)
        {
            this.IDItemVenda = idItemVenda;
            this.IDPassagem = idPassagem;
            this.ValorUnitario = valorUnitario;
        }
        public override string ToString()
        {
            return "\nDADOS ITEM VENDA: \nID Item Venda: " + IDItemVenda + "\nID Passagem: " + IDPassagem + "\nValor Unitário: " + ValorUnitario;
        }
        public string ObterDados()
        {
            return IDItemVenda + IDPassagem + ValorUnitario;
        }
    }
}
