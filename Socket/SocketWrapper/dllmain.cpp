// dllmain.cpp : 定义 DLL 应用程序的入口点。
#include "pch.h"

int add(int a, int b)
{
	return a + b;
}

int minus(int a, int b)
{
	return a - b;
}

int multiply(int a, int b)
{
	return a * b;
}

double divide(int a, int b)
{
	double m = (double)a / b;
	return m;
}

