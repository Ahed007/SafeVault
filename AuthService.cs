using BCrypt.Net;
using System.Data.SqlClient;

public class AuthService {
    private readonly string _connectionString;
    public AuthService(string connectionString) {
        _connectionString = connectionString;
    }

    public bool RegisterUser(string username, string email, string password, string role = "User") {
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        using (var conn = new SqlConnection(_connectionString))
        using (var cmd = new SqlCommand("INSERT INTO Users (Username, Email, PasswordHash, Role) VALUES (@Username, @Email, @PasswordHash, @Role)", conn)) {
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
            cmd.Parameters.AddWithValue("@Role", role);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }

    public bool AuthenticateUser(string email, string password) {
        using (var conn = new SqlConnection(_connectionString))
        using (var cmd = new SqlCommand("SELECT PasswordHash FROM Users WHERE Email = @Email", conn)) {
            cmd.Parameters.AddWithValue("@Email", email);
            conn.Open();
            var result = cmd.ExecuteScalar()?.ToString();
            if (result == null) return false;
            return BCrypt.Net.BCrypt.Verify(password, result);
        }
    }
}
