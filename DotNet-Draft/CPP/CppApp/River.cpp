#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define STEP_MAX 20 //���ع��ӵĴ���
#define KIND_NUM 3 //ÿ�����������
#define BOAT_NUM 2 //����������
typedef enum
{
	BOAT_THIS,//���ڱ���
	BOAT_THAT,//���ڶ԰�
} boat_t;
typedef enum
{
	ROAD_GO,//����
	ROAD_COME,//����
} road_t;
typedef struct
{
	int ye;//�԰�Ұ������
	int man;//�԰�����ʿ����
	boat_t boat;//���Ƿ��ڶ԰�
} state_t;//һ�־���
typedef struct
{
	int ye;//Ұ�˹�������
	int man;//����ʿ���ӵ�����
	road_t road;//���������
} step_t;//һ������

state_t states[STEP_MAX] = { 0 };
step_t steps[STEP_MAX] = { 0 };

//�ж����е�Ұ�˺ʹ���ʿ�Ƿ񶼵��˶԰�
bool final(state_t s)
{
	const state_t cs =
	{
		KIND_NUM,
		KIND_NUM,
		BOAT_THAT
	};
	if (memcmp(&cs, &s, sizeof(state_t)) == 0)
	{
		return true;
	}
	return false;
}
//�Ƿ�ᷢ��Ұ��ɱ����ʿ
bool bad(state_t s)
{
	if (((KIND_NUM - s.ye) > (KIND_NUM - s.man) && (KIND_NUM - s.man) > 0)
		|| (s.ye > s.man && s.man > 0))
	{
		return true;
	}
	return false;
}
//��n�־����Ƿ��ǰ������ظ�
bool repeat(state_t s[], int n)
{
	int i;

	for (i = 0; i < n; i++)
	{//�Ѿ������������
		if (memcmp(&states[i], &states[n], sizeof(states[i])) == 0)
		{
			return true;
		}
	}
	return false;
}
void output(step_t steps[STEP_MAX], int n)
{
	char *kinds[KIND_NUM] = { "Ұ��","����ʿ" };
	char *routine[2] = { "����.","����." };
	int i;
	for (i = 0; i < n; i++)
	{
		if ((steps[i].ye * steps[i].man) > 0)
		{
			printf("%d��%s��%d��%s%s\n", steps[i].ye, kinds[0],
				steps[i].man, kinds[1], routine[steps[i].road]);
		}
		else if (steps[i].ye > 0)
		{
			printf("%d��%s%s\n", steps[i].ye, kinds[0],
				routine[steps[i].road]);
		}
		else if (steps[i].man > 0)
		{
			printf("%d��%s%s\n", steps[i].man, kinds[1],
				routine[steps[i].road]);
		}
	}
	printf("\n");
}
//�������ӷ���(n��ʾ���Ӵ���)
void search(int n)
{
	int i, j;
	if (n > STEP_MAX)
	{//��������̫����
		printf("Step Overflow!");
		return;
	}
	if (final(states[n]))
	{//�����԰���
		output(steps, n);
		return;
	}
	if (bad(states[n]))
	{//������Ұ��ɱ����ʿ��
		return;
	}
	if (repeat(states, n))
	{//��ǰ��ľ������ظ���
		return;
	}
	if (states[n].boat == BOAT_THIS)
	{//���ڱ���
		for (i = 0; i <= BOAT_NUM && i <= (KIND_NUM - states[n].ye); i++)
			for (j = 0; j <= BOAT_NUM - i && j <= (KIND_NUM - states[n].man); j++)
			{
				if (i == 0 && j == 0)
				{
					continue;
				}
				steps[n].ye = i;
				steps[n].man = j;
				steps[n].road = ROAD_GO;
				memcpy(&states[n + 1], &states[n], sizeof(state_t));
				states[n + 1].ye += i;
				states[n + 1].man += j;
				states[n + 1].boat = BOAT_THAT;
				search(n + 1);
			}
	}
	else
	{
		for (i = 0; i <= BOAT_NUM && i <= states[n].ye; i++)
			for (j = 0; j <= BOAT_NUM - i && j <= states[n].man; j++)
			{
				if (i == 0 && j == 0)
				{
					continue;
				}
				steps[n].ye = i;
				steps[n].man = j;
				steps[n].road = ROAD_COME;
				memcpy(&states[n + 1], &states[n], sizeof(state_t));
				states[n + 1].ye -= i;
				states[n + 1].man -= j;
				states[n + 1].boat = BOAT_THIS;
				search(n + 1);
			}
	}
}

int mainx()
{
	search(0);
	return 0;
}