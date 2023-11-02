using System;
using System.Collections.Generic;

namespace DailyPlanner
{
    class Program
    {
        static List<Note> notes;
        static int currentIndex;

        static void Main(string[] args)
        {
            InitializeNotes();
            currentIndex = 0;

            ConsoleKeyInfo keyInfo;
            do
            {
                Console.Clear();
                ShowMenu();

                keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        MoveToPreviousNote();
                        break;
                    case ConsoleKey.RightArrow:
                        MoveToNextNote();
                        break;
                    case ConsoleKey.Enter:
                        ShowNoteDetails();
                        break;
                }
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        static void InitializeNotes()
        {
            notes = new List<Note>();

            // Пример разных заметок с разными датами
            notes.Add(new Note { Title = "Заметка 1", Description = "Описание заметки 1", Date = new DateTime(2022, 6, 6) });
            notes.Add(new Note { Title = "Заметка 2", Description = "Описание заметки 2", Date = new DateTime(2022, 6, 8) });
            notes.Add(new Note { Title = "Заметка 3", Description = "Описание заметки 3", Date = new DateTime(2022, 6, 13) });
            // Добавьте остальные заметки с разными датами здесь
        }

        static void ShowMenu()
        {
            Console.WriteLine("Ежедневник");

            Note currentNote = notes[currentIndex];
            Console.WriteLine($"Дата: {currentNote.Date.ToShortDateString()}");
            Console.WriteLine();

            Console.WriteLine("Заметки:");
            for (int i = 0; i < notes.Count; i++)
            {
                if (i == currentIndex)
                    Console.WriteLine($"- {notes[i].Title} <");
                else
                    Console.WriteLine($"- {notes[i].Title}");
            }

            Console.WriteLine("\nИспользуйте стрелки влево-вправо для навигации, Enter для просмотра деталей, Esc для выхода");
        }

        static void MoveToNextNote()
        {
            currentIndex++;
            if (currentIndex >= notes.Count)
                currentIndex = 0;
        }

        static void MoveToPreviousNote()
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = notes.Count - 1;
        }

        static void ShowNoteDetails()
        {
            Console.Clear();
            Note selectedNote = notes[currentIndex];

            Console.WriteLine("Детали заметки");
            Console.WriteLine($"Название: {selectedNote.Title}");
            Console.WriteLine($"Описание: {selectedNote.Description}");
            Console.WriteLine($"Дата: {selectedNote.Date.ToShortDateString()}");
            // Добавьте остальные детали заметки по желанию

            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
        }
    }

    class Note
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}