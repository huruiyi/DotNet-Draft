#include <stdio.h>
#include <math.h>
#include <stdlib.h>
/*
蛇形矩阵另外一种算法：

整体思路：顺时针方向依次放入数据，如果走到边缘（数组边缘或者已经存放过数据）就顺时针拐弯。
直到将所有的数据填满。

算法优点：这种算法是模拟实际中画蛇形矩阵的方法，只用到了判断是否为0的一个小函数，
没有用到更高级的数学方法来解此题目，个人感觉更加直观，便于理解。
*/
int isEmpty(int a)//判断数组元素是否为0
{
	if (a == 0)
		return 1;
	else
		return 0;
}

int main3()
{
	const int N = 3;
	int a[N][N] = { 0 };//将所有元素初始化为0
	int i = 0;//
	int j = 0;
	int k = 1;//数据元素，从1---N*N
	while (1)
	{
		while (i <= N - 1)//横向向下走，最多走N步，此处只需考虑最大值就行，
			//循环内部会自己判断是否要进行转弯
		{
			if (isEmpty(a[i][j]))//如果数组元素是0则赋值
			{
				a[i][j] = k;
				i++;//再走一步
				k++;//数据跟着增加1
			}
			else//如果不为空则跳出循环，拐弯
				break;
		}
		i--;//i往前复位一步
		j++;//往右转向
		while (j <= N - 1)//向右依次走
		{
			if (isEmpty(a[i][j]))
			{
				a[i][j] = k;
				j++;
				k++;
			}
			else
				break;
		}
		j--;//退一步复位
		i--;//继续转向
		while (i >= 0)//往上走，走到边缘（边缘可以是0，也可以是一个非0数）
		{
			if (isEmpty(a[i][j]))
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
		while (j >= 0)//往上走
		{
			if (isEmpty(a[i][j]))
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