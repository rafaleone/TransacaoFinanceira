using System.Collections.Generic;
using TransacaoFinanceira.Model;

namespace TransacaoFinanceira.DataAccess
{
    public interface IAcessoDadosDB
    {
        ContasSaldoModel getConta(string id);
    }
}
