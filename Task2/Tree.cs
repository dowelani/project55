using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Task2
{
    class Tree
    {
        BTNode Root = null;


        public bool balancedHeight()
        /* A height-balanced binary tree is a binary tree where the depth of 
         * the two subtrees of every node in the tree never differs by more than 1.
         * 
         * pre:  Have a binary tree (Root) which may be empty.
         * post: Return true if Root is height-balanced, otherwise return false. */ 
        {
            if (Root == null || (Root.left() == null && Root.right() == null)) //if tree is empty or only has a one node(the root node) then (Root) is balanced
            {
                return true;
            }

            return check(Root);
        }
        private bool check(BTNode T)
        {
            if (T == null) { return true; }
            else
            {
                int hleft = d(T.left()) - 1;     //gets depth of left subtree
                int hright = d(T.right()) - 1;   //gets depth of right subtree 
                if (Math.Abs(hleft - hright) <= 1 && (check(T.left()) && check(T.right()))) //if depth of the two subtrees of every node in the tree never differs by more than 1 return true else return false           
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private int d(BTNode T)
        {
            if (T == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(d(T.right()), d(T.left())); //
            }
        }
        // NO MODIFICATIONS TO METHODS BELOW

        public Tree(String Expr)
        {
            Root = doBuild(Expr);
        }

        private String getSubtree(String Expr, int i)
        {
            int count = 0;
            String subTree = "";
            while (true)
            {
                subTree += Expr[i];
                switch (Expr[i])
                {
                    case '(': count++;
                        break;
                    case ')': count--;
                        break;
                    default: break;
                }
                i++;
                if (count <= 0)
                    break;
            }
            return subTree;
        }

        private BTNode doBuild(String Expr)
        {
            if (Expr.Length <= 2)
                return null;
            if (Expr.Length == 3) 
            {
                return new BTNode(Expr[1]);
            }
            BTNode parent = new BTNode(Expr[1]);
            String leftSubtree = getSubtree(Expr, 2);
            String rightSubtree = getSubtree(Expr, 2 + leftSubtree.Length); 
            parent.setLeft(doBuild(leftSubtree));
            parent.setRight(doBuild(rightSubtree));
            return parent;
        }

        public void displayTreeStructure()
        // with thanks to Minnaar Fullard (WRA202 Class of 2014)
        // adapted from Will's answer at http://stackoverflow.com/questions/1649027/how-do-i-print-out-a-tree-structure
        {
            if (Root != null)
                PrintPretty(Root, "", false);
            Console.WriteLine();
            //Console.WriteLine("Press enter to continue");
            //Console.ReadLine();
        }

        public void PrintPretty(BTNode node, String indent, bool rightChild)
        {
            String output = Convert.ToString((char)node.value());
            if (!node.isRoot())
            {
                if (node.isLeft())
                    output += " ~l";
                else
                    output += " ~r";
            }
            Console.Write(indent);
            if (rightChild)
            {
                Console.Write(" /--");
                indent += " | ";
            }
            else
                if (!node.isRoot())
            {
                Console.Write(" \\--");
                indent += "   ";
            }
            Console.WriteLine("{0}", output);
            if (node.left() != null && node.right() != null)
            {
                PrintPretty(node.right(), indent, true);
                PrintPretty(node.left(), indent, false);
            }
            else if (node.left() != null)
            {
                PrintPretty(node.left(), indent, true);
            }
            else if (node.right() != null)
            {
                PrintPretty(node.right(), indent, true);
            }
        }


    }
}

