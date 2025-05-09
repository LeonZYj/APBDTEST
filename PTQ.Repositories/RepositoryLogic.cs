using Microsoft.Data.SqlClient;
using PTQ.Models;

namespace PTQ.Repositories;

public class RepositoryLogic : IRepository
{
    private readonly string _connectionString;

    public RepositoryLogic(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IEnumerable<RequestTestDTO> GetAllTests()
    {
        var quizes = new List<RequestTestDTO>();
        var query = "SELECT ID, NAME FROM QUIZ";

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        quizes.Add(new RequestTestDTO
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString(),
                        });
                    }
                }
            }
            finally
            {
                reader.Close();
            }
        }
        return quizes;
    }
    public RequestTestDTO GetTestById(int id)
    {
        RequestTestDTO quiz = null;
        var query = "SELECT q.ID,q.NAME,q.POTATOTEACHERNAME,q.PATH FROM QUIZ q JOIN PotatoTeacher p ON q.ID = @ID";
    
        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", id);
            var reader = command.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        quiz = new RequestTestDTO
                        {
                            ID = (int)reader["ID"],
                            Name = reader["Name"].ToString(),
                            PotatoTeacherName = (string)reader["potatoTeacherName"],
                            Path = (string)reader["path"],
                        };
                    }
                }
            }
            finally
            {
                reader.Close();
            }
        }
        return quiz;
    }

    public bool CreateTest(CreateTestDTO testDTO)
    {
        throw new NotImplementedException();
    }
}

