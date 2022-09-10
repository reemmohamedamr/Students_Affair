using AutoMapper;
using Students.Model.CustomModels;
using Students.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Model
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentModel, Student>().ReverseMap()
                .ForMember(x=>x.StudentClass_Name,opt=>opt.MapFrom(src=>src.StudentClass.StudentClass_Name));
            CreateMap<StudentClassModel, StudentClass>().ReverseMap();
            CreateMap<StudentSubjectModel, StudentSubject>().ReverseMap()
                .ForMember(x => x.Student_Name, opt => opt.MapFrom(src => src.Student.Student_Name))
                .ForMember(x => x.Subject_Name, opt => opt.MapFrom(src => src.Subject.Subject_Name));
            CreateMap<SubjectModel, Subject>().ReverseMap();
        }
    }
}
