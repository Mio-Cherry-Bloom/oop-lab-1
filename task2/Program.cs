public class FileReader
{
    public string ReadFileIntoString(string path)
    {
        try
        {
            return File.ReadAllText(path);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            return string.Empty;
        }
    }
}

public class TextData
{
    public string FileName ;
    public string Text ;
    public int NumberOfVowels ;
    public int NumberOfConsonants ;
    public int NumberOfLetters ;
    public int NumberOfSentences ;
    public string LongestWord ;

    public TextData(string fileName, string text)
    {
        FileName = fileName;
        Text = text;
        NumberOfVowels = getNumberOfVowels(Text);
        NumberOfConsonants = getNumberOfConsonants(Text);
        NumberOfLetters = getNumberOfLetters(Text);
        NumberOfSentences = getNumberOfSentences(Text);
        LongestWord = getLongestWord(Text);
    }

    private int getNumberOfVowels(string text)
    {
        return text.Count(c => "AEIOUaeiou".Contains(c));
    }

    private int getNumberOfConsonants(string text)
    {
        return text.Count(c => "BCDFGHJKLMNPQRSTVWXYZbcdfghjklmnpqrstvwxyz".Contains(c));
    }
    private int getNumberOfLetters(string text)
    {
        return text.Count(c => "BCDFGHJKLMNPQRSTVWXYZbcdfghjklmnpqrstvwxyzAEIOUaeiou".Contains(c));
    }
    private int getNumberOfSentences(string text)
    {
        return text.Count(c => ".!?".Contains(c));
    }

    private string getLongestWord(string text)
    {
        string[] words = text.Split(new char[] { ' ', '\n', '\r', '\t', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        return words.OrderByDescending(word => word.Length).FirstOrDefault();
    }

    public override string ToString()
    {
        return $"File Name: {FileName}\n" +
               $"Text: {Text}\n" +
               $"Number of Vowels: {NumberOfVowels}\n" +
               $"Number of Consonants: {NumberOfConsonants}\n" +
               $"Number of Letters: {NumberOfLetters}\n" +
               $"Number of Sentences: {NumberOfSentences}\n" +
               $"Longest Word: {LongestWord}";
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        string filePath = args[0];

        FileReader fileReader = new FileReader();
        string textContent = fileReader.ReadFileIntoString(filePath);

        TextData textData = new TextData(filePath, textContent);
        Console.WriteLine(textData);
    }
}
