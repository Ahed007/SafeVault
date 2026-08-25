using NUnit.Framework;

[TestFixture]
public class TestInputValidation {
    [Test]
    public void TestForSQLInjection() {
        string maliciousInput = "'; DROP TABLE Users; --";
        string sanitized = InputSanitizer.SanitizeUsername(maliciousInput);
        Assert.IsFalse(sanitized.Contains("DROP"));
        Assert.IsFalse(sanitized.Contains(";"));
    }

    [Test]
    public void TestForXSS() {
        string maliciousInput = "<script>alert('XSS');</script>";
        string sanitized = InputSanitizer.SanitizeUsername(maliciousInput);
        Assert.IsFalse(sanitized.Contains("<script>"));
        Assert.IsFalse(sanitized.Contains("</script>"));
    }
}
