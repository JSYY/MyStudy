// TestApplication.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include <iostream>
#include "Person.h"
#include "instance.cpp"

int main()
{
    std::cout << "Hello World!\n";
    Person p1;
    Person p2(18, "jerry");

    std::cout << p1.GetPersonInfo();
    std::cout << '\n';
    std::cout << p2.GetPersonInfo();
    std::cout << '\n';
    Cat cat;
    Fish fish;
    cat.setAge(1);
    cat.setName("猫");
    fish.setAge(2);
    fish.setName("鱼");

    cat.Breathe();
    std::cout << '\n';
    fish.Breathe();
}

