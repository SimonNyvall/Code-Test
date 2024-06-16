using WordCounter;

namespace CS_tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        string[] args = ["file.txt", "file2.txt"];

        // Act
        bool result = Program.ValidateArgs(args);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ValidateArgs_WithNonExistingFile_ReturnsFalse()
    {
        // Arrange
        string[] args = ["notAFile.txt"];

        // Act
        bool result = Program.ValidateArgs(args);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void ValidateArgs_WithExistingFile_ReturnsTrue()
    {
        // Arrange
        string[] args = ["file.txt"];
        File.WriteAllText(args.First(), "This is a test file.");

        // Act
        bool result = Program.ValidateArgs(args);

        // Assert
        Assert.True(result);

        // Clean up
        File.Delete(args.First());
    }

    [Fact]
    public void ParseArgs_WithValidArgs_ReturnsValidArgs()
    {
        // Arrange
        string[] args = ["file.txt"];

        // Act
        SearchQuery result = Program.ParseArgs(args);

        // Assert
        Assert.Equal("file.txt", result.FilePath);
    }

    [Fact]
    public void CountWordAccurences_WithNullLine_ReturnsZero()
    {
        // Arrange
        string? line = null;
        string word = "test";

        // Act
        int result = Program.CountWordAccurences(line, word);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void CountWordAccurences_WithNoMatchingWord_ReturnsZero()
    {
        // Arrange
        string line = "This is a test line.";
        string word = "word";

        // Act
        int result = Program.CountWordAccurences(line, word);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void CountWordAccurences_WithMatchingWord_ReturnsOne()
    {
        // Arrange
        string line = "This is a test line.";
        string word = "test";

        // Act
        int result = Program.CountWordAccurences(line, word);

        // Assert
        Assert.Equal(1, result);
    }

    // case sensitive test
    [Fact]
    public void CountWordAccurences_WithMatchingWordCaseSensitive_ReturnsZero()
    {
        // Arrange
        string line = "This is a test line.";
        string word = "Test";

        // Act
        int result = Program.CountWordAccurences(line, word);

        // Assert
        Assert.Equal(0, result);
    }
}

