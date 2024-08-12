using System;
using System.Collections.Generic;
using TransacaoFinanceira.DataAccess;
using TransacaoFinanceira.Model;


//Obs: Voce é livre para implementar na linguagem de sua preferência, desde que respeite as funcionalidades e saídas existentes, além de aplicar os conceitos solicitados.

namespace TransacaoFinanceira
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<TransacaoModel> transacoes = new List<TransacaoModel>() {
                                     new TransacaoModel (1, Convert.ToDateTime("09/09/2023 14:15:00"), "938485762", "2147483649", 150),
                                     new TransacaoModel (2, Convert.ToDateTime("09/09/2023 14:15:05"), "2147483649", "210385733", 149),
                                     new TransacaoModel (3, Convert.ToDateTime("09/09/2023 14:15:29"), "347586970", "238596054", 1100),
                                     new TransacaoModel (4, Convert.ToDateTime("09/09/2023 14:17:00"), "675869708", "210385733", 5300),
                                     new TransacaoModel (5, Convert.ToDateTime("09/09/2023 14:18:00"), "238596054", "674038564", 1489),
                                     new TransacaoModel (6, Convert.ToDateTime("09/09/2023 14:18:20"), "573659065", "563856300", 49),
                                     new TransacaoModel (7, Convert.ToDateTime("09/09/2023 14:19:00"), "938485762", "2147483649", 44),
                                     new TransacaoModel (8, Convert.ToDateTime("09/09/2023 14:19:01"), "573659065", "675869708", 150)
            };
                Business.ITransacaoFinanceira executor = new Business.TransacaoFinanceira(new AcessoDadosDB());
                transacoes.ForEach((item) =>
                {
                    executor.transferir(item.correlationId, item.contaOrigem, item.contaDestino, item.vlrTransacao);
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
