using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_POG_OnTheFly
{
    internal class Passageiro
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public char Sexo { get; set; }
        public DateTime DataUltimaCompra { get; set; }
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }

        public Passageiro(string cpf, string nome, DateTime dataNascimento, char sexo)
        {
            this.Cpf = cpf;
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.DataUltimaCompra = System.DateTime.Now;//Data do sistema
            this.DataCadastro = System.DateTime.Now;
            this.Situacao = 'A'; // Ativo,Inativo
        }
        public override string ToString() // Console
        {
            return "\nDADOS PASSAGEIRO: \nNome: " + Nome + "\nCPF: " + Cpf + "\nData Nascimento: " + DataNascimento + "\nSexo: " + Sexo + "\nData Cadastro: " + DataCadastro + "\nData Última Compra: " + DataUltimaCompra + "\nSituação: " + Situacao;
        }
        public string ObterDados() // Arquivo Texto
        {
            return Cpf + Nome + DataNascimento + Sexo + DataUltimaCompra + DataCadastro + Situacao;
        }
    }
}
