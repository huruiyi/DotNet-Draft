#include <stdlib.h>
#include <stdio.h>

//循环打印出二维数组
void main9()
{
	int a[4] = { 1, 2, 3, 4 };
	int b[3][4] = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
	//  b[2][3],
	printf("%d", sizeof(b) / sizeof(int));
	for (int i = 0; i < 3; i++)//外层循环
	{
		for (int j = 0; j < 4; j++)//内层循环
		{
			printf("\n%d,%d,%d,%x", i, j, b[i][j], &b[i][j]);
			//内存里面是一行一行来进行存储
		}
	}

	system("pause");
}