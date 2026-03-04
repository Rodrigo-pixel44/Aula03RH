using System;
using aula03RH.Models;

namespace aula03RH
{
    public class Program
    {
        static void Main(string[] args)
        {
            Funcionario func = new Funcionario();
            
            func.Id = 10;
            func.Nome = "Neymar";
            func.Cpf = "12345678910"; 
            func.DataAdmissao = DateTime.Parse("01/01/2010");
            func.Salario = 1000.00M;
            func.Tipofuncionario = Models.Enuns.TipofuncionarioEnum.CLT;

            string mensagem = func.ExibirPeriodoExperiencia();
            Console.WriteLine(mensagem);
        }
    }
}