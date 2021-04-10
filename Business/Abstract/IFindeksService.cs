﻿using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFindeksService
    {
        IDataResult<int> CalculateFindeksRating();
    }
}
