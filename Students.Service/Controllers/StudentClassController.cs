using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.BL.IManager;
using Students.Model.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentClassController : ControllerBase
    {
        private readonly IStudentClassManager _studentClassManager;
        public StudentClassController(IStudentClassManager studentClassManager)
        {
            _studentClassManager = studentClassManager;
        }
        [HttpGet]
        public IEnumerable<StudentClassModel> GetStudentClasses()
        {
            return _studentClassManager.GetStudentClasses().ToList();
        }
    }
}
