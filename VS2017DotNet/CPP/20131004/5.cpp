#include <stdio.h>
#include <stdlib.h>

//1 ,1,2,3,5,8,13------------------------
//打印出斐波那契数列前四十项
void main5()
{
	int a[40] = { 1, 1 };
	//a[0]=1,a[1]=1;
	//a[2]=a[1]+a[0];
	//a[3]=a[2]+a[1];
	for (int i = 2; i <= 39; i++)
	{
		a[i] = a[i - 1] + a[i - 2];//实现斐波那契数列的计算
	}
	//循环打印出数组每一个元素
	for (int j = 0; j < 40; j++)
	{
		if (j % 5 == 0)//检测是否被5整除
		{
			printf("\n");//打印换行
		}
		printf("%d    ", a[j]);
	}

	system("pause");
}