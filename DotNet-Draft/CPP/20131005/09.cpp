#include <stdio.h>
#include <stdlib.h>
#include <math.h>


int main9()
{
	int score = 0;
	printf("请输入成绩：");
	scanf_s("%d", &score);

	if (score > 100)
	{
		printf("你OUT了！！\n");
		goto END;
	}

	score = score / 10 * 10;//去除个位

	if (score < 60)
	{
		printf("不及格\n");
		goto END;
	}
	else
	{
		switch (score)
		{
		case 60:
			printf("及格\n");
			break;
		case 70:
			printf("一般\n");
			break;
		case 80:
			printf("优秀\n");
			break;
		case 90:
			printf("卓越\n");
			break;
		case 100:
			printf("完美\n");
			break;
		}
	}



END:
	system("pause");
	return 0;
}