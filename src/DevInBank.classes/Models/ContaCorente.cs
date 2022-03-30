using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.classes.Models
{
    internal class ContaCorente: Conta
    {
        public decimal checkEspecial { get; set; }
        
        public ContaCorente(string contaId, string nomeTitular, decimal rendaMensal, string cPF, string endereco, string agencia)
        {
            checkEspecial = calculaValorCheckEspecial(rendaMensal);
        }

        public decimal calculaValorCheckEspecial(decimal valor)
        {
            return 0.1m * valor;
        }
    }
}
