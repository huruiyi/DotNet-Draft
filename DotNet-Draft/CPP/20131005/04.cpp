#include <stdio.h>
#include <math.h>
#include <stdlib.h>
int main4()
{

	double a;
	scanf_s("%lf", &a);
	printf("%.2f", a);
	double  b = ((int)(a * 10 + 0.5)) / 10.0;
	printf("\n%f", b);

	system("pause");


	const int N = 8; //	输入的正偶数

	for (int i = 1; i <= N / 2; i++)
	{
		if (i % 2 == 0)
			printf("%d = %d + %d\n", N, i, N - i);
	}



	system("pause");
	return 0;
}