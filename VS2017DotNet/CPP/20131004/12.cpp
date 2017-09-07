#include <stdlib.h>
#include <stdio.h>

void main12()
{
	int a[3][4] = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			printf("%d     ", a[i][j]);
		}
		printf("\n");//每行打印完成以后换行
	}

	int b[4][3];
	for (int i = 0; i < 4; i++)
	{
		for (int j = 0; j < 3; j++)
		{
			b[i][j] = a[j][i];
			printf("%d   ", b[i][j]);
		}
		printf("\n");//换行
	}
	system("pause");
}