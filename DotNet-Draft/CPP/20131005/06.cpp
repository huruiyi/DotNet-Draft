#include <stdio.h>
#include <math.h>
#include <stdlib.h>

int isPrime(int num)
{
	int flag = 0;//
	if (num == 0 || num == 1)
		return 0;
	if (num == 2 || num == 3)
		return 1;
	for (int i = 2; i <= (int)sqrt(num*1.0); i++)
	{
		if (num % i == 0)
		{
			flag = 0;
			break;
		}
		else
			flag = 1;//质数
	}
	if (flag == 0)
		return 0;
	else
		return 1;//质数
}

int main6()
{
	int j = 0;
	int k = 0;
	int prm[10000] = { 0 };
	int unPrm[10000] = { 0 };
	for (int i = 0; i < 10000; i++)
	{
		if (isPrime(i))
		{
			prm[j] = i;
			j++;
		}
		else
		{
			unPrm[k] = i;
			k++;
		}
	}
	/*
	for (int i = 0; i < j; i++)
	{
		printf("%d\t", prm[i]);
	}
	putchar(10);
	for (int i = 0; i < k; i++)
	{
		printf("%d\t", unPrm[i]);
	}
	*/
	system("pause");
	return 0;
}