using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructTree_InorderLevelOrder
{
    class BinaryTree
    {
        BinaryTreeNode root;

        public BinaryTree(BinaryTreeNode binaryTreeNode) {
            root = binaryTreeNode;
        }

        public void SetBinaryTreeRoot(BinaryTreeNode binaryTreeNode){
            root = binaryTreeNode;
        }

        public BinaryTreeNode GetBinaryTreeRoot() {
            return root;
        }

        public BinaryTreeNode Insert(BinaryTreeNode binaryTreeNode, int data) {
            if (binaryTreeNode == null) {
                binaryTreeNode = new BinaryTreeNode(data);
                return binaryTreeNode;
            }

            if (binaryTreeNode.GetBinaryTreeNodeData() < data){
                binaryTreeNode.SetBinaryTreeNodeRight(
                    Insert(binaryTreeNode.GetBinaryTreeNodeRight(), data));
            }
            else {
                binaryTreeNode.SetBinaryTreeNodeLeft(
                    Insert(binaryTreeNode.GetBinaryTreeNodeLeft(), data));
            }

            return binaryTreeNode;
        }

        public BinaryTreeNode ConstructTreeFromInorderLevelOrder(BinaryTreeNode binaryTreeNode,
            int[] levelOrderArray, int[] inorderArray, int startPosition, int endPosition, int length) {

            binaryTreeNode = new BinaryTreeNode(levelOrderArray[0]);
            int inorderPosition = FindIndexOfElementInArray(inorderArray, binaryTreeNode.GetBinaryTreeNodeData(), startPosition, endPosition);
            int[] leftNodesArray = new int[inorderPosition-startPosition];
            for (int index = startPosition; index < inorderPosition; index++){
                leftNodesArray[index] = inorderArray[inorderPosition];
            }

            int[] rightNodesArray = new int[endPosition-startPosition-leftNodesArray.Length];
            int rightNodeIndex = 0;
            for (int index = 1; index < length; index++) {
                if (FindIndexOfElementInArray(leftNodesArray, levelOrderArray[index], 0, leftNodesArray.Length) == -1) {
                    rightNodesArray[rightNodeIndex] = levelOrderArray[index];
                }
            }

            binaryTreeNode.SetBinaryTreeNodeLeft(ConstructTreeFromInorderLevelOrder(
                binaryTreeNode.GetBinaryTreeNodeLeft(), leftNodesArray, inorderArray, startPosition, inorderPosition-1, inorderPosition-startPosition));
            binaryTreeNode.SetBinaryTreeNodeRight(ConstructTreeFromInorderLevelOrder(
                binaryTreeNode.GetBinaryTreeNodeRight(), rightNodesArray, inorderArray, inorderPosition+1, endPosition, endPosition-inorderPosition));

            return binaryTreeNode;
        }

        public void PrintInorderTraversal(BinaryTreeNode binaryTreeNode) {
            if (binaryTreeNode == null) {
                return;
            }
            PrintInorderTraversal(binaryTreeNode.GetBinaryTreeNodeLeft());
            Console.Write(binaryTreeNode.GetBinaryTreeNodeData() + " ");
            PrintInorderTraversal(binaryTreeNode.GetBinaryTreeNodeRight());
        }

        private static int FindIndexOfElementInArray(int[] array, int value, int startPosition, int endPosition) {
            int arrayLength = array.Length;

            for (int arrayIndex = startPosition; arrayIndex <= endPosition; arrayIndex++) {
                if (array[arrayIndex] == value) {
                    return arrayIndex;
                }
            }
            return -1;
        }
    }
}
