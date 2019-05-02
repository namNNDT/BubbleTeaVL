﻿using System;
using System.Linq;
using WebApplication2.Controllers;
using WebApplication2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using System.Collections.Generic;

namespace WebApplication2.Tests.Controllers
{
    [TestClass]
    public class TestControllerVLTea
    {
        [TestMethod]
        public void TestIndex()
        {
            var db = new CS4PEEntities();
            var controller = new VLTeaController();

            var result = controller.Index(); 
             var view = result   as ViewResult;

            Assert.IsNotNull(view);
            var model = view.Model as List<BubleTea>;
            Assert.IsNotNull(model);
            Assert.AreEqual(db.BubleTeas.Count(), model.Count);
        }
      [TestMethod]
        public void TestCreate()
        {
            var controller = new VLTeaController();
            var result = controller.Create();
            var view = result as ViewResult;
            Assert.IsNotNull(view);
        }
         [TestMethod]
      public void TestCreateP()
      {
          var db = new CS4PEEntities();
          var model = new BubleTea
          {
              Name = "Trà Sữa VL",
              Price = 25000,
              Topping = "Tran chau trang"
          };
          var controller = new VLTeaController();
          var result = controller.Create(model);
          var redirect = result as RedirectToRouteResult;
          Assert.IsNotNull(redirect);
          Assert.AreEqual("Index", redirect.RouteValues["action"]);
          var item = db.BubleTeas.Find(model.id);
          Assert.IsNotNull(item);
          Assert.AreEqual(model.Name, item.Name);
          Assert.AreEqual(model.Price, item.Price);
          Assert.AreEqual(model.Topping, item.Topping);

      }
        [TestMethod]
      public void TestDetails()
      {
          var db = new CS4PEEntities();
          var item = db.BubleTeas.First();
          var controller = new VLTeaController();

          var result = controller.Details(item.id);
          var view = result as ViewResult;
          Assert.IsNotNull(view);
          var model = view.Model as BubleTea;
          Assert.IsNotNull(model);
          Assert.AreEqual(item.id,model.id);

          result = controller.Details(0);
          Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
          }
        [TestMethod]
        public void TestEdit()
        {
            var controller = new VLTeaController();
            var result0 = controller.Edit(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

            var db = new CS4PEEntities();
            var item = db.BubleTeas.First();
            var result1 = controller.Edit(item.id) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as BubleTea;
            Assert.IsNotNull(model);
            Assert.AreEqual(item.id, model.id);



        }  
            [TestMethod]
         public void TestEditP()
         {

             var controller = new VLTeaController();
             var db = new CS4PEEntities();
             var item = db.BubleTeas.First();
             var result1 = controller.Edit(item.id) as ViewResult;
             Assert.IsNotNull(result1);
             var model = result1.Model as BubleTea;
             Assert.IsNotNull(model);
             var result = controller.Edit(model);
             var redirect = result as RedirectToRouteResult;
             Assert.IsNotNull(redirect);
             Assert.AreEqual("Index", redirect.RouteValues["action"]);

         }
          [TestMethod]
            public void TestDelete()
            {

                var controller = new VLTeaController();
                var result0 = controller.Delete(0);
                Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

                var db = new CS4PEEntities();
                var item = db.BubleTeas.First();
                var result1 = controller.Delete(item.id) as ViewResult;
                Assert.IsNotNull(result1);
                var model = result1.Model as BubleTea;
                Assert.IsNotNull(model);
                Assert.AreEqual(item.id, model.id);

            }

      

    }
}
