#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <conio.h>//输入输出文件
#include <iostream>
#include <array>
using namespace std;
void main()
{
	struct  Student
	{
		int Id;
		char UserName[10];
		char MobilePhoe[20];
		char UserPassword[20];
	} stu1, stu2;

	stu1.Id = 123456;
	strcpy_s(stu1.UserName, "胡睿毅");
	strcpy_s(stu1.MobilePhoe, "13612340000");
	strcpy_s(stu1.UserPassword, "Passord");

	printf("Id=%d\nUserName=%s\nMobilePhoe=%s\nUserPassword=%s\n", stu1.Id, stu1.UserName, stu1.MobilePhoe, stu1.UserPassword);

	stu2 = stu1;
	if (stu2.Id == NULL)
	{
		printf("为.0");
	}
	printf("Id=%d\nUserName=%s\nMobilePhoe=%s\nUserPassword=%s\n", stu2.Id, stu2.UserName, stu2.MobilePhoe, stu2.UserPassword);

	system("pause");
}

struct info
{
	int a;
	char b[30];
};
void main01()
{
	FILE *pf;//建立好文件的指针
	//指定读写的打开方式
	fopen_s(&pf, "G:\\传智播客\\C 基础课\\C++TEST\\2013-10-17\\上午\Test01\\Debug\\bin1.txt", "rb");//r==read,fopen打开一个文件
	if (pf == NULL)
	{
		printf("文件打开失败");
	}
	else
	{
		printf("文件打开成功\n");

		struct info  a1, a2, a3;
		a1.a = 123;
		char *str1 = "Ak47";
		strcpy_s(a1.b, str1);

		a2.a = 123;
		char *str2 = "Bk47";
		strcpy_s(a2.b, str2);

		a3.a = 123;
		char *str3 = "Ck47";
		strcpy_s(a3.b, str3);

		fwrite(&a1, sizeof(a1), 1, pf);
		fwrite(&a2, sizeof(a2), 1, pf);
		fwrite(&a3, sizeof(a3), 1, pf);

		fclose(pf);//关闭文件
	}
	system("pause");
}

void main02()
{
	FILE *fp;
	fopen_s(&fp, "G:\\传智播客\\C 基础课\\C++TEST\\2013-10-17\\上午\\Test01\\Debug\\bin1.txt", "rb");//r==read,fopen打开一个文件

	if (fp == NULL)
	{
		printf("文件打开失败");
	}
	else
	{
		while (!feof(fp))//从光标的开头
		{
			char str[80];
			fgets(str, 80, fp);//每次读取9个字符

			printf("\n%s", str);
			printf("\n%x", fp->_Placeholder);//光标的地址
		}
		rewind(fp);//将光标移动到文件开头
		int  weiyi = 10;
		fseek(fp, 10, SEEK_CUR);//从当前位置读到尾部
		printf("\n\n\n\n\n\n\n\n\n");
		while (!feof(fp))//从光标的开头,检测到结束为标志
		{
			char str[80];
			fgets(str, 80, fp);//每次读取9个字符

			printf("\n%s", str);
			//printf("\n%x", fp->_ptr);//光标的地址
		}

		rewind(fp);//将光标移动到文件开头
		fseek(fp, -80, SEEK_END);//根据这个位置，前后移动，
		printf("\n\n\n\n\n\n\n\n\n");

		char str[80] = { 0 };//往前读，必须数组初始化
		//fgets(str,80,fp);//每次读取9个字符,
		fread(str, 1, 79, fp);

		printf("\n%s", str);
		//printf("\n%x", fp->_ptr);//光标的地址

		fclose(fp);
	}
	system("pause");
}

int main03()
{
	array<int, 3> arr = { 9, 8, 7 };
	cout << "Array size = " << arr.size() << endl;
	for (auto i : arr)
		cout << i << endl;

	system("pause");
	return 0;
}
FILE * stream, *stream2;

void main04()
{
	int numclosed;
	errno_t err;

	// Open for read (will fail if file "crt_fopen_s.c" does not exist)
	if ((err = fopen_s(&stream, "crt_fopen_s.c", "r")) != 0)
		printf("The file 'data.txt' was not opened\n");
	else
		printf("The file 'crt_fopen_s.c' was opened\n");

	// Open for write 
	if ((err = fopen_s(&stream2, "data2", "w+")) != 0)
		printf("The file 'data2' was not opened\n");
	else
		printf("The file 'data2' was opened\n");

	// Close stream if it is not NULL 
	if (stream)
	{
		if (fclose(stream))
		{
			printf("The file 'crt_fopen_s.c' was not closed\n");
		}
	}

	// All other files are closed:
	numclosed = _fcloseall();
	printf("Number of files closed by _fcloseall: %u\n", numclosed);
	system("pause");
}

void main05()
{
	FILE *fp;
	int re = fopen_s(&fp, "data.txt", "w");//==0打开成功
	fputs("你好吗", fp);
	fclose(fp);
}

void main6()
{
	char str[1024] = {};
	gets_s(str);
	puts(str);
	system(str);
}