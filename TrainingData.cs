using System;
using System.Collections.Generic;
using System.Text;

namespace neural_network1._0
{
    public class TrainingData
    {
        public int[] inputArray;
        public int[] targetArray;

        public int[] InputArray { get { return this.inputArray; } set { this.inputArray = value; } }
        public int[] TargetArray { get { return this.targetArray; } set { this.targetArray = value; } }



        public static int[] DataInput(int[] arr)
        {
            int[] data_array = new int[arr.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                data_array[i] = arr[i];
            }

            return data_array;
        }

        public static int[] DataTarget(int[] arr)
        {
            int[] data_array = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                data_array[i] = arr[i];
            }

            return data_array;
        }
    }
}
