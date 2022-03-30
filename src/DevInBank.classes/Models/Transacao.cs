using DevInBank.classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.classes.Models
{
    public class Transacao
    {
        public string TransacaoID { get; set; }
        public Conta ContaOrigem { get; set; }
        public Conta ContaDestino { get; set; }
        public decimal valor { get; set; }
        public DateTime Data { get; set; }
    }
}
