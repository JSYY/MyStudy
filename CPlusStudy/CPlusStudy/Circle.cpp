#include "cmath"
#include "Circle.h"
#include <iostream>
using namespace std;

inline double pi() {
	return std::atan(1) * 4;
}

MyCircle::MyCircle(double _radius,char* des):Shape(des),radius(_radius) {
	cout << radius << endl;
	//����̳л��࣬���û��๹�췽�������Ҷ��ⲿ�����_radius��ֵ��MyCicle�Լ�������radius
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
