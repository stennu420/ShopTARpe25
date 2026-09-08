using ShopTARpe25.Core.Domain;
using ShopTARpe25.Core.Dto;
using ShopTARpe25.Core.ServiceInterface;
using ShopTARpe25.Data;


namespace ShopTARpe25.ApplicationServices.Services
{
    public class SpaceshipServices : ISpaceshipServices
    {
        private readonly ShopTARpe25Context _context;

        public SpaceshipServices
            (
                ShopTARpe25Context context
            )
        {
            _context = context;
        }

        
        
        public  async Task<Spaceship> Create(SpaceshipDto Dto)
        {


            Spaceship domain = new();

            domain.Id = Dto.Id;
            domain.Name = Dto.Name;
            domain.Classification = Dto.Classification;
            domain.BuildDate = Dto.BuildDate;
            domain.EnginePower = Dto.EnginePower;
            domain.CreatedAt = Dto.CreatedAt;
            domain.ModifiedAt = Dto.ModifiedAt;

            //siia tuleb kood,mis salvestab domain
            //objekti andmebaasi
            //tuleb kasutada repot, mis 
            // on defineeritud Core projektis
            //konstruktori kaudu tuleb injectida repository

            await _context.Spaceships.AddAsync(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
    }
}
