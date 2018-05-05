﻿using NLog;
using SnilAcademicDepartment.Filters;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    [Culture]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly IService _previewService;

        /// <summary>
        /// Constructor of the HomeController.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="previewService"></param>
        public HomeController(ILogger logger, IService previewService)
        {
            this._logger = logger;
            this._previewService = previewService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}