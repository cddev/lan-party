using DAL.model;

namespace DAL
{
    public interface IJsonFileCrud
    {
        string JsonDbPath { get; }

        bool Add(ref Game newGame);
        bool Delete(string id);
        GameResponse GetAll();
        bool Update(Game newGame);
    }
}