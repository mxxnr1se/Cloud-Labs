using AutoMapper;
using BLL.DTOs.Project;
using BLL.DTOs.Task;
using BLL.DTOs.User;
using Entities;
using Task = Entities.Task;

namespace BLL.Injections;

public class BllAutoMapperProfiles : Profile
{
    public BllAutoMapperProfiles()
    {
        CreateMap<Project, ProjectDto>().ReverseMap();
        CreateMap<Project, ProjectCreateDto>().ReverseMap();

        CreateMap<Task, TaskDto>()
                .ForMember(dest => dest.Deadline,
                           opt => opt.MapFrom(source => source.Deadline.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.LastUpdate,
                           opt => opt.MapFrom(source => source.LastUpdate.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.CreationDate,
                           opt => opt.MapFrom(source => source.CreationDate.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.TaskStatus,
                           opt => opt.MapFrom(source => source.TaskStatus.ToString()))
                .ForMember(dest => dest.TaskStatusId,
                           opt => opt.MapFrom(source => source.TaskStatus))
                .ForMember(dest => dest.TaskPriority,
                           opt => opt.MapFrom(source => source.TaskPriority.ToString()))
                .ForMember(dest => dest.TaskPriorityId,
                           opt => opt.MapFrom(source => source.TaskPriority))
                .ReverseMap();

        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserOfProjectDto>()
                .ForMember(dest => dest.FullName,
                           opt => opt.MapFrom(source => $"{source.Surname} {source.FirstName}"))
                .ReverseMap();
        CreateMap<User, RegistrationDto>().ReverseMap();
    }
}