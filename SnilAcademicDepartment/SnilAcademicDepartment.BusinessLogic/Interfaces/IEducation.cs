﻿using SnilAcademicDepartment.BusinessLogic.Models;
using System.Collections.Generic;

namespace SnilAcademicDepartment.BusinessLogic.Interfaces
{
    public interface IEducation
    {
        IEnumerable<KeyAreaBlock> GetKeyAreas(uint pages);
    }
}