using System;
using System.Linq;

namespace MovieManager
{
    public class MovieCollection
    {
        public class Node
        {
            public Movie Data;
            public Node Left;
            public Node Right;
            public Node(Movie i)
            {
                Data = i;
                Left = Right = null;
            }
            public void DisplayNode()
            {
                Data.DisplayDetails();
            }
        }

        public Node root;
        private int numMovies = 0;

        public MovieCollection()
        {
            root = null;
        }

        // new node precedes current node (new node goes left)
        //if (key.GetTitle().CompareTo(root.Data.GetTitle()) < 0)
        public void Insert(Movie i)
        {
            root = InsertRec(root, i);
        }

        Node InsertRec(Node root, Movie key)
        {
            // If tree is empty, return new node 
            if (root == null)
            {
                root = new Node(key);
                return root;
            }

            // Otherwise, recur down the tree 
            if (key.GetTitle().CompareTo(root.Data.GetTitle()) < 0)
                root.Left = InsertRec(root.Left, key);
            else if (key.GetTitle().CompareTo(root.Data.GetTitle()) > 0)
                root.Right = InsertRec(root.Right, key);
            // return the (unchanged) node pointer
            numMovies++;
            return root;
        }
        public void Remove(Movie key)
        {
            root = DeleteRec(root, key);
        }

        Node DeleteRec(Node root, Movie key)
        {
            // Base Case: If the tree is empty
            if (root == null) return root;

            // Otherwise, recur down the tree
            if (key.GetTitle().CompareTo(root.Data.GetTitle()) < 0)
                root.Left = DeleteRec(root.Left, key);
            else if (key.GetTitle().CompareTo(root.Data.GetTitle()) > 0)
                root.Right = DeleteRec(root.Right, key);

            // if key is same as root's key, then This is the node  
            // to be deleted  
            else
            {
                // node with only one child or no child  
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)
                    return root.Left;

                root.Data = MinValue(root.Right);

                // Delete the inorder successor  
                root.Right = DeleteRec(root.Right, root.Data);
            }
            numMovies--;
            return root;
        }

        Movie MinValue(Node root)
        {
            Movie minv = root.Data;
            while (root.Left != null)
            {
                minv = root.Left.Data;
                root = root.Left;
            }
            return minv;
        }

        public Movie SearchMovie(Node root, string title)
        {
            // Traverse untill root reaches to dead end 
            while (root != null)
            {
                // pass right subtree as new tree 
                if (title.CompareTo(root.Data.GetTitle()) > 0)
                    root = root.Right;

                // pass left subtree as new tree 
                else if (title.CompareTo(root.Data.GetTitle()) < 0)
                    root = root.Left;
                else
                    return root.Data; // if the key is found return 1 
            }
            return null;
        }
        
        public int GetNumMovies()
        {
            return numMovies;
        }

        public void DisplayAllMovies(Node node)
        {
            if (root == null)
                Console.WriteLine("No movies added yet!");
            if (node != null)
            {
                // in order traversal (in alphabetical order)
                DisplayAllMovies(node.Left);
                node.DisplayNode();
                Console.WriteLine();
                DisplayAllMovies(node.Right);
            }
        }
        public void DisplayTop10Borrowed()
        {
            // LIMIT TO 10
            int size = 10;
            Movie[] results = new Movie[size];
            extractValues(root, results, 0);
            var sorted = results.Where(result => result != null).OrderByDescending(result => result.GetTimesBorrowed());
            foreach (var rankMovie in sorted)
            {
                Console.WriteLine("{0} has been borrowed: {1} times", rankMovie.GetTitle(), rankMovie.GetTimesBorrowed());
            }
        }

        private int extractValues(Node node, Movie[] results, int index)
        {
            if (node.Left != null)
            {
                index = extractValues(node.Left, results, index);
            }

            if (node.Right != null)
            {
                index = extractValues(node.Right, results, index);
            }

            results[index] = node.Data;

            return index + 1;
        }
    }
}
