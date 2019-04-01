#include<stdio.h>
#include <stdlib.h>
//¹ú¼ÊÏóÆåÆåÅÌ
void International_Chessboard(int number)
{
	for (int i = 0; i < number; i++)
	{
		for (int j = 0; j < number; j++)
		{
			if ((i + j) % 2 == 0)
			{
				printf("1");
			}
			else
			{
				printf("0");
			}
		}
		printf("\n");
	}
}
void International_Chessboard(int number);
void main8()//main3()
{
	int a = 0;
	scanf_s("%d", &a);
	International_Chessboard(a);
	system("pause");
}