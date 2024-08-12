using System;
using System.Collections.Generic;
using System.Text;

namespace TransacaoFinanceira.Model
{
    public class TransacaoModel
    {
        public TransacaoModel(int correlationId, DateTime dtTransacao, string contaOrigem, string contaDestino, decimal vlrTransacao)
        {
            this.correlationId = correlationId;
            this.dtTransacao = dtTransacao;
            this.contaOrigem = contaOrigem;
            this.contaDestino = contaDestino;
            this.vlrTransacao = vlrTransacao;
        }
        public int correlationId { get; set; }
        public DateTime dtTransacao { get; set; }
        public string contaOrigem { get; set; }
        public string contaDestino { get; set; }
        public decimal vlrTransacao { get; set; }
    }
}
