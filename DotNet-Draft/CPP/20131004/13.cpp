#include <stdio.h>
#include <stdlib.h>

void main()
{
	const int N = 8;
	int a[N][N];

	int data = 1;
	//��������������,N*N��Ԫ��
	//i,j�𵽿��ƺ�������������
	for (int i = 0, j = 0, k = 0; k < (N + 1) / 2; k++)//k�𵽷ֲ������,��<k+1/2,���ݲ�����ѭ��
	{
		while (j < N - k)
		{
			//a[i][j++]=data++;
			a[i][j] = data;  //��������a[0][0]    a[0][1]  a[0][2] ��i���䣬j�仯
			j = j + 1;
			data = data + 1;
			//	printf("")
		}
		j--;//��������Ӱ�죬��Խ��
		i++;//�ı��У�

		while (i < N - k)
		{
			a[i][j] = data;
			i = i + 1;
			data = data + 1;
		}
		i--;//��������Ӱ�죬��Խ��
		j--;

		while (j > k - 1)
		{
			a[i][j] = data;
			j = j - 1;
			data = data + 1;
		}
		j++;//��������Ӱ�죬��Խ��
		i--;

		while (i > k)
		{
			a[i][j] = data;
			i = i - 1;
			data = data + 1;
		}
		i++;//��������Ӱ�죬��Խ��
		j++;
	}
	//����������д�ӡ
	for (int u = 0; u < N; u++)
	{
		for (int v = 0; v < N; v++)
		{
			printf("%10d", a[u][v]);
		}
		printf("\n");
	}

	system("pause");
}