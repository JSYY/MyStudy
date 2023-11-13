#include "Animal.h"
#include <iostream>
#include <string>
using namespace std;

class Cat :public Animal {
public:
	void Breathe() {
		cout << Name + "ʹ����ͺ���,����Ϊ" + to_string(Age);
	}
};

class Fish :public Animal {
public:
	void Breathe() {
		cout << Name + "ʹ��������������Ϊ" + to_string(Age);
	}
};