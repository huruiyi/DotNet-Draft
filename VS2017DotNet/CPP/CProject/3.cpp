#include <stdio.h>
#include <stdlib.h>

void  main31()
{
	char c;
	do
	{
		c = getchar();//接收字符的输入
		if (c >= 'A' && c <= 'Z')//判断是否大写字母
		{
			putchar(c + 32);//输出小写字母
		}
	} while (c != '\t');//\t代表tab键盘
}

void main32()
{
	int i = 1;
	int jieguo = 0;

	do //do下面的语句模块就是循环体
	{
		jieguo = jieguo + i;
		i = i + 1;
		printf("\ni=%d,jieguo=%d", i, jieguo);
	} while (i < 101);//就是检测循环的条件

	system("pause");
}