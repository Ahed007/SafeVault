using System.Data.SqlClient;

public class UserRepository {
    private readonly string _connectionString;
    public UserRepository(string connectionString) {
        _connectionString = connectionString;
    }

    public void AddUser(string username, string email) {
        using (var conn = new SqlConnection(_connectionString))
        using (var cmd = new SqlCommand("INSERT INTO Users (Username, Email) VALUES (@Username, @Email)", conn)) {
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Email", email);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public string GetUserByEmail(string email) {
        using (var conn = new SqlConnection(_connectionString))
        using (var cmd = new SqlCommand("SELECT Username FROM Users WHERE Email = @Email", conn)) {
            cmd.Parameters.AddWithValue("@Email", email);
            conn.Open();
            var result = cmd.ExecuteScalar();
            return result?.ToString();
        }
    }
}
