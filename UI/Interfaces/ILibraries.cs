using UI.Models;

namespace UI.Interfaces
{
    public interface ILibraries
    {
        List<Libraries> GetAll();

        Libraries Find(int id);
    }
}