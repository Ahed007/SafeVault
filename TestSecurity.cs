using NUnit.Framework;

[TestFixture]
public class TestSecurity {
    [Test]
    public void TestSQLInjectionAttempt() {
        string maliciousInput = "' OR 1=1 --";
        var repo = new UserRepository("YourConnectionStringHere");
        var result = repo.GetUserByEmail(maliciousInput);
        Assert.IsNull(result, "SQL injection should not return all users");
    }

    [Test]
    public void TestXSSAttempt() {
        string maliciousInput = "<script>alert('XSS');</script>";
        string encoded = OutputSanitizer.EncodeForHtml(maliciousInput);
        Assert.IsFalse(encoded.Contains("<script>"), "XSS script should be escaped");
        Assert.IsTrue(encoded.Contains("&lt;script&gt;"), "Script should be encoded safely");
    }
}
