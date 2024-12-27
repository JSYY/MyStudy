#include <iostream>
using namespace std;
#include "MathLib.h"
#include <MathDll.h>
#include "Shape.h"
#include "Circle.h"
#include <thread> 
#include <mutex>
#include <sstream>

void TestClass() {
    double radius = 2.5;
    char str[] = "Circle";
    //Shape* circleX = new MyCircle(radius, str);  //circleX代表指代MyCircle对象的指针
    MyCircle circle(radius, str);
    cout << circle.area() << endl;
    circle.printdescription();
}

void CallExternalFunc() {
    cout << MathLib::Arithmetic::Add(1, 2) << endl;
    cout << add(10, 12) << endl;
    Circle myCircle(20);
    cout << myCircle.getArea() << endl;
    cout << myCircle.getRadius() << endl;
}

void Point() {
    //指针是一个 用来存储变量地址 的特殊数据类型。简单来说，指针变量存储的是内存地址，而不是常规的值,指针也会是对象。
    // 通过指针，我们可以直接访问和操作内存中的数据，而不必知道实际存储的值是什么。
    //可以使用 解引用操作符* 来访问指针所指向的变量，使用地址运算符& 来获取变量的地址。
    //"*"在左边为标记指针的含义，在右边一般表示取值含义
    //"&"表示取地址
    int a = 5;
    float b = 12.5;
    int* c = &a;
    float* d = &b;
    cout << "a的存放地址" << &a << endl;
    cout << "b的存放地址" << &b << endl;
    cout << "对应a的存放地址" << c << endl;
    cout << "对应b的存放地址" << d << endl;
    cout << "c自己的地址" << &c << endl;
    cout << "d自己的地址" << &d << endl;
    cout << "指向a的值" << *c << endl;
    cout << "指向b的值" << *d << endl;

    //指针数组是一个数组，其中的每个元素都是指针。这些指针可以指向不同的内存地址，通常用于存储一组相同类型的指针
    //数组指针是一个指针，它指向数组的首地址。它本身是一个指针，但指向的内容是一个数组对象。
    int array[2] = { 2,3 };
    int* arrayOfPoints[2];//指针型数组
    int(*PointToAnArray)[2];//数组的指针
    PointToAnArray = &array;
    for (unsigned int i = 0; i < 2; i++) {
        arrayOfPoints[i] = &(array[i]);
    }
    cout << arrayOfPoints[0] << endl;
    cout << arrayOfPoints[1] << endl;
    cout << *(arrayOfPoints[0]) << endl;
    cout << *PointToAnArray << endl;
    cout << &array[0] << endl;
    cout << &array[1] << endl;
    cout << (*PointToAnArray)[0] << endl;

    //指针的指针
    int x = 123;
    int* y = &x;
    int** z = &y;

    cout << y << endl;//x的地址
    cout << *y << endl;//x的值
    cout << z << &y << endl;//y的地址
    cout << *z << &x << endl;//x的地址
    cout << **z << x << endl;//x的值

    //&放在左边标识引用，代表ref引用了x，ref和x都指向的同一个内存变量的整数值
    int& ref = x;
    cout << ref << endl;
    cout << &ref << endl;
    cout << &x << endl;
    
    int* const value1 = &x;//常量指针 无法再修改指向的对象，但是可以修改指向对象的值
    *value1 = 20;
    cout << x << endl;
    cout << *value1 << endl;

    int const* value2 = &x;//指针常量，可以修改指向的对象，但无法修改对象的值
    value2 = &a;
    cout << *value2 << endl;
}

void Func1() {
    for (int i = 0; i < 10000; i++)
    {
        cout << i <<":"<< this_thread::get_id() << endl;
    }
}

//join 开启线程
void StartThreadByJoin() {
    thread t1(Func1);
    t1.join();
}

//分离新线程,在调用的地方开辟一个新的线程运行
void StartThreadByDetach() {
    thread t1(Func1);
    t1.detach();
}

//在多线程编程中，当多个线程同时访问和修改同一个共享变量时，如果没有对共享资源进行适当的同步控制，
//可能会导致线程竞争，导致程序的结果不确定。
//为了确保 线程安全 的手段之一就是 加锁 保护，C++11 中就有一个 mutex 类，其中包含了 互斥锁 的各种常用操作
int global_value = 0;
mutex mtx;
void Func2() {
    for (int i = 0; i < 1000; i++) {
        mtx.lock();
        global_value++;
        stringstream ss;
        ss << global_value << ":" << this_thread::get_id();
        cout << ss.str() << endl;
        mtx.unlock();
    }
}

int main(int argc, char* argv[])
{

}