// See https://aka.ms/new-console-template for more information
using PeripassTest.FileHandler;
using PeripassTest.Models;
using PeripassTest.Processors;
using PeripassTest.Test;

Console.WriteLine("\nThe Program Started Reading the input file...");

// step 1: read the source file
// step 2: find all words that are 6 characters(target words)
// step 3: fird all words that are < 6 characters
// step 4: Find parts of the target word 
// step 5: Combine parts to check if they make the target word
// step 6: Store the matching word to a list for later to use in the testing part
// step 7: Test the solution


string relativeSourcePath = "..\\..\\..\\Sources\\input.txt";

FileReader fileReader = new(relativeSourcePath);

List<string> content = fileReader.GetContent();

if (content != null)
{
    TargetResult targetResult = ContentProcessor.ProcessContent(content);

    bool testResult = AppTest.TestingTwoListsEquality(targetResult.TargetWords, targetResult.Results);

    // Testing the solution

    Console.WriteLine("\n---------Test Result----------");
    Console.WriteLine(testResult ? "The Solution Works...\nHave a nice day\n\n" : "The Solution Does not Work...\n\n");
}
else
{
    Console.WriteLine("\nThe Source File Has No Content!\n");
}

