using UI.Models;

namespace UI.Interfaces
{
    public interface IEpisodes
    {
        Episodes Find(int id);

        List<Episodes> GetAll();
    }
}