namespace PTQ.Application;
using PTQ.Models;

public class Service : IService
{
    private readonly IService _repository;

    public Service(IService service)
    {
        _repository = service;
    }

    public IEnumerable<RequestTestDTO> GetAllTests()
    {
        return _repository.GetAllTests();
    }

    public RequestTestDTO GetTestById(int id)
    {
        return _repository.GetTestById(id);
    }

    public bool CreateTest(CreateTestDTO testDTO)
    {
        return _repository.CreateTest(testDTO);
    }
}