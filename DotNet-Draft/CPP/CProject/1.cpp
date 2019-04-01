#include <iostream>
using namespace std;

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>

unsigned int prime_number(unsigned int *iData)
{
	for (unsigned int i = 2; i <= *iData; i++)
	{
		unsigned char flag = 'Y';
		if (i >= 4)
		{
			for (unsigned int j = 2; j < i - 1; j++)
			{
				if (i%j == 0)
				{
					flag = 'N';
					break;
				}
			}
		}
		if (flag == 'Y')
		{
			printf("%d\n", i);
			continue;
		}
	}
	return 0;
}
unsigned int prime_number1(unsigned int *iData)
{
	for (unsigned int i = 2; i <= *iData; i++)//循环所有的数，遍历
	{
		char  flag = 'Y';//假定所有的数都是质数

		if (i >= 4)
		{
			for (int j = 2; j <= sqrt((double)i); j++) //循环判断，如果能被整除，
				//就跳出循环，标志非质数
			{
				if (i%j == 0)
				{
					flag = 'N';
					break;//跳出循环
				}
			}
		}

		if (flag == 'N')//检测到非质数，跳出循环
		{
			continue;
		}

		printf("\n%d", i);
	}

	return 0;
}

unsigned int prime_number(unsigned int *iData);
unsigned int prime_number1(unsigned int *iData);

void main2(void)
{
	unsigned int in;
	printf("请输入一个整数：");
	scanf_s("%d", &in);
	prime_number1(&in);
	system("pause");
}

int main1(void)
{
	char stra[] = "abcde";
	char strb[30];
	int i = 0;
	gets_s(strb);

	while (stra[i] == strb[i] & strb != '\0')
	{
		i++;
	}
	if (stra[i] > strb[i])
		printf("stra > strb %d\n", i);
	else if (stra[i] < strb[i])
		printf("stra < strb %d\n", i);
	else
		printf("stra == strb %d\n", i);

	system("pause");
	return 0;
}

/*
#ifdef _cplusplus
extern "c"{
#endif

#ifdef _cplusplus extern "c"{
#endif
unsigned int CalcCRC(unsigned char  *pdata, unsigned int  datalen) ;
void main()
{
	unsigned char a[]="d,s,d,d,s,d,s,d,s,";
	CalcCRC(a,9);
	cout<<CalcCRC<<endl;
	cout<<&CalcCRC;
	getchar();
}

unsigned int CalcCRC(unsigned char  *pdata, unsigned int  datalen)
{
	unsigned short reg16 = 0xFFFF;
	unsigned short general_mask=0x1021;
	int i,j,byte_temp,bit_temp;
	for(i = 0; i < datalen; i++)
	{
		byte_temp = *(pdata + i);
		for(j = 0;j <= 7;j++)
		{
			bit_temp = ((byte_temp >> j) & 0x01) ^ ((reg16 & 0x8000)>>15);
			reg16 = reg16 << 1;
			if(bit_temp)
			{
				reg16 = reg16 ^ general_mask;
			}
		}
	}
	return reg16;
}
*/
/*void show()
{
	std::cout<<"hello world\n";
}
int main()
{
	std::cout<<"main函数开始\n";
	show();
	std::cout<<"main函数结束\n";
	getchar();
	return 0;
}
*/