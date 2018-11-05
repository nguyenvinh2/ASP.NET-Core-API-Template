using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using API.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
  [Route("api/todo")]
  [ApiController]
  public class ToDoController : ControllerBase
  {
    private readonly ToDoContext _context;
    public ToDoController(ToDoContext context)
    {
      _context = context;
    }

    /// <summary>
    /// get everything
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<List<ToDoItem>> GetAll()
    {
       return _context.ToDoItems.ToList();
    }
    /// <summary>
    /// get item by id number
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}", Name = "GetTodo")]
    public ActionResult<ToDoItem> GetById(int id)
    {
      var item = _context.ToDoItems.Find(id);
      if (item == null)
      {
        return NotFound();
      }
      return item;
    }

    [HttpPost]
    public IActionResult Create(ToDoItem item)
    {
      _context.ToDoItems.Add(item);
      _context.SaveChanges();

      return CreatedAtRoute("GetTodo", new { id = item.ID }, item);
    }
    /// <summary>
    /// updates the specified item
    /// </summary>
    /// <param name="id"></param>
    /// <param name="Item"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Update(int id, ToDoItem Item)
    {
      var todo = _context.ToDoItems.Find(id);
      if (todo == null)
      {
        return NotFound();
      }

      todo.Name = Item.Name;
      todo.Status = Item.Status;
      todo.ListID = Item.ListID;

      _context.ToDoItems.Update(todo);
      _context.SaveChanges();
      return NoContent();
    }
    /// <summary>
    /// delete item at specified
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var todo = _context.ToDoItems.Find(id);
      if (todo == null)
      {
        return NotFound();
      }

      _context.ToDoItems.Remove(todo);
      _context.SaveChanges();
      return NoContent();
    }
  }
}
