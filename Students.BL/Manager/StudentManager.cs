using Students.DAL.IRepositories;
using Students.BL.IManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Students.Model.Models;
using Students.Model.CustomModels;
using AutoMapper;

namespace Students.BL.Manager
{
    public class StudentManager: IStudentManager
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentSubjectRepository _studentSubjectRepository;
        private readonly IMapper _mapper;
        public StudentManager(IStudentRepository studentRepository,
            IStudentSubjectRepository studentSubjectRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _studentSubjectRepository = studentSubjectRepository;
            _mapper = mapper;
        }
        public IQueryable<StudentModel> GetStudents()
        {
            return _studentRepository.GetStudents().Select(student => _mapper.Map<StudentModel>(student)) ;

        }
        public StudentModel GetStudentByID(int id)
        {
            StudentModel studentModel = new StudentModel();
            Student student = _studentRepository.GetStudentByID(id);
            if(student!=null)
            {
                studentModel.Student_ID = student.Student_ID;
                studentModel.Student_Name = student.Student_Name;
                studentModel.Student_Address = student.Student_Address;
                studentModel.Student_BirthDate = student.Student_BirthDate;
                studentModel.Student_EmailAddress = student.Student_EmailAddress;
                studentModel.StudentClass_ID = student.StudentClass_ID;
                studentModel.StudentClass_Name = student.StudentClass?.StudentClass_Name;
                studentModel.StudentSubjectsList = new List<StudentSubjectModel>();
                foreach(var subject in student.StudentSubjects)
                {
                    StudentSubjectModel subjectModel = new StudentSubjectModel();
                    subjectModel.ID = subject.ID;
                    subjectModel.Student_ID = subject.Student_ID;
                    subjectModel.Subject_ID = subject.Subject_ID;
                    subjectModel.Student_Name = subject.Student?.Student_Name;
                    subjectModel.Subject_Name = subject.Subject?.Subject_Name;
                    studentModel.StudentSubjectsList.Add(subjectModel);
                }
            }
            return studentModel;
        }
        public void AddStudent(StudentModel studentModel)
        {
            Student studentObject = new Student();
            if (studentModel != null)
            {
              studentObject = _mapper.Map<Student>(studentModel);
            }
            foreach (var sub in studentModel.StudentSubjectsList.ToList())
            {
                studentObject.StudentSubjects.Add(new StudentSubject()
                {
                    Student_ID = sub.Student_ID,
                    Subject_ID = sub.Subject_ID
                });
            }
            _studentRepository.AddStudent(studentObject);
        }
        public StudentModel UpdateStudent(StudentModel studentModel)
        {
            Student studentObject = _studentRepository.GetStudentByID(studentModel.Student_ID);
            if (studentObject != null)
            {
                //studentObject.Student_ID = studentModel.Student_ID;
                studentObject.Student_Name = studentModel.Student_Name;
                studentObject.Student_Address = studentModel.Student_Address;
                studentObject.Student_EmailAddress = studentModel.Student_EmailAddress;
                studentObject.Student_BirthDate = studentModel.Student_BirthDate;
                studentObject.StudentClass_ID = studentModel.StudentClass_ID;

                //var subIDs = studentModel.StudentSubjectsList.Select(c => c.Subject_ID).ToList();
                //var newSubjects = studentModel.StudentSubjectsList.Where(c => c.ID == 0).ToList();
                //var deletedSubjects = studentObject.StudentSubjects.Where(x => !subIDs.Contains(x.Subject_ID)).ToList();

                studentObject.StudentSubjects = new List<StudentSubject>();
                foreach (var sub in studentModel.StudentSubjectsList)
                {
                    studentObject.StudentSubjects.Add(new StudentSubject()
                    {
                        Student_ID = sub.Student_ID,
                        Subject_ID = sub.Subject_ID
                    });
                }

                //foreach (var sub in deletedSubjects)
                //{
                //    studentObject.StudentSubjects.Remove(sub);
                //}

                _studentRepository.UpdateStudent(studentObject);
            }
            return studentModel;
        }
        public void DeleteStudent(int id)
        {
            var student = _studentRepository.GetStudentByID(id);
            _studentRepository.DeleteStudent(student);
        }
    }
}
