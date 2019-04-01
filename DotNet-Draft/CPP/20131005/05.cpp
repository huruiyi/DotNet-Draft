#include <stdio.h>
#include <math.h>
#include <stdlib.h>

#define MAXLEN 10//int最大10位

int numberOfInt(int num)
{
	int i;
	for (i = 1; i <= MAXLEN; i++)
	{
		if ((num /= 10) == 0)
		{
			break;
		}
	}

	return i;
}

int main5()
{
	int num = 123456789;
	printf("%d的整数个数有%d个\n", num, numberOfInt(num));

	system("pause");
	return 0;
}