using Contracts.DAL.App.Repositories;
using Contracts.DAL.Base.Mappers;
using DAL.App.EF.Mappers;
using DAL.Base.EF.Repositories;
using DAL.Base.Mappers;
using Domain.App;

namespace DAL.App.EF.Repositories
{
    public class TrackRepository:
        EFBaseRepository<ApplicationDbContext, Domain.App.Identity.AppUser, Domain.App.Track, DAL.App.DTO.Track>,
        ITrackRepository
    {
        public TrackRepository(ApplicationDbContext repoDbContext) : base(repoDbContext, new DALMapper<Domain.App.Track, DTO.Track>())
        {
        }
    }
}