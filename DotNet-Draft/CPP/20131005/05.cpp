#include <stdio.h>
#include <math.h>
#include <stdlib.h>

#define MAXLEN 10//int���10λ

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
	printf("%d������������%d��\n", num, numberOfInt(num));

	system("pause");
	return 0;
}