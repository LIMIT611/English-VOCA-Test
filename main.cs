using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class TestSentence
{
    static void ChoseSentences(ref string[] sentences, ref string[] answers, int range)
    {
        StreamReader sr;
        Random randomNum = new Random();
        List<int> randomNumList = new List<int>();
        string[] readLine = new string[2];
        int count = 0, randomNumber;

        while(randomNumList.Count < sentences.Length)
        {
            randomNumber = randomNum.Next(sentences.Length);
            
            if (randomNumList.Contains(randomNumber) == false) randomNumList.Add(randomNumber);
        }
        
        foreach (int index in randomNumList)
        {
            sr = new StreamReader(@$"C:\Projects\cs\EnglishSentenceTest\english_sentences\day{range}.txt");

            for (int j = 0; j <= index; j++)
            {
                readLine[0] = sr.ReadLine();
                readLine[1] = sr.ReadLine();
            }
                
            sentences[count] = readLine[0];
            answers[count] = readLine[1];

            count++;
        }

    }


    static void Main(string[] args)
    {
        int range;
        string readAnswer;
        string[] sentences = new string[1];
        string[] answers = new string[1];

        while(true)
        {
            Console.WriteLine();
            Console.WriteLine("테스트할 범위를 입력하세요");
            range = int.Parse(Console.ReadLine());
            var lineCount = File.ReadAllLines(@$"C:\Projects\cs\EnglishSentenceTest\english_sentences\day{range}.txt").Length;
            
            Array.Resize(ref sentences, lineCount / 2);
            Array.Clear(sentences, 0, sentences.Length);
            Array.Resize(ref answers, lineCount / 2);
            Array.Clear(answers, 0, sentences.Length);
        
            ChoseSentences(ref sentences, ref answers, range);
        
            for (int i = 0; i < sentences.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine(sentences[i]);

                readAnswer = Console.ReadLine();
            
                if (readAnswer == answers[i]) Console.WriteLine("\nCorrect Answer");
                else Console.WriteLine($"\nAnswer is \"{answers[i]}\"");
            }

            Console.WriteLine("다시할래요? (YES)");
            readAnswer = Console.ReadLine();

            if (readAnswer != "YES") break;
        }

    }
}