﻿using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Models
{
    public class KeyAreaBlock
    {
        /// <summary>
        /// Key area block title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description of the key area block.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Image of the current block.
        /// </summary>
        public byte[] Image { get; set; }

        /// <summary>
        /// Topics of this ke area block.
        /// </summary>
        public IEnumerable<string> Topics { get; set; }
    }
}
