using DollarSenseDB.Models;

namespace DollarSenseDB
{
    public interface IUSStateData
    {
        Task<List<USStateModel>> GetUSState(string usStateName);
        Task<List<USStateModel>> GetUSStates();
    }
}