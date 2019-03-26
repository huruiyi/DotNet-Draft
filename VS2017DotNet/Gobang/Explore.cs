using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Gobang
{
    sealed class Explore
    {
        public static Point FindOptimalPoint(int[,] table)
        {
            int[,] score_1 = CalScore(table, true);
            int[,] score_2 = CalScore(table, false);
            int i, j, max_1 = 0, max_2 = 0;
            for (i = 0; i < 15; i++)
            {
                for (j = 0; j < 15; j++)
                {
                    if (max_1 < score_1[i, j])
                        max_1 = score_1[i, j];
                    if (max_2 < score_2[i, j])
                        max_2 = score_2[i, j];
                }
            }
            ArrayList alist = new ArrayList();
            if (max_1 >= max_2)
            {
                for (i = 0; i < 15; i++)
                    for (j = 0; j < 15; j++)
                        if (score_1[i, j] == max_1)
                            alist.Add(new Point(i, j));
            }
            else
            {
                for (i = 0; i < 15; i++)
                    for (j = 0; j < 15; j++)
                        if (score_2[i, j] == max_2)
                            alist.Add(new Point(i, j));
            }
            return (Point)alist[new Random().Next(alist.Count)];
        }
        public static bool Test(int[,] table)
        {
            int i, j, white = 0, black = 0;
            for (i = 0; i < 11; i++)
            {
                for (j = 0; j < 15; j++)
                {
                    Right(table, i, j, ref white, ref black);
                    if (white == 5 || black == 5)
                        return true;
                }
            }
            for (i = 0; i < 15; i++)
            {
                for (j = 0; j < 11; j++)
                {
                    Down(table, i, j, ref white, ref black);
                    if (white == 5 || black == 5)
                        return true;
                }
            }
            for (i = 0; i < 11; i++)
            {
                for (j = 0; j < 11; j++)
                {
                    RightDown(table, i, j, ref white, ref black);
                    if (white == 5 || black == 5)
                        return true;
                }
            }
            for (i = 4; i < 15; i++)
            {
                for (j = 0; j < 11; j++)
                {
                    LeftDown(table, i, j, ref white, ref black);
                    if (white == 5 || black == 5)
                        return true;
                }
            }
            return false;
        }

        private static int[,] values = { { 7, 15, 400, 1800, 100000 }, { 35, 0, 0, 0, 0 }, 
                                       { 800, 0, 0, 0, 0 }, { 15000, 0, 0, 0, 0 }, { 800000, 0, 0, 0, 0 } };

        #region 过程方法...

        private static int[,] CalScore(int[,] table, bool isWhite)
        {
            int[,] score = new int[15, 15];
            int i, j, k, white = 0, black = 0;
            for (i = 0; i < 11; i++)
            {
                for (j = 0; j < 15; j++)
                {
                    Right(table, i, j, ref white, ref black);
                    if (isWhite)
                    {
                        k = white;
                        white = black;
                        black = k;
                    }
                    for (k = 0; k < 5; k++)
                        score[i + k, j] += values[white, black];
                }
            }
            for (i = 0; i < 15; i++)
            {
                for (j = 0; j < 11; j++)
                {
                    Down(table, i, j, ref white, ref black);
                    if (isWhite)
                    {
                        k = white;
                        white = black;
                        black = k;
                    }
                    for (k = 0; k < 5; k++)
                        score[i, j + k] += values[white, black];
                }
            }
            for (i = 0; i < 11; i++)
            {
                for (j = 0; j < 11; j++)
                {
                    RightDown(table, i, j, ref white, ref black);
                    if (isWhite)
                    {
                        k = white;
                        white = black;
                        black = k;
                    }
                    for (k = 0; k < 5; k++)
                        score[i + k, j + k] += values[white, black];
                }
            }
            for (i = 4; i < 15; i++)
            {
                for (j = 0; j < 11; j++)
                {
                    LeftDown(table, i, j, ref white, ref black);
                    if (isWhite)
                    {
                        k = white;
                        white = black;
                        black = k;
                    }
                    for (k = 0; k < 5; k++)
                        score[i - k, j + k] += values[white, black];
                }
            }
            for (i = 0; i < 15; i++)
            {
                for (j = 0; j < 15; j++)
                {
                    if (table[i, j] != 0)
                        score[i, j] = -1;
                }
            }
            return score;
        }

        #region 检测四个方向的五元组...
        private static void Right(int[,] table, int row, int column, ref int white, ref int black)
        {
            white = 0; black = 0;
            for (int i = 0; i < 5; i++)
            {
                if (table[row + i, column] == 1)
                    white++;
                if (table[row + i, column] == 2)
                    black++;
            }
        }
        private static void Down(int[,] table, int row, int column, ref int white, ref int black)
        {
            white = 0; black = 0;
            for (int i = 0; i < 5; i++)
            {
                if (table[row, column + i] == 1)
                    white++;
                if (table[row, column + i] == 2)
                    black++;
            }
        }
        private static void RightDown(int[,] table, int row, int column, ref int white, ref int black)
        {
            white = 0; black = 0;
            for (int i = 0; i < 5; i++)
            {
                if (table[row + i, column + i] == 1)
                    white++;
                if (table[row + i, column + i] == 2)
                    black++;
            }
        }
        private static void LeftDown(int[,] table, int row, int column, ref int white, ref int black)
        {
            white = 0; black = 0;
            for (int i = 0; i < 5; i++)
            {
                if (table[row - i, column + i] == 1)
                    white++;
                if (table[row - i, column + i] == 2)
                    black++;
            }
        }
        #endregion

        #endregion
    }
}
