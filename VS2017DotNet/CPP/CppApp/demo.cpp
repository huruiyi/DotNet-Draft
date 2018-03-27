#include <Windows.h>
#include <iostream>
#include <string.h>

using namespace std;

//string ת���� char *
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
	//s2 = s1;  //����ERROR
	//s1 = s2;  //OK
	//������s2���ַ���������������ﲻ�ܸı�
}

void DemoCpoint2()
{
	char s2[] = "hello";
	char *s1 = s2;  //������������ʽ��ת�� ʵ��Ϊ&s2
	//char *s2 = &s2;//error
}

void DemoCpoint3()
{
	char *s1 = "hello";
	char s2[] = "hello";
	//s1[0] = 'a';  //��  vs����ERROR ,����������
	s2[0] = 'a';  //OK
}

void DemoCpoint4()
{
	char *s1 = "hello";
	char s2[] = "hello";
	char *s3 = s2;       //��ע��������Ҫ��
	char **s4 = &s3;   //s2��char[]��Ҫ������������ɸ�ֵ
	char **s5 = &s1;   //s1��char*�� ֻ��һ��
	printf("s4=[%s]\n", *s4);//��ӡ�����s4=[hello]
	printf("s5=[%s]\n", *s5);//��ӡ�����s5=[hello]
}

int index = 0;
// �ٽ����ṹ����
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
					 // �����ٽ���
		EnterCriticalSection(&g_cs);
		// �ȴ��������֪ͨ
		//WaitForSingleObject(hMutex, INFINITE);
		// �Թ�����Դ����д�����
		//cout << "a" << index++ << endl;
		changeMe();
		changeMe2();
		changeMe3();
		// �ͷŻ������
		//ReleaseMutex(hMutex);
		// �뿪�ٽ���
		LeaveCriticalSection(&g_cs);
	}
	return 0;
}
DWORD WINAPI th2(LPVOID lpParameter)
{
	while (1)
	{
		Sleep(2000); //sleep 2 s
					 // �����ٽ���
		EnterCriticalSection(&g_cs);

		// �ȴ��������֪ͨ
		//WaitForSingleObject(hMutex, INFINITE);
		//cout << "b" << index++ << endl;
		changeMe();
		changeMe2();
		changeMe3();
		// �ͷŻ������
		//ReleaseMutex(hMutex);

		// �뿪�ٽ���
		LeaveCriticalSection(&g_cs);
	}
	return 0;
}

void ThreadDemo()
{
	// �����������
	//hMutex = CreateMutex(NULL, TRUE, NULL);
	// ��ʼ���ٽ���
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