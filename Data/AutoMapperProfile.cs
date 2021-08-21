using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace APIs_Tutorial.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Entities.Student, DTO.StudentDTO>().
                ForMember(
                dest => dest.UserName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<DTO.StudentCreationDTO, Entities.Student>();
            
            CreateMap<Entities.ExamDetail, DTO.ExamDetailDTO>().
                ForMember(
                dest => dest.Subjects,
                opt => opt.MapFrom(src => $"{src.SubjectOne} {src.SubjectTwo} {src.SubjectThree} {src.SubjectFour}"));
            CreateMap<DTO.ExamDetailCreationDTO, Entities.ExamDetail>();


            CreateMap<Entities.Results, DTO.ResultDTO>().ReverseMap();
            CreateMap<DTO.ResultCreationDTO, Entities.Results>();







        }

        

    }


}
