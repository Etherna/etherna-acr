﻿using System.Threading.Tasks;

namespace Etherna.SSL.Services
{
    public interface IRazorViewRenderer
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}
