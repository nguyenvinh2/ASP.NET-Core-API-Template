using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
  public class ToDoList
  {
    [Key]
    public int ListID { get; set; }
    public string ListName { get; set; }
    public List<ToDoItem> ToDoItems { get; set; }

  }
}
