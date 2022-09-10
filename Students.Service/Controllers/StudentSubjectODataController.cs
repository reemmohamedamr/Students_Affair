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
    public class StudentSubjectODataController : ODataController
    {
        private readonly IStudentSubjectManager _studentSubjectManager;
        public StudentSubjectODataController(IStudentSubjectManager studentSubjectManager)
        {
            _studentSubjectManager = studentSubjectManager;
        }
        [HttpGet]
        [EnableQuery]
        public IEnumerable<StudentSubjectModel> Get()
        {
            return _studentSubjectManager.GetStudentSubjects().ToList();
        }
    }
}
