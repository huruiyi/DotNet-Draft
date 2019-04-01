#include <stdio.h>
#include <stdlib.h> 

int add(int x, int y)//加法的函数
{
	return x + y; //返回加法的结果
}

int cheng(int x, int y)
{
	return x*y;
}

//函数int add(int x,int y);

void maindd()
{
	int a = 1;
	int b = 2;

	printf("%d", add(a, b));

	int(*p)(int, int);//函数指针类型，第一个int返回值类型，后面两个int是参数

	p = add;//add就是函数内存地址，p指针变量，函数指针

	printf("%x", p);
	printf("\n%d", p(a, b));//打印出1+2，打印p，也是函数的内存地址
	p = cheng;
	printf("\n%x", p);
	printf("\n%d", p(a, b));

	getchar();
}

void main02()//指针修改变量
{
	int a = 1;
	int b = 2;
	int c = 0;
	printf("\na地址=%x,b地址=%x,c地址=%x", &a, &b, &c);

	c = a + b;

	printf("\n%d", c);//数学计算

	int *p;
	p = &a;//p相当于内存地址，等价于int *, int起到指示占据四个字节，从这个内存地址开始
	*p = 5;//*p相当于int类型数据，指针P所指向的数据
	printf("\n%d", a);
	printf("\n%x,%d", p, *p);

	printf("\n%d", add(a, b));//调用函数实现加减

	getchar();
}