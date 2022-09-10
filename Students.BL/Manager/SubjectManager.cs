using AutoMapper;
using Students.BL.IManager;
using Students.DAL.IRepositories;
using Students.Model.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Students.BL.Manager
{
    public class SubjectManager : ISubjectManager
    {
        private readonly ISubjectRepository _SubjectRepository;
        private readonly IMapper _mapper;
        public SubjectManager(ISubjectRepository SubjectRepository, IMapper mapper)
        {
            _SubjectRepository = SubjectRepository;
            _mapper = mapper;
        }
        public IQueryable<StudentSubjectModel> GetSubjects()
        {
            var ff= _SubjectRepository.GetSubjects().Select(Subject => new StudentSubjectModel()
            {
                ID = 0,
                Student_ID = 0,
                Student_Name = "",
                Subject_ID = Subject.Subject_ID,
                Subject_Name = Subject.Subject_Name
            });
            return ff;
        }
    }
}
