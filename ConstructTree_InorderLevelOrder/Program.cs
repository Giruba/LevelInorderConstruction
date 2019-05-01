using System;

namespace ConstructTree_InorderLevelOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Construct Tree from Inorder and Level order traversals!");
            Console.WriteLine("-------------------------------------------------------");

            Console.WriteLine("Levelorder array");
            int[] levelOrderArray = ArrayUtility.GetArrayFromUser();
            Console.WriteLine("Inorder array");
            int[] inorderArray = ArrayUtility.GetArrayFromUser();
            BinaryTree binaryTree = new BinaryTree(null);
            binaryTree.SetBinaryTreeRoot(binaryTree.ConstructTreeFromInorderLevelOrder(
                binaryTree.GetBinaryTreeRoot(), levelOrderArray, inorderArray, 0, inorderArray.Length, inorderArray.Length));
            Console.WriteLine();
            binaryTree.PrintInorderTraversal(binaryTree.GetBinaryTreeRoot());
            Console.ReadLine();
        }
    }
}
