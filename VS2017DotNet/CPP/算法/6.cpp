//有1、2、3、4,5个数字，能组成多少个互不相同且无重复数字的4位数？都是多少？

//   _  _ _
//   1  1  1
//   2  2  2
//   3  3  3
//   4  4  4
#include<stdio.h>
#include <stdlib.h>
#include<math.h>

//首先搞定所有可能，然后筛掉不符合条件的。
//循环很容易实现遍历所有的可能，然后筛掉不符合条件的。
int method_exhaustion(int number)
{
	for (int i = 1; i <= number; i++)//遍历百位
	{
		for (int j = 1; j <= number; j++)//遍历十位
		{
			for (int k = 1; k <= number; k++)//遍历个位
			{
				if (i != j && j != k && i != k)
				{
					printf("%d%d%d\n", i, j, k);
				}
			}
		}
	}
	return 0;
}
int method_exhaustion(int number);
int main6()//main()
{
	int a;
	scanf_s("%d", &a);
	method_exhaustion(a);
	system("pause");
	return 0;
}