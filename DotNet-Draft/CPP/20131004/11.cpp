#include <stdlib.h>
#include <stdio.h>

void main11()
{
	const int N = 3;//const���峣��
	int a[N][N];
	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++)
		{
			a[i][j] = i*N + j + 1;//��ѧ��ʽ
			printf("%d   ", a[i][j]);//��ӡ��ÿ��Ԫ�ص�����
		}
		printf("\n");//���л���
	}
	int jieguo = 0;
	for (int k = 0; k < N; k++)
	{
		jieguo += a[k][k];//�Խ��ߣ������������
	}
	printf("\n%d", jieguo);
	system("pause");
}