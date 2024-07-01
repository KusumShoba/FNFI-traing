//StringEncoder
using System;
using System.Collections.Generic;
using System.Text;

public class Program
{
    public static string EncodeString(string inputString)
    {
        // Convert input string to lowercase to make case-insensitive
        inputString = inputString.ToLower();

        // Split the input into words based on space
        string[] words = inputString.Split();

        List<string> encodedChars = new List<string>();

        // Iterate through each word and encode the characters
        for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
        {
            string word = words[wordIndex];
            
            for (int charIndex = 0; charIndex < word.Length; charIndex++)
            {
                char currentChar = word[charIndex];
                
                // Find the position of the current character in the inputString
                int position = inputString.IndexOf(currentChar) + 1;
                
                // Generate the code by combining wordIndex and charIndex
                int wI=wordIndex + 1;
                int cI=charIndex + 1;
                //int code ={wI+cI};
                string code = (wordIndex + 1)+""+(charIndex + 1);

                //string code = "{wordIndex + 1}{charIndex + 1}";
                encodedChars.Add(code);
            }
        }

        // Join the encoded characters with comma and replace space with hyphen
        string encodedString = string.Join(",", encodedChars);
        encodedString = encodedString.Replace(" ", "-");

        return encodedString;
    }

    public static void Main(string[] args)
    {
        string inputText = "The quick and brown fox jumps over the Lazy Dog";
        string encodedOutput = EncodeString(inputText);
        Console.WriteLine(encodedOutput);
    }
}