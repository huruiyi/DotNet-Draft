#include <stdio.h>
#include <stdlib.h>

int isEmpty2(int nuber)//判断数组元素是否为0
{
	if (nuber == 0)
		return 1;
	else
		return 0;
}

int main01()
{
	const int N = 4;
	int a[N][N] = { 0 };	//将所有元素初始化为0
	int i = 0;			//横坐标
	int j = 0;			//纵坐标
	int k = 1;			//数据元素，从1---N*N
	while (1)
	{
		while (i <= N - 1)	//向下依次走
		{
			if (isEmpty2(a[i][j]))
			{
				a[i][j] = k;
				i++;
				k++;
				//printf("%d\n",a[i][j]);
			}
			else
				break;
		}
		i--;					//退一步复位
		j++;					//继续转向
		while (j <= N - 1)		//横向向右走，最多走N步，此处只需考虑最大值就行，
			//循环内部会自己判断是否要进行转弯
		{
			if (isEmpty2(a[i][j]))//如果数组元素是0则赋值
			{
				a[i][j] = k;
				j++;			//再走一步
				k++;			//数据跟着增加1
			}
			else//如果不为空则跳出循环，拐弯
				break;
		}
		j--;//j往前复位一步
		i--;//往下转向

		while (i >= 0)//往上走
		{
			if (isEmpty2(a[i][j]))
			{
				a[i][j] = k;
				i--;
				k++;
			}
			else
				break;
		}
		i++;//复位
		j--;//转向
		while (j >= 0)//往左走，走到边缘（边缘可以是0，也可以是一个非0数）
		{
			if (isEmpty2(a[i][j]))
			{
				a[i][j] = k;
				j--;
				k++;
			}
			else
				break;
		}
		j++;//复位
		i++;//转向
		if (k == N*N + 1)//填充完所有数据以后K值在自加到过程中会比N*N多1
		{
			break;
		}
	}

	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++)
		{
			printf("%d\t", a[i][j]);
		}
		putchar(10);//回车
	}

	system("pause");
	return 0;
}