/*
һ��������������100����һ����ȫƽ������
�ټ���168����һ����ȫƽ���������ʸ����Ƕ��٣�
���һ������ƽ������ƽ�����ڸ�������˵����������ȫƽ����
100 10
99  9
*/

#include <stdio.h>
#include <stdlib.h>
#include <math.h>//sqrt��������ƽ����
int Wq_sqrt(int j)
{
	int u, v;
	char flag;
	for (int i = 0; i < j; i++)
	{
		u = (int)sqrt((double)(i + 100));//ȡƽ����
		v = (int)sqrt((double)(i + 268));//ȡƽ����
		if (u*u == (i + 100) && v*v == (i + 268))//����ת���ɴ��롣
		{
			printf("\n%d", i);
		}
		flag = 'y';
	}
	if (flag != 'y')
		printf("\n%c", flag);
	return 0;
}
int Wq_sqrt(int j);
void main7()// main2()
{
	int a = 0;
	scanf_s("%d", &a);
	Wq_sqrt(a);
	system("pause");
}