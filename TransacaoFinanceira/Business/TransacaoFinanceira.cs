using System;
using TransacaoFinanceira.DataAccess;
using TransacaoFinanceira.Model;

namespace TransacaoFinanceira.Business
{
    public class TransacaoFinanceira : ITransacaoFinanceira
    {
        private readonly IAcessoDadosDB _acessoDadosDB;

        public TransacaoFinanceira(IAcessoDadosDB acessoDadosDB)
        {
            _acessoDadosDB = acessoDadosDB;
        }

        public void transferir(int correlationId, string contaOrigem, string contaDestino, decimal vlrTransacao)
        {
            ContasSaldoModel contaSaldoOrigem = _acessoDadosDB.getConta(contaOrigem);
            if (contaSaldoOrigem.saldo < vlrTransacao)
            {
                Console.WriteLine("Transacao numero {0 } foi cancelada por falta de saldo", correlationId);
            }
            else
            {
                ContasSaldoModel contaSaldoDestino = _acessoDadosDB.getConta(contaDestino);
                contaSaldoOrigem.saldo -= vlrTransacao;
                contaSaldoDestino.saldo += vlrTransacao;
                Console.WriteLine("Transacao numero {0} foi efetivada com sucesso! Novos saldos: Conta Origem:{1} | Conta Destino: {2}", correlationId, contaSaldoOrigem.saldo, contaSaldoDestino.saldo);
            }
        }
    }
}
