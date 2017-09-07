#include <stdio.h>
#include <stdlib.h>

void main61()
{
	for (int i = 0; 1; i++)
	{
		printf("\n%d", i);

		if (i > 100)
		{
			break;//跳出当前循环
		}
	}

	system("pause");
}

void  main62()
{
	for (int i = 0; i < 10; i++)
	{
		printf("\n%d", i);

		for (int j = 0; j < 10; j++)
		{
			printf("    %d", j);

			if (j >= 6)
			{
				//break;//跳出当前的循环
				break;//break只能跳出当前循环
				//break后面的语句就不会再执行
				//printf("   AAAA");
				//break;
			}
		}

		if (i >= 3)
		{
			break;
		}
	}
	system("pause");
}

void main63()
{
	//continue被执行，continue以后的语句就不会再执行
	//continue结束本次循环
	for (int i = 0; i < 10; i++)
	{
		printf("\n%d", i);

		if (i == 5)
		{
			continue;
		}
		printf("    AAAA   ");

		for (int j = 0; j < 10; j++)
		{
			if (j > 5)
			{
				continue;
			}
			printf("    %d", j);
		}
	}

	getchar();
}
//12  (3)45(6)  78
void main64()
{
	for (int i = 100; i <= 200; i++)
	{
		if (i % 3 == 0)
		{
			continue;//continue后面的语句不会再执行
		}

		printf("\n%d", i);
	}

	system("pause");
}

void main65()
{
	int i = 1;
	int j;
	//316=i*13+11*j
	for (; 1; i++)
	{
		if ((316 - i * 13) % 11 == 0)
		{
			j = (316 - i * 13) / 11;
			printf("316=13*%d+11*%d", i, j);
			break;
		}
	}
	getchar();
}