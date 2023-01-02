using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentAPI.RazorViews
{
    public interface IRazorViewRenderer
    {
        string RenderPartialViewToString<TModel>(string name, TModel model);
    }
}
