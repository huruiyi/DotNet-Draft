#include <stdio.h>
#include <stdlib.h>

void  main31()
{
	char c;
	do
	{
		c = getchar();//�����ַ�������
		if (c >= 'A' && c <= 'Z')//�ж��Ƿ��д��ĸ
		{
			putchar(c + 32);//���Сд��ĸ
		}
	} while (c != '\t');//\t����tab����
}

void main32()
{
	int i = 1;
	int jieguo = 0;

	do //do��������ģ�����ѭ����
	{
		jieguo = jieguo + i;
		i = i + 1;
		printf("\ni=%d,jieguo=%d", i, jieguo);
	} while (i < 101);//���Ǽ��ѭ��������

	system("pause");
}