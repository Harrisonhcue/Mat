using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebraAssignment1
{
    /// <summary>
    /// Written by Harrison U-Ebili 991375192
    /// </summary>
    class MatrixN
    {
        /// <summary>
        /// Field variable which stores the array
        /// </summary>
        private double[,] _matrixN;


        /// <summary>
        /// Default constructor which creates a 3x3 identity matrix
        /// </summary>
        public MatrixN()
        {

            _matrixN = new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, 0, 1 } };
        }

        /// <summary>
        /// Creates a nxn matrix for the user  
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public MatrixN(int row, int column)
        {
            //Default sets the array to all zeroes until the user explicitly puts in values
            _matrixN = new double[row, column];
            for (int iRow = 0; iRow < _matrixN.GetLength(0); iRow++)
            {
                for (int iColumn = 0; iColumn < _matrixN.GetLength(1); iColumn++)
                {
                    _matrixN[iRow, iColumn] = 0;
                }
            }
        }


        //Property which returns the size of the matrix 
        public int Size
        {
            get { return _matrixN.Length; }
        }
        /// <summary>
        /// Indexer for a matrix instance
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>

        public double this[int row, int column]
        {
            get { return _matrixN[row, column]; }
            set { _matrixN[row, column] = value; }
        }
        /// <summary>
        /// Property which returns the number of rows a matric has 
        /// </summary>
        public int Row
        {
            get { return _matrixN.GetLength(0); }
        }
        /// <summary>
        /// Property ehich returns the number of columns a matrix has
        /// </summary>
        public int Column
        {
            get { return _matrixN.GetLength(1); }
        }
        /// <summary>
        /// Adds two matrices
        /// </summary>
        /// <param name="mat1"></param>
        /// <param name="mat2"></param>
        /// <returns></returns>
        public static MatrixN Add(MatrixN mat1, MatrixN mat2)
        {
            MatrixN result;
            if (mat1.Row == mat2.Row && mat1.Column == mat2.Column)
            {
                result = mat1 + mat2;
            }
            else
            {
                throw new Exception("Matrices need to have same dimensions in order to be added");
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mat1"></param>
        /// <param name="mat2"></param>
        /// <returns></returns>
        public static MatrixN Subtract(MatrixN mat1, MatrixN mat2)
        {
            MatrixN result;
            if (mat1.Row == mat2.Row && mat1.Column == mat2.Column)
            {
                result = mat1 - mat2;
            }
            else
            {
                throw new Exception("Matrices need to have same dimensions in order to perform subtraction");
            }
            return result;
        }
        /// <summary>
        /// Multiplies two matrices if possible and throws an exception for invalid operations 
        /// </summary>
        /// <param name="mat1"></param>
        /// <param name="mat2"></param>
        /// <returns></returns>
        public static MatrixN Times(MatrixN mat1, MatrixN mat2)
        {
            MatrixN result;
            if (mat1.Column == mat2.Row)
            {
                result = mat1 * mat2;
            }
            else
            {
                throw new Exception("Invalid matrix multiplication operation, row and column dont match");
            }
            return result;
        }
        /// <summary>
        /// Operator overload for two matrix N objects
        /// </summary>
        /// <param name="mat1"></param>
        /// <param name="mat2"></param>
        /// <returns></returns>
        public static MatrixN operator *(MatrixN mat1, MatrixN mat2)
        {
            MatrixN result = new MatrixN(mat1.Row, mat1.Column);
            for (int iRow = 0; iRow < mat1.Row; iRow++)
            {
                for (int iColumn = 0; iColumn < mat2.Column; iColumn++)
                {
                    for (int counter = 0; counter < mat2.Column; counter++)
                    {
                        result[iRow, iColumn] += mat1[iRow, counter] * mat2[counter, iColumn];
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Operator overload which adds two matrixN objects together
        /// </summary>
        /// <param name="mat1"></param>
        /// <param name="mat2"></param>
        /// <returns> A new matrix leaving others unchanged result needs to be stored</returns>
        public static MatrixN operator +(MatrixN mat1, MatrixN mat2)
        {
            MatrixN result = new MatrixN(mat1.Row, mat1.Column);
            for (int iRow = 0; iRow < mat1.Row; iRow++)
            {
                for (int iColumn = 0; iColumn < mat1.Column; iColumn++)
                {
                    result[iRow, iColumn] = mat1[iRow, iColumn] + mat2[iRow, iColumn];
                }
            }
            return result;
        }
        /// <summary>
        /// Operator overload which subtracts matrix2 from matrix1 
        /// </summary>
        /// <param name="mat1"></param>
        /// <param name="mat2"></param>
        /// <returns>New matrix which needs to be stored</returns>
        public static MatrixN operator -(MatrixN mat1, MatrixN mat2)
        {
            MatrixN result = new MatrixN(mat1.Row, mat1.Column);
            for (int iRow = 0; iRow < mat1.Row; iRow++)
            {
                for (int iColumn = 0; iColumn < mat1.Column; iColumn++)
                {
                    result[iRow, iColumn] = mat1[iRow, iColumn] - mat2[iRow, iColumn];
                }
            }
            return result;
        }
        /// <summary>
        /// Reduces a matrix using gaussian elimination into row reduced form
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public static MatrixN Elimination(MatrixN mat)
        {
            MatrixN result = mat;
            for (int k = 0; k < (Math.Min(result.Row, result.Column) - 1); k++)
            {

                for (int iundPivot = k + 1; iundPivot < result.Row; iundPivot++)
                {
                    double l = result[iundPivot, k] / result[k, k];
                    for (int iremRow = k + 1; iremRow < result.Column; iremRow++)
                    {
                        result[iundPivot, iremRow] = result[iundPivot, iremRow] - result[k, iremRow] * l;
                    }

                    result[iundPivot, k] = 0;
                }

            }

            return result;
        }
    }








}
