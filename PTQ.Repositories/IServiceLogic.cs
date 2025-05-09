using PTQ.Models;

namespace PTQ.Repositories;

public interface IServiceLogic
{
    IEnumerable<RequestTestDTO> GetAllTests();
    RequestTestDTO GetTestById(int id);
    bool CreateTest (CreateTestDTO testDTO);
}