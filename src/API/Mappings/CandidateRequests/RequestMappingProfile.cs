using AutoMapper;
using Domain.Entitites.CandidateRequests;
using DTO.CandidateRequests;

namespace API.Mappings.Categories
{
    public class RequestMappingProfile : Profile
    {
        public RequestMappingProfile()
        {
            #region Create

            CreateMap<AddRequestDto, CandidateRequest>()
                .ReverseMap();

            #endregion Create

            #region Read

            CreateMap<CandidateRequest, CandidateRequestResponseDto>()
                .ReverseMap()
                .ForAllMembers(x => x.Condition(
                    (src, dest, property) =>
                    {
                        if (property == null) return false;

                        return true;
                    }));

            #endregion Read

            #region Update

            CreateMap<UpdateRequestDto, CandidateRequest>().ReverseMap();

            #endregion Update

        }
    }
}
