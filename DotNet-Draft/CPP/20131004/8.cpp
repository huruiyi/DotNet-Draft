#include <stdio.h>
#include <stdlib.h>

int i = 1119;
//����һ�����飬ʵ�ִ�С���󣬴Ӵ�С
void main8()
{
	const  int  N = 10;
	int a[N];
	int  i = 10;//�ⲿ������������Ҳ���Ǵ����Ű��������Ŀ����
	for (int i = 0; i < 10; i++)//����������������ڲ�����Ϊ���ȡ�
	{
		a[i] = rand() % 125;//ȡ0��125�������
		printf("%d   ", a[i]);
	}

	int min;//���������С����Ԫ�ص��±�

	for (int u = 0; u < N - 1; u++)
	{
		min = u;//�ٶ���u��ʼʱ��С�ı���
		printf("��ѯʱ�̣�min,v��ֵ");
		for (int v = u + 1; v < N; v++)//��u+1�����һ��������һ����ѵ
		{
			if (a[v] < a[min])
			{
				min = v;//ѭ�����棬ʹ�����һ��ֵ����ֵ
				printf("%d,%d    ", min, v);
			}
		}

		printf("\n�������֮ǰ��״̬\n");
		for (int i = 0; i < N; i++)
		{
			printf("%d  ", a[i]);
		}
		if (min != u)
		{
			//ʵ�����������Ľ���
			int temp;
			temp = a[min];
			a[min] = a[u];
			a[u] = temp;
		}
		printf("\n�������֮���״̬\n");
		for (int i = 0; i < N; i++)
		{
			printf("%d  ", a[i]);
		}
	}
	//
	printf("\n���������Ժ��״̬\n");
	for (int i = 0; i < N; i++)
	{
		printf("%d  ", a[i]);
	}

	system("pause");
}