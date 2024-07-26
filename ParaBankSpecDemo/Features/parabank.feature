Feature: ParaBankDemo

@mytag
Scenario: Navigate with quick links
	Given that the Parabank homepage is open
	When the "<leftPanelLink>" link is clicked
	Then I am directed to the "<expectedHeader>" page

Examples:
	| leftPanelLink | expectedHeader             |
	| About Us      | ParaSoft Demo              |
	| Services      | Bookstore SOAP             |
	| Products      | Innovative and Intelligent |
	| Locations     | Automation Solutions       |