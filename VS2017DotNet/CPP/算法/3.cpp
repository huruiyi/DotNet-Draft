#include<stdio.h>
#include <stdlib.h>
/*
�����Ϊһ�������������������

1  1  2  3  5  8 13
a  b  c
a  b  c
a  b  c
a  b  c

a b c
1+1=2

a b c
1+2=3

a b c
2+3=5

3+5=8
*/

void main3()
{
	int a = 1, b = 1, c = 0;
	printf("%d\n%d\n", a, b);

	for (int i = 1; i <= 38; i++)
	{
		c = a + b;
		printf("\n%d", c);
		a = b;
		b = c;
	}
	system("pause");
}