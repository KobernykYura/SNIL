﻿using NLog;
using SnilAcademicDepartment.BusinessLogic.Interfaces;
using SnilAcademicDepartment.DataAccess;
using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using SnilAcademicDepartment.BusinessLogic.DTOModels;

namespace SnilAcademicDepartment.BusinessLogic.Services
{
    public sealed class PreViewService : IService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly SnilDBContext _repository;

        public PreViewService(ILogger logger, SnilDBContext repository, IMapper mapper)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._repository = repository;
        }

        /// <summary>
        /// Method of getting firs or default preview of the page type.
        /// </summary>
        /// <param name="pageType">Type of the page.</param>
        /// <returns>Single page preview.</returns>
        public PreViewModel GetPagePreview(string pageType, int langLCID)
        {
            if (string.IsNullOrEmpty(pageType) || string.IsNullOrWhiteSpace(pageType))
            {
                throw new ArgumentNullException(nameof(pageType), "Your argument is Null, Empty or WhiteSpace");
            }

            var requestResult = this._repository.PreViews
                .FirstOrDefault(e => pageType.Equals(e.PageTypeName.PageTypeName,StringComparison.OrdinalIgnoreCase)
                && e.Language.LanguageCode == langLCID);

            if (requestResult == null)
            {
                throw new InvalidOperationException("Cant't find page preview");
            }

            return this._mapper.Map<PreViewModel>(requestResult);
        }

        /// <summary>
        /// Return a collection of previews from database.
        /// </summary>
        /// <param name="pageType">Name of the preview type.</param>
        /// <returns>Collection of preview.</returns>
        public IEnumerable<PreViewModel> GetPagePreviews(string pageType, int langLCID)
        {
            if (string.IsNullOrEmpty(pageType) || string.IsNullOrWhiteSpace(pageType))
            {
                throw new ArgumentNullException(nameof(pageType), "Your argument is Null, Empty or WhiteSpace");
            }

            var requestResult = this._repository.PreViews
                .Where(e => e.PageTypeName.PageTypeName == pageType && e.Language.LanguageCode == langLCID)
                .AsEnumerable();

            if (requestResult == null)
            {
                throw new InvalidOperationException("Cant't find previews for this page.");
            }

            return this._mapper.Map<IEnumerable<PreViewModel>>(requestResult);
        }
    }
}
