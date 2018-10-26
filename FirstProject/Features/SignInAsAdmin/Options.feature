Feature: Options
In order to test pages
As an admin 
I want to be able to access the system after I enter my credencials and to test my options as admin

@mytag
Scenario: Download Report On Invoice Validator Page
Given User navigates to Invoice Validator web application 1
When User logs in as Admin 1
And Admin is on home page 1
And User clicks on Invoice Validator button and select accounting period 
Then User clicks on Check request button and downloads request

Scenario: Change Language Admin
Given User navigates to Invoice Validator Web application 6
When User logs in as Admin 6
And Admin is on home page 6
When User clicks on RS option language is changed
Then User clicks on EN option and back to english