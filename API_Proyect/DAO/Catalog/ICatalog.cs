using API_Proyect.Entities;

namespace API_Proyect.DAO.Catalog
{
    public interface ICatalog
    {
        List<StatesVO> GetStates();

        List<PositionVO> GetPosition();
    }
}
