using System;
using System.Collections.Generic;
using System.Text;
namespace N_Puzzel_Project
{
    class Priority_Queue //O(N ^ 2)
    {
        public List<Puzzel> PUZZLE = new List<Puzzel>();
        public void Enqueue(Puzzel item)//O(N^2)
        {
            PUZZLE.Add(item);//O(1)
            int child_index = PUZZLE.Count - 1, parent_index;//O(N)
            here://O(N) * O(N) --> O(N^2)
            parent_index = (child_index - 1) / 2;//O(1)
            if ((PUZZLE[child_index].cost) < (PUZZLE[parent_index].cost))//O(N) + O(N) --> O(N)
            {
                Puzzel tmp = PUZZLE[parent_index];//O(N)
                PUZZLE[parent_index] = PUZZLE[child_index];//O(N)
                PUZZLE[child_index] = tmp;//O(N)
                child_index = parent_index;//O(1)
                goto here;//O(1)
            }
        }
        public Puzzel Dequeue()//O(N^2)
        {
            Puzzel frontItem = PUZZLE[0];//O(N)
            int lastindex_beforeremove = PUZZLE.Count - 1;//O(1)
            PUZZLE[0] = PUZZLE[lastindex_beforeremove];//O(N)
            PUZZLE.RemoveAt(lastindex_beforeremove);//O(1)
            int lastindex_afterchange = lastindex_beforeremove - 1;//O(1)
            int parent_index = 0;//O(1)
            again://O(N)
            int leftchild_index = parent_index * 2 + 1;//O(1)
            if (leftchild_index <= lastindex_afterchange)// O(N ^ 2) --> O(N ^ 2)
            {
                int right_children = leftchild_index + 1;//O(1)
                if (right_children <= lastindex_afterchange && PUZZLE[right_children].cost < PUZZLE[leftchild_index].cost)//O(N)
                    leftchild_index = right_children;//O(1)
                if (PUZZLE[parent_index].cost > (PUZZLE[leftchild_index].cost))//O(N) * O(N) --> O(N ^ 2)
                {
                    Puzzel tmp = PUZZLE[parent_index];
                    PUZZLE[parent_index] = PUZZLE[leftchild_index];//O(N)
                    PUZZLE[leftchild_index] = tmp;//O(N)
                    parent_index = leftchild_index;//O(1)
                    goto again;//O(1)
                }
            }
            return frontItem;//O(1)
        }
    }
}