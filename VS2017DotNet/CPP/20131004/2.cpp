#include <stdio.h>
#include <stdlib.h>

void main2()
{
	int hj3[10] = { 1, 2, 3, 4, 5 };//除了循环初始化，也可以大括号集合初始化
	//一唯数组初始化的一般格式{1,2,3,4,5,6,7,8,9,0}
	//如果数组的元素超过了大括号中集合的元素，没有得到赋值的元素，就会被初始化为0

	//int hj4[10];//数组没有初始化，出现的垃圾数据

	int hj1[] = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };//元素大小确定的场合，数组的大小可以省略;
	//int hj2[];//数组必须有明确的大小

	//int jk[]={};数组必须要有明确的大小，必须是正整数

	int hj5[10] = { 0 };//所有的元素初始化为0
	/*
	int  b[  ]={1,2,3,4};有四个元素
	int  b[10]={1,2,3,4};有十个元素，所以不等价
	*/

	for (int i = 0; i < 10; i++)
	{
		printf("\n%d", hj5[i]);
	}
	system("pause");
}