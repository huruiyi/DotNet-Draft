#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define STEP_MAX 20 //来回过河的次数
#define KIND_NUM 3 //每个种类的数量
#define BOAT_NUM 2 //船的载重量
typedef enum
{
	BOAT_THIS,//船在本岸
	BOAT_THAT,//船在对岸
} boat_t;
typedef enum
{
	ROAD_GO,//过河
	ROAD_COME,//回来
} road_t;
typedef struct
{
	int ye;//对岸野人数量
	int man;//对岸传教士数量
	boat_t boat;//船是否在对岸
} state_t;//一种局面
typedef struct
{
	int ye;//野人过河数量
	int man;//传教士过河的数量
	road_t road;//回来或过河
} step_t;//一个步骤

state_t states[STEP_MAX] = { 0 };
step_t steps[STEP_MAX] = { 0 };

//判断所有的野人和传教士是否都到了对岸
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
//是否会发生野人杀传教士
bool bad(state_t s)
{
	if (((KIND_NUM - s.ye) > (KIND_NUM - s.man) && (KIND_NUM - s.man) > 0)
		|| (s.ye > s.man && s.man > 0))
	{
		return true;
	}
	return false;
}
//第n种局面是否跟前面的相重复
bool repeat(state_t s[], int n)
{
	int i;

	for (i = 0; i < n; i++)
	{//已经有这种情况了
		if (memcmp(&states[i], &states[n], sizeof(states[i])) == 0)
		{
			return true;
		}
	}
	return false;
}
void output(step_t steps[STEP_MAX], int n)
{
	char *kinds[KIND_NUM] = { "野人","传教士" };
	char *routine[2] = { "过河.","回来." };
	int i;
	for (i = 0; i < n; i++)
	{
		if ((steps[i].ye * steps[i].man) > 0)
		{
			printf("%d个%s和%d个%s%s\n", steps[i].ye, kinds[0],
				steps[i].man, kinds[1], routine[steps[i].road]);
		}
		else if (steps[i].ye > 0)
		{
			printf("%d个%s%s\n", steps[i].ye, kinds[0],
				routine[steps[i].road]);
		}
		else if (steps[i].man > 0)
		{
			printf("%d个%s%s\n", steps[i].man, kinds[1],
				routine[steps[i].road]);
		}
	}
	printf("\n");
}
//搜索过河方案(n表示过河次数)
void search(int n)
{
	int i, j;
	if (n > STEP_MAX)
	{//步数限制太少了
		printf("Step Overflow!");
		return;
	}
	if (final(states[n]))
	{//都到对岸了
		output(steps, n);
		return;
	}
	if (bad(states[n]))
	{//发生了野人杀传教士了
		return;
	}
	if (repeat(states, n))
	{//与前面的局面相重复了
		return;
	}
	if (states[n].boat == BOAT_THIS)
	{//船在本岸
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