using EvenMoreAmazingTaskList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EvenMoreAmazingTaskList.Infrastructure
{
    // EvenMoreAmazingTaskListDbContext vai herdar a classe DbContext
    public class EvenMoreAmazingTaskListDbContext : DbContext
    {
        // TaskList é uma entidade do dominio e precisa de referencia ao Domain - using EvenMoreAmazingTaskList.Domain.Entities;
        // TaskItens
        public DbSet<TaskItem> TaskItems { get; set; }

        // Conceito "code first" cria o código e depois o banco é criado automaticamente
        public EvenMoreAmazingTaskListDbContext()
        {
            Database.EnsureCreated();
        }

        // shortcut "override onconf" é preciso sobrescrever um metodo que existe na classe pai DbContext
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // é aqui que escrevemos nossa string de conexão
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EvenMoreAmazingTaskListDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
