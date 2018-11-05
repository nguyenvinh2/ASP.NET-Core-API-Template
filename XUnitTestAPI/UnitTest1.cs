using System;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using API;
using API.Controllers;
using API.Models;
using API.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace XUnitTestAPI
{
  public class UnitTest1
  {
    /// <summary>
    /// read of todo item
    /// </summary>
    [Fact]
    public void GetToDoItemByID()
    {
      DbContextOptions<ToDoContext> options =
          new DbContextOptionsBuilder<ToDoContext>().UseInMemoryDatabase("GetAllItems")
          .Options;


      using (ToDoContext context = new ToDoContext(options))
      {
        //Arrange
        var item = new ToDoItem();
        item.ID = 1;
        item.Name = "Dummy Item";
        item.Status = true;
        item.ListID = 1;
        context.ToDoItems.Add(item);
        context.SaveChanges();

        var controller = new ToDoController(context).GetById(1);

        Assert.Equal(item, controller.Value);
      }
    }
    /// <summary>
    /// tests the read part of todolist
    /// </summary>
    [Fact]
    public void ReadToDoListsById()
    {
      DbContextOptions<ToDoContext> options =
          new DbContextOptionsBuilder<ToDoContext>().UseInMemoryDatabase("GetLists")
          .Options;


      using (ToDoContext context = new ToDoContext(options))
      {
        //Arrange
        var item = new ToDoList();
        item.ListID = 1;
        item.ListName = "Dummy List";
        context.ToDoLists.Add(item);
        context.SaveChanges();

        var controller = new ToDoListController(context).GetById(1);

        Assert.Equal(item, controller.Value);
      }
    }
    /// <summary>
    /// tests create item
    /// </summary>
    [Fact]
    public void CreateToDoItem()
    {
      DbContextOptions<ToDoContext> options =
          new DbContextOptionsBuilder<ToDoContext>().UseInMemoryDatabase("CreateToDoItem")
          .Options;


      using (ToDoContext context = new ToDoContext(options))
      {
        var item = new ToDoItem();
        item.ID = 1;
        item.Name = "Dummy Item";
        item.Status = true;
        item.ListID = 1;

        var controllerCreate = new ToDoController(context);
        controllerCreate.Create(item);
        var getItem = controllerCreate.GetById(1);

        Assert.Equal(item, getItem.Value);
      }
    }

    /// <summary>
    /// tests for updating item specifically if the name is updated
    /// </summary>
    [Fact]
    public void UpdateToDoItem()
    {
      DbContextOptions<ToDoContext> options =
          new DbContextOptionsBuilder<ToDoContext>().UseInMemoryDatabase("UpdateToDoItem")
          .Options;


      using (ToDoContext context = new ToDoContext(options))
      {
        var item = new ToDoItem();
        item.ID = 1;
        item.Name = "Dummy Item";
        item.Status = true;
        item.ListID = 1;

        var controllerCreate = new ToDoController(context);
        controllerCreate.Create(item);
        var getItem = controllerCreate.GetById(1);

        var updatedItem = new ToDoItem();
        updatedItem.ID = 1;
        updatedItem.Name = "Dummy Item updates";
        updatedItem.Status = false;
        updatedItem.ListID = 2;

        controllerCreate.Update(1, updatedItem); 

        Assert.Equal(updatedItem.Name, getItem.Value.Name);
      }
    }
    /// <summary>
    /// tests for deleting item, should return to content after delete and trying
    /// to find the item by id
    /// </summary>
    [Fact]
    public void DeleteToDoItem()
    {
      DbContextOptions<ToDoContext> options =
          new DbContextOptionsBuilder<ToDoContext>().UseInMemoryDatabase("DeleteToDoItem")
          .Options;


      using (ToDoContext context = new ToDoContext(options))
      {
        var item = new ToDoItem();
        item.ID = 1;
        item.Name = "Dummy Item";
        item.Status = true;
        item.ListID = 1;

        var controllerCreate = new ToDoController(context);
        controllerCreate.Create(item);
        var getItem = controllerCreate.GetById(1);

        var deleteItem = controllerCreate.Delete(1);

        Assert.Equal("Microsoft.AspNetCore.Mvc.NoContentResult", deleteItem.ToString());
      }
    }

    /// <summary>
    /// tests create list
    /// </summary>
    [Fact]
    public void CreateToDoList()
    {
      DbContextOptions<ToDoContext> options =
          new DbContextOptionsBuilder<ToDoContext>().UseInMemoryDatabase("CreateToDoList")
          .Options;


      using (ToDoContext context = new ToDoContext(options))
      {
        var list = new ToDoList();
        list.ListID = 1;
        list.ListName = "Dummy List";

        var controllerCreate = new ToDoListController(context);
        controllerCreate.Create(list);
        var getList = controllerCreate.GetById(1);

        Assert.Equal(list, getList.Value);
      }
    }
    /// <summary>
    /// tests for updating a list
    /// </summary>
    [Fact]
    public void UpdateToDoList()
    {
      DbContextOptions<ToDoContext> options =
          new DbContextOptionsBuilder<ToDoContext>().UseInMemoryDatabase("UpdateToDoList")
          .Options;


      using (ToDoContext context = new ToDoContext(options))
      {
        var list = new ToDoList();
        list.ListID = 1;
        list.ListName = "Dummy List";

        var controllerCreate = new ToDoListController(context);
        controllerCreate.Create(list);
        var getList = controllerCreate.GetById(1);


        var updatedList = new ToDoList();
        updatedList.ListID = 1;
        updatedList.ListName = "Dummy List updates";

        controllerCreate.Update(1, updatedList);

        Assert.Equal(updatedList.ListName, getList.Value.ListName);
      }
    }

    /// <summary>
    /// tests for deleting list, should return to content after delete and trying
    /// to find the list by id
    /// </summary>
    [Fact]
    public void DeleteToDoList()
    {
      DbContextOptions<ToDoContext> options =
          new DbContextOptionsBuilder<ToDoContext>().UseInMemoryDatabase("DeleteToDoList")
          .Options;


      using (ToDoContext context = new ToDoContext(options))
      {
        var item = new ToDoList();
        item.ListID = 1;
        item.ListName = "Dummy List";

        var controllerCreate = new ToDoListController(context);
        controllerCreate.Create(item);
        var getItem = controllerCreate.GetById(1);

        var deleteItem = controllerCreate.Delete(1);

        Assert.Equal("Microsoft.AspNetCore.Mvc.NoContentResult", deleteItem.ToString());
      }
    }
  }
}