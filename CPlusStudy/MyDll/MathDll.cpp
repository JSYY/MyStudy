#include "MathDll.h"

int add(int a, int b)	// 加法
{
	return a + b;
}


int sub(int a, int b)	// 减法
{
	return a - b;
}


Circle::Circle(float radius)	// 实现一个圆
{
	this->radius = radius;
	this->area = 3.14 * radius * radius;
}

float Circle::getRadius()
{
	return this->radius;
}

float Circle::getArea()
{
	return this->area;
}