using PTQ.Models;

namespace PTQ.Repositories;

public interface IRepository
{
    IEnumerable<RequestTestDTO> GetAllTests();
    RequestTestDTO GetTestById(int id);
    bool CreateTest (CreateTestDTO testDTO);
}