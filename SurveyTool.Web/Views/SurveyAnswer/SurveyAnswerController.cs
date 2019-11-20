using Microsoft.AspNetCore.Mvc;
using SurveyTool.Web.Views.Shared;
using System;

namespace SurveyTool.Web.Views.SurveyAnswer
{
    [Route("survey")]
    public class SurveyAnswerController : Controller
    {

        [HttpGet]
        [Route("answer/{id:guid}")]
        public IActionResult Index(Guid id)
        {
            return View(new ViewModelBase { Title = "Answer Survey" });
        }

    }
}
