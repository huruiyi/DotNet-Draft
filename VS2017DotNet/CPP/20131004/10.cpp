#include <stdlib.h>
#include <stdio.h>

void main10()
{
	int  hj[5] = { 1, 2, 3, 4, 5 };
	for (int o = 0; o < 5; o++)
	{
		printf("\n%d,%x,%x", hj[o], &hj[o], hj + o);
	}
	int a[3][2] = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
	//3指定有几行，2就代表每行有两列
	int  a1[][5] = { 1, 3, 4, 5, 6 };//在元素确定的情况下，可以不指定有几行
	//int  a2[2][5]={{1,2,3},{4,5,6}};//每一行有几列必须指定。
	int  a2[2][5] = { 0 };//所有的元素都为0
	printf("a2地址%x\n", a2);

	for (int i = 0; i < 2; i++)
	{
		for (int j = 0; j < 5; j++)
		{
			printf("\n%d,%x,%x", a2[i][j], &a2[i][j], a2[i] + j);
		}
	}
	system("pause");
}