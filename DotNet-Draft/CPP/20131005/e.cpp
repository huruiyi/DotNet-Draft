#include <stdio.h>
#include <stdlib.h>

double func11(double num)
{
	num += 0.04;
	return (((int)(num * 10)) / 10.0);
}

double func22(double num)
{
	num += 0.005;
	return (((int)(num * 100)) / 100.0);
}

int maine()
{
	double a = 1.25;
	double b = 1.26;
	double c = 1.224;
	double d = 1.225;
	printf("a = %lf, b = %lf\n", func11(a), func11(b));
	printf("c = %lf, d = %lf\n", func22(c), func22(d));

	system("pause");
	return 0;
}