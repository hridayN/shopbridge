# shopbridge Product admin API
1. This is a web API project for ShopBridge's Product module. It is created using netcore (version 3.1)
2. The database used in the project is Postgresql.
3. Key features of the Project:
	a. EntityFramework is used for creating the Database(using code first approach).
	b. Currently the project supports the following actions:
		i. Save a new Product
		ii. Update an existing Product
		iii. Retrieve an existing Product
		iv. Delete an existing Product
	c. Design Pattern used in the project:
		i. IOC: Using Dependency Injection for resolving the dependencies of the Services at runtime.
	d. Every action performed will return the respective Message with the corresponding Status on the action performed.
4. Postman collection pack with the above mentioned(point 3.b) actions is added under Resources folder.
5. Models used are stored under Models folder.
6. Request/Response objects are stored under DTO folder.
7. Project enhancements:
	a. Search API can be developed, to search all products, accepting the search criteria only in a single variable. e.g., "searchText": "ProductId:'f8a2bf37-cb10-4efb-85c5-c3f2fdcbadcd',Name:'Product 1'"
	b. Product's offers can be implemented.
	c. Pagination can be implemented.
	d. Createion of response from all actions can be implemented at one place.