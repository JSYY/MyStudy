#include "MathDll.h"

int add(int a, int b)	// �ӷ�
{
	return a + b;
}


int sub(int a, int b)	// ����
{
	return a - b;
}


Circle::Circle(float radius)	// ʵ��һ��Բ
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