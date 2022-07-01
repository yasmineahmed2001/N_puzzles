using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
namespace N_Puzzel_Project
{
    class Program //O(N^4)
    {
        static int indexn0, indexi0;//O(1)
        static string choice;//O(1)
        public static int x, y = 0;//O(1)
        static FileStream choosefile()//O(N)
        {           
            FileStream d;//O(1)
            Console.WriteLine("________________________________________");//O(1)
            Console.WriteLine("|\tIs it A kind of model\t\t|\n"
                + "|\t[a]Simple \t\t\t|\n" + "|\t[b]Complete \t\t\t|\n" + "|\t( Enter your choice A or B )\t|");//O(1)
            Console.WriteLine("________________________________________");//O(1)
        HERE://O(N)
            Console.Write(" ====> ");//O(1)
            string choice = Console.ReadLine();//O(N)
            if (choice == "a" || choice == "A")//O(1) * O(N) --> O(N)
            {
                Console.WriteLine("________________________________________");//O(1)
                Console.WriteLine("|\tIs it A kind of text\t\t|\n" 
                    + "|\t1-8 Puzzle (1)\t\t\t|\n" + "|\t2-8 Puzzle - Case 1\t\t|\n" + "|\t3-8 Puzzle (2)\t\t\t|\n"
                    + "|\t4-8 Puzzle (3)\t\t\t|\n" + "|\t5-8 Puzzle(2) - Case 1\t\t|\n" + "|\t6-8 Puzzle(3) - Case 1\t\t|\n"
                    + "|\t7-15 Puzzle - 1\t\t\t|\n" + "|\t8-24 Puzzle 1\t\t\t|\n" + "|\t9-15 Puzzle - Case 2\t\t|\n" + "|\t10-15 Puzzle - Case 3\t\t|\n"
                    + "|\t11-24 Puzzle 2\t\t\t|");//O(1)
                Console.WriteLine("________________________________________");//O(1)
                Console.Write(" ====> ");//O(1)
                string txt = Console.ReadLine();//O(N)
                if (txt == "1") return d = new FileStream("Testcases/Sample/Solvable Puzzles/8 Puzzle (1).txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "2") return d = new FileStream("Testcases/Sample/Unsolvable Puzzles/8 Puzzle - Case 1.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "3") return d = new FileStream("Testcases/Sample/solvable Puzzles/8 Puzzle (2).txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "4") return d = new FileStream("Testcases/Sample/Solvable Puzzles/8 Puzzle (3).txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "5") return d = new FileStream("Testcases/Sample/Unsolvable Puzzles/8 Puzzle(2) - Case 1.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "6") return d = new FileStream("Testcases/Sample/Unsolvable Puzzles/8 Puzzle(3) - Case 1.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "7") return d = new FileStream("Testcases/Sample/Solvable Puzzles/15 Puzzle - 1.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "8") return d = new FileStream("Testcases/Sample/Solvable Puzzles/24 Puzzle 1.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "9") return d = new FileStream("Testcases/Sample/Unsolvable Puzzles/15 Puzzle - Case 2.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "10") return d = new FileStream("Testcases/Sample/Unsolvable Puzzles/15 Puzzle - Case 3.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "11") return d = new FileStream("Testcases/Sample/Solvable Puzzles/24 Puzzle 2.txt", FileMode.Open, FileAccess.Read);//O(N)
                else Console.WriteLine("invalid source\n" + "press a or b to choose again\n");//O(1)
            }
            else if (choice == "b" || choice == "B")//O(1)
            {
                Console.WriteLine("________________________________________");//O(1)
                Console.WriteLine("|\tIs it A kind of text\t\t|\n" + "|\t1-50 Puzzle\t\t\t|\n" + "|\t2-99 Puzzle - 1\t\t\t|\n"
                    + "|\t3-99 Puzzle - 2\t\t\t|\n" + "|\t4-9999 Puzzle\t\t\t|\n" + "|\t5-15 Puzzle 1\t\t\t|\n" + "|\t6-15 Puzzle 3\t\t\t|\n"
                    + "|\t7-15 Puzzle 4\t\t\t|\n" + "|\t8-15 Puzzle 5\t\t\t|\n" + "|\t9-15 Puzzle 1 - Unsolvable\t|\n"
                    + "|\t10-99 Puzzle - Unsolvable Case 1|\n" + "|\t11-99 Puzzle - Unsolvable Case 2|\n"
                    + "|\t12-9999 Puzzle - Unsolvable case|\n" + "|\t13-TEST\t\t\t\t|");//O(1)
                Console.WriteLine("________________________________________");//O(1)
                Console.Write(" ====> ");//O(1)
                string txt = Console.ReadLine();//O(N)
                if (txt == "1") return d = new FileStream("Testcases/Complete/Solvable puzzles/Manhattan & Hamming/50 Puzzle.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "2") return d = new FileStream("Testcases/Complete/Solvable puzzles/Manhattan & Hamming/99 Puzzle - 1.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "3") return d = new FileStream("Testcases/Complete/Solvable puzzles/Manhattan & Hamming/99 Puzzle - 2.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "4") return d = new FileStream("Testcases/Complete/Solvable puzzles/Manhattan & Hamming/9999 Puzzle.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "5") return d = new FileStream("Testcases/Complete/Solvable puzzles/Manhattan Only/15 Puzzle 1.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "6") return d = new FileStream("Testcases/Complete/Solvable puzzles/Manhattan Only/15 Puzzle 3.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "7") return d = new FileStream("Testcases/Complete/Solvable puzzles/Manhattan Only/15 Puzzle 4.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "8") return d = new FileStream("Testcases/Complete/Solvable puzzles/Manhattan Only/15 Puzzle 5.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "9") return d = new FileStream("Testcases/Complete/Unsolvable puzzles/15 Puzzle 1 - Unsolvable.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "10") return d = new FileStream("Testcases/Complete/Unsolvable puzzles/99 Puzzle - Unsolvable Case 1.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "11") return d = new FileStream("Testcases/Complete/Unsolvable puzzles/99 Puzzle - Unsolvable Case 2.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "12") return d = new FileStream("Testcases/Complete/Unsolvable puzzles/9999 Puzzle.txt", FileMode.Open, FileAccess.Read);//O(N)
                else if (txt == "13") return d = new FileStream("Testcases/Complete/V. Large test case/TEST.txt", FileMode.Open, FileAccess.Read);//O(N)
                else Console.WriteLine("invalid source\n" + "press a or b to choose again\n");//O(1)
            }
            goto HERE;//O(1)
        }
        static int getnumberofversion(int N, int[] arr2)//O(S^2)
        {
            int num_of_version = 0;//O(1)
            for (int i = 0; i < N * N - 1; i++)//O(S) * O(S) --> O(S^2)
                for (int j = i + 1; j < N * N; j++)//O(S) * O(1) --> O(S)
                    if (arr2[j] != 0 && arr2[i] != 0 && arr2[i] > arr2[j])//O(1)
                        num_of_version++;//O(1)
            return num_of_version;//O(1)
        }
        static bool isSolvable(int N, int[] puzzle)//O(S^2) //O(N^4)
        {
            bool num = false;//O(1)
            int num_of_Inversions = getnumberofversion(N, puzzle);//O(S^2)
            //number odd and version even
            if (N % 2 != 0 && num_of_Inversions % 2 == 0)//O(1)
                num = true;//O(1)
            //number even
            //1-version odd w blank even
            //2-version even w blank odd
            else if (N % 2 == 0)//O(1)
            {
                if (num_of_Inversions % 2 != 0 && (N - indexn0 + 2) % 2 == 0)//O(1)
                    num = true;//O(1)
                else if (num_of_Inversions % 2 == 0 && (N - indexn0 + 2) % 2 != 0)//O(1)
                    num = true;//O(1)
            }
            else
                num = false;//O(1)
            if (num)//O(1)
                Console.WriteLine("This puzzel is Solvable");//O(1)
            else//O(1)
                Console.WriteLine("This puzzel  is Nan_Solvable");//O(1)
            return num;//O(1)
        }
        static void Main(string[] args)
        {
            FileStream file_puzzle = choosefile();//O(N)
            StreamReader sr = new StreamReader(file_puzzle);//O(N)
            string[] vertices = sr.ReadLine().Split(' ');//O(N)
            int cases = int.Parse(vertices[0]);//O(1)
            int[,] arr = new int[cases, cases];//O(1)
            int[] arr2 = new int[cases * cases];//O(1)
            int n = 0, counter = 0;//O(1)
            while (n < cases)//O(NlogN)
            {
                String line = sr.ReadLine();//O(N)
                if (line == "")//O(1)
                    continue;//O(1)
                string[] only_line = line.Split(' ');//O(N)
                int i = 0;//O(1)
                while (i < cases)//O(logN)
                {
                    arr2[counter] = int.Parse(only_line[i]);//O(1)
                    arr[n, i] = int.Parse(only_line[i]);//O(1)
                    if (int.Parse(only_line[i]) == 0)//O(1)
                    {
                        indexn0 = n;//O(1)
                        indexi0 = i;//O(1)
                    }
                    i++;
                    counter++;//O(1)
                }
                n++;//O(1)
            }
            Console.WriteLine("________________________________________");//O(1)
            Console.WriteLine("|\tIs it A kind of model\t\t|\n" + "|\t[1] Hamming\t\t\t|\n"
                + "|\t[2] Manhattan\t\t\t|\n" + "|\t[3] Hamming &Manhattan\t\t|\n"
                + "|\t( Enter your choice 1 or 2 )\t|");//O(1)
            Console.WriteLine("________________________________________");//O(1)
            Console.Write(" ====> ");//O(1)
            string choose = Console.ReadLine();//O(N)
            int x, y = 0;//O(1)
            //x = Environment.TickCount;
            if (choose == "1")//O(N ^ 4)
            {             
                Stopwatch t = new Stopwatch();//O(1)
                t.Start();//O(1)
                // Check If Board Is Solvable Or Not 
                if (isSolvable(cases, arr2))//O(N ^ 4)
                {
                    Puzzel start = new Puzzel(cases, arr, indexn0, indexi0);//O(N^2)
                    Hamming A = new Hamming();//O(N^2)
                    A.A_Star_Algorithm_wiht_hamming(start);//E(log(v))
                    t.Stop();//O(1)
                    var s = t.Elapsed;//O(1)
                    Console.WriteLine("Time Taken In S : " + ((s)));//O(1)
                }             
            }
            else if (choose == "2")//O(N ^ 4)
            {
                Stopwatch t = new Stopwatch();//O(1)
                t.Start();//O(1)
                // Check If Board Is Solvable Or Not 
                if (isSolvable(cases, arr2))//O(N ^ 4)
                {
                    Puzzel start = new Puzzel(cases, arr, indexn0, indexi0);//O(N^2)
                    Manhattan A = new Manhattan();
                    A.A__Algorithm(start);//E(log(v))
                    t.Stop();//O(1)
                    var s = t.Elapsed;//O(1)
                    Console.WriteLine("Time Taken In S : " + ((s)));//O(1)
                }
            }
            else if (choose == "3")//O(1)
            {
                Stopwatch t = new Stopwatch();//O(1)
                t.Start();//O(1)
                if (isSolvable(cases, arr2))//O(N ^ 4)
                {
                    Puzzel start = new Puzzel(cases, arr, indexn0, indexi0);//O(N^2)
                    Console.WriteLine("------MANHATTAN------");//O(1)
                    Manhattan M = new Manhattan();//O(N^2)
                    M.A__Algorithm(start);//E(log(v))
                    Hamming A = new Hamming();//O(N^2)
                    Console.WriteLine("------HAMMING------");//O(1)
                    A.A_Star_Algorithm_wiht_hamming(start);//E(log(v))
                    t.Stop();//O(1)
                    var s = t.Elapsed;//O(1)
                    Console.WriteLine("Time Taken In S : " + ((s)));//O(1)
                }
            }
            else
                Console.WriteLine(" No Feasible Solution For The Given Board ");//O(1)
        }
    }
}
 