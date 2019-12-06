using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.IO;
using System.Linq.Expressions;

namespace SurveyTool.Web.Extensions
{
    public class HtmlQuestionHelper<TModel>
    {
        private readonly IHtmlHelper<TModel> html;

        public HtmlQuestionHelper(IHtmlHelper<TModel> html)
        {
            this.html = html;
        }
        public IHtmlContent Text<TResult>(Expression<Func<TModel, TResult>> expression)
        {
            return HtmlHelperInputExtensions.TextBoxFor(html, expression);

            //var result = new HtmlString("");

            //using (var writer = new StringWriter())
            //{
            //    result.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
            //    br.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);

            //}
            ////result.WriteTo()
            ////result.WriteTo()
            //return result;
        }

        public IHtmlContent MultipleChoiceSingleSelect<TResult>(Expression<Func<TModel, TResult>> expression)
        {

            return new HtmlString("");
        }

    }
}