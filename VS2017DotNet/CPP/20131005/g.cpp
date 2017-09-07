/*
功能：
生成随机的100个数，范围为100到200之间的随机数，存入一个数组，实现从大到小排序
与从小到大排序。
然后设计一个查找函数，查找出最小的数。
然后设计一个查找函数，查找出最大的数。
实现输入一个数，检测是否存在

思路：
用rand函数生成100以内的随机数然后加上100，然后存进去就OK了
然后是GetMaxNum函数，得到最大值
然后是GetMinNum函数，得到最大值
然后用二分法查找
*/

#include <stdio.h>
#include <stdlib.h>

#define TRUE 1
#define FALSE 0

typedef int Status;

const int ArraySize = 100;//定义数组大小常量

void PrintArray(int a[], int n);
void bubble_sort_ascend(int a[], int n);
void bubble_sort_descend(int a[], int n);
int GetMaxNum(int a[], int n);
int GetMinNum(int a[], int n);
int BinarySearch(int a[], int n, int elem);

int main1()
{
	int iArray[ArraySize] = { 0 };//初始化数组

	for (int i = 0; i < ArraySize; i++)
	{
		iArray[i] = rand() % 100 + 100;
	}

	PrintArray(iArray, ArraySize);
	bubble_sort_ascend(iArray, ArraySize);
	PrintArray(iArray, ArraySize);
	bubble_sort_descend(iArray, ArraySize);
	PrintArray(iArray, ArraySize);
	printf("In this array, the max value is:%d\n", GetMaxNum(iArray, ArraySize));
	printf("In this array, the min value is:%d\n", GetMinNum(iArray, ArraySize));
	bubble_sort_ascend(iArray, ArraySize);
	printf("The element %d in this array No.%d\n", 112, BinarySearch(iArray, ArraySize, 112) + 1);

	system("pause");

	return 0;
}

void PrintArray(int a[], int n)
{
	for (int i = 0; i < n; i++)
	{
		printf("%d ", a[i]);
	}

	printf("\n");
}

void bubble_sort_ascend(int a[], int n)
{ // 将a中整数序列重新排列成自小至大有序的整数序列(冒泡排序)
	int i, j, t;
	Status change;
	for (i = n - 1, change = TRUE; i > 1 && change; --i)
	{
		change = FALSE;
		for (j = 0; j<i; ++j)
			if (a[j]>a[j + 1])
			{
			t = a[j];
			a[j] = a[j + 1];
			a[j + 1] = t;
			change = TRUE;
			}
	}
}

void bubble_sort_descend(int a[], int n)
{ // 将a中整数序列重新排列成自大至小有序的整数序列(冒泡排序)
	int i, j, t;
	Status change;
	for (i = n - 1, change = TRUE; i > 0 && change; --i)
	{
		change = FALSE;
		for (j = 0; j < i; ++j)
		{
			if (a[j] < a[j + 1])
			{
				t = a[j];
				a[j] = a[j + 1];
				a[j + 1] = t;
				change = TRUE;
			}
		}
	}
}

int GetMaxNum(int a[], int n)
{
	int Max = a[1];

	for (int i = 1; i < n; i++)
	{
		if (Max < a[i])
		{
			Max = a[i];
		}
	}

	return Max;
}

int GetMinNum(int a[], int n)
{
	int Min = a[1];

	for (int i = 1; i < n; i++)
	{
		if (Min > a[i])
		{
			Min = a[i];
		}
	}

	return Min;
}
///*****************二分算法 另一个函数***********必须是顺序排列****
int BinarySearch(int a[], int n, int elem)
{
	int low = 0;
	int high = n;
	int middle = (low + high) / 2;

	while (low <= high)
	{
		if (elem == a[middle])
		{
			return middle;
		}
		else if (elem > a[middle])
		{
			low = middle + 1;
			middle = (low + high) / 2;
		}
		else if (elem < a[middle])
		{
			high = middle - 1;
			middle = (low + high) / 2;
		}//else
	}//while

	return -1;
}