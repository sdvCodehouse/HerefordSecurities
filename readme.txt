Project Information

Entitiy Framework set to auto-configure, so will try and create the mysql db if it doesn't exist.

Configuration environments
Debug
Release
Live

Publishing
FileSystemLocal - deploys to herefordsecurities.local using the Debug configuration setting.
FileSystemRelease - deploys to herefordsecurities.release using the Release configuration setting. (So release version can be viewed before uploading to 123-reg.)
FileSystemDeployment - deploys to Builds/Deployment for upload to 123-reg. Cannot be viewed before submission as uses 123-reg db connection settings.

Administration
The herefordsecurities.admin local site links to the Admin project, which should not be published.
This project allows data to be edited.

MySQL
Steps to data migration to 123-reg servers.

Export from local db.
1. Open MySql Workbench application.
2. Open localhost instance.
3. Select Data Export in left panel.
4. Select herefordb schema.
5. Click on herefordb to make the tables appear.
6. Uncheck __migrationhistory.
7. Make sure Dump Structure and Data is selected in dropdown.
8. Check the Export to Self-Containing File radio button.
9. Check the Include Create Schema.
10. Click Start Export.
11. Continue past any versioning errors that may appear.
12. Check data export finished without errors.

This expoerted to C:\Users\Simon\Documents\dumps\Dump##########.sql

Upload to 123-reg.
1. Log into 123-reg Control Panel and go to Manage Domain | Manage Web hosting.
2. Go to My Tools section and select MySql databases.
3. In Manage MySQL Databases section enter password and click Manage.
4. Select the Import tab.
5. Choose file (file created in 10 above).
6. Click 'Go'.
7. Check report for import completed without errors.
