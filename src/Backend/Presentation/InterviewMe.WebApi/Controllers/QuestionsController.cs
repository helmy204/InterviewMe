using InterviewMe.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using QuestionsManagement.Core.Model;

namespace InterviewMe.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody]QuestionModel questionModel)
        {
            try
            {
                Question.CreateQuestion(questionModel.Title, questionModel.BodyText);
            }
            catch
            {

            }

            return BadRequest();
        }
    }
}