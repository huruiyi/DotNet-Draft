#include <stdio.h>
#include <stdlib.h>
//1*2+3*4+5*6+    99*100
//2n*(2n-1)   50

void main43()
{
	//for (int i=0;i<10;i++)
	//���û�п���䣬Ĭ�Ϸ�Χ��������ķֺ�ǰ�����䣬�����Ҳ������
	;
	int i = 0;
	while (i < 10)//;�ֺţ�while,for������÷�Χ��������ֺ�ǰ�����䣬�����Ҳ������
	{
		i++;
		printf("\n%d", i);
	}
	printf("\n111");
	printf("\n2222");
	getchar();
}

void  main42()
{
	for (int n = 1, jieguo = 0; n < 51; n++)
	{
		printf("\n=%d", n);

		jieguo = jieguo + 2 * n*(2 * n - 1);

		printf("   jieguo=%d", jieguo);
	}

	system("pause");
}

void main41()
{
	for (int i = 1, jieguo = 0; i < 101; i++)//���1����ʼ��������//���2���ж�ѭ�������Ƿ���ֹ��
		//���3����i��������������ѭ��
	{
		printf("\n%d", i);

		jieguo = jieguo + i;
		printf("   %d", jieguo);
	}

	system("pause");
}