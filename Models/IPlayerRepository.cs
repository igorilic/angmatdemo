namespace WebApiTest.Models
{
    interface IPlayerRepository
    {
        Player[] GetAll();
        Player GetPlayerById(int id);
        Player AddNewPlayer(Player player);
        void RemovePlayer(int id);
        bool UpdatePlayer(Player player);
    }
}
