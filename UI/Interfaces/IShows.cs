using UI.Models;

namespace UI.Interfaces
{
    public interface IShows
    {
        Shows Find(int id);

        List<Shows> GetAll();
    }
}