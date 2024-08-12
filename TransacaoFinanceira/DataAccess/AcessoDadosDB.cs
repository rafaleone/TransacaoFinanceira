using System.Collections.Generic;
using TransacaoFinanceira.Model;

namespace TransacaoFinanceira.DataAccess
{
    public class AcessoDadosDB: IAcessoDadosDB
    {
        private List<ContasSaldoModel> tbSaldos;
        public AcessoDadosDB()
        {
            tbSaldos = new List<ContasSaldoModel>();
            tbSaldos.Add(new ContasSaldoModel("938485762", 180));
            tbSaldos.Add(new ContasSaldoModel("347586970", 1200));
            tbSaldos.Add(new ContasSaldoModel("2147483649", 0));
            tbSaldos.Add(new ContasSaldoModel("675869708", 4900));
            tbSaldos.Add(new ContasSaldoModel("238596054", 478));
            tbSaldos.Add(new ContasSaldoModel("573659065", 787));
            tbSaldos.Add(new ContasSaldoModel("210385733", 10));
            tbSaldos.Add(new ContasSaldoModel("674038564", 400));
            tbSaldos.Add(new ContasSaldoModel("563856300", 1200));
        }

        public ContasSaldoModel getConta(string id)
        {
            return tbSaldos.Find(x => x.conta == id);
        }
    }
}
