#pragma once

// 下面的宏代码是用来判断，当前那个项目在使用"头文件"
/*
	原理是：通过在DLL项目配置一个 MYDLL 的宏定义，而在 exe 项目里面不配置 MYDLL 的宏定义
	当此头文件被DLL项目使用时，MYDLL必然是有定义的，从而执行 "#define PORT __declspec(dllexport)"这一句代码
	当此头文件被exe项目使用时，MYDLL必然是没有定义，从而执行 "#define PORT __declspec(dllimport)"这一句代码
	最终在不同项目下，PORT 有着不同的功能
	在DLL项目里面，POET 将起到 "导出"的作用
	在exe项目里面，POET 将起到 "导入"的作用
*/
#ifdef MYDLL						// 如果 MYDLL 有定义，说明当前头文件是"DLL项目"在使用
#define PORT __declspec(dllexport)  // 将 PORT 定义为 导出功能
#else								// 如果 MYDLL 没有定义，说明当前头文件是"exe项目"在使用
#define PORT __declspec(dllimport)	// 将 PORT 定义为 导入功能
#endif

PORT int add(int a, int b);// 详细写法：extern "C" PORT int add(int a, int b);
PORT int sub(int a, int b);// 详细写法：extern "C" PORT int sub(int a, int b);

class PORT Circle
{
private:
	float radius;
	float area;

public:
	Circle(float);
	float getRadius();
	float getArea();
};