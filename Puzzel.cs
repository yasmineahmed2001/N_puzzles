using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace N_Puzzel_Project
{
    struct Movements//O(1)
    {
        public bool up;
        public bool down;
        public bool left;
        public bool right;
    }

    class Puzzel //O(N^2)
    {
        public int[,] puzzel_2D_array;//O(1)
        public int puzzel_size, blank_space_i, blank_space_j, hamming_value, manhattan_value, cost, number_of_level; //number of moves tree level  //O(1)
        public String direction_of_moves , key="";//O(1)
        public Puzzel parent;//O(1)
        public Movements mov;//O(1)
        //*****************************************************************************************
        public Puzzel(int size, int[,] puzzel , int blank_i , int blank_j)//O(N^2)
        {
            puzzel_2D_array = puzzel; //O(N)
            puzzel_size = size; //O(1)
            blank_space_i = blank_i; //O(1)
            blank_space_j = blank_j; //O(1)
            direction_of_moves = "Start"; //O(1)
            Hamming(); //O(N)
            manhattan(); //O(N)
            number_of_level = 0; //O(1)
            parent = null; //O(1)

            for (int x = 0; x < puzzel_size * puzzel_size; x++)//O(N) * O(N) --> O(N^2)
            {
                int i = x / puzzel_size; //O(1)
                int j = x % puzzel_size; //O(1)
                puzzel_2D_array[i, j] = puzzel[i, j]; //O(N)
                key += puzzel[i, j];  //O(1)
            }
        }     
        //*****************************************************************************************
        public Puzzel(Puzzel p, int x)//O(N^2)
        {
            puzzel_size = p.puzzel_size; //O(1)
            puzzel_2D_array = new int[puzzel_size, puzzel_size]; //O(1)
            blank_space_i = p.blank_space_i;//O(1)
            blank_space_j = p.blank_space_j;//O(1)
            number_of_level = p.number_of_level;//O(1)
            parent = p; //O(1)
            cost = p.cost; //O(1)
            key = p.key; //O(1)
            hamming_value = p.hamming_value; //O(1)
            manhattan_value = p.manhattan_value; //O(1)

            for (int y = 0; y < puzzel_size * puzzel_size; y++)//O(N) * O(N) --> O(N^2)
            {
                int i = y / puzzel_size; //O(1)
                int j = y % puzzel_size; //O(1)
                puzzel_2D_array[i, j] = p.puzzel_2D_array[i, j]; //O(N)

            }
        }

        //***************copy constructor**************************************************************************
        public Puzzel(Puzzel p)//O(N^2)
        {
            puzzel_size = p.puzzel_size; //O(1)
            puzzel_2D_array = new int[puzzel_size, puzzel_size]; //O(1)
            blank_space_i = p.blank_space_i; //O(1)
            blank_space_j = p.blank_space_j; //O(1)
            number_of_level = p.number_of_level + 1; //O(1)
            parent = p.parent;

            for (int x = 0; x < puzzel_size * puzzel_size; x++)//O(N) * O(N) --> O(N^2)
            {
                int i = x / puzzel_size; //O(1)
                int j = x % puzzel_size; //O(1)
                puzzel_2D_array[i, j] = p.puzzel_2D_array[i, j]; //O(N)
            }
         }

        //*****************************************************************************************
        public void Hamming()//O(log N)
        {
            /* ex
             * ==> 1  2  3  4  5  6  7  8 
             * ==> 1  1  0  0  1  1  0  0
             * hamming_value = 4;
             */
            int miss_position = 0; //O(1)  // number of blocks out of place
            int correct_position = 1; //O(1)  // position correct number allocation
            int i = 0, j = 0;//O(1)
            while (i < puzzel_size)//O(log N)
            {
                if (i != puzzel_size - 1 && j != puzzel_size - 1)//O(1)
                {
                    key += this.puzzel_2D_array[i, j];//O(1)
                    if (puzzel_2D_array[i, j] != correct_position && puzzel_2D_array[i, j] != 0) //O(1) //blank space
                    {
                        miss_position++;//O(1)
                    }
                    correct_position++;//O(1)
                    j++;//O(1)
                }
                else if (i != puzzel_size - 1 && j == puzzel_size - 1)//O(1)
                {
                    key += this.puzzel_2D_array[i, j];//O(1)
                    if (puzzel_2D_array[i, j] != correct_position && puzzel_2D_array[i, j] != 0) //O(1)  //blank space
                    {
                        miss_position++;//O(1)
                    }
                    correct_position++;//O(1)
                    j = 0;//O(1)
                    i++;//O(1)
                }
                else if (i == puzzel_size - 1 && j != puzzel_size - 1)//O(1)
                {
                    key += this.puzzel_2D_array[i, j];//O(1)
                    if (puzzel_2D_array[i, j] != correct_position && puzzel_2D_array[i, j] != 0) //O(1)  //blank space
                    {
                        miss_position++;//O(1)
                    }
                    correct_position++;//O(1)
                    j++;//O(1)
                }
                else
                {
                    key += this.puzzel_2D_array[i, j];//O(1)
                    if (puzzel_2D_array[i, j] != correct_position && puzzel_2D_array[i, j] != 0)//O(1) //blank space
                    {
                        miss_position++;//O(1)
                    }
                    correct_position++;//O(1)
                    hamming_value = miss_position;//O(1)
                    break;//O(1)
                }
            }
        }

        //*****************************************************************************************

        public void manhattan()//O(log N)
        {
            int i = 0, j = 0, cnt = 0, RES = 0;//O(1)
            while (i < puzzel_size)//O(log N)
            {
                if (i != puzzel_size - 1 && j != puzzel_size - 1)//O(1)
                {
                    this.key += this.puzzel_2D_array[i, j];//O(1)
                    int val = this.puzzel_2D_array[i, j];//O(1)
                    RES++;//O(1)
                    if (val != 0 && val != RES)//O(1)
                    {
                        int temp1 = ((val - 1) / puzzel_size);//O(1)
                        int temp2 = ((val - 1) % puzzel_size);//O(1)
                        cnt += Math.Abs(i - temp1) + Math.Abs(j - temp2);//O(1)
                    }
                    j++;//O(1)
                }
                else if (i != puzzel_size - 1 && j == puzzel_size - 1)//O(1)
                {
                    this.key += this.puzzel_2D_array[i, j];//O(1)
                    int val = this.puzzel_2D_array[i, j];//O(1)
                    RES++;//O(1)
                    if (val != 0 && val != RES)//O(1)
                    {
                        int temp1 = ((val - 1) / puzzel_size);//O(1)
                        int temp2 = ((val - 1) % puzzel_size);//O(1)
                        cnt += Math.Abs(i - temp1) + Math.Abs(j - temp2);//O(1)
                    }
                    j = 0;//O(1)
                    i++;//O(1)
                }
                else if (i == puzzel_size - 1 && j != puzzel_size - 1)//O(1)
                {
                    this.key += this.puzzel_2D_array[i, j];//O(1)
                    int val = this.puzzel_2D_array[i, j];//O(1)
                    RES++;//O(1)
                    if (val != 0 && val != RES)//O(1)
                    {
                        int temp1 = ((val - 1) / puzzel_size);//O(1)
                        int temp2 = ((val - 1) % puzzel_size);//O(1)
                        cnt += Math.Abs(i - temp1) + Math.Abs(j - temp2);//O(1)
                    }
                    j++;//O(1)
                }
                else
                {
                    this.key += this.puzzel_2D_array[i, j];//O(1)
                    int val = this.puzzel_2D_array[i, j];//O(1)
                    RES++;//O(1)
                    if (val != 0 && val != RES)//O(1)
                    {
                        int temp1 = ((val - 1) / puzzel_size);//O(1)
                        int temp2 = ((val - 1) % puzzel_size);//O(1)
                        cnt += Math.Abs(i - temp1) + Math.Abs(j - temp2);//O(1)
                    }
                    manhattan_value = cnt;//O(1)
                    break;//O(1)
                }
            }
        }

        //*****************************************************************************************

        public void Calculate_cost_of_hamming()//O(1)
        { 
            // f(n) = g(n) + h(n)
            cost = number_of_level + hamming_value;//O(1)
        }
        public void Calculate_cost_Manhattan()//O(1)
        {
            /*f(n) = g(n) + h(n)*/
            cost = number_of_level + manhattan_value;//O(1)
        }

        //*****************************************************************************************

        public bool IS_reache_to_goal_hamming()//O(1)
        {
            // f(n) = g(n) + 0
            if (hamming_value == 0)//O(1)
            {
                return true;//O(1)
            }
            else
            { 
                return false;//O(1)
            }
        }
        public bool IS_reache_to_goal_manhattan()//O(1)
        {
            // f(n) = g(n) + 0
            if (manhattan_value == 0)//O(1)
            {
                return true;//O(1)
            }
            else
            {
                return false;//O(1)
            }
        }
        /*********************************************Movement**********************************************/
        /*  j/i | 0  1  2
         *  ----|----------
         *   0  | 4  1  3
         *   1  | 0  2  5
         *   2  | 7  8  6
         */
        public int UP_movement() //O(N)
        {           
            int swap_part = puzzel_2D_array[blank_space_i - 1, blank_space_j];//O(1)
            puzzel_2D_array[blank_space_i,blank_space_j] = swap_part;//O(N)
            swap_part = 0;//O(1)
            puzzel_2D_array[blank_space_i - 1, blank_space_j] = swap_part;//O(N)
            // To know where blank space is it 
            blank_space_i = blank_space_i - 1;//O(1)
            return puzzel_2D_array[blank_space_i, blank_space_j];//O(1)
        }

        public int Down_movement()//O(N)
        {
            int swap_part = puzzel_2D_array[blank_space_i + 1, blank_space_j];//O(1)
            puzzel_2D_array[blank_space_i, blank_space_j] = swap_part;//O(N)
            swap_part = 0; //O(1)  //position = 0 
            puzzel_2D_array[blank_space_i + 1, blank_space_j] = swap_part;//O(N)
            // To know where blank space is it 
            blank_space_i = blank_space_i + 1;//O(1)
            return puzzel_2D_array[blank_space_i, blank_space_j];//O(1)

        }
       
        public int Left_movement()//O(N)
        {
            int swap_part = puzzel_2D_array[blank_space_i, blank_space_j - 1];//O(1)
            puzzel_2D_array[blank_space_i, blank_space_j] = swap_part;//O(N)
            swap_part = 0;//O(1)   //position = 0 
            puzzel_2D_array[blank_space_i, blank_space_j - 1] = swap_part;//O(N)
            // To know where blank space is it 
            blank_space_j = blank_space_j - 1;//O(1)
            return puzzel_2D_array[blank_space_i, blank_space_j];//O(1)
        }
       
        public int Right_movement()//O(N)
        {
            int swap_part = puzzel_2D_array[blank_space_i, blank_space_j + 1];//O(1)
            puzzel_2D_array[blank_space_i, blank_space_j] = swap_part;//O(N)
            swap_part = 0; //O(1)  //position = 0 
            puzzel_2D_array[blank_space_i, blank_space_j + 1] = swap_part;//O(N)
            // To know where blank space is it 
            blank_space_j = blank_space_j + 1;//O(1)
            return puzzel_2D_array[blank_space_i, blank_space_j];//O(1)
        }


        public bool check_Movement_value(int u, int d, int l, int r)//O(N)
        {
            if (u == 1)//O(N)
            {
                if (blank_space_i != 0)//O(1)
                {
                    mov.up = true;//O(N)
                }
                return mov.up;//O(1)
            }
            if (d == 1)//O(N)
            {
                if (blank_space_i != puzzel_size - 1)//O(1)
                {
                    mov.down = true;//O(N)
                }
                return mov.down;//O(1)
            }
            if (l == 1)//O(N)
            {
                if (blank_space_j != 0)//O(1)
                {
                    mov.left = true;//O(N)
                }
                return mov.left;//O(1)
            }
            if (r == 1)//O(N)
            {
                if (blank_space_j != puzzel_size - 1)//O(1)
                {
                    mov.right = true;//O(N)
                }
                return mov.right;//O(1)
            }
            else
                return false;//O(1)
        }

        /*********************************************End of movement********************************************/

        public void Display()//O(log N)
        {
            int i = 0, j = 0, cn = 0;//O(1)
            while (i < puzzel_size)//O(log N)
            {
                if (cn == i && cn % puzzel_size == 0)//O(1)
                {
                    Console.WriteLine(" ---> " + direction_of_moves);//O(1)
                    cn++;//O(1)
                }
                if (i != puzzel_size - 1 && j != puzzel_size - 1)//O(1)
                {
                    Console.Write(puzzel_2D_array[i, j]);//O(1)
                    Console.Write(" ");//O(1)
                    j++;//O(1)
                }
                else if (i != puzzel_size - 1 && j == puzzel_size - 1)//O(1)
                {
                    Console.Write(puzzel_2D_array[i, j]);//O(1)
                    Console.WriteLine();//O(1)
                    j = 0;//O(1)
                    i++;//O(1)
                }
                else if (i == puzzel_size - 1 && j != puzzel_size - 1)//O(1)
                {
                    Console.Write(puzzel_2D_array[i, j]);//O(1)
                    Console.Write(" ");//O(1)
                    j++;//O(1)
                }
                else
                {
                    Console.Write(puzzel_2D_array[i, j]);//O(1)
                    Console.WriteLine("\n");//O(1)
                    break;//O(1)
                }
            }
        }

    }

}

