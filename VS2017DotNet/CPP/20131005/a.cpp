#include <stdio.h>
#include <stdlib.h>

int isEmpty2(int nuber)//�ж�����Ԫ���Ƿ�Ϊ0
{
	if (nuber == 0)
		return 1;
	else
		return 0;
}

int main01()
{
	const int N = 4;
	int a[N][N] = { 0 };	//������Ԫ�س�ʼ��Ϊ0
	int i = 0;			//������
	int j = 0;			//������
	int k = 1;			//����Ԫ�أ���1---N*N
	while (1)
	{
		while (i <= N - 1)	//����������
		{
			if (isEmpty2(a[i][j]))
			{
				a[i][j] = k;
				i++;
				k++;
				//printf("%d\n",a[i][j]);
			}
			else
				break;
		}
		i--;					//��һ����λ
		j++;					//����ת��
		while (j <= N - 1)		//���������ߣ������N�����˴�ֻ�迼�����ֵ���У�
			//ѭ���ڲ����Լ��ж��Ƿ�Ҫ����ת��
		{
			if (isEmpty2(a[i][j]))//�������Ԫ����0��ֵ
			{
				a[i][j] = k;
				j++;			//����һ��
				k++;			//���ݸ�������1
			}
			else//�����Ϊ��������ѭ��������
				break;
		}
		j--;//j��ǰ��λһ��
		i--;//����ת��

		while (i >= 0)//������
		{
			if (isEmpty2(a[i][j]))
			{
				a[i][j] = k;
				i--;
				k++;
			}
			else
				break;
		}
		i++;//��λ
		j--;//ת��
		while (j >= 0)//�����ߣ��ߵ���Ե����Ե������0��Ҳ������һ����0����
		{
			if (isEmpty2(a[i][j]))
			{
				a[i][j] = k;
				j--;
				k++;
			}
			else
				break;
		}
		j++;//��λ
		i++;//ת��
		if (k == N*N + 1)//��������������Ժ�Kֵ���Լӵ������л��N*N��1
		{
			break;
		}
	}

	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++)
		{
			printf("%d\t", a[i][j]);
		}
		putchar(10);//�س�
	}

	system("pause");
	return 0;
}