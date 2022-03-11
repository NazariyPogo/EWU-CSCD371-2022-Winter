# EWU-CSCD371-2021-Winter

## See [Docs](Docs)

<<<<<<< HEAD
## Assignment 5&6

The purpose of this assignment is to solidify your learning of:

- Lambda expressions
- LINQ with Standard Query Operators
  - Selecting (projection)
  - Filtering
  - Aggregation
  - Sorting
  - Unit testing collections.
- Implementing IEnumerable

Given the amount of material (reading and assignment), **the homework will span two weeks of class with the final submission on Thursday 2/25**. (No assignment is due Thu 2/17)

## Reading

Prior to Thu 2/15:

- Chapter 13: Delegates and Lambda Expressions
- Chapter 15: Collection Interfaces with Standard Query Operators
- Chapter 17: Building Custom Collections (You can skim the More Collection Interfaces and Primary Collection Classes sections)

Prior to Tue 2/22:
=======
## Assignment 9&10

The purpose of this assignment is to solidify your learning of multithreaded programing
with the Task Parallel Library (TPL).

### Due Dates

- Assignment 9&10 is due (even though you are pairing) **Monday March 21, 11:59 PM.**
- Code reviews (be everyone individually) are due **Wednesday March 23, 11:59 PM**. (Thus all PRs will be reviewed twice.)
- Final PR is due **Thursday March 24, 11:59 PM**.
- **The combination of Assignment 9&10 will be graded - starting Friday March 24.**

## Reading

- Chapter 19: Introducing Multithreading
- Chapter 21: Iterating in Parallel

Previously Assigned
>>>>>>> 60e7b3d17ecfe75d00773639ee1d20a5d3fdf804

- Chapter 20: Programming with Task-Based Asynchronous Pattern
- Chapter 22: Thread Synchronization

<<<<<<< HEAD
Recommended But **Not** Required (in order of priority)

- Chapter 19: Introducing Multithreading
- Chapter 21: Iterating in Parallel
- Chapter 18: Reflection, Attributes, and Dynamic Programming
- Chapter 16: LINQ with Query Expressions
- Chapter 14: Events

## Instructions

**Throughout, consider using the `System.Linq.Enumerable` methods `Zip`, `Count`, `Sort` and `Contains` methods for testing collections.**. (Preferably avoid using `Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert` although that might be easier, to get a firmer grasp on additional LINQ API.)

1. Implement the `ISampleData.CsvRows` property, loading the data from the `People.csv` file and returning each line as a single string. ❌✔

   - Change the "Copy to" property on People.csv to "Copy if newer" so that the file is deployed along with your test project. ❌✔
   - Using LINQ, skip the first row in the `People.csv`. ❌✔
   - Be sure to appropriately handle resource (`IDisposable`) items correctly if applicable (and it may not be depending on how you implement it). ❌✔

2. Implement `IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()` to return a **sorted**, **unique** list of states. ❌✔

   - Use `ISampleData.CsvRows` for your data source. ❌✔
   - Don't forget the list should be unique. ❌✔
   - Sort the list alphabetically. ❌✔
   - Include a test that leverages a hardcoded list of Spokane-based addresses. ❌✔
   - Include a test that uses LINQ to verify the data is sorted correctly (do not use a hardcoded list). ❌✔

3. Implement `ISampleData.GetAggregateSortedListOfStatesUsingCsvRows()` to return a `string` that contains a **unique**, comma separated list of states. ❌✔

   - Use `ISampleData.GetUniqueSortedListOfStatesGivenCsvRows()` for your data source. ❌✔
   - Consider "selecting" only the states and calling `ToArray()` to retrieve an array of all the state names. ❌✔
   - Given the array, consider using `string.Join` to combine the list into a single string. ❌✔

4. Implement the `ISampleData.People` property to return all the items in `People.csv` as `Person` objects ❌✔

   - Use `ISampleData.CsvRows` as the source of the data. ❌✔
   - Sort the list by State, City, Zip. (Sort the addresses first then select). ❌✔
   - Be sure that `Person.Address` is also populated. ❌✔
   - Adding null validation to all the `Person` and `Address` properties is **optional**.
   - Consider using `ISampleData.CsvRows` in your test to verify your results. ❌✔

5. Implement `ISampleDate.FilterByEmailAddress(Predicate<string> filter)` to return a list of names where the email address matches the `filter`. ❌✔

   - Use `ISampleData.People` for your data source. ❌✔

6. Implement `ISampleData.GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)` to return a `string` that contains a **unique**, comma separated list of states. ❌✔

   - Use the `people` parameter from `ISampleData.GetUniqueListOfStates` for your data source. ❌✔
   - At a minimum, use `System.Linq.Enumerable.Aggregate` LINQ method to create your result. ❌✔
   - Don't forget the list should be unique. ❌✔
   - It is recommended that, at a minimum, you use `ISampleData.GetUniqueSortedListOfStatesGivenCsvRows` to validate your result.

7. Given the implementation of `Node` in Assignment5

- Implement `IEnumerable<T>` to return all the items in the "circle" of items. ❌✔
- Add an `IEnumberable<T> ChildItems(int maximum)` method to `Node` that returns the remaining items with a maximum number of items returned less than `maximum`.  

## Extra Credit

- Implement the homework using async/await and multi-threading by defining a new `SampleDataAsync` class that implements `IAsyncSampleData`). Refactor your `SampleData` and `SampleDataAsync` classes with minimal duplication. Be sure to refactor your tests to re-use a significant amount of the test code for both implementations. ❌✔
=======
## Instructions

1. Implement `PingProcess`' `public Task<PingResult> RunTaskAsync(string hostNameOrAddress)` ❌✔
   - First implement `public void RunTaskAsync_Success()` test method to test `PingProcess.RunTaskAsync()` using `"localhost"`. ❌✔
   - Do NOT use async/await in this implementation. ❌✔
2. Implement `PingProcess`' `async public Task<PingResult> RunAsync(string hostNameOrAddress)` ❌✔
   - First implement the `public void RunAsync_UsingTaskReturn_Success()` test method to test `PingProcess.RunAsync()` using `"localhost"` **without** using async/await. ❌✔
   - Also implement the `async public Task RunAsync_UsingTpl_Success()` test method to test `PingProcess.RunAsync()` using `"localhost"` but this time **DO** using async/await. ❌✔
3. Add support for an optional cancellation token to the `PingProcess.RunAsync()` signature. ❌✔
   Inside the `PingProcess.RunAsync()` invoke the token's `ThrowIfCancellationRequested()` method so an exception is thrown. ❌✔
   Test that, when cancelled from the test method, the exception thrown is an `AggregateException` ❌✔ with a `TaskCanceledException` inner exception ❌✔ using the test methods `RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrapping` ❌✔and `RunAsync_UsingTplWithCancellation_CatchAggregateExceptionWrappingTaskCanceledException` ❌✔ respectively.
4. Complete/fix **AND test** `async public Task<PingResult> RunAsync(IEnumerable<string> hostNameOrAddresses, CancellationToken cancellationToken = default)` which executes ping for and array of hostNameOrAddresses (which can all be "localhost") **in parallel**, adding synchronization if needed. ❌✔
   NOTE:
      - The order of the items in the stdOutput is irrelevent and expected to be intermingled.
      - StdOutput must have all the ping output returned (no lines can be missing) even though intermingled. ❌✔
5. Implement **AND test** `public Task<int> RunLongRunningAsync(ProcessStartInfo startInfo, Action<string?>? progressOutput, Action<string?>? progressError, CancellationToken token)` using `Task.Factory.StartNew()` and invoking `RunProcessInternal` with a `TaskCreation` value of `TaskCreationOptions.LongRunning` and a `TaskScheduler` value of `TaskScheduler.Current`.
   NOTE: This method does **NOT** use `Task.Run`.

## Extra Credit

- Test and implement `PingProcess.RunAsync(System.IProgress<T> progess)` so that you can capture the output as it occurs rather than capturing the output only when the process finishes. ❌✔
>>>>>>> 60e7b3d17ecfe75d00773639ee1d20a5d3fdf804

## Fundamentals

- Ensure you enable:
  - nullable reference types is enabled ❌✔
  - net6 targeted ❌✔
  - C# 10.0 ❌✔
  - and enabled .NET analyzers for both projects ❌✔
<<<<<<< HEAD
- For this assignment, favor using Assert.AreEqual<T>() (the generic version) ❌✔
- All of the above should be unit tested ❌✔
- Choose simplicity over complexity ❌✔
=======
- All of the above should be unit tested ❌✔
- Choose simplicity over complexity ❌✔
>>>>>>> 60e7b3d17ecfe75d00773639ee1d20a5d3fdf804
