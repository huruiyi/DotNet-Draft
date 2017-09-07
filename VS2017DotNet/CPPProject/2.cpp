#include <iostream>
#include <climits>              // use limits.h for older systems
using namespace std;
#include <cmath>
int arith();
int assign();
int bondini();
int chartype();
int divide();
int exceed();
int floatnum();
int fltadd();
int hexoct1();
int hexoct2();
int init();
int limits();

class Point
{
public:
	void setPoint(int x, int y) //实现setPoint函数
	{
		xPos = x;
		yPos = y;
	}

	void printPoint()       //实现printPoint函数
	{
		cout << "x = " << xPos << endl;
		cout << "y = " << yPos << endl;
	}

private:
	int xPos;
	int yPos;
};

void main21()
{
	Point m;        //用定义好的类创建一个对象 点M
	m.setPoint(10, 20); //设置 M点 的x,y值
	m.printPoint();     //输出 M点 的信息

	cin.get();
}

int arith()
{
	using namespace std;
	float hats, heads;

	cout.setf(ios_base::fixed, ios_base::floatfield); // fixed-point
	cout << "Enter a number: ";
	cin >> hats;
	cout << "Enter another number: ";
	cin >> heads;

	cout << "hats = " << hats << "; heads = " << heads << endl;
	cout << "hats + heads = " << hats + heads << endl;
	cout << "hats - heads = " << hats - heads << endl;
	cout << "hats * heads = " << hats * heads << endl;
	cout << "hats / heads = " << hats / heads << endl;
	// cin.get();
	// cin.get();

	cout.setf(ios::hex, ios::basefield);  // set hex as the basefield
	cout.setf(ios::showbase);                  // activate showbase
	cout << 100 << '\n';
	cout.unsetf(ios::showbase);                // deactivate showbase
	cout << 100 << '\n';
	system("pause");
	return 0;
}

int assign()
{
	using namespace std;
	cout.setf(ios_base::fixed, ios_base::floatfield);
	float tree = 3;     // int converted to float
	cout << "tree = " << tree << endl;
	// cin.get();
	return 0;
}

int bondini()
{
	using namespace std;
	cout << "\aOperation \"HyperHype\" is now activated!\n";
	cout << "Enter your agent code:________\b\b\b\b\b\b\b\b";
	long code;
	cin >> code;
	cout << "\aYou entered " << code << "...\n";
	cout << "\aCode verified! Proceed with Plan Z3!\n";
	// cin.get();
	// cin.get();
	return 0;
}

int chartype()
{
	using namespace std;
	char ch;        // declare a char variable

	cout << "Enter a character: " << endl;
	cin >> ch;
	cout << "Hola! ";
	cout << "Thank you for the " << ch << " character." << endl;
	// cin.get();
	// cin.get();
	return 0;
}

int divide()
{
	using namespace std;
	cout.setf(ios_base::fixed, ios_base::floatfield);
	cout << "Integer division: 9/5 = " << 9 / 5 << endl;
	cout << "Floating-point division: 9.0/5.0 = ";
	cout << 9.0 / 5.0 << endl;
	cout << "Mixed division: 9.0/5 = " << 9.0 / 5 << endl;
	cout << "double constants: 1e7/9.0 = ";
	cout << 1.e7 / 9.0 << endl;
	cout << "float constants: 1e7f/9.0f = ";
	cout << 1.e7f / 9.0f << endl;
	// cin.get();
	return 0;
}

// exceed.cpp -- exceeding some integer limits
#define ZERO 0      // makes ZERO symbol for 0 value
int exceed()
{
	using namespace std;
	short sam = SHRT_MAX;     // initialize a variable to max value
	unsigned short sue = sam;// okay if variable sam already defined

	cout << "Sam has " << sam << " dollars and Sue has " << sue;
	cout << " dollars deposited." << endl
		<< "Add $1 to each account." << endl << "Now ";
	sam = sam + 1;
	sue = sue + 1;
	cout << "Sam has " << sam << " dollars and Sue has " << sue;
	cout << " dollars deposited.\nPoor Sam!" << endl;
	sam = ZERO;
	sue = ZERO;
	cout << "Sam has " << sam << " dollars and Sue has " << sue;
	cout << " dollars deposited." << endl;
	cout << "Take $1 from each account." << endl << "Now ";
	sam = sam - 1;
	sue = sue - 1;
	cout << "Sam has " << sam << " dollars and Sue has " << sue;
	cout << " dollars deposited." << endl << "Lucky Sue!" << endl;
	// cin.get();
	return 0;
}

// floatnum.cpp -- floating-point types
int floatnum()
{
	using namespace std;
	cout.setf(ios_base::fixed, ios_base::floatfield); // fixed-point
	float tub = 10.0 / 3.0;     // good to about 6 places
	double mint = 10.0 / 3.0;   // good to about 15 places
	const float million = 1.0e6;

	cout << "tub = " << tub;
	cout << ", a million tubs = " << million * tub;
	cout << ",\nand ten million tubs = ";
	cout << 10 * million * tub << endl;

	cout << "mint = " << mint << " and a million mints = ";
	cout << million * mint << endl;
	// cin.get();
	return 0;
}

// fltadd.cpp -- precision problems with float
int fltadd()
{
	using namespace std;
	float a = 2.34E+22f;
	float b = a + 1.0f;

	cout << "a = " << a << endl;
	cout << "b - a = " << b - a << endl;
	// cin.get();
	return 0;
}

// hexoct1.cpp -- shows hex and octal literals
int hexoct1()
{
	using namespace std;
	int chest = 42;     // decimal integer literal
	int waist = 0x42;   // hexadecimal integer literal
	int inseam = 042;   // octal integer literal

	cout << "Monsieur cuts a striking figure!\n";
	cout << "chest = " << chest << " (42 in decimal)\n";
	cout << "waist = " << waist << " (0x42 in hex)\n";
	cout << "inseam = " << inseam << " (042 in octal)\n";
	// cin.get();
	return 0;
}

// hexoct2.cpp -- display values in hex and octal
using namespace std;
int hexoct2()
{
	using namespace std;
	int chest = 42;
	int waist = 42;
	int inseam = 42;

	cout << "Monsieur cuts a striking figure!" << endl;
	cout << "chest = " << chest << " (decimal for 42)" << endl;
	cout << hex;      // manipulator for changing number base
	cout << "waist = " << waist << " (hexadecimal for 42)" << endl;
	cout << oct;      // manipulator for changing number base
	cout << "inseam = " << inseam << " (octal for 42)" << endl;
	// cin.get();
	return 0;
}

// init.cpp -- type changes on initialization
int init()
{
	using namespace std;
	cout.setf(ios_base::fixed, ios_base::floatfield);
	float tree = 3;     // int converted to float
	int guess(123);  // double converted to int
	int debt = 7.2E12;  // result not defined in C++
	cout << "tree = " << tree << endl;
	cout << "guess = " << guess << endl;
	cout << "debt = " << debt << endl;
	// cin.get();
	return 0;
}

// limits.cpp -- some integer limits
int limits()
{
	using namespace std;
	int n_int = INT_MAX;        // initialize n_int to max int value
	short n_short = SHRT_MAX;   // symbols defined in climits file
	long n_long = LONG_MAX;
	long long n_llong = LLONG_MAX;

	// sizeof operator yields size of type or of variable
	cout << "int is " << sizeof(int) << " bytes." << endl;
	cout << "short is " << sizeof n_short << " bytes." << endl;
	cout << "long is " << sizeof n_long << " bytes." << endl;
	cout << "long long is " << sizeof n_llong << " bytes." << endl;
	cout << endl;

	cout << "Maximum values:" << endl;
	cout << "int: " << n_int << endl;
	cout << "short: " << n_short << endl;
	cout << "long: " << n_long << endl;
	cout << "long long: " << n_llong << endl << endl;

	cout << "Minimum int value = " << INT_MIN << endl;
	cout << "Bits per byte = " << CHAR_BIT << endl;
	// cin.get();

	system("pause");
	return 0;
}

// modulus.cpp -- uses % operator to convert lbs to stone
int modulus()
{
	using namespace std;
	const int Lbs_per_stn = 14;
	int lbs;

	cout << "Enter your weight in pounds: ";
	cin >> lbs;
	int stone = lbs / Lbs_per_stn;      // whole stone
	int pounds = lbs % Lbs_per_stn;     // remainder in pounds
	cout << lbs << " pounds are " << stone
		<< " stone, " << pounds << " pound(s).\n";
	// cin.get();
	// cin.get();
	return 0;
}

// morechar.cpp -- the char type and int type contrasted
int morechar()
{
	using namespace std;
	char ch = 'M';       // assign ASCII code for M to ch
	int i = ch;          // store same code in an int
	cout << "The ASCII code for " << ch << " is " << i << endl;

	cout << "Add one to the character code:" << endl;
	ch = ch + 1;          // change character code in ch
	i = ch;               // save new character code in i
	cout << "The ASCII code for " << ch << " is " << i << endl;

	// using the cout.put() member function to display a char
	cout << "Displaying char ch using cout.put(ch): ";
	cout.put(ch);

	// using cout.put() to display a char constant
	cout.put('!');

	cout << endl << "Done" << endl;
	// cin.get();
	return 0;
}

// typecast.cpp -- forcing type changes
int typecast()
{
	using namespace std;
	int auks, bats, coots;

	// the following statement adds the values as double,
	// then converts the result to int
	auks = 19.99 + 11.99;

	// these statements add values as int
	bats = (int) 19.99 + (int) 11.99;   // old C syntax
	coots = int(19.99) + int(11.99);  // new C++ syntax
	cout << "auks = " << auks << ", bats = " << bats;
	cout << ", coots = " << coots << endl;

	char ch = 'Z';
	cout << "The code for " << ch << " is ";    // print as char
	cout << int(ch) << endl;                    // print as int
	cout << "Yes, the code is ";
	cout << static_cast<int>(ch) << endl;       // using static_cast
												// cin.get();
	return 0;
}

;