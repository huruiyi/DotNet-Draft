#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
#include <string.h>
#include <math.h>

int mainf1()
{
	//���100-2000֮�����в��ܱ�3���������ܱ�5���������ܱ�2���������ܱ�7��������
	for (int i = 101; i < 2000; i += 2)//ֻ���������ж�
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
	//����948��Ϊ������֮�ͣ�����һ��Ϊ13�ı�����һ��Ϊ11�ı�����
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
		printf("������\n");
	}
	else if (score >= 60 && score < 70)
	{
		printf("����\n");
	}
	else if (score >= 70 && score < 80)
	{
		printf("һ��\n");
	}
	else if (score >= 80 && score < 90)
	{
		printf("����\n");
	}
	else if (score >= 90 && score < 100)
	{
		printf("׿Խ\n");
	}
	else if (score == 100)
	{
		printf("����\n");
	}
	else
	{
		printf("��OUT��\n");
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
		printf("������\n");
	}
		break;
	case 6:
	{
		printf("����\n");
	}
		break;
	case 7:
	{
		printf("һ��\n");
	}
		break;
	case 8:
	{
		printf("����\n");
	}
		break;
	case 9:
	{
		printf("׿Խ\n");
	}
		break;
	case 10:
	{
		printf("����\n");
	}
		break;
	default:
		printf("��OUT��\n");
		break;
	}//switch

	system("pause");
	return 0;
}

int GetIntegerDigit(int num);

int mainf4()
{
	//�ж�һ�������ж���λ
	//��whileѭ����10������Ȼ��ͳ��ѭ��������ѭ�������ǳ�10��Ľ��
	printf("���������λ����%d\n", GetIntegerDigit(10));

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
	//�����Ϊһ��������ż��������ż�����
	//���磺n=8,8=2+6,8=4+4����ӵ��������ظ���
	PrintEvenExpression(50);

	system("pause");
	return 0;
}

void PrintEvenExpression(int num)
{
	if (num <= 2 || num % 2 == 1)
	{
		printf("��ȷ�������������ż�����һ����ֽܷ����ż��\n");
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
	//����һ������С���������С������һλ���Եڶ�λ������������
	//˼·��
	//��С������pow(10, n) + 0.5ȡ�����ٳ���pow(10, n)������
	double testNum;

	printf("������һ��С��:\n");
	scanf_s("%lf", &testNum);

	GetPointOneDigit(testNum);
	GetPointTwoDigits(testNum);

	system("pause");

	return 0;
}

void GetPointOneDigit(double dNum)
{
	printf("����һλ���������ֵΪ%f\n", (int)(dNum * 10 + 0.5) / 10.0);
}

void GetPointTwoDigits(double dNum)
{
	printf("������λλ���������ֵΪ%f\n", (int)(dNum * 100 + 0.5) / 100.0);
}

int GetMulSum(int n);
int GetMulSumFor(int n);
int GetMulSumDoWhile(int n);
int GetMulSumWhile(int n);
int GetMulSumGoto(int n);

int mainf7()
{
	//ʵ�ִ�1*2+3*4+5*6....+99*100�ĵݹ�ʵ�֣�for��while��do while�� gotoʵ��
	printf("�ݹ�ʵ����ֵΪ%d", GetMulSum(4));
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
	//����һ��a[3][5]�Ķ�ά���飬�����������䣬��������ת��b[5][3],
	//����ƽ�������������
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
���ܣ�
���һ�����������һ�����Ƿ�Ϊ����������0-10000����������һ�����飬��������������һ�����顣
˼·��
����һ��bool�Զ������͵����飬��ɸѡ����
��2֮�������ż������������
�����ı�������������
*/

#define TRUE 1
#define FALSE 0

typedef int Boolean;
typedef int Status;

Status TestPrime(int num);

int mainf9()
{
	Boolean* bArray = (Boolean *)malloc(10001 * sizeof(Boolean));//�ڴ�ִ溯��

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
���ܣ�
����N��ӡ�������Ľ�����ٶ�N=3��
1 8 7
2 9 6
3 4 5
˼·��
������ijk���ƺ�����������ѭ������
i��j����ı䷽��
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