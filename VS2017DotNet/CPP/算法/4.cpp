#include <stdio.h>
#include <stdlib.h>
//��ס��ѧԭ������ѧԭ��ת���ɴ���

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
	scanf_s("%d%d", &u, &v);//������������
	printf("�������������%d,%d", u, v);
	int hj = u*v;

	if (u > v)
	{
		//ɶ������
	}
	else
	{
		//����U��V��ֵ
		int temp;
		temp = u;
		u = v;
		v = temp;

		//������U,V��ֵ
		//u=u+v;
		//v=u-v;
		// u=u-v;
	}
	//����������֮��=��С������*���Լ��

	int temp;
	while (v != 0)
	{
		temp = u%v;//������
		u = v;
		v = temp;
	}
	printf("���Լ��=%d,��С������%d", u, hj / u);

	system("pause");
}