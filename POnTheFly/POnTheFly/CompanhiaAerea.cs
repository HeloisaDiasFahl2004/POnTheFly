using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_POG_OnTheFly
{
    internal class CompanhiaAerea
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime UltimoVoo { get; set; }
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }

        public CompanhiaAerea(string cnpj, string razaoSocial, DateTime DataAbertura)
        {
            this.Cnpj = cnpj;
            this.RazaoSocial = razaoSocial;
            this.DataAbertura = DataAbertura;
            this.UltimoVoo = System.DateTime.Now;
            this.DataCadastro = System.DateTime.Now;
            this.Situacao = 'A'; //Ativo,Inativo
        }
        public override string ToString()
        {
            return "\nDADOS COMPANHIA AÉREA: \nRazão Social: " + RazaoSocial + "\nCNPJ: " + Cnpj + "\nData Abertura: " + DataAbertura + "\nData Cadastro: " + DataCadastro + "\nÚltimo Voo: " + UltimoVoo + "\nSituação: " + Situacao;
        }
        public string ObterDados()
        {
            return Cnpj + RazaoSocial + DataAbertura + UltimoVoo + DataCadastro + Situacao;
        }

    }
}
