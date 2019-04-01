#include <stdio.h>//输入输出
#include <stdlib.h>//system函数调用

void main11()
{
	//从1+2+3+4+             100
	//从1+2+3+4+             200
	//从 2+4+6+8             200

	int i;//循环的变量。
	int jieguo;
	i = 1;
	jieguo = 0;
	while (i <= 100)//i《100也就是循环是否执行的条件
	{
		jieguo = jieguo + i;
		i = i + 1;//是这个循环终止，
		printf("\ni=%d,jieguo=%d", i, jieguo);
	}

	system("pause");
}

void  main12()
{
	//死循环
	while (1)
	{
		printf("\ngogogo");
	}
}

void   main13()
{
	//输入N，求2^n  ,7^n
	int  n = 0;
	scanf_s("%d", &n);//接收一个n的值

	int jieguo;
	jieguo = 1;//保存结果

	if (n < 0)
	{
		printf("你越界了");
	}

	int i = 0;//循环变量
	while (i < n)  //从0开始循环，就是<n,从1开始就是<=n
	{
		jieguo = jieguo * 2;
		i = i + 1;
		printf("\njieguo=%d,i=%d", jieguo, i);
	}

	system("pause");
}

void main14()
{
	int n = 365;
	//求出1.01^365,0.99^365
	double a = 1.0;
	double b = 1.0;
	double c = 1.0;
	double d = 1.0;
	int i = 0;//循环变量
	while (i < n)
	{
		a = a*1.01;
		b = b*0.99;
		c = c*1.02;
		d = d*0.98;
		i = i + 1;
	}
	printf("a=%f,b=%f", a, b);
	printf("\nc=%f,d=%f", c, d);
	system("pause");
}