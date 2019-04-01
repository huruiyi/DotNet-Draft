#include <stdio.h>
#include <stdlib.h>
#include <math.h>//数学的头文件，引用sqrt求平方根
//打印出2-200以内的所有质数。

void main21()//44
{
	for (int i = 2; i <= 200; i++)
	{
		char  flag = 'Y';//标志是否一个质数
		if (i >= 4)
		{
			for (int j = 2; j <= i - 1; j++)
			{
				if (i%j == 0)
				{
					flag = 'N';
					break;//跳出循环
				}
			}
		}
		if (flag == 'N')
		{
			continue;   //结束当前循环，重复上层循环
		}
		printf("\n%d", i);
	}

	system("pause");
}

void main22()//高质量算法
{
	for (int i = 2; i <= 200; i++)//循环所有的数，遍历
	{
		char  flag = 'Y';//假定所有的数都是质数

		if (i >= 4)
		{
			for (int j = 2; j <= sqrt((double)i); j++) //循环判断，如果能被整除，
				//就跳出循环，标志非质数
			{
				if (i%j == 0)
				{
					flag = 'N';
					break;//跳出循环
				}
			}
		}

		if (flag == 'N')//检测到非质数，跳出循环
		{
			continue;
		}

		printf("\n%d", i);
	}

	system("pause");
}

void main23()//筛选法、分析程序的方法，自顶向下，逐步调试
{
	for (int i = 2; i <= 200; i++)//循环所有的数，遍历
	{
		char  flag = 'Y';//假定所有的数都是质数

		if (i >= 4)
		{
			for (int j = 2; j <= sqrt((double)i); j++) //循环判断，如果能被整除，
				//就跳出循环，标志非质数
			{
				if (i%j == 0)
				{
					flag = 'N';
					break;//跳出循环
				}
			}
		}
		if (flag == 'Y')//是质数，跳出循环
		{
			continue;
		}

		printf("\n%d", i);
	}

	system("pause");
}

void main24()//筛选法、
{
	for (int i = 2; i <= 200; i++)//循环所有的数，遍历
	{
		char  flag = 'Y';//假定所有的数都是质数

		if (i >= 4)
		{
			for (int j = 2; j <= sqrt((double)i); j++) //循环判断，如果能被整除，
				//就跳出循环，标志非质数
			{
				if (i%j == 0)
				{
					flag = 'N';
					break;//跳出循环
				}
			}
		}

		if (flag == 'Y')//是质数，跳出循环
		{
			continue;
		}

		printf("\n%d", i);
	}

	system("pause");
}