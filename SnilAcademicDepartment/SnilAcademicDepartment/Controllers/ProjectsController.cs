﻿using NLog;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SnilAcademicDepartment.Controllers
{
    [RoutePrefix("{language}")]
    public class ProjectsController : Controller
    {
        private readonly ILogger _logger;
        private readonly IService _previewService;
        private readonly IProjects _projectsService;
        private readonly IProjectsPreview _projectsPreview;

        /// <summary>
        /// Constructor of the ProjectsController.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="projectsService"></param>
        public ProjectsController(ILogger logger,IService previewService, IProjects projectsService, IProjectsPreview projectsPreview)
        {
            this._logger = logger;
            this._previewService = previewService;
            this._projectsService = projectsService;
            this._projectsPreview = projectsPreview;
        }

        [HttpGet]
        [Route("Projects")]
        public async Task<ActionResult> Projects()
        {
            PreViewModel projectPreview = null;

            IEnumerable<ProjectPreview> currentPreviews = null;
            IEnumerable<ProjectPreview> newPreviews = null;
            IEnumerable<ProjectPreview> finishedPreviews = null;

            try
            {
                // Get project previews.
                projectPreview = await this._previewService.GetPagePreviewAsync("Projects", Thread.CurrentThread.CurrentCulture.LCID);

                currentPreviews = await this._projectsPreview
                    .GetProjectsPreviewsAsync<ProjectPreview>("Current", 0, 12, Thread.CurrentThread.CurrentCulture.LCID);

                newPreviews = await this._projectsPreview
                    .GetProjectsPreviewsAsync<ProjectPreview>("New", 0, 12, Thread.CurrentThread.CurrentCulture.LCID);

                finishedPreviews = await this._projectsPreview
                    .GetProjectsPreviewsAsync<ProjectPreview>("Finished", 0, 12, Thread.CurrentThread.CurrentCulture.LCID);
            }
            catch (Exception)
            {
                return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
            }

            ViewBag.Preview = projectPreview;

            ViewBag.currentPreviews = currentPreviews;
            ViewBag.newPreviews = newPreviews;
            ViewBag.finishedPreviews = finishedPreviews;

            return View();
        }

        [HttpGet]
        [Route("New")]
        public async Task<ActionResult> PageNew(int id)
        {
            ProjectModel projectModel = null;
            IEnumerable<ProjectPreview> newPreviews = null;

            try
            {
                projectModel = this._projectsService.GetProjectById(id, Thread.CurrentThread.CurrentCulture.LCID);

                newPreviews = await this._projectsPreview
                    .GetProjectsPreviewsAsync<ProjectPreview>("New", 0, 6, Thread.CurrentThread.CurrentCulture.LCID);

            }
            catch (Exception )
            {
                return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
            }

            ViewBag.Title = projectModel.ProjectTitle;
            ViewBag.Project = projectModel;
            ViewBag.Previews = newPreviews;

            return View("ProjectPage");
        }

        [HttpGet]
        [Route("Finished")]
        public async Task<ActionResult> PageFinished(int id)
        {
            ProjectModel projectModel = null;
            IEnumerable<ProjectPreview> finishedPreviews = null;

            try
            {
                projectModel = this._projectsService.GetProjectById(id, Thread.CurrentThread.CurrentCulture.LCID);

                finishedPreviews = await this._projectsPreview
                    .GetProjectsPreviewsAsync<ProjectPreview>("Finished", 0, 6, Thread.CurrentThread.CurrentCulture.LCID);

            }
            catch (Exception)
            {
                return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
            }

            ViewBag.Title = projectModel.ProjectTitle;
            ViewBag.Project = projectModel;
            ViewBag.Previews = finishedPreviews;

            return View("ProjectPage");
        }

        [HttpGet]
        [Route("Current")]
        public async Task<ActionResult> PageCurrent(int id)
        {
            ProjectModel projectModel = null;
            IEnumerable<ProjectPreview> currentPreviews = null;

            try
            {
                projectModel = this._projectsService.GetProjectById(id, Thread.CurrentThread.CurrentCulture.LCID);

                currentPreviews = await this._projectsPreview
                   .GetProjectsPreviewsAsync<ProjectPreview>("Current", 0, 6, Thread.CurrentThread.CurrentCulture.LCID);

            }
            catch (Exception)
            {
                return Redirect(this.Request.UrlReferrer?.AbsoluteUri ?? "/");
            }

            ViewBag.Title = projectModel.ProjectTitle;
            ViewBag.Project = projectModel;
            ViewBag.Previews = currentPreviews;

            return View("ProjectPage");
        }
    }
}