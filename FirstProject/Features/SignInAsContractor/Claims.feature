Feature: Claims
In order to test pages
As an contractor 
I want to be able to access the system after I enter my credencials and to test creating
And editing claims with valid and invalid values, and assert claims and search them as an admin

@mytag
Scenario: Create Clims Invalid
Given User logs in as contractor 
When Contractor deletes values from accounting number to pay input and clicks on create button
Then Message under input is showed 1
When Contractor enters invalid values in accounting number to pay input and clicks on create button
Then Messages under inputs are showed 2

Scenario: Create And Assert claims
Given User logs in as contractor 1
When Contractor select accounting period and enter valid values 1
Then Contractor is redirected to Claim list and new claim is visible in the table
When Conrtactor logs out and admin logs in and navigates on contractors claim list
And Filter and Search by username of contractor and by accounting number to pay for new claim
Then New searched claim by filter contractor is showed

Scenario: Create And Edit Claims
Given User logs in as contractor 
When Contractor select accounting period and enter valid values 
Then Contractor is redirected to Claim list and new claim is visible in the table 1
When Contractor clicks on Edit link for new Claim
And Contractor deletes values from accounting number to pay input and clicks on save button
Then Error message under Account number input is showed
When Contractor enters invalid values in Edit page form
Then Message about error under Account number input is showed
When Contractor enter valid values and clicks save button
Then Contractor is successfully edited and visible in table
When Contractor clicks on Detalis link