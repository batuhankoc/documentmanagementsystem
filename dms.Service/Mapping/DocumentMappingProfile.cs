using AutoMapper;
using dms.Contract.DocumentContracts;
using dms.Entity.Entity;

namespace dms.Service.Mapping
{
    public class DocumentMappingProfile : Profile
    {
        public DocumentMappingProfile()
        {
            CreateMap<AddDocumentContract, Document>()
                .ForMember(dest => dest.DocumentTags, opt => opt.Ignore())
                .ForMember(dest => dest.UploadDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}