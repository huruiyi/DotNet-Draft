#include <stdio.h>
#include <math.h>
#include <stdlib.h>

int findMin(int a[], int num)
{
	int minN;
	minN = a[0];
	for (int i = 0; i < num; i++)
	{
		if (minN > a[i])
		{
			minN = a[i];
		}
	}

	return minN;
}

int findMax(int a[], int num)
{
	int maxN;
	maxN = a[0];
	for (int i = 0; i < num; i++)
	{
		if (maxN < a[i])
		{
			maxN = a[i];
		}
	}
	return maxN;
}
//数组首地址，数组大小，和要查找的数
int isExist(int a[], int num, int n)
{
	int startN = 0;
	int endN = num - 1;//
	int middleN = endN / 2;

	//先进行排序
	for (int i = 0; i < num; i++)
	{
		for (int j = i + 1; j < num; j++)
		{
			if (a[i] > a[j])
			{
				a[i] = a[i] + a[j];
				a[j] = a[i] - a[j];
				a[i] = a[i] - a[j];
			}
		}
	}
	for (int i = 0; i < endN; i++)
	{
		printf("%d\t", a[i]);
	}

	if ((n > a[endN]) || (n < a[startN]))
		return 0;
	while (startN <= endN)
	{
		if (n > a[middleN])
		{
			startN = middleN + 1;
			middleN = (endN + startN) / 2;
		}
		else if (n < a[middleN])
		{
			endN = middleN - 1;
			middleN = (middleN + startN) / 2;
		}
		else if (n == a[middleN])
		{
			return 1;
		}
	}
	return 0;
}

int main()
{
	int a[100];
	for (int i = 0; i < 100; i++)
	{
		a[i] = rand() % 100 + 100;
		printf("%d\t", a[i]);
	}
	//从大到小
	for (int i = 0; i < 100; i++)
	{
		for (int j = i + 1; j < 100; j++)
		{
			if (a[i] < a[j])
			{
				a[i] = a[i] + a[j];
				a[j] = a[i] - a[j];
				a[i] = a[i] - a[j];
			}
		}
	}

	//从小到大
	for (int i = 0; i < 100; i++)
	{
		for (int j = i + 1; j < 100; j++)
		{
			if (a[i] > a[j])
			{
				a[i] = a[i] + a[j];
				a[j] = a[i] - a[j];
				a[i] = a[i] - a[j];
			}
		}
	}

	printf("min: %d\n", findMin(a, sizeof(a) / 4));
	printf("max: %d\n", findMax(a, sizeof(a) / 4));
	printf("199:%d\n", isExist(a, sizeof(a) / 4, 199));
	printf("250:%d\n", isExist(a, sizeof(a) / 4, 250));
	system("pause");
	return 0;
}