# GartnerAssignmentQA


Identify end-to-end scenarios and build test plans in English for our platform:

# Happy Test Scenarios :-

1. -> For every review Text, Rating, Language should be provided. (Required feild validation)

2. -> Input must be in Text format only. 

3. -> Rating must be in numeric and must be in range(1-5).

4. -> System must be automatically detect language in ISO format provided by the user.

5. -> System must be automatically detect duplicate reviews provided by the user.

# Negative Test Scenarios :-

1. -> Data must not be processed if Rating not numeric and  is not between 1-5.

2. -> Data must not be processed if Language provided by user is invalid. E.g. &*REng68lis3h12

3. -> Data must not be processed if any of one requireed feild is missing (Text, Rating, Language).

# Thoughts:-

1. -> Text Input should have some text input range and accept only alphanumeric format (without special characters) to prevent Sql injection.

2. -> Review should be provided for registered users only. 

3. -> Rating feature text boxes should be tested for SQL injection, JS execution, HTML execution.

4. -> REST API services should use HTTPS, for saving and retrieving rating information.

5. -> Try to save the rating without providing any input, should display proper message .

6. -> Depending on the number of rating compare from different users, system should change the overall ranking of the product in algorithm.

7. -> After user rating system should be considered for calculating overall rating of the product.
