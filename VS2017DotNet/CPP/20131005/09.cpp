#include <stdio.h>
#include <stdlib.h>
#include <math.h>


int main9()
{
	int score = 0;
	printf("������ɼ���");
	scanf_s("%d", &score);

	if (score > 100)
	{
		printf("��OUT�ˣ���\n");
		goto END;
	}

	score = score / 10 * 10;//ȥ����λ

	if (score < 60)
	{
		printf("������\n");
		goto END;
	}
	else
	{
		switch (score)
		{
		case 60:
			printf("����\n");
			break;
		case 70:
			printf("һ��\n");
			break;
		case 80:
			printf("����\n");
			break;
		case 90:
			printf("׿Խ\n");
			break;
		case 100:
			printf("����\n");
			break;
		}
	}



END:
	system("pause");
	return 0;
}