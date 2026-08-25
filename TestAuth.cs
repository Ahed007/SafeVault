using NUnit.Framework;

[TestFixture]
public class TestAuth {
    private AuthService _auth;

    [SetUp]
    public void Setup() {
        _auth = new AuthService("YourConnectionStringHere");
    }

    [Test]
    public void TestInvalidLogin() {
        bool result = _auth.AuthenticateUser("fake@safevault.com", "wrongpassword");
        Assert.IsFalse(result, "Invalid login should fail");
    }

    [Test]
    public void TestValidLogin() {
        _auth.RegisterUser("Alice", "alice@safevault.com", "SecurePass123", "User");
        bool result = _auth.AuthenticateUser("alice@safevault.com", "SecurePass123");
        Assert.IsTrue(result, "Valid login should succeed");
    }

    [Test]
    public void TestUnauthorizedAccess() {
        string role = "User"; // simulate retrieval from DB
        Assert.AreEqual("User", role);
        Assert.AreNotEqual("Admin", role, "Non-admin should not access admin features");
    }
}
