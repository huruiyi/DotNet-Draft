#include <stdlib.h>
#include <stdio.h>

//ѭ����ӡ����ά����
void main9()
{
	int a[4] = { 1, 2, 3, 4 };
	int b[3][4] = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
	//  b[2][3],
	printf("%d", sizeof(b) / sizeof(int));
	for (int i = 0; i < 3; i++)//���ѭ��
	{
		for (int j = 0; j < 4; j++)//�ڲ�ѭ��
		{
			printf("\n%d,%d,%d,%x", i, j, b[i][j], &b[i][j]);
			//�ڴ�������һ��һ�������д洢
		}
	}

	system("pause");
}