#include "Animal.h"
#include <iostream>
#include <string>
using namespace std;

class Cat :public Animal {
public:
	void Breathe() {
		cout << Name + "使用嘴巴呼吸,年龄为" + to_string(Age);
	}
};

class Fish :public Animal {
public:
	void Breathe() {
		cout << Name + "使用鳃呼吸，年龄为" + to_string(Age);
	}
};