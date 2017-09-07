#include <stdio.h>
#include <math.h>
#include <stdlib.h>

int main10()
{
	const int N = 948;
	for (int i = 0; i <= N / 11; i++)
	{
		for (int j = 0; j <= N / 13; j++)
		{
			if (i * 13 + j * 11 == N)
			{
				printf("%d*13 + %d*11 = %d\n", i, j, N);
			}
		}
	}



	system("pause");
	return 0;
}