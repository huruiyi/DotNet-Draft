/*
一个整数，它加上100后是一个完全平方数，
再加上168又是一个完全平方数，请问该数是多少？
如果一个数的平方根的平方等于该数，这说明此数是完全平方数
100 10
99  9
*/

#include <stdio.h>
#include <stdlib.h>
#include <math.h>//sqrt函数，求平方根
int Wq_sqrt(int j)
{
	int u, v;
	char flag;
	for (int i = 0; i < j; i++)
	{
		u = (int)sqrt((double)(i + 100));//取平方根
		v = (int)sqrt((double)(i + 268));//取平方根
		if (u*u == (i + 100) && v*v == (i + 268))//条件转换成代码。
		{
			printf("\n%d", i);
		}
		flag = 'y';
	}
	if (flag != 'y')
		printf("\n%c", flag);
	return 0;
}
int Wq_sqrt(int j);
void main7()// main2()
{
	int a = 0;
	scanf_s("%d", &a);
	Wq_sqrt(a);
	system("pause");
}