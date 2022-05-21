using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AI_Project_8_Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] puzzle =
             {
                1, 2, 4,
                3, 0, 5,
                7, 6, 8
            };
            Node root = new Node(puzzle);
            UninformedSearch ui = new UninformedSearch();

            List<Node> solution = ui.BreadthFirstSearch(root);

            
            if (solution.Count > 0)
            {
                solution.Reverse();
                for (int i = 0; i < solution.Count; i++)
                    solution[i].PrintPuzzle();

            }
            else
            {
                Console.WriteLine("No Path to solution is found");
            }
            Console.Read();
        }

         
    }
}
