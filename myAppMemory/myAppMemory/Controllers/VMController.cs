﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myAppMemory.ViewModels;

namespace myAppMemory.Controllers
{
    public class VMController : Controller
    {
        private Repo_Student repo = new Repo_Student();
        //
        // GET: /VM/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
         [HttpPost]
        public ActionResult Create(StudentFull st)
        {
            if (ModelState.IsValid)
            {
                repo.createStudent(st);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }

        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
	}
}