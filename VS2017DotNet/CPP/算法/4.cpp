#include <stdio.h>
#include <stdlib.h>
//记住数学原理，将数学原理转换成代码

/*
100  =10*10
30   =3*10

10  300

100
48=12*4

4  ,1200=12*100

10
300

100  30  10
u    v    t

100  30  10
30   10  0

120  40  0
6*20 6*3

120  18  12
u     v  temp
18   12   6
u    v  temp
12   6    0
u    v    temp
6     0
u     v   temp

*/
void main4()
{
	int u, v;
	scanf_s("%d%d", &u, &v);//传入两个变量
	printf("你输入的数据是%d,%d", u, v);
	int hj = u*v;

	if (u > v)
	{
		//啥都不做
	}
	else
	{
		//交换U，V的值
		int temp;
		temp = u;
		u = v;
		v = temp;

		//交换，U,V的值
		//u=u+v;
		//v=u-v;
		// u=u-v;
	}
	//任意两个数之积=最小公倍数*最大公约数

	int temp;
	while (v != 0)
	{
		temp = u%v;//求余数
		u = v;
		v = temp;
	}
	printf("最大公约数=%d,最小公倍数%d", u, hj / u);

	system("pause");
}