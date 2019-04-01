#include <stdio.h>
#include <stdlib.h>

void main04()
{
	char s1[10] = { 'A', 'B', 'C', 'D', 'M', '1', '2', 'T', 'U', '\0' };
	printf("\n%s", s1);
	for (int i = 0; i < 10; i++)
	{
		if (s1[i] >= 'A' && s1[i] <= 'Z')
		{
			s1[i] += 32;
		}
	}
	printf("\n%s", s1);

	char s2[4] = { '1', '2', '3', '\0' };
	printf("\n%s", s2);
	for (int i = 0; i < 10; i++)
	{
		int  flag = 1;
		for (int j = 0; j < 3; j++)
		{
			if (s1[i + j] != s2[j])
			{
				flag = 0;
				break;
			}
		}
		if (flag == 1)
		{
			printf("\nOK");
		}
	}
	system("pause");
}