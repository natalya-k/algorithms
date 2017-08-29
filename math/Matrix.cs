using System;
using System.Collections;

namespace Algorithms
{
    class Matrix : IEnumerable
    {
        private int[,] items;

        private static Random random = new Random();

        public int this[int row, int col]
        {
            get
            {
                CheckIndexes(row, col);
                return items[row, col];
            }

            set
            {
                CheckIndexes(row, col);
                items[row, col] = value;
            }
        }

        public int Rows { get { return items.GetLength(0); } }
        public int Columns { get { return items.GetLength(1); } }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
            {
                throw new Exception("The matrices sizes must be equal.");
            }

            Matrix sum = new Matrix(a.Rows, a.Columns);

            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < a.Columns; col++)
                {
                    sum[row, col] = a[row, col] + b[row, col];
                }                
            }

            return sum;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Rows != b.Rows || a.Columns != b.Columns)
            {
                throw new Exception("The matrices sizes must be equal.");
            }

            Matrix difference = new Matrix(a.Rows, a.Columns);

            for (int row = 0; row < a.Rows; row++)
            {
                for (int col = 0; col < a.Columns; col++)
                {
                    difference[row, col] = a[row, col] - b[row, col];
                }
            }

            return difference;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.Columns != b.Rows)
            {
                throw new Exception("The columns number in the 1st matrix must be equal to the rows number in the 2nd matrix.");
            }

            Matrix product = new Matrix(a.Rows, b.Columns);

            int row, col, k;

            for (row = 0; row < a.Rows; row++)
            {
                for (col = 0; col < b.Columns; col++)
                {
                    product[row, col] = 0;

                    for (k = 0; k < a.Columns; k++)
                    {
                        product[row, col] += a[row, k] * b[k, col];
                    }
                }
            }

            return product;
        }

        public Matrix(int rows, int columns)
        {
            items = new int[rows, columns];
        }

        public static void Test()
        {
            Matrix a = new Matrix(3, 3);
            a.FillWithRandomValues();
            Console.WriteLine("Matrix A");
            a.Print();
            Console.WriteLine();

            Matrix b = new Matrix(3, 3);
            b.FillWithRandomValues();
            Console.WriteLine("Matrix B");
            b.Print();
            Console.WriteLine();

            Matrix sum = a + b;
            Console.WriteLine("Sum A + B");
            sum.Print();
            Console.WriteLine();

            Matrix difference = a - b;
            Console.WriteLine("Difference A - B");
            difference.Print();
            Console.WriteLine();

            Matrix c = new Matrix(3, 4);
            c.FillWithRandomValues();
            Console.WriteLine("Matrix C");
            c.Print();
            Console.WriteLine();

            Matrix product = a * c;
            Console.WriteLine("Product A * C");
            product.Print();
            Console.WriteLine();

            a.Transpose();
            Console.WriteLine("Matrix A transposed");
            a.Print();
            Console.WriteLine();

            c.Transpose();
            Console.WriteLine("Matrix C transposed");
            c.Print();
            Console.WriteLine();
        }

        public void FillWithRandomValues()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    items[row, col] = random.Next(1, 10);
                }
            }
        }        

        public void Print()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    Console.Write("{0, 5}", items[row, col]);
                }

                Console.WriteLine();
            }
        }

        public void Transpose()
        {
            if (Rows == Columns)
            {
                for (int row = 0; row < Rows - 1; row++)
                {
                    for (int col = 1; col < Columns; col++)
                    {
                        if (row != col)
                        {
                            int temp = items[row, col];
                            items[row, col] = items[col, row];
                            items[col, row] = temp;
                        }
                    }                    
                }
            }
            else
            {
                Matrix result = new Matrix(Columns, Rows);

                for (int row = 0; row < result.Rows; row++)
                {
                    for (int col = 0; col < result.Columns; col++)
                    {
                        result[row, col] = this[col, row];
                    }
                }

                this.items = result.items;
            }            
        }

        private void CheckIndexes(int row, int col)
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Columns)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    yield return items[row, col];
                }
            }
        }
    }
}