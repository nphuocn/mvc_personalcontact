# Create a simple project using the Repository and Unit of Work Patterns in an ASP.NET Core MVC Application to insert/edit/delete a personal contact entity
# Technical
	ASP.Net Core MVC
# Design Pattern
	Repository and Unit Of Work
# Pages
	Personal Contact List
	Create new personal contact
	Edit personal contact
	Delete personal contact
	Personal contact detail
# Unit Test
	Implemented 3 method to run unit testing for Create function.
	Other functions (Update, Delete) will be implement later.
	
# Note: 
	- To run project on the local machine with database, need to jump into the appsetting.json and update correct connection string
		- If run with authentication
			"Server=localhost; Database=MVCDotNetCoreDatabase; user id=phuoc; password=123456; persist security info=True;"
		- If run without authentication
			"Server=localhost; Database=MVCDotNetCoreDatabase; Trusted_Connection=True; MultipleActiveResultSets=True"
	- Then open the Nuget by console to run command 'app-migration first' and run 'update-database'
