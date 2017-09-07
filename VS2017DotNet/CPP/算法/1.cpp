//给定一个正整数，比如说N
//当N=5，N=1+4=2+3
// =3+2=4+1
//1
//数学的抽屉原理
//
/*
10
一个数划分为两个数，必定有一个小于等于5
c=a+b
1+9   ,  9+1

100
一个数划分为两个数之积，必定有一个小于等10。
c=a*b
*/

#include <stdio.h>
#include <stdlib.h>
void main1()
{
	/*
	5      5/2
	1+4 2+3 3+2 4+1

	6 ===== 3
	1+5 2+4 3+3  4+2 5+1
	*/
	unsigned int n;
	scanf_s("%d", &n);//接收一个数字N  //“此程序要注意不能输入字符”
	printf("\n全排列");
	//拆分式的算法。遍历所有的可能。
	for (int i = 1; i < n; i++)
	{
		printf("\n%d=%d+%d", n, i, n - i);
	}
	printf("\n半排列");
	for (int i = 1; i <= n / 2; i++)
	{
		printf("\n%d=%d+%d", n, i, n - i);
	}
	system("pause");
}
int j;

void drawer_principle(unsigned int *iData)
{
	//unsigned int *iData;
	printf("\n全排列");  //#include <stdio.h> #include <stdlib.h>
	for (int i = 1; i < *iData; i++)
	{
		printf("\n%d=%d+%d", *iData, i, *iData - i);
	}
	printf("\n半排列");
	for (int i = 1; i <= *iData / 2; i++)
	{
		printf("\n%d=%d+%d", *iData, i, *iData - i);
	}
}