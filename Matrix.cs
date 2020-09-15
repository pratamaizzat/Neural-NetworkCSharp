using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace neural_network1._0
{
    public class Matrix
    {
        public int rows = 0;
        public int cols = 0;
        public double[,] data;

        /// <summary>
        /// Create new Object Matrix
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            this.data = new double[this.rows, this.cols];
            for(int i = 0; i < this.rows; i++)
            {
                for(int j = 0; j < this.cols; j++)
                {
                    this.data[i, j] = 0;
                }
            }
        }

        /// <summary>
        /// Create new Matrix from Array Object input
        /// </summary>
        /// <param name="array">Array Object</param>
        /// <returns>Matrix Object</returns>
        public static Matrix FromArray(Array array)
        {
            double[] newArr = new double[array.Length];
            Array.Copy(array, newArr, array.Length);
            var newMatrix = new Matrix(array.Length, 1);
            for(int i = 0; i < array.Length; i++)
            {
                newMatrix.data[i, 0] = newArr[i];
            }

            return newMatrix;
        }

        /// <summary>
        /// Convert a Matrix to Array
        /// </summary>
        /// <returns>Object Array</returns>
        public Array ToArray()
        {
            int count = 0;
            double[] arr = new double[this.rows * this.cols];
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    arr[count] = this.data[i, j];
                    count++;
                }
            }

            return arr;
        }

        /// <summary>
        /// Make Randomize value in eact colomn/rows matrix
        /// </summary>
        public void Randomize()
        {
            var rand = new Random();
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    //this.data[i, j] = rand.Next(10);
                    this.data[i, j] = (rand.NextDouble() * 2.0) - 1.0;
                }
            }
        }

        /// <summary>
        /// Matrix Subraction. Matrix A will subract with Matrix B
        /// </summary>
        /// <param name="a">Object Matrix</param>
        /// <param name="b">Object Matrix</param>
        /// <returns>Object Matrix</returns>
        public static Matrix Subtract(Matrix a, Matrix b)
        {
            var result = new Matrix(a.rows, a.cols);
            for (int i = 0; i < result.rows; i++)
            {
                for (int j = 0; j < result.cols; j++)
                {
                    result.data[i, j] = a.data[i, j] - b.data[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// Add Matrix with number
        /// </summary>
        /// <param name="x">Ingteger int</param>
        public void AddWithNumber(double x)
        {
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    this.data[i, j] += x;
                }
            }
        }

        /// <summary>
        /// Matrix Addition between Matrix and Matrix
        /// </summary>
        /// <param name="matrix">Object Matrix</param>
        public void AddWithMatrix(Matrix matrix)
        {
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    this.data[i, j] += matrix.data[i, j];
                }
            }
        }

        /// <summary>
        /// Static Matrix Addition between two Matrix
        /// </summary>
        /// <param name="firstMatrix">Object Matrix</param>
        /// <param name="secondMatrix">Object Matrix</param>
        /// <returns>Obejct Matrix</returns>
        public static Matrix AddWithMatrix(Matrix firstMatrix, Matrix secondMatrix)
        {
            var result = new Matrix(firstMatrix.rows, firstMatrix.cols);
            for (int i = 0; i < result.rows; i++)
            {
                for (int j = 0; j < result.cols; j++)
                {
                    result.data[i, j] = firstMatrix.data[i, j] + secondMatrix.data[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// Multiply Matrix with number
        /// </summary>
        /// <param name="x">Integer integer</param>
        public void Multiply(double x)
        {
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    this.data[i, j] *= x;
                }
            }
        }

        /// <summary>
        /// The Hadamart Multiply Product
        /// </summary>
        /// <param name="matrix">
        /// Matrix Object
        /// </param>
        public void MultiplyWithMatrix(Matrix matrix)
        {
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    this.data[i, j] *= matrix.data[i, j];
                }
            }
        }

        /// <summary>
        /// Matrix multiplication betwin Matrix with Matrix
        /// </summary>
        /// <param name="a">Object Matrix</param>
        /// <param name="b">Object Matrix</param>
        /// <returns>Object Matrix</returns>
        public static Matrix MultiplyWithMatrix(Matrix a, Matrix b)
        {
            if (a.cols != b.rows) throw new ApplicationException("The colomn of first matrix must match with seocnd matrix rows");
            var result = new Matrix(a.rows, b.cols);
            for (int i = 0; i < result.rows; i++)
            {
                for (int j = 0; j < result.cols; j++)
                {
                    double sum = 0;
                    for(int k = 0; k < a.cols; k++)
                    {
                        sum += a.data[i, k] * b.data[k, j];
                    }

                    result.data[i, j] = sum;
                }
            }
            return result;
        }

        /// <summary>
        /// Mapping a new value of the Matrix from Function logic
        /// </summary>
        /// <param name="func">Func function</param>
        public void Map(Func<double, double> func )
        {
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    var value = this.data[i, j];
                    this.data[i, j] = func(value);
                }
            }
        }

        /// <summary>
        /// Mapping a new value from the Old Matrix and store to new Matrix
        /// </summary>
        /// <param name="matrix">Marix matrix</param>
        /// <param name="func">Func function</param>
        /// <returns>Object Matrix</returns>
        public static Matrix Map(Matrix matrix, Func<double, double> func)
        {
            var result = new Matrix(matrix.rows, matrix.cols);
            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.cols; j++)
                {
                    var value = matrix.data[i, j];
                    result.data[i, j] = func(value);
                }
            }

            return result;
        }

        /// <summary>
        /// Transpose the Old Matrix and store to new Matrix
        /// </summary>
        /// <param name="matrix">Object Matrix</param>
        /// <returns>Object Matrix</returns>
        public static Matrix Transpose (Matrix matrix)
        {
            var result = new Matrix(matrix.cols, matrix.rows);
            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.cols; j++)
                {
                    result.data[j, i] = matrix.data[i, j];
                }
            }
            return result;
        }
        /// <summary>
        /// Print the value of Matrix
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    Console.Write($"{this.data[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}