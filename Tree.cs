using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    
    public class Node
    { 
        public int Value{get;set;}
        public Node Left { get; set; }
        public Node Right { get; set; }
        public bool Present { get; set; }
    }

    class Tree
    {
        private string message = "";
        public Node Root { get; set; }

        public void InsertItem(int value)
        {
            bool flag = true;
            Node n = new Node
            {
                Value = value,
                Present = true
            };
            if (Root == null)
            {
                Root = n;
                flag = false;
            }

            Node ptr = Root;
            while (flag == true)
            {
                if (ptr.Value > value)
                {
                    if (ptr.Left == null)
                    {
                        ptr.Left = n;
                        flag = false;
                    }
                    else
                        ptr = ptr.Left;

                }
                else if (ptr.Right == null)
                {
                    ptr.Right = n;
                    flag = false;
                }
                else
                    ptr = ptr.Right;
            }

        }
        public string DisplayTree()
        {

            //if (start != null)
            //{
            //    message += " " + start.Value;
            //    DisplayTree(start.Left);
            //    DisplayTree(start.Right);
            //}

            message = BuildTree(Root);

            return message;
        }
        public string BuildTree(Node start)
        {
            if (start != null)
            {
                message += " " + start.Value;
                BuildTree(start.Left);
                BuildTree(start.Right);
            }


            return message;
        }

        public bool FindItem(int val)
        {
            Node ptr = Root;
            while (ptr != null)
            {
                if (ptr.Value == val && ptr.Present == true)
                    return true;
                if (ptr.Value > val)
                    ptr = ptr.Left;
                else
                    ptr = ptr.Right;


            }
            return false;
        }
        public bool DeleteItem(int val)
        {
            if (Root == null)
                return false;
            Node ptr = Root;
            while (ptr != null)
            {
                if (ptr.Value == val && ptr.Present == true)
                {
                    ptr.Present = false;
                    return true;
                }

                if (ptr.Value > val)
                    ptr = ptr.Left;
                else
                    ptr = ptr.Right;
            }
            return false;
        }
        /// <summary>
        /// search the tree for value and return it
        /// if the node doesnt exist return the next largest value
        /// if there is nothing left to return -1
        /// </summary>
        public int FindNext(int val)
        {
            int i = -1;
            int big = FindBig();
            bool found = false;
            if (val > big)
            {
                return -1;

            }

            var ptr = Root;


            //do
            while (ptr != null /*|| found == false*/)
            {
                //if (ptr == null)
                //    return -1;
                if (ptr.Value == val && ptr.Present)
                {
                    found = true;
                    return ptr.Value;
                }                   
                if (ptr.Value > val )
                    ptr = ptr.Left;
                else 
                    ptr = ptr.Right;
  

            }
            //while (ptr != null || found == false);

           val++;
           return  FindNext(val);
            //if (ptr == null)
            //    return -1;
            return ptr.Value;

            
        }
        public int FindBig()
        {
            Node ptr = Root;
            int num = Root.Value;
            while (ptr != null)
            {
                
                
                    num = ptr.Value;
                    ptr = ptr.Right;
                
            }
            return num;
        }
        public int DeleteNext(int val)
        {
           
            int big = FindBig();
            
            if (val > big)
            {
                return -1;

            }

            var ptr = Root;


          
            while (ptr != null )
            {
                
                if (ptr.Value == val && ptr.Present)
                {
                    DeleteItem(val);
                    return val;
                }
                if (ptr.Value > val)
                    ptr = ptr.Left;
                else
                    ptr = ptr.Right;


            }
           

            val++;
            return DeleteNext(val);

        }
    }
}
