#define  _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <ctime>
using  namespace  std;

#define TIME_MAX 32

int cgi_hello()
{
	cout << "Content-Type:text/html\n\n";
	cout << "<br/>Hello World" << endl;

	time_t  vtime;
	time(&vtime);

	cout << "<br/>Current time is" << asctime(localtime(&vtime)) << endl;

	time_t now;
	time(&now);

	struct tm tmTmp;
	char stTmp[TIME_MAX];

	localtime_s(&tmTmp, &now);
	asctime_s(stTmp, &tmTmp);

	cout << "<br/>Current time is" << stTmp << endl;

	return 0;
}