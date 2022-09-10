using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.BL.IManager;
using Students.Model.CustomModels;
using Students.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentManager _studentManager;
        private readonly IStudentClassManager _studentClassManager;
        public StudentController(IStudentManager studentManager, IStudentClassManager studentClassManager)
        {
            _studentManager = studentManager;
            _studentClassManager = studentClassManager;
        }
        [HttpGet("{id}")]
        public StudentModel GetStudent(int id)
        {
            return _studentManager.GetStudentByID(id);
        }
        [HttpPost]
        public void AddStudent([FromBody] StudentModel student)
        {
            _studentManager.AddStudent(student);
        }



        [HttpGet("{id}")]
        public StudentModel AddStudent(int id)
        {
            StudentModel student = _studentManager.GetStudentByID(id);
            //student.ClassesList = _studentClassManager.GetStudentClasses().ToList();
            return student;
        }
        [HttpPut]
        public StudentModel UpdateStudent([FromBody] StudentModel student)
        {
            return _studentManager.UpdateStudent(student);
        }
        [HttpDelete("{id}")]
        public void DeleteStudent(int id)
        {
            _studentManager.DeleteStudent(id);
        }

    }
}
