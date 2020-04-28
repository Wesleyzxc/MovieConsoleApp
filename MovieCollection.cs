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

        public void Insert(Movie i)
        {
            root = InsertRec(root, i);
            numMovies++;
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
            // new node precedes current node (new node goes left)
            if (key.GetTitle().CompareTo(root.Data.GetTitle()) < 0)
                root.Left = InsertRec(root.Left, key);
            // new node succeeds current node (new node goes right)
            else if (key.GetTitle().CompareTo(root.Data.GetTitle()) > 0)
                root.Right = InsertRec(root.Right, key);
            
            // return the node pointer
            return root;
        }
        public void Remove(Movie key)
        {
            root = DeleteRec(root, key);
            numMovies--;
        }

        Node DeleteRec(Node root, Movie key)
        {
            // Base Case: If the tree is empty
            if (root == null) return root;

            // Otherwise, recur down the tree
            // new node precedes current node (new node goes left)
            if (key.GetTitle().CompareTo(root.Data.GetTitle()) < 0)
                root.Left = DeleteRec(root.Left, key);
            // new node succeeds current node (new node goes right)
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
                // in order traversal so left first then current node then right(in alphabetical order)
                DisplayAllMovies(node.Left);
                node.DisplayNode();
                Console.WriteLine();
                DisplayAllMovies(node.Right);
            }
        }
        private int ExtractNode(Node node, Movie[] results, int index)
        {
            if (root == null)
                Console.WriteLine("No movies added yet!");

            if (node != null)
            {
                index = ExtractNode(node.Left, results, index);
                results[index] = node.Data;
                index++;
                index = ExtractNode(node.Right, results, index);
            }
            

            return index;
        }
        public void DisplayTop10Borrowed()
        {
            Movie[] results = new Movie[GetNumMovies()];
            ExtractNode(root, results, 0);
            QuickSort(results, 0, GetNumMovies() - 1);
            int loopCount = GetNumMovies() > 10 ? 10 : GetNumMovies();
            for (int i = 0; i < loopCount; i++) // only show top 10
                Console.WriteLine("{0} has been borrowed: {1} times", results[i].GetTitle(), results[i].GetTimesBorrowed());

            
        }
        private int Partition(Movie[] arr, int start, int end)
        {
            Movie temp;
            Movie pivot = arr[end];
            int i = start - 1;
            for (int leftBound = start; leftBound < end ; leftBound++)
            {
                // if current movie is more popular than pivot
                if (arr[leftBound].GetTimesBorrowed() > pivot.GetTimesBorrowed())
                {
                    i++;
                    temp = arr[i];
                    // swaps arr[i] and arr[leftBound]
                    arr[i] = arr[leftBound];
                    arr[leftBound] = temp;
                }
            }

            if (arr[i + 1].GetTimesBorrowed() != arr[end].GetTimesBorrowed())
            { // only swap the first and last if there is a difference
                temp = arr[i + 1];
                arr[i + 1] = arr[end];
                arr[end] = temp;
            }
            return i + 1;
        }
        private void QuickSort(Movie[] arr, int start, int end)
        {
            int i;
            if (start < end)
            {
                i = Partition(arr, start, end);
                QuickSort(arr, start, i - 1);
                QuickSort(arr, i + 1, end);
            }
        }
    }
}
