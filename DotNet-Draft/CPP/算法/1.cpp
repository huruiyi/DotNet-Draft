//����һ��������������˵N
//��N=5��N=1+4=2+3
// =3+2=4+1
//1
//��ѧ�ĳ���ԭ��
//
/*
10
һ��������Ϊ���������ض���һ��С�ڵ���5
c=a+b
1+9   ,  9+1

100
һ��������Ϊ������֮�����ض���һ��С�ڵ�10��
c=a*b
*/

#include <stdio.h>
#include <stdlib.h>
void main1()
{
	/*
	5      5/2
	1+4 2+3 3+2 4+1

	6 ===== 3
	1+5 2+4 3+3  4+2 5+1
	*/
	unsigned int n;
	scanf_s("%d", &n);//����һ������N  //���˳���Ҫע�ⲻ�������ַ���
	printf("\nȫ����");
	//���ʽ���㷨���������еĿ��ܡ�
	for (int i = 1; i < n; i++)
	{
		printf("\n%d=%d+%d", n, i, n - i);
	}
	printf("\n������");
	for (int i = 1; i <= n / 2; i++)
	{
		printf("\n%d=%d+%d", n, i, n - i);
	}
	system("pause");
}
int j;

void drawer_principle(unsigned int *iData)
{
	//unsigned int *iData;
	printf("\nȫ����");  //#include <stdio.h> #include <stdlib.h>
	for (int i = 1; i < *iData; i++)
	{
		printf("\n%d=%d+%d", *iData, i, *iData - i);
	}
	printf("\n������");
	for (int i = 1; i <= *iData / 2; i++)
	{
		printf("\n%d=%d+%d", *iData, i, *iData - i);
	}
}