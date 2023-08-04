# SmartInMediaCodingTest
# Gilded Rose Refactoring Kata - C#
# Smart In Media Test Code

This repository contains a C# implementation of the Gilded Rose Refactoring Kata. The original kata was created by Terry Hughes, and this version of the code has been refactored and improved for better maintainability and readability.

## How to Access the Source Code

You can access the source code by forking this repository. Follow these steps:

1. Visit the GitHub repository at [https://github.com/aljaserm/SmartInMediaCodingTest.git](https://github.com/aljaserm/SmartInMediaCodingTest.git).

2. Click on the "Fork" button at the top right corner of the page. This will create a copy of the repository in your GitHub account.

3. Once the forking process is complete, you can clone the repository to your local machine using the following command (replace `<your-github-username>` with your actual GitHub username):

   ```
   git clone https://github.com/<your-github-username>/SmartInMediaCodingTest.git
   ```

Now you have the source code on your local machine and can explore it further.

## How to Compile and Run the Code

To compile and run the code, you need the .NET SDK installed on your machine. You can download it from the official .NET website: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).

After installing .NET SDK, navigate to the root directory of the cloned repository (where the .csproj file is located) using the command prompt or terminal.

### Compile the Code

To compile the code, use the following command:

```
dotnet build
```

### Run the Tests

This implementation includes unit tests to verify the correctness of the code. To run the tests, use the following command:

```
dotnet test
```

The test results will be displayed in the terminal, indicating whether all tests passed successfully or if there were any failures.

## Changes Made

During the refactoring process, the following changes were made to improve the code:

1. **Helper Methods**: Added helper methods `ItemExists` and `GetItem` to simplify the test code and avoid duplication.

2. **Improved Test Coverage**: Expanded the test suite to cover more scenarios and edge cases, ensuring better validation of the code logic.

3. **Enhanced Code Readability**: Renamed test methods and variables to have more descriptive names, making the code easier to understand.

4. **Documentation**: Included comments in the test file to explain each test's purpose and its expected outcome.

## Test Method Definitions

Below is an explanation of each test method in the `GildedRoseTest` class:

1. `NormalItemQualityDecreasesByOne`: This test ensures that the quality of a normal item decreases by one after a single update.

2. `NormalItemSellInDecreasesByOne`: This test checks that the sell-in value of a normal item decreases by one after a single update.

3. `NormalItemQualityDegradesTwiceAsFastAfterSellIn`: This test verifies that the quality of a normal item degrades twice as fast after the sell-in date has passed.

4. `AgedBrieQualityIncreasesByOne`: This test validates that the quality of Aged Brie increases by one after a single update.

5. `AgedBrieQualityIncreasesTwiceAsFastAfterSellIn`: This test ensures that the quality of Aged Brie increases twice as fast after the sell-in date has passed.

6. `QualityNeverExceedsFifty`: This test checks that the quality of an item never exceeds 50, even if its value is updated.

7. `SulfurasQualityNeverChanges`: This test verifies that the quality of Sulfuras remains constant and never changes, regardless of updates.

8. `BackstagePassQualityIncreasesByOne`: This test ensures that the quality of a Backstage Pass increases by one after a single update.

9. `BackstagePassQualityIncreasesByTwoWhenSellInIsTenOrLess`: This test validates that the quality of a Backstage Pass increases by two when its sell-in value is ten or less.

10. `BackstagePassQualityIncreasesByThreeWhenSellInIsFiveOrLess`: This test checks that the quality of a Backstage Pass increases by three when its sell-in value is five or less.

11. `BackstagePassQualityDropsToZeroAfterConcert`: This test verifies that the quality of a Backstage Pass drops to zero after the concert date has passed.

12. `ConjuredItemQualityDecreasesByTwo`: This test ensures that the quality of a Conjured item decreases by two after a single update.

13. `ConjuredItemQualityDegradesTwiceAsFastAfterSellIn`: This test validates that the quality of a Conjured item degrades twice as fast after the sell-in date has passed.

14. `ConjuredItemQualityNeverDropsBelowZero`: This test checks that the quality of a Conjured item never drops below zero, even if its value is updated.

15. `NonExistingItemDoesNotExistAfterUpdate`: This test ensures that a non-existing item is removed from the list of items after an update.

Feel free to explore the source code and run the tests to see the Gilded Rose Refactoring Kata in action. If you encounter any issues or have suggestions for further improvements, you can create an issue or submit a pull request in the GitHub repository.

