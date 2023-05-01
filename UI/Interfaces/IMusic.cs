using UI.Models;

namespace UI.Interfaces
{
    public interface IMusic
    {
        Music Find(int id);

        List<Music> GetAll();
    }
}