using System;
using System.Collections.Generic;
using System.Threading;

class Piano
{
    private int[] currentOctave;
    private List<int[]> octaves;

    public Piano()
    {
        octaves = new List<int[]>();
        octaves.Add(new int[] { 200, 300, 400 }); 
        currentOctave = octaves[0]; 
    }

    public void Play()
    {
        Console.WriteLine("Для игры на пианино используйте клавиши A, S, D, F, G, H, J, K, L");
        Console.WriteLine("Используйте клавиши F1, F2, F3 и т.п. для переключения октав");

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                    break;

                if (keyInfo.Key >= ConsoleKey.F1 && keyInfo.Key <= ConsoleKey.F12)
                {
                    int octaveIndex = (int)keyInfo.Key - (int)ConsoleKey.F1;
                    if (octaveIndex < octaves.Count)
                        currentOctave = octaves[octaveIndex];
                }
                else
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.A:
                            PlaySound(currentOctave[0]);
                            break;
                        case ConsoleKey.S:
                            PlaySound(currentOctave[1]);
                            break;
                        case ConsoleKey.D:
                            PlaySound(currentOctave[2]);
                            break;
                            
                    }
                }
            }
        }
    }

    private void PlaySound(int frequency)
    {
        Console.Beep(frequency, 500); 
    }
}

class Program
{
    static void Main(string[] args)
    {
        Piano piano = new Piano();
        piano.Play();
    }
}