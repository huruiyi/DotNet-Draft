#include <stdio.h>
#include <stdlib.h>

void main7()
{
	const int N = 10;
	int  a[N];
	for (int i = 0; i < N; i++)
	{
		a[i] = rand() % 100;//取0-1000之间的随机数
	}
	for (int j = 0; j < N; j++)
	{
		printf("\n%d", a[j]);//打印出数组的数据
	}
	printf("\n\n\n");
	int minb = 0;//保存临时的最小值的下标
	int min = 0;//临时的最小值
	for (int u = 0; u < N - 1; u++)//10个，一直到两个之间，选择极小值。
	{
		minb = u;//假定当前元素为最小元素
		for (int v = u + 1; v < N; v++)//u=0,a[1]到a[N-1],u=1,a[2]到a[N-1]
		{
			if (a[v] < a[minb])//吧a[v] a[minb]中间最小数的下标保存到minb
			{
				minb = v;    //循环判断，吧最小的下标存入minb,
				//
			}
		}
		printf("\n 调整以前的数据\n");
		for (int iii = 0; iii < N; iii++)
		{
			printf("%d    ", a[iii]);//打印出数组的数据
		}

		if (minb != u)//如果minb发生变化，就交换两个变量的值
		{
			//完成两个变量的交换
			int temp = a[minb];
			a[minb] = a[u];
			a[u] = temp;
		}
		printf("\n 调整以后的数据\n");
		for (int ii = 0; ii < N; ii++)
		{
			printf("%d    ", a[ii]);//打印出数组的数据
		}
	}

	printf("\n\n\n");

	for (int jj = 0; jj < N; jj++)
	{
		printf("\n%d", a[jj]);//打印出数组的数据
	}

	system("pause");
}