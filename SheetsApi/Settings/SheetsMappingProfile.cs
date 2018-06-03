using AutoMapper;
using SheetsApi.Sheets;

namespace SheetsApi.Settings
{
    public class SheetsMappingProfile : Profile
    {
        public SheetsMappingProfile()
        {
            CreateMap<SheetModel, Sheet>();
            CreateMap<Sheet, SheetModel>()
                .ForMember(m => m.Created, a => a.Ignore())
                .ForMember(m => m.Modified, a => a.Ignore())
                .ForMember(m => m.AddedByUser, a => a.MapFrom(s => s /* TODO: Get user from token? */));
        }
    }
}
