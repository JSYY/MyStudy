#include "cmath"
#include "Circle.h"
#include <iostream>
using namespace std;

inline double pi() {
	return std::atan(1) * 4;
}

MyCircle::MyCircle(double _radius,char* des):Shape(des),radius(_radius) {
	cout << radius << endl;
	//这里继承基类，调用基类构造方法，并且对外部传入的_radius赋值给MyCicle自己的属性radius
};

double MyCircle::area() {
	return pi() * radius * radius;
}

void MyCircle::printdescription() {
	cout << description << endl;
}

MyCircle::~MyCircle()
{
	cout << "MyCircle deleted" << endl;
}
