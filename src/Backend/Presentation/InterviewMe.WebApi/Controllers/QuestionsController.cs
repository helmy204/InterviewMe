using AutoMapper;
using InterviewMe.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using QuestionsManagement.Core.Interfaces;
using QuestionsManagement.Core.Model;
using System.Collections.Generic;
using System.Linq;

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
            var questions = _questionsRepository.GetQuestions();
            var result = Mapper.Map<IEnumerable<QuestionModel>>(questions);
            return Ok(result);
        }

        //[HttpGet("{id}")]
        //public IActionResult Get(long id)
        //{
        //    try
        //    {
        //        Patient patient = _patientRepository.GetById(id);
        //        if (patient == null) return NotFound($"Patient {id} was not found");
        //        PatientModel patientModel = patient.ToModel();
        //        return Ok(patientModel);
        //    }
        //    catch
        //    {
        //    }

        //    return BadRequest();
        //}

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