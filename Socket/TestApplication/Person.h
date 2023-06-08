#pragma once
#include <string>

class Person
{
private:
	int Age;
	std::string Name;
public:
	Person();
	Person(int age, std::string name);
	std::string GetPersonInfo();
};

