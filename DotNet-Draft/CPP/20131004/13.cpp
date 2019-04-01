#include <stdio.h>
#include <stdlib.h>

void main()
{
	const int N = 8;
	int a[N][N];

	int data = 1;
	//对于数组进行填充,N*N个元素
	//i,j起到控制横坐标与纵坐标
	for (int i = 0, j = 0, k = 0; k < (N + 1) / 2; k++)//k起到分层的作用,层<k+1/2,根据层数才循环
	{
		while (j < N - k)
		{
			//a[i][j++]=data++;
			a[i][j] = data;  //横向向左a[0][0]    a[0][1]  a[0][2] ，i不变，j变化
			j = j + 1;
			data = data + 1;
			//	printf("")
		}
		j--;//消除最后的影响，不越界
		i++;//改变行，

		while (i < N - k)
		{
			a[i][j] = data;
			i = i + 1;
			data = data + 1;
		}
		i--;//消除最后的影响，不越界
		j--;

		while (j > k - 1)
		{
			a[i][j] = data;
			j = j - 1;
			data = data + 1;
		}
		j++;//消除最后的影响，不越界
		i--;

		while (i > k)
		{
			a[i][j] = data;
			i = i - 1;
			data = data + 1;
		}
		i++;//消除最后的影响，不越界
		j++;
	}
	//对于数组进行打印
	for (int u = 0; u < N; u++)
	{
		for (int v = 0; v < N; v++)
		{
			printf("%10d", a[u][v]);
		}
		printf("\n");
	}

	system("pause");
}