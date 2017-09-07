#include <stdio.h>
#include <math.h>
#include <stdlib.h>

int main8()
{
	int a[3][5];
	int b[5][3];

	for (int i = 0; i < 15; i++)
	{
		*(*a + i) = rand() % 100;
	}
	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 5; j++)
		{
			printf("%d\t", a[i][j]);
		}
		putchar(10);
	}
	printf("\nb[5][3]:\n");
	for (int j = 0; j < 5; j++)
	{
		for (int i = 0; i < 3; i++)
		{
			b[j][i] = a[i][j];
			printf("%d\t", b[j][i]);
		}
		putchar(10);
	}


	system("pause");
	return 0;
}