﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// You are free to add anything else you would like to this program,
        /// however the maze solving part needs to occur in the MazeSolver class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /// <summary>
            /// Starting Coordinates.
            /// </summary>
            const int X_START = 1;
            const int Y_START = 1;

            ///<summary>
            /// The first maze that needs to be solved.
            /// Note: You may want to make a smaller version to test and debug with.
            /// You don't have to, but it might make your life easier.
            /// </summary>
            char[,] maze1 = 
            { { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
              { '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
              { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
              { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
              { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', '.' },
              { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
              { '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
              { '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
              { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
              { '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '#' },
              { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
              { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' } };

            MazeSolver mazeSolver = new MazeSolver();

            showMaze(maze1); //Show base maze
            char[,] maze2 = transposeMaze(maze1); 

            char[,] maze1Solved = mazeSolver.SolveMaze(maze1, Y_START, X_START); //pass maze1 into the solver object, it returns the solved maze we save as maze1Solved
            showMaze(maze1Solved); //Show the solved maze1Solved

            //Create the second maze by transposing the first maze, and show it

            showMaze(maze2); //Show the (should be) blank maze2

            //Solve the transposed maze.
            char[,] maze2Solved = (mazeSolver.SolveMaze(maze2, Y_START, X_START));
            showMaze(maze2Solved);

        }

        /// <summary>
        /// This method will take in a 2 dimensional char array and return
        /// a char array maze that is flipped along the diagonal, or in mathematical
        /// terms, transposed.
        /// ie. if the array looks like 1, 2, 3
        ///                             4, 5, 6
        ///                             7, 8, 9
        /// The returned result will be:
        ///                             1, 4, 7
        ///                             2, 5, 8
        ///                             3, 6, 9
        /// The current return statement is just a placeholder so the program
        /// doesn't complain about no return value.
        /// </summary>
        /// <param name="mazeToTranspose"></param>
        /// <returns>transposedMaze</returns>
        static char[,] transposeMaze(char[,] mazeToTranspose)
        {
            //Write code here to create a transposed maze.
            char[,] transposedMaze = new char[mazeToTranspose.GetLength(0), mazeToTranspose.GetLength(1)];

            for (int y = 0; y < mazeToTranspose.GetLength(0); y++)
            {   //Go through the rows
                for (int x = 0; x < mazeToTranspose.GetLength(1); x++)
                {   //Go through the columns
                    transposedMaze[y, x] = mazeToTranspose[x, y];
                }
            }

            return transposedMaze;
        }

        static void showMaze(char[,] mazeToShow)
        {   //Method to show the array passed to the method
            for (int y = 0; y < mazeToShow.GetLength(0); y++)
            {
                for (int x = 0; x < mazeToShow.GetLength(1); x++)
                {
                    Console.Write(mazeToShow[y, x] + " ");

                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
