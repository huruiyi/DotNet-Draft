#include <stdio.h>
#include <stdlib.h>
//ʵ���ҳ���С��Ԫ��
void main6()
{
	int a[10];
	for (int i = 0; i < 10; i++)
	{
		a[i] = rand() % 100;//ȡ0��100�������
	}
	for (int j = 0; j < 10; j++)
	{
		printf("\n%d", a[j]);
	}
	int min;//��С��Ԫ��
	min = a[0];

	printf("\n\n\n");
	for (int k = 1; k<10; k++)
	{
		if (min >a[k])//��ak,min����Сֵ����min
		{
			//������������
			int temp;
			temp = min;
			min = a[k];
			a[k] = temp;
		}
		printf("\nk=%d,min=%d,a[%d]=%d ", k, min, k, a[k]);
		a[0] = min;//��ֵ����һ��Ԫ�أ��õ�һ��Ԫ����С
		for (int u = 0; u < 10; u++)//��ӡ�������״̬
		{
			printf("\n%d", a[u]);
		}
	}
	printf("\n%d", min);

	system("pause");
}