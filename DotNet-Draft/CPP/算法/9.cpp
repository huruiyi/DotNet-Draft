#include<stdio.h>
#include<stdlib.h>
#include<math.h>
#include<iostream>
#include<string>
using namespace std;
//��Ŀ����һ���������ֽ������������磺����90,��ӡ��90=2*3*3*5��
//     �Ƿ�һ�������� 97  =1*97;
void  Nature_(int num)
{
	printf("\n%d", num);
	int a = 0;
	if (num)
	{
		printf("\n1�޷��ֽ�������");
	}
	else if (num == 2)
	{
		printf("\n2=1*2");
	}
	else if (num == 3)
	{
		printf("\n3=1*3");
	}
	else
	{
		char flag = 'Y';
		for (int i = 2; i < sqrt((double)num); i++)
		{
			if (num%i == 0)
			{
				flag = 'N';
				break;
			}
		}
		if (flag == 'Y')
		{
			printf("����һ������");
			printf("%d=%d*1", num, num);
		}
		else
		{
			printf("�ⲻ��һ������");
			printf("%d=", num);

			for (int j = 2; j < num; j++)//�𵽴�2��num-1��������������
			{
				while (num != j)//�����ס�
				{
					if (num%j == 0)//num��������j
					{
						printf("%d*", j);
						num = num / j;//���num����2�Ժ����
					}
					else
					{
						break;//��������ֱ������whileѭ��
					}
				}
			}
			printf("%d", num);
		}
	}
}
void  Nature_(int num);
void main()//main4()
{
	cout << _MSC_VER << endl;

	int a;
	scanf_s("%d", &a);

	Nature_(a);
	system("pause");
}