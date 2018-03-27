#define   _CRT_SECURE_NO_WARNINGS
// Fig. 19.9: querystring.cpp
// Demonstrating QUERY_STRING.
#include <iostream>
using std::cout;

#include <string>
using std::string;

#include <cstdlib>
using::getenv;

int cgi_querystring()
{
	string query = "";

	if (getenv("QUERY_STRING")) // QUERY_STRING variable exists
		query = getenv("QUERY_STRING"); // retrieve QUERY_STRING value

	cout << "Content-Type: text/html\n\n"; // output http header

										   // output XML declaration and DOCTYPE
	cout << "<?xml version = \"1.0\"?>"
		<< "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.1//EN\" "
		<< "\"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\">";

	// output html element and some of its contents
	cout << "<html xmlns = \"http://www.w3.org/1999/xhtml\">"
		<< "<head><title>Name/Value Pairs</title></head><body>";
	cout << "<h2>Name/Value Pairs</h2>";

	// if query contained no data
	if (query == "")
		cout << "Please add some name-value pairs to the URL above.<br/> Or"
		<< " try <a href=\"querystring.cgi?name=Joe&age=29\">this</a>.";
	else // user entered query string
		cout << "<p>The query string is: " << query << "</p>";

	cout << "</body></html>";
	return 0;
}