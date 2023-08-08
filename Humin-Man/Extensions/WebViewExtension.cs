using Microsoft.AspNetCore.Mvc.Rendering;

namespace Humin_Man.Extensions
{
    /// <summary>
    /// Web View Extension
    /// </summary>
    public static class WebViewExtension
    {
        private const string ClassName = "active";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewContext"></param>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static string IsSelected(this ViewContext viewContext, string controller, string action)
        {
            if(string.IsNullOrEmpty(controller) || string.IsNullOrEmpty(action))
                return string.Empty;

            if (viewContext.RouteData.Values["Action"].ToString() == action && viewContext.RouteData.Values["Controller"].ToString() == controller)
            {
                return ClassName;
            }

            return string.Empty;
        }
    }
}
