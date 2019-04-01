// Ex10_11.cpp Using an array storing tuple objects
#include <array>
#include <tuple>
#include <string>
#include <iostream>
#include <iomanip>

const size_t maxRecords{ 100 };
using Record = std::tuple<int, std::string, std::string, int>;
using Records = std::array<Record, maxRecords>;
using namespace std;
// Lists the contents of a Records array
void listRecords(const Records& people)
{
	const size_t ID{}, firstname{ 1 }, secondname{ 2 }, age{ 3 };
	cout << setiosflags(std::ios::left);
	Record empty;
	for (const auto& record : people)
	{
		if (record == empty)
			break;            // In case array is not full
		cout << "ID: " << setw(6) << get<ID>(record)
			<< "Name: " << setw(25) << (get<firstname>(record) + " " + get<secondname>(record))
			<< "Age: " << setw(5) << get<age>(record) << endl;
	}
}

int main1()
{
	int a{ 15 };
	cout << a << endl;
	Records personnel
	{ Record(1001, "Arthur", "Dent", 35),
		Record{ 1002, "Mary", "Poppins", 55 },
		Record{ 1003, "David", "Copperfield", 34 },
		Record{ 1004, "James", "Bond", 44 } };
	personnel[4] = make_tuple(1005, "Harry", "Potter", 15);
	personnel.at(5) = Record{ 1006, "Bertie", "Wooster", 28 };

	listRecords(personnel);

	system("pause");
	return 0;
}

int main2()
{
	int width{ 1280 };
	int height{ 1024 };
	//   double aspect = width / height;
	double aspect{ static_cast<double>(width) / height };

	cout << "The aspect ratio is " << aspect << endl;

	system("pause");
	return 0;
}

int main3()
{
	using namespace std;

	int carrots;            // declare an integer variable

	carrots = 25;            // assign a value to the variable
	cout << "I have ";
	cout << carrots;        // display the value of the variable
	cout << " carrots.";
	cout << endl;
	carrots = carrots - 1;  // modify the variable
	cout << "Crunch, crunch. Now I have " << carrots << " carrots." << endl;
	// cin.get();
	system("pause");

	return 0;
}

int stonetolb(int);     // function prototype

int main4()
{
	using namespace std;
	int stone;
	cout << "Enter the weight in stone: ";
	cin >> stone;
	int pounds = stonetolb(stone);
	cout << stone << " stone = ";
	cout << pounds << " pounds." << endl;
	// cin.get();
	// cin.get();
	system("pause");

	return 0;
}

int stonetolb(int sts)
{
	return 14 * sts;
}

int main5()
{
	using namespace std;

	int carrots;

	cout << "How many carrots do you have?" << endl;
	cin >> carrots;                // C++ input
	cout << "Here are two more. ";
	carrots = carrots + 2;
	// the next line concatenates output
	cout << "Now you have " << carrots << " carrots." << endl;
	// cin.get();
	// cin.get();

	system("pause");

	return 0;
}

int main6()
{
	// i is an int; p is a pointer to int; r is a reference to int
	int i = 1024, *p = &i, &r = i;

	// three ways to print the value of i
	cout << i << " " << *p << " " << r << endl;

	int j = 42, *p2 = &j;
	int *&pref = p2;  // pref is a reference to the pointer p2

					  // prints the value of j, which is the int to which p2 points
	cout << *pref << endl;

	// pref refers to a pointer; assigning &i to pref makes p point to i
	pref = &i;
	cout << *pref << endl; // prints the value of i

						   // dereferencing pref yields i, the int to which p2 points;
	*pref = 0;  // changes i to 0

	cout << i << " " << *pref << endl;

	system("pause");

	return 0;
}

int main7()
{
	int x = -1;
	cout << "x=" << x << endl;
	if (x)
	{
		cout << "x true" << endl;
	}
	else
	{
		cout << "x false" << endl;
	}

	int y = 0;
	cout << "y=" << y << endl;
	if (y)
	{
		cout << "y true" << endl;
	}
	else
	{
		cout << "y false" << endl;
	}

	int z = 1;
	cout << "z=" << z << endl;
	if (z)
	{
		cout << "z true" << endl;
	}
	else
	{
		cout << "z false" << endl;
	}

	cout << "+++++++++++++++++++++++" << endl;
	bool b = 42;
	cout << b << endl;

	int j = b;
	cout << j << endl;

	double pi = 3.14;
	cout << pi << endl;

	j = pi;
	cout << j << endl;

	unsigned char c = -10;
	int i = c;

	cout << i << endl;

	system("pause");

	return 0;
}

int main8()
{
	int ival = 1024;
	int *pi = &ival;   // pi points to an int
	int **ppi = &pi;   // ppi points to a pointer to an int
	cout << "The value of ival\n"
		<< "direct value: " << ival << "\n"
		<< "indirect value: " << *pi << "\n"
		<< "doubly indirect value: " << **ppi
		<< endl;

	int i = 2;
	int *p1 = &i;     // p1 points to i
	*p1 = *p1 * *p1;  // equivalent to i = i * i
	cout << "i  = " << i << endl;

	*p1 *= *p1;       // equivalent to i *= i
	cout << "i  = " << i << endl;

	system("pause");

	return 0;
}

int main9()
{
	int a = 0;
	decltype(a) c = a;   // c is an int
	decltype((a)) d = a; // d is a reference to a
	++c;                 // increments c, a (and d) unchanged
	cout << "a: " << a << " c: " << c << " d: " << d << endl;
	++d;                 // increments a through the reference d
	cout << "a: " << a << " c: " << c << " d: " << d << endl;

	int A = 0, B = 0;
	decltype((A)) C = A;   // C is a reference to A
	decltype(A = B) D = A; // D is also a reference to A
	++C;
	cout << "A: " << A << " C: " << C << " D: " << D << endl;
	++D;
	cout << "A: " << A << " C: " << C << " D: " << D << endl;

	system("pause");
	return 0;
}

int main10() {
	std::cout << '\n';       // prints a newline
	std::cout << "\tHi!\n";  // prints a tab followd by "Hi!" and a newline
	std::cout << "Hi \x4dO\115   !    \n"; // prints Hi MOM! followed by a newline
	std::cout << '\115' << '\n';    // prints M followed by a newline

	system("pause");
	return 0;
}

// crt_getchar.c
// Use getchar to read a line from stdin.

#include <stdio.h>

int main11()
{
	char buffer[81];
	int i, ch;

	for (i = 0; (i < 80) && ((ch = getchar()) != EOF) && (ch != '\n'); i++) {
		buffer[i] = (char)ch;
	}

	buffer[i] = '\0';
	printf("Input was: %s\n", buffer);

	system("pause");
}

void main111(void)
{
	int c;
	int a;
	a = getchar();

	if (EOF != a)
		printf("%c", a);

	while ((c = getchar()) != '\n')//c接收的值是输入第一个字符后按下的回车换行符'\n',c是不会显示的
	{
		if (EOF == a)
			break;
		printf("%c", c);
	}
	getchar();
}

int main12()
{
	int v1(1024);    // direct-initialization, functional form
	int v3 = 1024;   // copy-initialization

					 // alternative ways to initialize string from a character string literal
	std::string titleA = "C++ Primer, 5th Ed.";
	std::string titleB("C++ Primer, 5th Ed.");
	std::string all_nines(10, '9');  // all_nines = "9999999999"

	system("pause");
	return 0;
}