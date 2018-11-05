using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using API.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace UnitTestAPI
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void GetAllToDoItems()
    {
      var testProducts = GetAll();
      var controller = new ToDoController(testProducts);

      var result = controller.GetAll() as List<ToDoItem>;
      Assert.AreEqual(testProducts.Count, result.Count);
    }

  }
}
