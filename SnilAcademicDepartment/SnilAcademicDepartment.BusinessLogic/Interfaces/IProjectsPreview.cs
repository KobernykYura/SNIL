﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface IProjectsPreview
    {
        /// <summary>
        /// Get preview of the first project by type and language code.
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        T GetProjectPreview<T>(string projectStatus, int langLCID);

        /// <summary>
        /// Get previews of all projects by type and language code.
        /// </summary>
        /// <param name="projectType">Status of the project.</param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        IEnumerable<T> GetProjectsPreviews<T>(string projectStatus, int langLCID);

        /// <summary>
        /// Get number of projects from start to end index by type and language code.
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        IEnumerable<T> GetProjectsPreviews<T>(string projectStatus, int startIndex, int endIndex, int langLCID);

        /// <summary>
        /// Get preview of the first project by type and language code.
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        Task<T> GetProjectPreviewAsync<T>(string projectStatus, int langLCID);

        /// <summary>
        /// Get previews of all projects by type and language code.
        /// </summary>
        /// <param name="projectType">Status of the project.</param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetProjectsPreviewsAsync<T>(string projectStatus, int langLCID);

        /// <summary>
        /// Get number of projects from start to end index by type and language code.
        /// </summary>
        /// <param name="projectType"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <param name="langLCID"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetProjectsPreviewsAsync<T>(string projectStatus, int startIndex, int endIndex, int langLCID);
    }
}