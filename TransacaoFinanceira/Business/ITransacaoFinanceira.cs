using System;
using System.Collections.Generic;
using System.Text;

namespace TransacaoFinanceira.Business
{
    public interface ITransacaoFinanceira
    {
        void transferir(int correlationId, string contaOrigem, string contaDestino, decimal vlrTransacao);
    }
}
