#include <stdio.h>
#include <math.h>
#include <stdlib.h>

int foo(int n)
{
	if (n == 1)
	{
		return 2;
	}
	else
		return foo(n - 2) + n*(n + 1);

}


int main7()
{
	int sum = 0;
	int i = 1;
	for (i = 1; i <= 99; i += 2)
	{
		sum += i * (i + 1);
	}
	printf("sum = %d\n", sum);

	sum = 0;
	i = 1;
	while (i <= 99)
	{
		sum += i * (i + 1);
		i += 2;
	}
	printf("sum = %d\n", sum);

	sum = 0;
	i = 1;
	do
	{
		sum += i * (i + 1);
		i += 2;
	} while (i <= 99);
	printf("sum = %d\n", sum);

	sum = 0;
	i = 1;
LOOP:
	sum += i * (i + 1);
	i += 2;
	if (i <= 99)
		goto LOOP;
	printf("sum = %d\n", sum);

	sum = 0;
	sum = foo(99);
	printf("sum = %d\n", sum);

	system("pause");
	return 0;
}