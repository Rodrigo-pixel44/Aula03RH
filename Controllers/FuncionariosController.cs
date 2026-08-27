using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula03RH.Models;
using Aula03RH.Models.Enuns;
using Microsoft.AspNetCore.Mvc;

namespace Aula03RH.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionariosController : ControllerBase
    {
        //Codificação da contoller ficará aqui
        private static List<Funcionario> lista = new List<Funcionario>()
        {
            //Modo de criação e inclusão de objetos de uma só vez
            new Funcionario() { Id = 1, Nome = "Neymar", Cpf = "12345678910", DataAdmissao = DateTime.Parse("01/01/2000"), Salario = 100.000M, TipoFuncionario = TipoFuncionarioEnum.CLT },
            new Funcionario() { Id = 2, Nome = "Cristiano Ronaldo", Cpf = "01987654321", DataAdmissao = DateTime.Parse("30/06/2002"), Salario = 150.000M, TipoFuncionario = TipoFuncionarioEnum.CLT },
            new Funcionario() { Id = 3, Nome = "Messi", Cpf = "135792468", DataAdmissao = DateTime.Parse("01/11/2003"), Salario = 70.000M, TipoFuncionario = TipoFuncionarioEnum.Aprendiz },
            new Funcionario() { Id = 4, Nome = "Mbappe", Cpf = "246813579", DataAdmissao = DateTime.Parse("15/09/2005"), Salario = 80.000M, TipoFuncionario = TipoFuncionarioEnum.Aprendiz },
            new Funcionario() { Id = 5, Nome = "Lewa", Cpf = "246813579", DataAdmissao = DateTime.Parse("20/10/1998"), Salario = 90.000M, TipoFuncionario = TipoFuncionarioEnum.Aprendiz },
            new Funcionario() { Id = 6, Nome = "Rodrigo Garro", Cpf = "246813579", DataAdmissao = DateTime.Parse("13/12/1997"), Salario = 300.000M, TipoFuncionario = TipoFuncionarioEnum.CLT }
        };

        //Próximos códigos aqui
        [HttpGet("GetFirst")]        
        public IActionResult GetFirst()
        {
            Funcionario f = lista[0];
            return Ok(f);
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(lista);
        }


    

        [HttpPost]
        public IActionResult AddFuncionario(Funcionario novoFuncionario)
        {

                if(string.IsNullOrEmpty(novoFuncionario.Nome))
                    return BadRequest("O nome do funcionário de ser digitado");


            lista.Add(novoFuncionario);
            return Ok(lista);
        }

        [HttpGet("Ordenar")]

        public IActionResult Ordenar()
        {
            lista = lista.OrderBy(x => x.Nome).ToList();
            return Ok(lista);
        }

        [HttpGet("Quantidade")]

        public IActionResult ContarFuncionarios()
        {
           int qtd = lista.Count();

           return Ok(qtd);
        }
        
   
        [HttpGet("SomarSalarios")]

        public IActionResult SomarSalarios()
        {
            decimal somatorio = lista.Sum(x => x.Salario);
            return Ok(somatorio);
        }
   
        [HttpGet("GetAprendizes")]

        public IActionResult GetAprendizes()
        {
            List<Funcionario> aprendizes = lista.FindAll(x => x.TipoFuncionario == TipoFuncionarioEnum.Aprendiz);
            return Ok(aprendizes);
        }

        [HttpGet ("GetPorNomeAproximado/{nome}")]

        public IActionResult GetPorNomeAProximado(string nome)
        {
            List<Funcionario> resultado = lista.FindAll(x => x.Nome.ToLower().Contains(nome.ToLower()));
            return Ok(resultado);
        }
   
        [HttpDelete("DeletePorCpf/{cpf}")]

        public IActionResult DeletePorCpf(string cpf)
        {
            Funcionario fBusca = lista.Find(x => x.Cpf == cpf);

            if (fBusca == null)
                return NotFound("Funcionário não encontrado.");

            lista.Remove(fBusca);
            return Ok(lista);
        }
   
        [HttpDelete("DeletePorIdMenorQue/{id}")]

        public IActionResult DeletePorIdMenorQue(int id)
        {
            int quantidadeRemovida = lista.RemoveAll(x => x.Id < id);
            if (quantidadeRemovida == 0)
                return NotFound("Nenhum registro atendeu ao critério de remoção.");

                return Ok(lista);
        }
   


   
   
   
   
   
    }
}

