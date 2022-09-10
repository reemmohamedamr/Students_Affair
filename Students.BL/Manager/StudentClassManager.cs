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
    public class StudentClassManager : IStudentClassManager
    {
        private readonly IStudentClassRepository _studentClassRepository;
        private readonly IMapper _mapper;
        public StudentClassManager(IStudentClassRepository studentClassRepository, IMapper mapper)
        {
            _studentClassRepository = studentClassRepository;
            _mapper = mapper;
        }
        public IQueryable<StudentClassModel> GetStudentClasses()
        {
            return _studentClassRepository.GetStudentClasses().Select(studentClass => _mapper.Map<StudentClassModel>(studentClass));

        }
        public StudentClassModel GetStudentByID(int id)
        {
            return _mapper.Map<StudentClassModel>(_studentClassRepository.GetStudentClassByID(id));
        }
    }
}
