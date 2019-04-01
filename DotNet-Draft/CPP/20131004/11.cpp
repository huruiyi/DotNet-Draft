#include <stdlib.h>
#include <stdio.h>

void main11()
{
	const int N = 3;//const定义常量
	int a[N][N];
	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++)
		{
			a[i][j] = i*N + j + 1;//数学公式
			printf("%d   ", a[i][j]);//打印出每个元素的数据
		}
		printf("\n");//隔行换行
	}
	int jieguo = 0;
	for (int k = 0; k < N; k++)
	{
		jieguo += a[k][k];//对角线，横纵坐标相等
	}
	printf("\n%d", jieguo);
	system("pause");
}