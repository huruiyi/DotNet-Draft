#include <stdio.h>
#include <stdlib.h>

void main051()
{
	int a[4096];
	for (int i = 0; i < 4096; i++)
	{
		a[i] = i + 1;
	}
	int hj;
	scanf_s("%d", &hj);
	int tou = 0;
	int wei = 4095;
	int zhong = (tou + wei) / 2;
	int cishu = 0;
	int flag = 0;//�ٶ��Ҳ���
	while (tou <= wei)//�ҵ�Ϊֹ
	{
		cishu += 1;
		printf("\n%d,%d,%d", tou, zhong, wei);
		if (hj == a[zhong])
		{
			flag = 1;
			printf("\n���������ҵ�λ��%d", zhong);
			break;
		}
		else if (hj > a[zhong])//����
		{
			tou = zhong + 1;
			zhong = (tou + wei) / 2;
		}
		else if (hj < a[zhong])//С��
		{
			wei = zhong - 1;
			zhong = (tou + wei) / 2;
		}
	}

	if (flag == 0)
	{
		printf("û���ҵ�");
	}

	printf("һ��ִ��%d�� ", cishu);

	system("pause");
}