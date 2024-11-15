﻿#include <iostream>
using namespace std;
#include "MathLib.h"
#include <MathDll.h>

int main()
{
    //"*"在左边为标记指针的含义，在右边一般表示取值含义
    //"&"表示取地址
    int a = 5;
    float b = 12.5;
    int* c = &a;
    float* d = &b;
    cout << "a的存放地址" << &a << endl;
    cout << "b的存放地址" << &b << endl;
    cout << "对应a的存放地址"<< c << endl;
    cout << "对应b的存放地址" << d << endl;
    cout << "c自己的地址" << &c << endl;
    cout << "d自己的地址" << &d << endl;
    cout << "指向a的值" << *c << endl;
    cout << "指向b的值" << *d << endl;

    int array[2] = { 2,3 };
    int* arrayOfPoints[2];//指针型数组
    int(*PointToAnArray)[2];//数组的指针
    PointToAnArray = &array;
    for (unsigned int i = 0; i < 2; i++) {
        arrayOfPoints[i] = &(array[i]);
    }
    cout << arrayOfPoints[0] << endl;
    cout << *(arrayOfPoints[0]) << endl;
    cout << (*PointToAnArray)[0] << endl;

    //指针的指针
    int x = 123;
    int* y = &x;
    int** z = &y;

    cout << y << endl;//x的地址
    cout << *y << endl;//x的值
    cout << z << &y<< endl;//y的地址
    cout << *z << &x<< endl;//x的地址
    cout << **z << x<< endl;//x的值

    cout << MathLib::Arithmetic::Add(1, 2) << endl;
    cout << add(10,12) << endl;
    Circle myCircle(20);
    cout << myCircle.getArea() << endl;
    cout << myCircle.getRadius() << endl;
}
