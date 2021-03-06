﻿using System.Linq;
using System.Collections.Generic;
using SnilAcademicDepartment.BusinessLogic.DTOModels;
using System.Threading.Tasks;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface ISeminarPreview
    {
        /// <summary>
        /// Get seminars.
        /// </summary>
        /// <typeparam name="TPreviewType">Type on what we should map type of Seminar.</typeparam>
        /// <param name="numberOfSeminars">Number of the seminars to get.</param>
        /// <param name="lcid">Language code of the seminar.</param>
        /// <returns>Previews of the seminars.</returns>
        IEnumerable<IGrouping<int, TPreviewType>> GetSeminarPreviews<TPreviewType>(int numberOfSeminars, int lcid) where TPreviewType : SeminarPreview;

        /// <summary>
        /// Get seminars async.
        /// </summary>
        /// <typeparam name="TPreviewType">Type on what we should map type of Seminar.</typeparam>
        /// <param name="numberOfSeminars">Number of the seminars to get.</param>
        /// <param name="lcid">Language code of the seminar.</param>
        /// <returns>Previews of the seminars.</returns>
        Task<IEnumerable<IGrouping<int, TPreviewType>>> GetSeminarPreviewsAsync<TPreviewType>(int numberOfSeminars, int lcid) where TPreviewType : SeminarPreview;
    }
}
