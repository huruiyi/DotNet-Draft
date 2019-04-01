#include <stdio.h>
#include <stdlib.h>

int main11()
{
	for (int i = 200; i <= 2000; i++)
	{
		if ((i % 2 != 0) && (i % 3 != 0) && (i % 5 != 0) && (i % 7 != 0))
		{
			printf(" i = %d\t", i);
		}
	}

	system("pause");
	return 0;
}