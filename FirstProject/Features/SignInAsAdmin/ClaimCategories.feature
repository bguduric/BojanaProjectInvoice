Feature: ClaimCategories
ClaimCategoriesCreateAndEdit
In order to test pages
As an admin 
I want to be able to access the system after I enter my credencials and to test creating
And editing Claim categories with valid and invalid values, and assert that new claim category
exists in all dropdowns and lists

@mytag
Scenario: Claim Categories Invalid Create
Given User logs in as admin and navigates on Claim category page 1
When User doesn't enter anything and clicks on create claim category button
Then Error message is showed 5
When User enters invalid values in Claim categories name field
Then Error message is showed 6
When User enters claim category name
Then Error message is showed 7

Scenario: Create and Edit Claim Category
Given User logs in as admin and navigates on Claim category page 3
When User enters valid values in create claim category form 2
Then User is redirected on claim categories list 3
When User navigates on edit link and deletes Claim category name and clicks on save button
Then Error message is showed 8
When User enters invalid values in Claim category edit name
Then Error message is showed 9
When User changes name in name that already exists in edit claim category
Then Error message is showed 10
When Admin enters valid values and change the name od claim category
Then Claim category is successfully changed
When Admin clicks on delete link and clicks on delete button
#Then claim is not visible in the table

Scenario: Create And Assert Claim Category
Given User logs in as admin and navigates on Claim category page 2
When Admin enters valid values in create claim category form
Then Admin is redirected on claim categories list 
When Admin logs out and logs in as contractor 1
Then On home page new claim category is showed