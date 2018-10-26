Feature: AccountingPeriod
In order to test pages
As an admin 
I want to be able to access the system after I enter my credencials and to test 
create and edit accounting period page with invalid values, create and edit new period
with valid values and assert that new accounting period is showen 
in all dropdowns and lists

@mytag
Scenario: Create Accounting Period Invalid 
Given User logs in as admin and navigate on Accouting period create page 1
When Admin clears Year input and click create button
Then Error messages are showed 6
When Admin enters year that is less than 1990.
Then Error messages are showed 7
When Admin enters year that is greater than 2100.
Then Error messages are showed 13
When Admin enters valid year and invalid special characters in claims inputs
Then Error messages are showed 8
When Admin enters valid year and invalid formats in claims inputs
Then Error messages are showed 12
When User select month and enters year for accounting period that already exists
Then Error message is showed 2

Scenario: Create And Assert Accounting Period
Given User logs in as admin and navigate on Accouting period create page 2
When User enters valid values in create accounting period form 2
Then Accounting period is successfully created
When Admin navigates on Invoice Validator home page
Then Admin should be able to select new accounting period
When Admin logs out and logs in as contractor
Then New accounting period should be in create claim dropdown

Scenario: Create And Edit Accounting Period
Given User logs in as admin and navigate on Accouting period create page
When Admin enters valid values in create accounting period page
And Admin navigates on Edit link for created accounting period and deletes all values
Then Error messeges are showed 9
When Admin enters year that is less than 1990. in edit year input
Then Error message is showed 3
When Admin enters year that is greater than 2100. in edit year input
Then Error message is showed 13
When User change claim date values to invalid
Then Error messages showed 9
When User select month and enters year for accounting period that already exists 2
Then Error message is showed 4
When Admin change month, year and claim dates
Then Accounting period is changed