#include <stdlib.h>
#include <stdio.h>

void main10()
{
	int  hj[5] = { 1, 2, 3, 4, 5 };
	for (int o = 0; o < 5; o++)
	{
		printf("\n%d,%x,%x", hj[o], &hj[o], hj + o);
	}
	int a[3][2] = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
	//3ָ���м��У�2�ʹ���ÿ��������
	int  a1[][5] = { 1, 3, 4, 5, 6 };//��Ԫ��ȷ��������£����Բ�ָ���м���
	//int  a2[2][5]={{1,2,3},{4,5,6}};//ÿһ���м��б���ָ����
	int  a2[2][5] = { 0 };//���е�Ԫ�ض�Ϊ0
	printf("a2��ַ%x\n", a2);

	for (int i = 0; i < 2; i++)
	{
		for (int j = 0; j < 5; j++)
		{
			printf("\n%d,%x,%x", a2[i][j], &a2[i][j], a2[i] + j);
		}
	}
	system("pause");
}