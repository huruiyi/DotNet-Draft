#include <stdio.h>
#include <stdlib.h>

int i = 1119;
//创建一个数组，实现从小到大，从大到小
void main8()
{
	const  int  N = 10;
	int a[N];
	int  i = 10;//外部变量，作于域也就是大括号包含起来的块语句
	for (int i = 0; i < 10; i++)//如果变量重名，以内部变量为优先。
	{
		a[i] = rand() % 125;//取0到125的随机数
		printf("%d   ", a[i]);
	}

	int min;//代表最大最小数组元素的下标

	for (int u = 0; u < N - 1; u++)
	{
		min = u;//假定从u开始时最小的变量
		printf("轮询时刻，min,v的值");
		for (int v = u + 1; v < N; v++)//从u+1到最后一个变量做一个轮训
		{
			if (a[v] < a[min])
			{
				min = v;//循环交替，使得最后一个值是最值
				printf("%d,%d    ", min, v);
			}
		}

		printf("\n数组操作之前的状态\n");
		for (int i = 0; i < N; i++)
		{
			printf("%d  ", a[i]);
		}
		if (min != u)
		{
			//实现两个变量的交换
			int temp;
			temp = a[min];
			a[min] = a[u];
			a[u] = temp;
		}
		printf("\n数组操作之后的状态\n");
		for (int i = 0; i < N; i++)
		{
			printf("%d  ", a[i]);
		}
	}
	//
	printf("\n数组排序以后的状态\n");
	for (int i = 0; i < N; i++)
	{
		printf("%d  ", a[i]);
	}

	system("pause");
}