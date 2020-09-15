using System;

namespace neural_network1._0
{
    class Program
    {
        static void Main(string[] args)
        {
            //var matrix = new Matrix(2, 2);
            //matrix.Print();
            var nn = new NeuralNetwork(2, 2, 2);

            int[] inputData = { 1, 0 };
            int[] target = { 1 , 0};

            nn.Train(inputData, target);
            //Array arr = nn.FeedForward(inputData);
            //double[] newarr = new double[arr.Length];
            //Array.Copy(arr, newarr, arr.Length);

            //Console.WriteLine(newarr[0]);
            //Console.WriteLine(newarr[1]);
        }
    }
}
