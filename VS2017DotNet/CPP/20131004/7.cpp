#include <stdio.h>
#include <stdlib.h>

void main7()
{
	const int N = 10;
	int  a[N];
	for (int i = 0; i < N; i++)
	{
		a[i] = rand() % 100;//ȡ0-1000֮��������
	}
	for (int j = 0; j < N; j++)
	{
		printf("\n%d", a[j]);//��ӡ�����������
	}
	printf("\n\n\n");
	int minb = 0;//������ʱ����Сֵ���±�
	int min = 0;//��ʱ����Сֵ
	for (int u = 0; u < N - 1; u++)//10����һֱ������֮�䣬ѡ��Сֵ��
	{
		minb = u;//�ٶ���ǰԪ��Ϊ��СԪ��
		for (int v = u + 1; v < N; v++)//u=0,a[1]��a[N-1],u=1,a[2]��a[N-1]
		{
			if (a[v] < a[minb])//��a[v] a[minb]�м���С�����±걣�浽minb
			{
				minb = v;    //ѭ���жϣ�����С���±����minb,
				//
			}
		}
		printf("\n ������ǰ������\n");
		for (int iii = 0; iii < N; iii++)
		{
			printf("%d    ", a[iii]);//��ӡ�����������
		}

		if (minb != u)//���minb�����仯���ͽ�������������ֵ
		{
			//������������Ľ���
			int temp = a[minb];
			a[minb] = a[u];
			a[u] = temp;
		}
		printf("\n �����Ժ������\n");
		for (int ii = 0; ii < N; ii++)
		{
			printf("%d    ", a[ii]);//��ӡ�����������
		}
	}

	printf("\n\n\n");

	for (int jj = 0; jj < N; jj++)
	{
		printf("\n%d", a[jj]);//��ӡ�����������
	}

	system("pause");
}