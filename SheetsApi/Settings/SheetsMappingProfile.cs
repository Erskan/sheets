using AutoMapper;
using SheetsApi.Sheets;

namespace SheetsApi.Settings
{
    public class SheetsMappingProfile : Profile
    {
        public SheetsMappingProfile()
        {
            CreateMap<SheetModel, Sheet>();
        }
    }
}
