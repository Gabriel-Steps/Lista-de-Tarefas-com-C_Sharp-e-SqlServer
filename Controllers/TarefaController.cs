using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoTarefasApi.Context;
using ProjetoTarefasApi.Models;

namespace ProjetoTarefasApi.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ListaTarefasContext _context;

        public TarefaController(ListaTarefasContext context){
            _context = context;
        }
        [HttpPost]
        public IActionResult Create(Tarefa tarefa){
            _context.Add(tarefa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new {id = tarefa.Id}, tarefa);
        }
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id){
            var tarefa = _context.Tarefas.Find(id);
            if(tarefa == null){
                return NotFound();
            }
            return Ok(tarefa);
        }
        [HttpGet("ObterTodos")]
        public IActionResult ObterTodos(){
            var tarefas = _context.Tarefas;
            return Ok(tarefas);
        }
        [HttpGet("ObterPorTitulo")]
        public IActionResult ObterPorTitulo(string titulo){
            var tarefa = _context.Tarefas.Where(x => x.Titulo.Contains(titulo));
            if(tarefa == null){
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpGet("ObterPorData")]
        public IActionResult ObterPorData(DateTime data){
            var tarefa = _context.Tarefas.Where(x => x.Data.Equals(data));
            if(tarefa == null){
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult ObterPorStatus(string status){
            var tarefa = _context.Tarefas.Where(x => x.Status.Equals(status));
            if(tarefa == null){
                return NotFound();
            }
            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Tarefa tarefa){
            var tarefaBanco = _context.Tarefas.Find(id);
            if(tarefaBanco == null){
                return NotFound();
            }
            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;
            _context.Tarefas.Update(tarefaBanco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new {id = tarefa.Id}, tarefa);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id){
            var contatoBanco = _context.Tarefas.Find(id);
            if(contatoBanco == null){
                return NotFound();
            }
            _context.Tarefas.Remove(contatoBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}