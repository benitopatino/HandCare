using AutoMapper;
using HandCare.Core.Domain;
using HandCare.HandShakeScheduler.API.Dtos;

namespace HandCare.HandShakeScheduler.API.Mapper;

public class ProfileMapper : Profile
{
    public ProfileMapper()
    {
        CreateMap<AppointmentDTO, Appointment>().ReverseMap();
    }
}