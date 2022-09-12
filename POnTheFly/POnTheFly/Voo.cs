﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_POG_OnTheFly
{
    internal class Voo
    {
        public string IDVoo { get; set; }
        public string Destino { get; set; }
        public string IDAeronave { get; set; }
        public DateTime DataVoo { get; set; }
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }
        public Voo(string idVoo, string destino, string idAeronave, DateTime dataVoo)
        {
            this.IDVoo = idVoo;
            this.Destino = destino;
            this.IDAeronave = idAeronave;
            this.DataVoo = dataVoo;
            this.DataCadastro = System.DateTime.Now;
            this.Situacao = 'A'; //Ativo,Cancelado
        }
        public override string ToString()
        {
            return "\nDADOS VOO: \nID Voo: " + IDVoo + "\nDestino: " + Destino + "\nID Aeronave: " + IDAeronave + "\nData Voo: " + DataVoo + "\nData Cadastro: " + DataCadastro + "\nSituação: " + Situacao;
        }
        public string ObterDados()
        {
            return this.IDVoo + Destino + IDAeronave + DataVoo + DataCadastro + Situacao;
        }
    }
}