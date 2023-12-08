Feature: DistanceMeasurement

A short summary of the feature

@tag1
Scenario: User selects miles as distance measurement
    Given the user selects miles
    When the user enters a distance
    Then the distance should be in miles
