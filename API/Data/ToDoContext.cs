using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class ToDoContext: DbContext
  {
    public ToDoContext(DbContextOptions<ToDoContext> options)
      : base(options)
    {
    }

    public DbSet<ToDoItem> ToDoItems { set; get; }
  }
}
