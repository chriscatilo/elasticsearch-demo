Feature: Stock

Scenario: Get all stock
	Given I navigate to home
		And I know the navigation address for stock
	When I get all stock successfully
	Then I get 240 properties

Scenario: Get stock by id
	When I get stock with Id AUS0000005298 successfully
	Then stock should have the following attributes
		| Name               | Value                   |
		| PropertyID         | AUS0000005298           |
		| OfficeID           | NSWHO                   |
		| PropertyCreateDate | 2015-12-29T17:00:03.660 |
		| PropertyModifyDate | 2015-08-10T19:53:04.860 |
		| Latitude           | -33.804559              |
		| Longitude          | 151.207967              |
		| Bathrooms          | 3                       |
		| Bedrooms           | 4                       |
		| Receptions         | 0                       |
		| PropertyStatus     | 0                       |

Scenario: Search stock by keyword
	When I search for stock successfully
		| Parameter | Argument |
		| Keyword   | road     |
		| MinPrice  | 100000   |
		| MaxPrice  | 650000   |
	Then I get 3 properties