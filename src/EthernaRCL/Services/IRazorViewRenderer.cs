using System.Threading.Tasks;

namespace Etherna.RCL.Services
{
    public interface IRazorViewRenderer
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}
