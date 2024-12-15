﻿using HistoryQuizApi.Models.Data;
using HistoryQuizApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HistoryQuizApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _service;

        public LessonController(ILessonService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLessons()
        {
            var lessons = await _service.GetAllLessonsAsync();
            return Ok(lessons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLessonById(Guid id)
        {
            var lesson = await _service.GetLessonByIdAsync(id);
            if (lesson == null)
                return NotFound();

            return Ok(lesson);
        }

        [HttpPost("{lessonId}/exam")]
        public async Task<IActionResult> AddExamToLesson(Guid lessonId, Exam exam)
        {
            try
            {
                await _service.AddExamToLessonAsync(lessonId, exam);
                return CreatedAtAction(nameof(GetLessonById), new { id = lessonId }, exam);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
    }