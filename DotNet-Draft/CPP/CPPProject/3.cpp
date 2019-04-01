#include <iostream>
#include <string>
#define TRUE = 1
using namespace std;

class dog
{
public:
	dog()
	{
		_legs = 4;
		_bark = true;
	}

	void setDogSize(string dogSize)
	{
		_dogSize = dogSize;
	}
	virtual void setEars(string type)      // virtual function
	{
		_earType = type;
	}

private:
	string _dogSize, _earType;
	int _legs;
	bool _bark;
};

class breed : public dog
{
public:
	breed(string color, string size)
	{
		_color = color;
		setDogSize(size);
	}

	string getColor()
	{
		return _color;
	}

	// virtual function redefined
	void setEars(string length, string type)
	{
		_earLength = length;
		_earType = type;
	}

protected:
	string _color, _earLength, _earType;
};

void main3()
{
	dog mongrel;
	breed labrador("yellow", "large");
	mongrel.setEars("pointy");
	labrador.setEars("long", "floppy");
	cout << "Cody is a " << labrador.getColor() << " labrador" << endl;
}