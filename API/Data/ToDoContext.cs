using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class ToDoContext : DbContext
  {
    public ToDoContext(DbContextOptions<ToDoContext> options)
      : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ToDoList>().HasData(new ToDoList {ListID = 1, ListName ="Dummy"});
    }

    public DbSet<ToDoItem> ToDoItems { set; get; }
    public DbSet<ToDoList> ToDoLists { get; set; }
  }
}
