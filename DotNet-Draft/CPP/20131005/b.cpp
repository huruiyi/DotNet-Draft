// 14.18.cpp : 定义控制台应用程序的入口点。
//  二分算法

#include <iostream>
#include <stdio.h>
#include <stdlib.h>
using namespace std;

int find(int m, int a[], int n);
bool add(int a[], int n);

int mainc()
{
	//int a[]={1,11,21,32,61,62,51,88,22,33,44,55,66,99,10};
	const int N = 100;
	int number[N];
	for (int i = 0; i < N; i++)
	{
		number[i] = (100 + rand() % 100);

		printf("%d\t", number[i]);
	}
	printf("*********************************************************\n");
	int minb = 0;//保存临时的最小值的下标
	int min = 0;//临时的最小值
	for (int u = 0; u < N - 1; u++)//10个，一直到两个之间，选择极小值。
	{
		minb = u;//假定当前元素为最小元素
		for (int v = u + 1; v < N; v++)//u=0,a[1]到a[N-1],u=1,a[2]到a[N-1]
		{
			if (number[v] < number[minb])//吧a[v] a[minb]中间最小数的下标保存到minb
			{
				minb = v;    //循环判断，吧最小的下标存入minb,
				//
			}
		}

		if (minb != u)//如果minb发生变化，就交换两个变量的值
		{
			//完成两个变量的交换
			int temp = number[minb];
			number[minb] = number[u];
			number[u] = temp;
		}

		printf("%d\t", number[u]);
	}
	printf("\n最大值为： %d", number[N - 1]);
	printf("\n最小值为： %d", number[min]);

	int data1;
	scanf_s("%d", &data1);

	cout << "32在数组a中的位置是：" << find(data1, number, 100) << endl;

	getchar();

	return 0;
}

int find(int m, int a[], int n)
{
	int o = 0, h = n - 1, i;  	//由于数组元素是从0到数组长度减1，因此这里初始化的0代表第1个元素的编号，h代表最后一个元素，i则代表当前正在查找的元素的编号
	while (o <= h)
	{
		i = (o + h) / 2;     	//取中间元素的编号
		if (a[i] == m)    	//假如我们查的数据与该编号元素的值相等
			return i;      	//返回该元素的编号
		if (a[i] < m)    	//假如该编号元素的值小于我们所要查的数据
			o = i + 1;      		//将该元素的编号加1赋给o，也就是在后半部分搜索
		else h = i - 1;   	//将该元素的编号减1赋给h，也就是在前半部分搜索
	}
	return n;			//搜索不到，返回数组长度
}
bool add(int a[], int n)
{
	for (int i = 1; i < n; i++)
	{
		if (a[i] < a[i - 1])
		{
			return false;
		}
	}
	return	true;
}