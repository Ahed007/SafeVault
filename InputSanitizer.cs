using System.Text.RegularExpressions;

public static class InputSanitizer {
    public static string SanitizeUsername(string username) {
        if (string.IsNullOrWhiteSpace(username)) return string.Empty;
        return Regex.Replace(username, @"[^a-zA-Z0-9_]", "");
    }

    public static string SanitizeEmail(string email) {
        if (string.IsNullOrWhiteSpace(email)) return string.Empty;
        var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailPattern) ? email : string.Empty;
    }
}
