Feature: EditProfileOfContractor
In order to test pages
As an contractor 
I want to be able to access the system after I enter my credencials and to test editing
my profile

@mytag
Scenario: Edit Contractors Profile Invalid
Given User logs in as contractor and navigates on profile page
When Contractor deletes all values from the fields
Then Error messages are showed under Inputs
When Contractor enters Invalid Values in input fields
Then Error messages are showed under Inputs 2

Scenario: Edit Contractors Profile Valid
Given User logs in as contractor and navigates on profile page 2
When Contractor enters new valid values and clicks the save button
Then Contractor is redirected on create claim page
When Contractor navigate again on Profile page
Then New values are in input fields
