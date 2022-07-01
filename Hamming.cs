using System;
using System.Collections.Generic;
using System.Text;

namespace N_Puzzel_Project
{        
    class Hamming //O(N^2)
    {
        static int Exit = 0;//O(1)
        public Dictionary<string, Puzzel> Open_child = new Dictionary<string, Puzzel>();
        public Dictionary<string, Puzzel> closed_child = new Dictionary<string, Puzzel>();
        public Priority_Queue PQ_list = new Priority_Queue();
        public List<Puzzel> Path_Of_Res = new List<Puzzel>();

        //***********************************************************************************
        public void Get_final_Path(Puzzel final) //(log(v)) //O(N log N)
        {
            Puzzel prnt = final.parent; //O(1)
            int size = final.puzzel_size; //O(1)
            while (prnt.parent != null) //O(N)
            {
                Path_Of_Res.Add(prnt); //O(1)
                prnt = prnt.parent; //O(1)
            }
            Path_Of_Res.Add(prnt); //O(1)
            Display_(size); //O(N log N)
        }

        //***********************************************************************************
        public void Display_(int size)//O(N log N)
        {
            if (Exit == 0) //O(1) * O(N ^ 2) --> O(N ^ 2)
            {
                int num = Path_Of_Res.Count; //O(1)
                if (size == 3) //O(N log N)
                {
                    for (int i = num - 1; i >= 0; i--) //O(N) * //O(log N) ==>O(N log N)
                    {
                        Path_Of_Res[i].Display();//O(log N)
                    }
                }
                Console.WriteLine("--> ( Number of Movements = " + (num - 1) + " )"); //O(1)
            }
            Exit = 1; //O(1)
        }

        //***********************************************************************************
        public bool Child_Open(Puzzel child)//O(N)
        {
            if (Open_child.ContainsKey(child.key) == true) //O(N)
            {
                return true; //O(1)
            }
            else
                return false; //O(1)
        }

        //***********************************************************************************
        public Puzzel Create_New_Child(Puzzel p) //O(N^2)
        {
            if (p.check_Movement_value(1,0,0,0)==true) //O(N^2)
            {
                Puzzel child = new Puzzel(p); //O(N^2)
                bool check; //O(1)
                child.UP_movement(); //O(N)
                child.Hamming(); //O(logN)
                child.Calculate_cost_of_hamming(); //O(1)

                if (child.IS_reache_to_goal_hamming() == true) //O(N logN)
                {
                    child.direction_of_moves = "Goal"; //O(1)
                    Path_Of_Res.Add(child); //O(1)
                    return child;
                }
                child.direction_of_moves = "UP"; //O(1)
                check = Child_Open(child); //O(N)

                if (check == false) //O(N log N)
                {
                    PQ_list.Enqueue(child);//O(N log N)
                    Open_child.Add(child.key, child); //O(1)
                }
            }

            if (p.check_Movement_value(0, 1, 0, 0) == true)//O(N^2)
            {
                Puzzel child = new Puzzel(p);//O(N^2)
                bool check;//O(1)
                child.Down_movement();//O(N)
                child.Hamming();//O(logN)
                child.Calculate_cost_of_hamming();//O(1)

                if (child.IS_reache_to_goal_hamming() == true) //O(N logN)
                {
                    child.direction_of_moves = "Goal"; //O(1)
                    Path_Of_Res.Add(child); //O(1)
                    return child;
                }

                child.direction_of_moves = "Down";//O(1)
                check = Child_Open(child);//O(N)

                if (check == false) //O(N logN)
                {
                    PQ_list.Enqueue(child);//O(N logN)
                    Open_child.Add(child.key, child); //O(1)
                }
            }

            if (p.check_Movement_value(0, 0, 1, 0) == true)//O(N^2)
            {
                Puzzel child = new Puzzel(p);//O(N^2)
                bool check;//O(1)
                child.Left_movement();//O(N)
                child.Hamming();//O(logN)
                child.Calculate_cost_of_hamming();//O(1)

                if (child.IS_reache_to_goal_hamming() == true) //O(N logN)
                {
                    child.direction_of_moves = "Goal"; //O(1)
                    Path_Of_Res.Add(child); //O(1)
                    return child;
                }
                child.direction_of_moves = "Left";//O(1)
                check = Child_Open(child);//O(N)

                if (check == false) //O(N logN)
                {
                    PQ_list.Enqueue(child);//O(N logN)
                    Open_child.Add(child.key, child); //O(1)
                }
            }

            if (p.check_Movement_value(0, 0, 0, 1) == true)//O(N^2)
            {
                Puzzel child = new Puzzel(p);//O(N^2)
                bool check;//O(1)
                child.Right_movement();//O(N)
                child.Hamming();//O(logN)
                child.Calculate_cost_of_hamming();//O(1)
                if (child.IS_reache_to_goal_hamming() == true) //O(N logN)
                {
                    child.direction_of_moves = "Goal"; //O(1)
                    Path_Of_Res.Add(child); //O(1)
                    return child;
                }
                child.direction_of_moves = "Right";//O(1)
                check = Child_Open(child);//O(N)

                if (check == false) //O(N logN)
                {
                    PQ_list.Enqueue(child);//O(N logN)
                    Open_child.Add(child.key, child); //O(1)
                }
            }
            return null;
        }

        //***********************************************************************************
        public int Closed_child(Puzzel N)//O(N ^ 3)
        {
            if (closed_child.ContainsKey(N.key) == true) //O(N) * O(N ^ 2) --> O(N ^ 3)
            {
                //check if cost of cloed one less than 
                Puzzel check = closed_child[N.key]; //O(1)
                if (check.cost < N.cost) //O(N ^ 2) * O(1) --> O(N ^ 2)
                {
                    PQ_list.Enqueue(check);//O(N ^ 2)
                    Open_child.Add(check.key, check);//O(1)
                }
                return 0; //O(1)
            }
            return 1;  //O(1)
        }

        //***********************************************************************************
        public void A_Star_Algorithm_wiht_hamming(Puzzel First)//E(log v)
        {
            Open_child.Add(First.key, First);//O(1)
            PQ_list.Enqueue(First);//O(N log N)
            while (Exit == 0)//E(log(v))
            {
                Puzzel New = new Puzzel(PQ_list.Dequeue(), 0);//O(N^2)
                if (Closed_child(New) == 1)//O(N^2)
                {
                    closed_child.Add(New.key, New);//O(1)
                    Puzzel Last = Create_New_Child(New);//O(N^2)
                    if (Last != null)//O(1)
                    {
                        Get_final_Path(Last);
                    }
                }
            }
        } 
    }
}
