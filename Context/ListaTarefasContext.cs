using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoTarefasApi.Models;

namespace ProjetoTarefasApi.Context
{
    public class ListaTarefasContext : DbContext
    {
        public ListaTarefasContext(DbContextOptions<ListaTarefasContext> options) : base(options){

        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}