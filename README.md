# User Info App - Deployment Instructions

1. Restore Database
   - Open SQL Server Management Studio.
   - Right-click Databases > Restore Database...
   - Select 'Device', add `UserInfoDb.bak` from the /Database folder.
   - Restore.

2. Update the connection string in `appsettings.json` to match your SQL Server.

3. Open the solution in Visual Studio and Build.

4. Run the project (`UserInfoApp.Web` as Startup).

5. Log in with:
   Username: testuser
   Password: Test@123

6. See /Screenshots for expected UI.
