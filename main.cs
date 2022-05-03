using System;


class TestSentence
{
    static void ChoseSentences(ref string[] sentences, ref string[] answers, int rangeStart, int rangeEnd)
    {
        StreamReader sr;
        Random randomNum = new Random();
        List<int> randomNumList = new List<int>();
        string[] readLine = new string[2];
        int lineCount, count = 0;
        
        for (int i = rangeStart; i < rangeEnd; i++)
        {
            sr = new StreamReader(@$"C:\Projects\cs\EnglishSentenceTest\english_sentence{i}.txt");
            lineCount = File.ReadLines(@$"C:\Projects\cs\EnglishSentenceTest\english_sentence{i}.txt").Count();

            while(randomNumList.Count < 10)
            {
                randomNumList.Add(randomNum.Next(lineCount / 2));
            }
            
            foreach (int index in randomNumList)
            {
                for (int j = 0; j < index; j++)
                {
                    readLine[0] = sr.ReadLine();
                    readLine[1] = sr.ReadLine();
                }
                
                sentences[count] = readLine[0];
                answers[count] = readLine[1];

                count++;
            }
        }

    }
    static void Main(string[] args)
    {
        string[] testRange = new string[2];
        int rangeStart, rangeEnd;
        string readAnswer;
        string[] sentences = new string[1];
        string[] answers = new string[1];

        while(true)
        {
            testRange = Console.ReadLine().Split();

            rangeStart = int.Parse(testRange[0]);
            rangeEnd = int.Parse(testRange[1]);

            Array.Resize(ref sentences, 10 * (rangeEnd - rangeStart + 1));
            Array.Clear(sentences, 0, sentences.Length);
            Array.Resize(ref answers, 10 * (rangeEnd - rangeStart + 1));
            Array.Clear(answers, 0, sentences.Length);
        
            ChoseSentences(ref sentences, ref answers, rangeStart, rangeEnd);
        
            for (int i = 0; i < sentences.Length; i++)
            {
                Console.WriteLine(sentences[i]);

                readAnswer = Console.ReadLine();
            
                if (readAnswer == answers[i]) Console.WriteLine("Correct Answer");
                else Console.WriteLine($"Answer is {answers[i]}");
            }

            Console.WriteLine("RE? YES or NO");
            readAnswer = Console.ReadLine();

            if (readAnswer == "NO") break;
        }
    }
}