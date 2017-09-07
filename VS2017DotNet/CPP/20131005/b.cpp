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
	int flag = 0;//假定找不到
	while (tou <= wei)//找到为止
	{
		cishu += 1;
		printf("\n%d,%d,%d", tou, zhong, wei);
		if (hj == a[zhong])
		{
			flag = 1;
			printf("\n数据类型找到位置%d", zhong);
			break;
		}
		else if (hj > a[zhong])//大于
		{
			tou = zhong + 1;
			zhong = (tou + wei) / 2;
		}
		else if (hj < a[zhong])//小于
		{
			wei = zhong - 1;
			zhong = (tou + wei) / 2;
		}
	}

	if (flag == 0)
	{
		printf("没有找到");
	}

	printf("一共执行%d次 ", cishu);

	system("pause");
}