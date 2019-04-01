#include <stdio.h>
#include <math.h>
#include <stdlib.h>

double func1(double num)
{
	num += 0.04;
	return (((int)(num * 10)) / 10.0);
}

double func2(double num)
{
	num += 0.005;
	return (((int)(num * 100)) / 100.0);
}

int main2()
{
	double a = 1.25;
	double b = 1.26;
	double c = 1.224;
	double d = 1.225;
	printf("a = %lf, b = %lf\n", func1(a), func1(b));
	printf("c = %lf, d = %lf\n", func2(c), func2(d));

	system("pause");
	return 0;
}