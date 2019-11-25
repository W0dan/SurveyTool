using Microsoft.AspNetCore.Mvc.Rendering;

namespace SurveyTool.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static HtmlQuestionHelper<TModel> Question<TModel>(this IHtmlHelper<TModel> html){
            return new HtmlQuestionHelper<TModel>(html);
        }
    }
}
