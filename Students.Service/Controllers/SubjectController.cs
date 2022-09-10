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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectManager _subjectManager;
        public SubjectController(ISubjectManager subjectManager)
        {
            _subjectManager = subjectManager;
        }
        [HttpGet]
        public IEnumerable<StudentSubjectModel> Get()
        {
            return _subjectManager.GetSubjects().ToList();
        }
    }
}
