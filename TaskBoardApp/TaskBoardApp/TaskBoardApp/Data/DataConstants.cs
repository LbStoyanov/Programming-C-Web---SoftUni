﻿namespace TaskBoardApp.Data
{
    public class DataConstants
    {
        public class User
        {
            public const int MaxUserFirstName = 15;
            public const int MaxUserLastName = 15;
            
        }

        public class Task
        {
            public const int MaxTaskTitle = 70;
            public const int MinTaskTitle = 5;

            public const int MaxTaskDescription = 1000;
            public const int MinTaskDescription = 10;
        }

        public class Board
        {
            public const int MaxBoardName = 30;
            public const int MinBoardName = 3;
        }
    }
}
