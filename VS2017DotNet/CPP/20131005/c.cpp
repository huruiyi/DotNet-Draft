// 14.18.cpp : �������̨Ӧ�ó������ڵ㡣
//  �����㷨

#include <iostream>
#include <stdio.h>
#include <stdlib.h>
using namespace std;

int find(int m, int a[], int n);
bool add(int a[], int n);

int mainc()
{
	//int a[]={1,11,21,32,61,62,51,88,22,33,44,55,66,99,10};
	const int N = 100;
	int number[N];
	for (int i = 0; i < N; i++)
	{
		number[i] = (100 + rand() % 100);

		printf("%d\t", number[i]);
	}
	printf("*********************************************************\n");
	int minb = 0;//������ʱ����Сֵ���±�
	int min = 0;//��ʱ����Сֵ
	for (int u = 0; u < N - 1; u++)//10����һֱ������֮�䣬ѡ��Сֵ��
	{
		minb = u;//�ٶ���ǰԪ��Ϊ��СԪ��
		for (int v = u + 1; v < N; v++)//u=0,a[1]��a[N-1],u=1,a[2]��a[N-1]
		{
			if (number[v] < number[minb])//��a[v] a[minb]�м���С�����±걣�浽minb
			{
				minb = v;    //ѭ���жϣ�����С���±����minb,
				//
			}
		}

		if (minb != u)//���minb�����仯���ͽ�������������ֵ
		{
			//������������Ľ���
			int temp = number[minb];
			number[minb] = number[u];
			number[u] = temp;
		}

		printf("%d\t", number[u]);
	}
	printf("\n���ֵΪ�� %d", number[N - 1]);
	printf("\n��СֵΪ�� %d", number[min]);

	int data1;
	scanf_s("%d", &data1);

	cout << "32������a�е�λ���ǣ�" << find(data1, number, 100) << endl;

	getchar();

	return 0;
}

int find(int m, int a[], int n)
{
	int o = 0, h = n - 1, i;  	//��������Ԫ���Ǵ�0�����鳤�ȼ�1����������ʼ����0�����1��Ԫ�صı�ţ�h�������һ��Ԫ�أ�i�����ǰ���ڲ��ҵ�Ԫ�صı��
	while (o <= h)
	{
		i = (o + h) / 2;     	//ȡ�м�Ԫ�صı��
		if (a[i] == m)    	//�������ǲ��������ñ��Ԫ�ص�ֵ���
			return i;      	//���ظ�Ԫ�صı��
		if (a[i] < m)    	//����ñ��Ԫ�ص�ֵС��������Ҫ�������
			o = i + 1;      		//����Ԫ�صı�ż�1����o��Ҳ�����ں�벿������
		else h = i - 1;   	//����Ԫ�صı�ż�1����h��Ҳ������ǰ�벿������
	}
	return n;			//�����������������鳤��
}
bool add(int a[], int n)
{
	for (int i = 1; i < n; i++)
	{
		if (a[i] < a[i - 1])
		{
			return false;
		}
	}
	return	true;
}