#pragma once

class Shape {
protected:
	char* description;

public:
	virtual ~Shape() {};
	virtual double area() = 0;
	virtual void printdescription() = 0;
	Shape(char *_description) :description(_description) {};
};
