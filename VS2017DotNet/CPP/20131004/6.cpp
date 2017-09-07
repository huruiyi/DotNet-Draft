#include <stdio.h>
#include <stdlib.h>
//实现找出最小的元素
void main6()
{
	int a[10];
	for (int i = 0; i < 10; i++)
	{
		a[i] = rand() % 100;//取0到100的随机数
	}
	for (int j = 0; j < 10; j++)
	{
		printf("\n%d", a[j]);
	}
	int min;//最小的元素
	min = a[0];

	printf("\n\n\n");
	for (int k = 1; k<10; k++)
	{
		if (min >a[k])//吧ak,min的最小值存入min
		{
			//交换两个变量
			int temp;
			temp = min;
			min = a[k];
			a[k] = temp;
		}
		printf("\nk=%d,min=%d,a[%d]=%d ", k, min, k, a[k]);
		a[0] = min;//赋值给第一个元素，让第一个元素最小
		for (int u = 0; u < 10; u++)//打印出数组的状态
		{
			printf("\n%d", a[u]);
		}
	}
	printf("\n%d", min);

	system("pause");
}