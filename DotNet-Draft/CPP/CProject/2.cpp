#include <stdio.h>//�������
#include <stdlib.h>//system��������

void main11()
{
	//��1+2+3+4+             100
	//��1+2+3+4+             200
	//�� 2+4+6+8             200

	int i;//ѭ���ı�����
	int jieguo;
	i = 1;
	jieguo = 0;
	while (i <= 100)//i��100Ҳ����ѭ���Ƿ�ִ�е�����
	{
		jieguo = jieguo + i;
		i = i + 1;//�����ѭ����ֹ��
		printf("\ni=%d,jieguo=%d", i, jieguo);
	}

	system("pause");
}

void  main12()
{
	//��ѭ��
	while (1)
	{
		printf("\ngogogo");
	}
}

void   main13()
{
	//����N����2^n  ,7^n
	int  n = 0;
	scanf_s("%d", &n);//����һ��n��ֵ

	int jieguo;
	jieguo = 1;//������

	if (n < 0)
	{
		printf("��Խ����");
	}

	int i = 0;//ѭ������
	while (i < n)  //��0��ʼѭ��������<n,��1��ʼ����<=n
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
	//���1.01^365,0.99^365
	double a = 1.0;
	double b = 1.0;
	double c = 1.0;
	double d = 1.0;
	int i = 0;//ѭ������
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