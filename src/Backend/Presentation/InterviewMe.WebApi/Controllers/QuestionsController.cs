using AutoMapper;
using InterviewMe.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using QuestionsManagement.Core.Interfaces;
using QuestionsManagement.Core.Model;
using System;
using System.Collections.Generic;

namespace InterviewMe.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsRepository _questionsRepository;

        public QuestionsController(IQuestionsRepository questionsRepository)
        {
            _questionsRepository = questionsRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Question> questions = _questionsRepository.GetQuestions();
            IEnumerable<QuestionModel> result = Mapper.Map<IEnumerable<QuestionModel>>(questions);
            return Ok(result);
        }

        [HttpGet("{tag}")]
        public IActionResult Get(string tag)
        {
            try
            {
                IEnumerable<Question> questions = _questionsRepository.GetQuestionsByTag(tag);
                IEnumerable<QuestionModel> result = Mapper.Map<IEnumerable<QuestionModel>>(questions);
                return Ok(result);
            }
            catch
            {
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Post([FromBody]QuestionModel questionModel)
        {
            try
            {
                Question.CreateQuestion(questionModel.Title, questionModel.Body, questionModel.Tags);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }


    }
}