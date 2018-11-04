using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
  [Route("api/ToDoList")]
  [ApiController]
  public class ToDoListController : ControllerBase
  {
    private readonly ToDoContext _context;
    public ToDoListController(ToDoContext context)
    {
      _context = context;
    }

    /// <summary>
    /// returns all to do lists if id not specified
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<List<ToDoList>> GetAll()
    {
      var items = _context.ToDoLists.ToList();
      var toDoItems = _context.ToDoItems.Where(item => item.ListID == item.ListID).ToList();

      return items;
    }

    [HttpGet("{id}", Name = "GetTodoList")]
    public ActionResult<ToDoList> GetById(int id)
    {
      var item = _context.ToDoLists.Find(id);
      var toDoItems = _context.ToDoItems.Where(items => items.ListID == item.ListID).ToList();
      if (item == null)
      {
        return NotFound();
      }
      return item;
    }
    /// <summary>
    /// create list object
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Create(ToDoList List)
    {
      _context.ToDoLists.Add(List);
      _context.SaveChanges();

      return CreatedAtRoute("GetTodoList", new { id = List.ListID }, List);
    }
    /// <summary>
    /// updates list names only
    /// </summary>
    /// <param name="id">primary key of list</param>
    /// <param name="List"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Update(int id, ToDoList List)
    {
      var todo = _context.ToDoLists.Find(id);
      if (todo == null)
      {
        return NotFound();
      }

      todo.ListName = List.ListName;

      _context.ToDoLists.Update(todo);
      _context.SaveChanges();
      return NoContent();
    }
    /// <summary>
    /// delete list at specified
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var todo = _context.ToDoLists.Find(id);
      if (todo == null)
      {
        return NotFound();
      }
      DeleteItems(id);
      _context.ToDoLists.Remove(todo);
      _context.SaveChanges();
      return NoContent();
    }

    public IActionResult DeleteItems(int id)
    {
      var items = _context.ToDoItems.Where(ide => ide.ListID == id).ToList();

      foreach (var item in items)
      {
        _context.ToDoItems.Remove(item);
        _context.SaveChanges();
      }
      return NoContent();
    }
  }
}
