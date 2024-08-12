using System;
using System.Collections.Generic;
using System.Text;

namespace TransacaoFinanceira.Model
{
    public class ContasSaldoModel
    {
        public ContasSaldoModel(string conta, decimal valor)
        {
            this.conta = conta;
            this.saldo = valor;
        }
        public string conta { get; set; }
        public decimal saldo { get; set; }
    }
}
