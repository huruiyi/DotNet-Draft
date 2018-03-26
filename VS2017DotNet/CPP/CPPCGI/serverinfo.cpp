#define  _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <string>
#include <cstdlib>
#include <ctime>

using  namespace  std;
using  std::getenv; //获取环境变量

string envstr[24] = {
	"COMSPEC",
	"DOCUMENT_ROOT",
	"GATEWAY_INTERFACE",
	"HTTP_ACCEPT","HTTP_ACCEPT_ENCODING",
	"HTTP_ACCEPT_LANGUAGE","HTTP_CONNECTION",
	"HTTP_HOST","HTTP_USER_AGENT","PATH",
	"QUERY_STRING","REMOTE_ADDR","REMOTE_PORT",
	"REQUEST_METHOD","REQUEST_URI","SCRIPT_FILENAME",
	"SCRIPT_NAME","SERVER_ADDR","SERVER_ADMIN",
	"SERVER_NAME","SERVER_PORT","SERVER_PROTOCOL",
	"SERVER_SIGNATURE","SERVER_SOFTWARE"
};

int  main2()
{
	cout << "Content-Type:text/html\n\n";
	cout << "<!DOCTYPE html>" << endl;
	cout << "<html>" << endl;
	cout << "<head>" << endl;
	cout << "<meta charset=\"utf - 8\" />" << endl;
	cout << "<title></title>" << endl;
	cout << "<style type=\"text/css\">table {border-collapse: collapse;}table ,td{border:2px solid #1e90ff}</style>" << endl;
	cout << "</head>" << endl;
	cout << "<body>" << endl;

	cout << "<table>" << endl;
	for (int i = 0; i < 24; i++)
	{
		char * penv = getenv(envstr[i].c_str());

		cout << "<tr>" << endl;
		cout << "<td>" << envstr[i] << "</td>" << endl;
		cout << "<td>" << penv << "</td>" << endl;
		cout << "</tr>" << endl;
	}
	cout << "</table>" << endl;

	cout << "</body>" << endl;
	cout << "</html>" << endl;
	return 0;
}