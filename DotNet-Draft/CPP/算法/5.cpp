#include <stdio.h>
#include <stdlib.h>

//数据分离算法
void main5()
{
	for (int i = 100; i <= 999; i++)
	{
		int gewei = i % 10; //求出个位，求出10位，求出百位
		int shiwei = i / 10 % 10;
		int baiwei = i / 100;
		if (i == gewei*gewei*gewei + shiwei*shiwei*shiwei + baiwei*baiwei*baiwei)
		{
			//一行写不下，可以用逗号分隔
			printf("\n%d=%d*%d*%d+%d*%d*%d+%d*%d*%d",
				i,
				gewei,
				gewei,
				gewei,
				shiwei,
				shiwei,
				shiwei,
				baiwei,
				baiwei,
				baiwei);
		}
	}

	getchar();
}