Feature: EditProfile
In order to test pages
As an admin 
I want to be able to access the system after I enter my credencials and to test editing
my profile

@mytag
Scenario: Edit Profile Invalid Values
Given User logs in as Admin 14
When Admin is on home page 14
When Admin navigates on Profile page and delete First name and Last name
Then Error messages are showed 10
When User enters invalid values in edit profile page
Then Error messages are showed 11

Scenario: Edit Profile Valid Values
Given User Logs in as admin and navigate on Profile page
When User changes name and last name 
Then User's changes are saved and he is redirected in Home page
When User navigates on profile Page and clicks on back button