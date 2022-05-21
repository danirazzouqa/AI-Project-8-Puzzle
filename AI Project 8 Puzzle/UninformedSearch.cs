using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_Project_8_Puzzle
{
    class UninformedSearch
    {
        public UninformedSearch()
        {

        }



        /*  R >> root
            1 2 4
            3 0 5
            7 6 8

            A       B       C       D
            1 2 4   1 2 4   1 0 4   1 2 4
            0 3 5   3 5 0   3 2 5   3 6 5
            7 6 8   7 6 8   7 6 8   7 0 8

            E,F,G - H,I,J - K,L,M - N,O,P

        OpenList
        R
        A B C D
        FROM A>B C D E F G
        FROM B>C D E F G H I J
        FROM C>D E F G H I J K L M
        FROM D>E F G H I J K L M N O P

        ClosedList
        R A B C D
        */


        public List<Node> BreadthFirstSearch(Node root)
        {
            List<Node> PathToSolution = new List<Node>();
            List<Node> OpenList = new List<Node>();
            List<Node> ClosedList = new List<Node>();

            OpenList.Add(root);
            bool GoalFound = false;

            while(OpenList.Count > 0 && !GoalFound)
            {
                Node currentNode = OpenList[0];
                ClosedList.Add(currentNode);
                OpenList.RemoveAt(0);

                currentNode.ExpandNode();
                currentNode.PrintPuzzle();
                for (int i = 0; i < currentNode.children.Count; i++)
                {
                    Node currentchild = currentNode.children[i];
                    if (currentchild.GoalTest())
                    {
                        
                        Console.WriteLine("Goal Found");
                        GoalFound = true;
                        PathTrace(PathToSolution, currentchild);
                    }


                    if(!Contains(OpenList, currentchild) && !Contains(ClosedList, currentchild))
                    {
                        OpenList.Add(currentchild);
                    }
                }
            }

            return PathToSolution;
        }

        public void PathTrace(List<Node> path, Node n)
        {
            Console.WriteLine("Tracing path..");
            Node current = n;
            path.Add(current);
            while (current.parent != null)
            {
                current = current.parent;
                path.Add(current);
            }
        }

        public static bool Contains(List<Node> list, Node c)
        {
            bool contains = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IsSamePuzzle(c.puzzle))
                    contains = true;
            }
            return contains;
        }
    }
}
