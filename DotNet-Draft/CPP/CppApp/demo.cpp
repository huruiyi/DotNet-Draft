#include <Windows.h>
#include <iostream>
#include <string.h>

using namespace std;

//string 转换成 char *
void DemoChar1()
{
	string s1 = "abcdeg";
	const char *k = s1.c_str();
	const char *t = s1.data();
	printf("%s%s", k, t);
	cout << k << t << endl;
}

void DemoChar2()
{
	string s1 = "abcdefg";
	char *data;
	int len = s1.length();
	data = (char *)malloc((len + 1) * sizeof(char));
	//s1.copy(data, len, 0);
	printf("%s", data);
	cout << data;
}

void DemoChar3()
{
	string s;
	char *p = "adghrtyh";
	s = p;
	cout << s.c_str() << endl;
}

void DemoChar4()
{
	string pp = "dagah";
	char p[8] = { 0 };
	int i;
	for (i = 0; i < pp.length(); i++)
		p[i] = pp[i];
	printf("%s\n", p);
	cout << p;
}

void DemoCpoint1()
{
	char *s1 = "hello";
	char s2[] = "hello";
	//s2 = s1;  //编译ERROR
	//s1 = s2;  //OK
	//分析：s2其地址和容量在生命期里不能改变
}

void DemoCpoint2()
{
	char s2[] = "hello";
	char *s1 = s2;  //编译器做了隐式的转换 实际为&s2
	//char *s2 = &s2;//error
}

void DemoCpoint3()
{
	char *s1 = "hello";
	char s2[] = "hello";
	//s1[0] = 'a';  //×  vs运行ERROR ,其他编译器
	s2[0] = 'a';  //OK
}

void DemoCpoint4()
{
	char *s1 = "hello";
	char s2[] = "hello";
	char *s3 = s2;       //★注意这句必须要★
	char **s4 = &s3;   //s2（char[]）要用两步才能完成赋值
	char **s5 = &s1;   //s1（char*） 只需一步
	printf("s4=[%s]\n", *s4);//打印结果：s4=[hello]
	printf("s5=[%s]\n", *s5);//打印结果：s5=[hello]
}

int index = 0;
// 临界区结构对象
CRITICAL_SECTION g_cs;
HANDLE hMutex = NULL;
void changeMe()
{
	cout << index++ << endl;
}
void changeMe2()
{
	cout << index++ << endl;
}
void changeMe3()
{
	cout << index++ << endl;
}
DWORD WINAPI th1(LPVOID lpParameter)
{
	while (1)
	{
		Sleep(1600); //sleep 1.6 s
					 // 进入临界区
		EnterCriticalSection(&g_cs);
		// 等待互斥对象通知
		//WaitForSingleObject(hMutex, INFINITE);
		// 对共享资源进行写入操作
		//cout << "a" << index++ << endl;
		changeMe();
		changeMe2();
		changeMe3();
		// 释放互斥对象
		//ReleaseMutex(hMutex);
		// 离开临界区
		LeaveCriticalSection(&g_cs);
	}
	return 0;
}
DWORD WINAPI th2(LPVOID lpParameter)
{
	while (1)
	{
		Sleep(2000); //sleep 2 s
					 // 进入临界区
		EnterCriticalSection(&g_cs);

		// 等待互斥对象通知
		//WaitForSingleObject(hMutex, INFINITE);
		//cout << "b" << index++ << endl;
		changeMe();
		changeMe2();
		changeMe3();
		// 释放互斥对象
		//ReleaseMutex(hMutex);

		// 离开临界区
		LeaveCriticalSection(&g_cs);
	}
	return 0;
}

void ThreadDemo()
{
	// 创建互斥对象
	//hMutex = CreateMutex(NULL, TRUE, NULL);
	// 初始化临界区
	InitializeCriticalSection(&g_cs);
	HANDLE hThread1;
	HANDLE hThread2;
	hThread1 = CreateThread(NULL, 0, th1, NULL, 0, NULL);
	hThread2 = CreateThread(NULL, 0, th2, NULL, 0, NULL);
	int k;
	cin >> k;
}
int main()
{
	system("pause");
	return 0;
}