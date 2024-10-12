using System;
using System.Collections.Generic;
using System.IO;

namespace lab3
{
    public class CalculateFile
    {
        static int[] dx = { -1, 1, 0, 0 };
        static int[] dy = { 0, 0, -1, 1 };

        public static void ProcessFiles()
        {
            var (maze, N, M, tigerX, tigerY) = ReadInput("INPUT.TXT");

            int shortestPathLength = FindShortestPath(maze, N, M);
            bool canEscape = CanEscape(maze, N, M, tigerX, tigerY);

            WriteOutput("OUTPUT.TXT", shortestPathLength, canEscape);
        }

        static (char[,], int, int, int, int) ReadInput(string filename)
        {
            string[] input = File.ReadAllLines(filename);
            string[] dimensions = input[0].Split();
            int N = int.Parse(dimensions[0]);
            int M = int.Parse(dimensions[1]);
            char[,] maze = new char[N, M];

            int tigerX = -1, tigerY = -1;

            for (int i = 0; i < N; i++)
            {
                string line = input[i + 1];
                for (int j = 0; j < M; j++)
                {
                    maze[i, j] = line[j];
                    if (line[j] == 'T')
                    {
                        tigerX = i;
                        tigerY = j;
                    }
                }
            }
            return (maze, N, M, tigerX, tigerY);
        }

        static int FindShortestPath(char[,] maze, int N, int M)
        {
            Queue<(int x, int y, int distance)> queue = new Queue<(int, int, int)>();
            bool[,] visited = new bool[N, M];

            queue.Enqueue((1, 1, 0));
            visited[1, 1] = true;

            while (queue.Count > 0)
            {
                var (x, y, distance) = queue.Dequeue();

                if (x == N - 2 && y == M - 2)
                {
                    return distance;
                }

                for (int d = 0; d < 4; d++)
                {
                    int newX = x + dx[d];
                    int newY = y + dy[d];

                    if (IsInBounds(newX, newY, N, M) && maze[newX, newY] != '#' && !visited[newX, newY])
                    {
                        visited[newX, newY] = true;
                        queue.Enqueue((newX, newY, distance + 1));
                    }
                }
            }

            return -1;
        }

        static bool CanEscape(char[,] maze, int N, int M, int tigerX, int tigerY)
        {
            Queue<(int x, int y)> tigerQueue = new Queue<(int, int)>();
            Queue<(int x, int y)> slaveQueue = new Queue<(int, int)>();
            bool[,] tigerVisited = new bool[N, M];
            bool[,] slaveVisited = new bool[N, M];

            tigerQueue.Enqueue((tigerX, tigerY));
            slaveQueue.Enqueue((1, 1)); 
            tigerVisited[tigerX, tigerY] = true;
            slaveVisited[1, 1] = true;

            while (tigerQueue.Count > 0 || slaveQueue.Count > 0)
            {
                if (tigerQueue.Count > 0)
                {
                    var (x, y) = tigerQueue.Dequeue();

                    MoveTigerToSlave(maze, N, M, tigerQueue, tigerVisited, x, y, slaveQueue);
                }

                if (slaveQueue.Count > 0)
                {
                    var (x, y) = slaveQueue.Dequeue();

                    for (int d = 0; d < 4; d++)
                    {
                        int newX = x + dx[d];
                        int newY = y + dy[d];

                        if (IsInBounds(newX, newY, N, M) && maze[newX, newY] != '#' && !slaveVisited[newX, newY])
                        {
                            slaveVisited[newX, newY] = true;
                            slaveQueue.Enqueue((newX, newY));

                            if (newX == N - 2 && newY == M - 2) 
                            {
                                if (tigerVisited[newX, newY])
                                {
                                    return false; 
                                }
                                return true; 
                            }
                        }
                    }
                }
            }
            return false; 
        }

        static void MoveTigerToSlave(char[,] maze, int N, int M, Queue<(int x, int y)> tigerQueue, bool[,] tigerVisited, int tigerX, int tigerY, Queue<(int x, int y)> slaveQueue)
        {
            for (int d = 0; d < 4; d++)
            {
                int newX = tigerX + dx[d];
                int newY = tigerY + dy[d];

                if (IsInBounds(newX, newY, N, M) && maze[newX, newY] != '#' && !tigerVisited[newX, newY])
                {
                    tigerVisited[newX, newY] = true;
                    tigerQueue.Enqueue((newX, newY));

                    foreach (var (slaveX, slaveY) in slaveQueue)
                    {
                        if (newX == slaveX && newY == slaveY)
                        {
                            return; 
                        }
                    }
                }
            }
        }

        static bool IsInBounds(int x, int y, int N, int M)
        {
            return x >= 0 && x < N && y >= 0 && y < M;
        }

        static void WriteOutput(string filename, int shortestPathLength, bool canEscape)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.Write(shortestPathLength);
                writer.Write(canEscape ? "No" : "Yes" );
            }
        }
    }
}
