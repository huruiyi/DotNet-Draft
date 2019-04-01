#include<stdio.h>
#include<stdlib.h>
#include<math.h>
#include<iostream>
#include<string>
using namespace std;
//题目：将一个正整数分解质因数。例如：输入90,打印出90=2*3*3*5。
//     是否一个质数， 97  =1*97;
void  Nature_(int num)
{
	printf("\n%d", num);
	int a = 0;
	if (num)
	{
		printf("\n1无法分解质因数");
	}
	else if (num == 2)
	{
		printf("\n2=1*2");
	}
	else if (num == 3)
	{
		printf("\n3=1*3");
	}
	else
	{
		char flag = 'Y';
		for (int i = 2; i < sqrt((double)num); i++)
		{
			if (num%i == 0)
			{
				flag = 'N';
				break;
			}
		}
		if (flag == 'Y')
		{
			printf("这是一个质数");
			printf("%d=%d*1", num, num);
		}
		else
		{
			printf("这不是一个质数");
			printf("%d=", num);

			for (int j = 2; j < num; j++)//起到从2到num-1挨个挨个的整除
			{
				while (num != j)//除到底。
				{
					if (num%j == 0)//num可以整除j
					{
						printf("%d*", j);
						num = num / j;//求出num除以2以后的数
					}
					else
					{
						break;//不能整除直接跳出while循环
					}
				}
			}
			printf("%d", num);
		}
	}
}
void  Nature_(int num);
void main()//main4()
{
	cout << _MSC_VER << endl;

	int a;
	scanf_s("%d", &a);

	Nature_(a);
	system("pause");
}