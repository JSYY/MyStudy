#pragma once
using namespace std;
#include <string>

class Animal
{
	protected:
		int Age;
		string Name;

	public :
		virtual void Breathe()=0;
		void setAge(int age)
		{
			Age = age;
		}

		void setName(string name)
		{
			Name = name;
		}
};

