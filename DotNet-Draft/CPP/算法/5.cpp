#include <stdio.h>
#include <stdlib.h>

//���ݷ����㷨
void main5()
{
	for (int i = 100; i <= 999; i++)
	{
		int gewei = i % 10; //�����λ�����10λ�������λ
		int shiwei = i / 10 % 10;
		int baiwei = i / 100;
		if (i == gewei*gewei*gewei + shiwei*shiwei*shiwei + baiwei*baiwei*baiwei)
		{
			//һ��д���£������ö��ŷָ�
			printf("\n%d=%d*%d*%d+%d*%d*%d+%d*%d*%d",
				i,
				gewei,
				gewei,
				gewei,
				shiwei,
				shiwei,
				shiwei,
				baiwei,
				baiwei,
				baiwei);
		}
	}

	getchar();
}