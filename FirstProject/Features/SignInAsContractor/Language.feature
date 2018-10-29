Feature: Language
In order to test pages
As an contractor 
I want to be able to access the system after I enter my credencials and to change language

@mytag
Scenario: Change Language
Given User logs in as Contractor 
When Contractor is on home page 
When User clicks on RS option language is changed 2
Then User clicks on EN option and back to english 2