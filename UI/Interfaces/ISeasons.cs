using UI.Models;

namespace UI.Interfaces
{
    public interface ISeasons
    {
        Seasons Find(int id);

        List<Seasons> GetAll();
    }
}