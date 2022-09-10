using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
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
    public class StudentODataController : ODataController
    {
        private readonly IStudentManager _studentManager;
        public StudentODataController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }
        [HttpGet]
        [EnableQuery]
        public IEnumerable<StudentModel> Get()
        {
            return _studentManager.GetStudents().ToList();
        }
    }
}
