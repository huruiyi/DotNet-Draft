#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
#include <string.h>
#include <math.h>

int mainf1()
{
	//输出100-2000之间所有不能被3整除，不能被5整除，不能被2整除，不能被7整除的数
	for (int i = 101; i < 2000; i += 2)//只用奇数做判断
	{
		if (i % 3 == 0
			&& i % 5 == 0
			&& i % 7 == 0)
		{
			printf("%d ", i);
		}
	}

	system("pause");
	return 0;
}

int mainf2()
{
	//把数948分为两个数之和，其中一个为13的倍数，一个为11的倍数。
	for (int i = 1; i < (948 - 11) / 13; i++)
	{
		for (int j = 1; j < (948 - 13) / 11; j++)
		{
			if (i * 13 + j * 11 == 948)
			{
				printf("i=%d, j=%d\n", i, j);
			}
		}
	}

	system("pause");
	return 0;
}

int mainf3()
{
	int score;

	printf("Please input your score, you will get the level of your score\n");
	scanf_s("%d", &score);

	if (score < 60)
	{
		printf("不及格\n");
	}
	else if (score >= 60 && score < 70)
	{
		printf("及格\n");
	}
	else if (score >= 70 && score < 80)
	{
		printf("一般\n");
	}
	else if (score >= 80 && score < 90)
	{
		printf("优秀\n");
	}
	else if (score >= 90 && score < 100)
	{
		printf("卓越\n");
	}
	else if (score == 100)
	{
		printf("完美\n");
	}
	else
	{
		printf("你OUT了\n");
	}

	printf("Please input your score, you will get the level of your score\n");
	scanf_s("%d", &score);
	switch (score / 10)
	{
	case 0:
	case 1:
	case 2:
	case 3:
	case 4:
	case 5:
	{
		printf("不及格\n");
	}
		break;
	case 6:
	{
		printf("及格\n");
	}
		break;
	case 7:
	{
		printf("一般\n");
	}
		break;
	case 8:
	{
		printf("优秀\n");
	}
		break;
	case 9:
	{
		printf("卓越\n");
	}
		break;
	case 10:
	{
		printf("完美\n");
	}
		break;
	default:
		printf("你OUT了\n");
		break;
	}//switch

	system("pause");
	return 0;
}

int GetIntegerDigit(int num);

int mainf4()
{
	//判断一个整数有多少位
	//用while循环除10操作，然后统计循环次数，循环条件是除10后的结果
	printf("这个整数的位数是%d\n", GetIntegerDigit(10));

	system("pause");
	return 0;
}

int GetIntegerDigit(int num)
{
	int count = 0;

	if (num == 0)
	{
		return 1;
	}

	while (num != 0)
	{
		count++;
		num /= 10;
	}

	return count;
}

void PrintEvenExpression(int num);

int mainf5()
{
	//输出和为一个给定正偶数的所有偶数组合
	//例如：n=8,8=2+6,8=4+4（相加的数不能重复）
	PrintEvenExpression(50);

	system("pause");
	return 0;
}

void PrintEvenExpression(int num)
{
	if (num <= 2 || num % 2 == 1)
	{
		printf("请确定你输入的数是偶数而且还是能分解的正偶数\n");
		return;
	}
	for (int i = 2; i <= num / 2; i += 2)
	{
		printf("%d,%d;\t ", i, num - i);
	}
	printf("\n");
}

void GetPointOneDigit(double dNum);
void GetPointTwoDigits(double dNum);

int mainf6()
{
	//输入一个浮点小数，对这个小数保留一位，对第二位进行四舍五入
	//思路：
	//用小数乘以pow(10, n) + 0.5取整，再除以pow(10, n)就行了
	double testNum;

	printf("请输入一个小数:\n");
	scanf_s("%lf", &testNum);

	GetPointOneDigit(testNum);
	GetPointTwoDigits(testNum);

	system("pause");

	return 0;
}

void GetPointOneDigit(double dNum)
{
	printf("保留一位四舍五入后值为%f\n", (int)(dNum * 10 + 0.5) / 10.0);
}

void GetPointTwoDigits(double dNum)
{
	printf("保留两位位四舍五入后值为%f\n", (int)(dNum * 100 + 0.5) / 100.0);
}

int GetMulSum(int n);
int GetMulSumFor(int n);
int GetMulSumDoWhile(int n);
int GetMulSumWhile(int n);
int GetMulSumGoto(int n);

int mainf7()
{
	//实现从1*2+3*4+5*6....+99*100的递归实现，for，while，do while， goto实现
	printf("递归实现数值为%d", GetMulSum(4));
	system("pause");
	return 0;
}

int GetMulSum(int n)
{
	if (n == 2)
	{
		return 1 * 2;
	}
	else
	{
		return n*(n - 1) + GetMulSum(n - 2);
	}
}

int GetMulSumFor(int n)
{
	int sum = 0;

	for (int i = 2; i <= n; i += 2)
	{
		sum += (n * (n - 1));
	}

	return sum;
}

int GetMulSumDoWhile(int n)
{
	int sum = 0;
	int i = 0;

	do
	{
		sum += i*(i - 1);
		i += 2;
	} while (i <= n);

	return sum;
}

int GetMulSumWhile(int n)
{
	int sum = 0;
	int i = 2;

	while (i <= n)
	{
		sum += i*(i - 1);
		i += 2;
	}

	return sum;
}

int GetMulSumGoto(int n)
{
	int sum = 0;
	int i = 2;
LOOPA:
	if (i <= n)
	{
		sum += i*(i - 1);
		i += 2;
		goto LOOPA;
	}

	return sum;
}

void ShowMatrix(int *a[], int x, int y);
void InitMatrix(int *a[], int x, int y);
void ChangeMatrix(int *a[], int x, int y, int *b[]);

int mainf8()
{
	//创建一个a[3][5]的二维数组，并用随机数填充，并将其逆转成b[5][3],
	//按照平面矩阵把它输出。
	int a[3][5];
	int b[5][3];

	InitMatrix((int **)a, 3, 5);
	ShowMatrix((int **)a, 3, 5);
	ChangeMatrix((int **)a, 3, 5, (int **)b);
	ShowMatrix((int **)b, 5, 3);

	system("pause");
	return 0;
}

void ShowMatrix(int *a[], int x, int y)
{
	for (int i = 0; i < x; i++)
	{
		for (int j = 0; j < y; j++)
		{
			printf("%4d", a[i][j]);
		}
		printf("\n");
	}
}

void InitMatrix(int *a[], int x, int y)
{
	for (int i = 0; i < x; i++)
	{
		for (int j = 0; j < y; j++)
		{
			a[i][j] = rand() % 100;
		}
	}
}

void ChangeMatrix(int *a[], int x, int y, int *b[])
{
	for (int i = 0; i < y; i++)
	{
		for (int j = 0; j < x; j++)
		{
			b[i][j] = a[j][i];
		}
	}
}

/*
功能：
设计一个函数，检测一个数是否为质数，并将0-10000的质数存入一个数组，非质数存入另外一个数组。
思路：
建立一个bool自定义类型的数组，用筛选法，
除2之外的所有偶数都不是素数
素数的倍数都不是素数
*/

#define TRUE 1
#define FALSE 0

typedef int Boolean;
typedef int Status;

Status TestPrime(int num);

int mainf9()
{
	Boolean* bArray = (Boolean *)malloc(10001 * sizeof(Boolean));//内存分存函数

	memset(bArray, 1, 10001 * sizeof(Boolean));
	bArray[1] = bArray[0] = FALSE;
	bArray[2] = TRUE;
	for (int i = 4; i < 10001; i += 2)
	{
		bArray[i] = FALSE;
	}
	for (int i = 3; i < 10001; i += 2)
	{
		if (bArray[i] == FALSE)
		{
			continue;
		}
		if (TestPrime(i))
		{
			for (int j = i + i; j < 10001; j += j)
			{
				bArray[j] = FALSE;
			}
		}
	}

	system("pause");
	free(bArray);
	return 0;
}

Status TestPrime(int num)
{
	for (int i = 2; i < sqrt((double)num); i++)
	{
		if (num%i == 0)
		{
			return FALSE;
		}
	}

	return TRUE;
}

/*
功能：
根据N打印输出下面的结果，假定N=3；
1 8 7
2 9 6
3 4 5
思路：
三个数ijk控制横坐标纵坐标循环层数
i和j负责改变方向
*/

void BuildHelixMatrix(int length);
void showMatrix(int *Matrix, int length);

int mainf10()
{
	BuildHelixMatrix(8);

	system("pause");
	return 0;
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

void BuildHelixMatrix(int length)
{
	int i, j, k;
	int a = 1;

	i = j = k = 0;

	int *Matrix = (int *)malloc(sizeof(int)*length*length);

	for (; k < (length + 1) / 2; k++)
	{
		while (i < length - k)
		{
			Matrix[i++*length + j] = a++;
		}
		i--;
		j++;
		while (j < length - k)
		{
			Matrix[i*length + j++] = a++;
		}
		i--;
		j--;

		while (i > k - 1)
		{
			Matrix[i--*length + j] = a++;
		}
		i++;
		j--;
		while (j > k)
		{
			Matrix[i*length + j--] = a++;
		}
		i++;
		j++;
	}
	showMatrix(Matrix, length);

	printf("\n");
}