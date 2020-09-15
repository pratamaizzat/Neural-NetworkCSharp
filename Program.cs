using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace neural_network1._0
{
    class Program
    {
        static void Main()
        {
            var nn = new NeuralNetwork(2, 4, 1);

            var trainingData = new List<TrainingData>()
            {
                new TrainingData(){InputArray = new int[] {0, 0}, TargetArray = new int[] { 0 } },
                new TrainingData(){InputArray = new int[] {0, 1}, TargetArray = new int[] { 1 } },
                new TrainingData(){InputArray = new int[] {1, 0}, TargetArray = new int[] { 1 } },
                new TrainingData(){InputArray = new int[] {1, 1}, TargetArray = new int[] { 0 } }
            };



            for(int trainCount = 0; trainCount < 50000; trainCount++)
            {
                for (int i = 0; i < trainingData.Count; i++)
                {
                    nn.Train(trainingData[i].InputArray, trainingData[i].TargetArray);
                }
            }

            Array xor00 = nn.FeedForward(new int[] { 0, 0 });
            Array xor01 = nn.FeedForward(new int[] { 0, 1 });
            Array xor10 = nn.FeedForward(new int[] { 1, 0 });
            Array xor11 = nn.FeedForward(new int[] { 1, 1 });

            double[] newXOR00 = new double[xor00.Length];
            double[] newXOR01 = new double[xor01.Length];
            double[] newXOR10 = new double[xor10.Length];
            double[] newXOR11 = new double[xor11.Length];

            Array.Copy(xor00, newXOR00, xor00.Length);
            Array.Copy(xor01, newXOR01, xor01.Length);
            Array.Copy(xor10, newXOR10, xor10.Length);
            Array.Copy(xor11, newXOR11, xor11.Length);

            Console.WriteLine("Logic Gate (XOR) With Neural Network");
            Console.WriteLine();
            Console.Write("A\t\t"); Console.Write("B\t\t"); Console.Write("Output\t\t\n");
            Console.Write("0\t\t"); Console.Write("0\t\t"); Console.Write(newXOR00[0]); Console.WriteLine();
            Console.Write("0\t\t"); Console.Write("1\t\t"); Console.Write(newXOR01[0]); Console.WriteLine();
            Console.Write("1\t\t"); Console.Write("0\t\t"); Console.Write(newXOR10[0]); Console.WriteLine();
            Console.Write("1\t\t"); Console.Write("1\t\t"); Console.Write(newXOR11[0]); Console.WriteLine();
        }
    }
}
