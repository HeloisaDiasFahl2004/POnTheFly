﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_POG_OnTheFly
{
    internal class Aeronave
    {
        public string Inscricao { get; set; }
        public int Capacidade { get; set; }
        public int AssentosOcupados { get; set; }
        public DateTime UltimaVenda { get; set; }
        public DateTime DataCadastro { get; set; }
        public char Situacao { get; set; }

        public Aeronave(string inscricao, int capacidade, int assentosOcupados,DateTime UltimaVenda,DateTime Cadastro, char situacao)
        {
            this.Inscricao = inscricao;
            this.Capacidade = capacidade;
            this.AssentosOcupados = assentosOcupados;
            this.UltimaVenda = System.DateTime.Now;
            this.DataCadastro = System.DateTime.Now;
            this.Situacao = situacao;
        }
        public override string ToString()
        {
            return "\nDADOS AERONAVE: \nInscrição: " + Inscricao + "\nCapacidade: " + Capacidade + "\nAssentos Ocupados: " + AssentosOcupados + "\nData Cadastro: " + DataCadastro.ToString("dd/MM/yyyyHH:mm") + "\nÚltima Venda: " + UltimaVenda.ToString("dd/MM/yyyyHH:mm") + "\nSituação: " + Situacao;
        }
        public string ObterDados()
        {
            return Inscricao + Capacidade + AssentosOcupados + UltimaVenda.ToString("ddMMyyyyHHmm") + DataCadastro.ToString("ddMMyyyyHHmm") + Situacao;
        }
    }
}
