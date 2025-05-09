using PTQ.Models;

namespace PTQ.Application;

public interface IService
{
    IEnumerable<RequestTestDTO> GetAllTests();
    RequestTestDTO GetTestById(int id);
    bool CreateTest (CreateTestDTO testDTO);
}