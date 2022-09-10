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
    public class StudentSubjectManager : IStudentSubjectManager
    {
        private readonly IStudentSubjectRepository _studentSubjectRepository;
        private readonly IMapper _mapper;
        public StudentSubjectManager(IStudentSubjectRepository studentSubjectRepository, IMapper mapper)
        {
            _studentSubjectRepository = studentSubjectRepository;
            _mapper = mapper;
        }
        public IQueryable<StudentSubjectModel> GetStudentSubjects()
        {
            return _studentSubjectRepository.GetStudentSubjects().Select(studentSubject => _mapper.Map<StudentSubjectModel>(studentSubject));

        }
    }
}
