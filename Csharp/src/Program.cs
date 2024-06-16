namespace WordCounter;

public class Program
{
    public static void Main(string[] args)
    {
        if (!ValidateArgs(args))
        {
            return;
        }

        SearchQuery query = ParseArgs(args);

        int wordCount = GetTotalWordAccurence(query);

        Console.WriteLine($"Word '{query.SearchWord}' appears {wordCount} times in the file '{query.FilePath}'");
    }

    public static bool ValidateArgs(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Usage: WordCounter <file-path>");
            return false;
        }

        if (!File.Exists(args[0]))
        {
            Console.WriteLine("File does not exist.");
            return false;
        }

        return true;
    }

    public static SearchQuery ParseArgs(string[] args)
    {
        string filePath = args[0];
        string searchWord = Path.GetFileNameWithoutExtension(filePath);

        return new SearchQuery(filePath, searchWord);
    }

    public static int GetTotalWordAccurence(SearchQuery query)
    {
        int totalWordCount = 0;

        using StreamReader reader = new(query.FilePath);

        while (!reader.EndOfStream)
        {
            string? line = reader.ReadLine();

            totalWordCount += CountWordAccurences(line, query.SearchWord);
        }

        return totalWordCount;
    }

    public static int CountWordAccurences(string? line, string word)
    {
        if (string.IsNullOrEmpty(line))
        {
            return 0;
        }

        int wordCount = line.Split(' ').Count(w => w == word);

        return wordCount;
    }
}
