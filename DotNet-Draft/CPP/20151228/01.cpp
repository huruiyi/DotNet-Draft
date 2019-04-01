#include <stdio.h>
#include <stdlib.h>

void BuildHelixMatrix(int length);
void showMatrix(int *Matrix, int length);

int main01()
{
	BuildHelixMatrix(4);

	system("pause");
	return 0;
}

void BuildHelixMatrix(int length)
{
	int i, j, k;
	int a = 1;
	j = length - 1;
	i = k = 0;

	int *Matrix = (int *)malloc(sizeof(int)*length*length);

	for (; k < (length + 1) / 2; k++)  //k为层数
	{
		while (i < length - k)   //向下
		{
			//int  a1;

			Matrix[i++*length + j] = a++;  //a 为填充的自然数

			//printf("%d",Matrix[a1]);
		}
		i--;  //复位一步
		j--;

		while (j > k)   //向左
		{
			Matrix[i*length + j--] = a++;
		}
		j++;  //复位一步
		i++;
	}
	while (i > k - 1)   //向上
	{
		Matrix[i--*length + j] = a++;
	}
	i--;
	j--;
	while (j < length - k)   //向右
	{
		Matrix[i*length + j++] = a++;
	}
	j--;
	i++;

	showMatrix(Matrix, length);

	printf("\n");
}

void showMatrix(int *Matrix, int length)
{
	int i, j;

	for (i = 0; i < length; i++)
	{
		for (j = 0; j < length; j++)
		{
			printf("%d\t", Matrix[i*length + j]);
		}
		printf("\n");
	}
}