#pragma once

// ����ĺ�����������жϣ���ǰ�Ǹ���Ŀ��ʹ��"ͷ�ļ�"
/*
	ԭ���ǣ�ͨ����DLL��Ŀ����һ�� MYDLL �ĺ궨�壬���� exe ��Ŀ���治���� MYDLL �ĺ궨��
	����ͷ�ļ���DLL��Ŀʹ��ʱ��MYDLL��Ȼ���ж���ģ��Ӷ�ִ�� "#define PORT __declspec(dllexport)"��һ�����
	����ͷ�ļ���exe��Ŀʹ��ʱ��MYDLL��Ȼ��û�ж��壬�Ӷ�ִ�� "#define PORT __declspec(dllimport)"��һ�����
	�����ڲ�ͬ��Ŀ�£�PORT ���Ų�ͬ�Ĺ���
	��DLL��Ŀ���棬POET ���� "����"������
	��exe��Ŀ���棬POET ���� "����"������
*/
#ifdef MYDLL						// ��� MYDLL �ж��壬˵����ǰͷ�ļ���"DLL��Ŀ"��ʹ��
#define PORT __declspec(dllexport)  // �� PORT ����Ϊ ��������
#else								// ��� MYDLL û�ж��壬˵����ǰͷ�ļ���"exe��Ŀ"��ʹ��
#define PORT __declspec(dllimport)	// �� PORT ����Ϊ ���빦��
#endif

PORT int add(int a, int b);// ��ϸд����extern "C" PORT int add(int a, int b);
PORT int sub(int a, int b);// ��ϸд����extern "C" PORT int sub(int a, int b);

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