﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.RazorTemplates.RazorRenderer
{
    public interface IRenderRazorView
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}
