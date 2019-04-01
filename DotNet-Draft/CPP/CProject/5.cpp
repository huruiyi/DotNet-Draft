#include <stdio.h>
#include <stdlib.h>

void main51()
{
	for (int i = 0; i < 10; i++)
	{
		printf("\n%d", i);

		for (int j = 0; j < 10; j++)
		{
			printf("    %d", j);
		}
	}

	getchar();
}

void main52()
{
	for (int i = 0; i < 10; i++)
	{
		for (int j = 0; j <= i; j++)
		{
			printf("  %d*%d=%d", i, j, i*j);
		}
		printf("\n");
	}

	getchar();
}