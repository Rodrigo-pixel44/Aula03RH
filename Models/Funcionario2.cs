using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula03RH.Models.Enuns;

namespace Aula03RH.Models
{
    public class Funcionario2
    {
        //Prop + TAB--> Cria propriedades
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Cpf { get; set; } = "";
        public DateTime DataAdmissao { get; set; }
        public decimal Salario { get; set; }
        public TipoFuncionarioEnum MyProperty { get; set; }
    }
}