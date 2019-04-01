#include <stdio.h>
#include <stdlib.h>
//1*2+3*4+5*6+    99*100
//2n*(2n-1)   50

void main43()
{
	//for (int i=0;i<10;i++)
	//如果没有块语句，默认范围就是最近的分号前面的语句，空语句也不例外
	;
	int i = 0;
	while (i < 10)//;分号，while,for语句作用范围都是最近分号前面的语句，空语句也不例外
	{
		i++;
		printf("\n%d", i);
	}
	printf("\n111");
	printf("\n2222");
	getchar();
}

void  main42()
{
	for (int n = 1, jieguo = 0; n < 51; n++)
	{
		printf("\n=%d", n);

		jieguo = jieguo + 2 * n*(2 * n - 1);

		printf("   jieguo=%d", jieguo);
	}

	system("pause");
}

void main41()
{
	for (int i = 1, jieguo = 0; i < 101; i++)//语句1，初始化条件，//语句2起到判断循环条件是否终止，
		//语句3，起到i不断自增，跳出循环
	{
		printf("\n%d", i);

		jieguo = jieguo + i;
		printf("   %d", jieguo);
	}

	system("pause");
}