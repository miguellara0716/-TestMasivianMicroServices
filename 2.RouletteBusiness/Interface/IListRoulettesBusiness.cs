using _4.OnlineRouletteBusinessEntities.Wrappers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _2.OnlineRouletteBusiness.Interface
{
    public interface IListRoulettesBusiness
    {
        Task<ICollection<Roulettes_Wrappers>> ListRoulettes();
    }
}
