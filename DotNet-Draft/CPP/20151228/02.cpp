#include <stdio.h>
#include <stdlib.h> 

int add(int x, int y)//�ӷ��ĺ���
{
	return x + y; //���ؼӷ��Ľ��
}

int cheng(int x, int y)
{
	return x*y;
}

//����int add(int x,int y);

void maindd()
{
	int a = 1;
	int b = 2;

	printf("%d", add(a, b));

	int(*p)(int, int);//����ָ�����ͣ���һ��int����ֵ���ͣ���������int�ǲ���

	p = add;//add���Ǻ����ڴ��ַ��pָ�����������ָ��

	printf("%x", p);
	printf("\n%d", p(a, b));//��ӡ��1+2����ӡp��Ҳ�Ǻ������ڴ��ַ
	p = cheng;
	printf("\n%x", p);
	printf("\n%d", p(a, b));

	getchar();
}

void main02()//ָ���޸ı���
{
	int a = 1;
	int b = 2;
	int c = 0;
	printf("\na��ַ=%x,b��ַ=%x,c��ַ=%x", &a, &b, &c);

	c = a + b;

	printf("\n%d", c);//��ѧ����

	int *p;
	p = &a;//p�൱���ڴ��ַ���ȼ���int *, int��ָʾռ���ĸ��ֽڣ�������ڴ��ַ��ʼ
	*p = 5;//*p�൱��int�������ݣ�ָ��P��ָ�������
	printf("\n%d", a);
	printf("\n%x,%d", p, *p);

	printf("\n%d", add(a, b));//���ú���ʵ�ּӼ�

	getchar();
}