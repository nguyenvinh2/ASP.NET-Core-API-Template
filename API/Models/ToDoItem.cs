using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
  public class ToDoItem
  {
    [Key]
    public int ID { get; set; }
    public string Name { get; set; }
    public bool Status { get; set; }
    public int ListID { get; set; }
  }
}
