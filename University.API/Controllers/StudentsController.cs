﻿using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Net;
using University.Core.Forms;
using University.Core.Services;
using University.Data.Context;
using University.Data.Repositries;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService StudentService)
        {
            _studentService = StudentService;
        }
        [HttpGet("{id}")]
        public ApiResponse GetById(int id)
        {
            var dto=_studentService.GetById(id);
            
            return new ApiResponse(dto);

        }
        [HttpGet()]
        public ApiResponse GetAll()
        {
            var dto = _studentService.GetAll();
            
            return new ApiResponse(dto);

        }
        [HttpPost]
        public ApiResponse Create([FromBody]CreateStudentForm form) 
        {
            _studentService.Create(form);
            return new ApiResponse(HttpStatusCode.Created);
                
        }
        [HttpPut("{id}")]
        public ApiResponse Update(int id,[FromBody] UpdateStudentForm form)
        {
            _studentService.Update(id, form);
            return new ApiResponse(HttpStatusCode.OK);

        }
        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            _studentService.Delete(id);
            return new ApiResponse(HttpStatusCode.OK);
        }
    }
}
