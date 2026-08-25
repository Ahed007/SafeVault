# SafeVault Web Application

SafeVault is a secure web application designed to protect sensitive data such as user credentials and financial records.  
This project demonstrates secure coding practices, authentication, and role-based authorization.

## Features
- ✅ Input validation & sanitization
- ✅ Parameterized queries (SQL injection prevention)
- ✅ Authentication with bcrypt password hashing
- ✅ Role-based authorization (RBAC)
- ✅ Security tests for SQL injection & XSS

## Vulnerabilities & Fixes
- **SQL Injection**: Unsafe string concatenation → replaced with parameterized queries.
- **XSS**: Direct rendering of user input → fixed with HTML encoding.
- **Copilot’s Assistance**: Guided secure code generation, suggested fixes, and produced unit tests simulating attack scenarios.

## How to Run
1. Import `database.sql` into your SQL server.
2. Update connection strings in `UserRepository.cs` and `AuthService.cs`.
3. Run tests with `NUnit` to verify security.
4. Deploy web form and controllers in ASP.NET Core.

## Tests
- **Input Validation**: Blocks malicious characters.
- **Authentication**: Verifies hashed passwords.
- **Authorization**: Restricts admin-only routes.
- **Security**: Simulates SQL injection & XSS attacks.

---
