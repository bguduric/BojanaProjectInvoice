Feature: CreateAndEditContractors
In order to test pages
As an admin 
I want to be able to access the system after I enter my credencials and to test creating
and editing contractor

@mytag
Scenario: Create Contractor Invalid Values
Given User logs in as Admin and navigates on Contractors Create page
When User doesn't enter values and clicks create button
Then Error messages under inputs are showed
When User enters invalid values and clicks create button
Then Error messages are showed 2
When User enters username and pccid that already exist
Then Error messages are showed 3

Scenario: Create And Edit Contractor
Given User logs in as Admin and navigates on Contractors Create page 1
When User enters valid values in create contractors page
Then Contractor is successfully created
When User clicks on Details about contractor and back to list button
When User navigates on edit page and deletes values
Then Error messages are showed 4
When User enters negativ pcc id and invalid first name and last name
Then Error messages are showed 5
When User enters pccid that already exists
Then Error message is showed
When Admin change values in contractors edit form and saves them
Then Edited Contractor is changed in list
When Admin navigates again in contractors edit page and uncheck active checkbox
Then Contractor is not visible in table