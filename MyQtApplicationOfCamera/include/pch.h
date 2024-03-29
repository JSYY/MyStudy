// pch.h: 这是预编译标头文件。
// 下方列出的文件仅编译一次，提高了将来生成的生成性能。
// 这还将影响 IntelliSense 性能，包括代码完成和许多代码浏览功能。
// 但是，如果此处列出的文件中的任何一个在生成之间有更新，它们全部都将被重新编译。
// 请勿在此处添加要频繁更新的文件，这将使得性能优势无效。

#ifndef PCH_H
#define PCH_H

// 添加要在此处预编译的标头
#include "framework.h"

#endif //PCH_H
//定义宏
#ifdef EXPORT_DLL
#else
#define EXPORT_DLL extern "C" _declspec(dllexport) //指的是允许将其给外部调用
#endif

EXPORT_DLL int add(int a, int b);
EXPORT_DLL int minus(int a, int b);
EXPORT_DLL int multiply(int a, int b);
EXPORT_DLL double divide(int a, int b);
