using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int numbersOfNodes = int.Parse(Console.ReadLine());

        List<int> nodeList = new List<int>();

        do
        {
            int inputNode = int.Parse(Console.ReadLine());
            if(inputNode >= numbersOfNodes || inputNode < 0)
            {
                break;
            }
            nodeList.Add(inputNode);     
        } while(true);

        int firstNode = int.Parse(Console.ReadLine());
        int lastNode = int.Parse(Console.ReadLine());


        int[,] adjMatrix = new int[numbersOfNodes, numbersOfNodes];

        for (int i = 0; i < nodeList.Count; i += 2)
        {
            int fromNode = nodeList[i];
            int toNode = nodeList[i + 1];
            adjMatrix[fromNode, toNode] = 1;
        }


        int[,] pathMatrix = new int[numbersOfNodes, numbersOfNodes];

        for (int i = 0; i < numbersOfNodes; i++)
        {
            for (int j = 0; j < numbersOfNodes; j++)
            {
                if (adjMatrix[i, j] == 1)
                {
                    pathMatrix[i, j] = 1;
                }
            }
        }


        for (int k = 0; k < numbersOfNodes; k++)
        {
            for (int i = 0; i < numbersOfNodes; i++)
            {
                for (int j = 0; j < numbersOfNodes; j++)
                {
                    if (pathMatrix[i, j] != 1 && pathMatrix[i, k] == 1 && pathMatrix[k, j] == 1)
                    {
                        pathMatrix[i, j] = 1;
                    }
                }
            }
        }
        if (pathMatrix[firstNode, lastNode] == 1)
        {
            Console.WriteLine("Reachable");
        }
        else
        {
            Console.WriteLine("Unreachable");
        }
    }
}

