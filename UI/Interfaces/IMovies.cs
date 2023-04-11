using UI.Models;

namespace UI.Interfaces
{
    public interface IMovies
    {
        Movies Find(int id);

        List<Movies> GetAll();
    }
}