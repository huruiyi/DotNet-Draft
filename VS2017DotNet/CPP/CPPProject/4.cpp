//#include<stdio.h>
//typedef char* PChar;
//
//void main()
//{
//	/*PChar p1,p2;
//	char c = 'a';
//	p1 = &c;
//	p2 = &c;*/
//
//	char* p1;
//	char* p2;
//	char c = 'a';
//	p1 = &c;
//	p2 = &c;
//
//	char *p3, *p4;
//	char c34 = 'a';
//	p3 = &c34;
//	p4 = &c34;
//
//	getchar();
//}

#include<stdio.h>
#define PChar char*

void main()
{
	PChar p3;
	PChar p4;

	char c = 2;
	p3 = &c;
	p4 = &c;

	getchar();
}