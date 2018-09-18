using AutoMapper;
using SheetsApi.Forces;
using SheetsApi.Games;
using SheetsApi.Sheets;

namespace SheetsApi.Settings
{
    public class SheetsMappingProfile : Profile
    {
        public SheetsMappingProfile()
        {
            CreateMap<SheetModel, Sheet>()
                .ForMember(m => m.Id, a => a.MapFrom(s => s.SheetId));
            CreateMap<Sheet, SheetModel>()
                .ForMember(m => m.SheetId, a => a.MapFrom(s => s.Id))
                .ForMember(m => m.Created, a => a.Ignore())
                .ForMember(m => m.Modified, a => a.Ignore())
                .ForMember(m => m.AddedByUser, a => a.MapFrom(s => s /* TODO: Get user from token? */))
                .ForMember(m => m.ModifiedByUser, a => a.MapFrom(s => s /* TODO: Get user from token? */));
            CreateMap<ForceModel, Force>()
                .ForMember(m => m.Id, a => a.MapFrom(s => s.ForceId));
            CreateMap<GameModel, Game>()
                .ForMember(m => m.Id, a => a.MapFrom(s => s.GameId));
            CreateMap<CombatantModel, Combatant>()
                .ForMember(m => m.Id, a => a.MapFrom(s => s.CombatantId));
        }
    }
}
