#include "Person.h"

Person::Person() {
	this->Age = 0;
	this->Name = "";
}

Person::Person(int age, std::string name) {
	this->Age = age;
	this->Name = name;
}

std::string Person::GetPersonInfo() {
	return std::to_string(this->Age) + this->Name;
}
