#include <stdio.h>
#include <stdlib.h>

void main3()
{
	int a[3] = { 1, 2, 3 };
	int b[3];
	// b=a;����֮�䲻����ֱ�Ӹ�ֵ,���Զ԰���Ԫ�ظ�ֵ
	printf("%x,%x", a, b);
	//a,b�����ڴ��ַ����һ��������
	//b+=a;���鲻����ֱ�����㣬ֱ�Ӹ�ֵ
	if (a > b)
	{
		//���ԱȽϣ�ʵ���ϱȽϵ����ڴ��ַ����ʵ�ʵ�����û���κ�Ӱ��
	}

	//printf("%d",a[1]);//ֻ�����ĳ��Ԫ�أ��������������;

	char  c[3] = { 'a', 'v', '\0' };//���ַ���������ַ����������һ��/0
	printf("%s", c);//�����ַ���������ַ�����/0Ϊ������

	system("pause");
}