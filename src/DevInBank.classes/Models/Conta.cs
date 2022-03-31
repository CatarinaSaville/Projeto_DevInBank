using DevInBank.classes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInBank.classes.Models
{
    public class Conta
    {
        public string ContaID { get; set; }
        public string NomeTitular { get; set; } 
        public long CPF { get; set; } //validar
        public string Endereco { get; set; }
        public decimal RendaMensal { get; set; }
        public Agencias Agencia { get; set; }
        public decimal Saldo { get; set; }
        public Contas Tipo { get; set; }

        //Atributos de Contas Correntes
        public decimal? ChequeEspecial { get; set; }       
    }
}
