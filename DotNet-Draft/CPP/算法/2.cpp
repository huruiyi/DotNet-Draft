#include <stdio.h>
#include <stdlib.h>
#include <math.h>//��ѧ��ͷ�ļ�������sqrt��ƽ����
//��ӡ��2-200���ڵ�����������

void main21()//44
{
	for (int i = 2; i <= 200; i++)
	{
		char  flag = 'Y';//��־�Ƿ�һ������
		if (i >= 4)
		{
			for (int j = 2; j <= i - 1; j++)
			{
				if (i%j == 0)
				{
					flag = 'N';
					break;//����ѭ��
				}
			}
		}
		if (flag == 'N')
		{
			continue;   //������ǰѭ�����ظ��ϲ�ѭ��
		}
		printf("\n%d", i);
	}

	system("pause");
}

void main22()//�������㷨
{
	for (int i = 2; i <= 200; i++)//ѭ�����е���������
	{
		char  flag = 'Y';//�ٶ����е�����������

		if (i >= 4)
		{
			for (int j = 2; j <= sqrt((double)i); j++) //ѭ���жϣ�����ܱ�������
				//������ѭ������־������
			{
				if (i%j == 0)
				{
					flag = 'N';
					break;//����ѭ��
				}
			}
		}

		if (flag == 'N')//��⵽������������ѭ��
		{
			continue;
		}

		printf("\n%d", i);
	}

	system("pause");
}

void main23()//ɸѡ������������ķ������Զ����£��𲽵���
{
	for (int i = 2; i <= 200; i++)//ѭ�����е���������
	{
		char  flag = 'Y';//�ٶ����е�����������

		if (i >= 4)
		{
			for (int j = 2; j <= sqrt((double)i); j++) //ѭ���жϣ�����ܱ�������
				//������ѭ������־������
			{
				if (i%j == 0)
				{
					flag = 'N';
					break;//����ѭ��
				}
			}
		}
		if (flag == 'Y')//������������ѭ��
		{
			continue;
		}

		printf("\n%d", i);
	}

	system("pause");
}

void main24()//ɸѡ����
{
	for (int i = 2; i <= 200; i++)//ѭ�����е���������
	{
		char  flag = 'Y';//�ٶ����е�����������

		if (i >= 4)
		{
			for (int j = 2; j <= sqrt((double)i); j++) //ѭ���жϣ�����ܱ�������
				//������ѭ������־������
			{
				if (i%j == 0)
				{
					flag = 'N';
					break;//����ѭ��
				}
			}
		}

		if (flag == 'Y')//������������ѭ��
		{
			continue;
		}

		printf("\n%d", i);
	}

	system("pause");
}