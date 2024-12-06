#pragma once
#include "Shape.h"

class MyCircle :public Shape {
	private:
		double radius;
	public:
		MyCircle(double radius,char *description);
		double area() override;
		void printdescription() override;
		~MyCircle();
};
