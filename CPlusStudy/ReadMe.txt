链接器-》常规-》附加库目录  这里指代的是工程依赖的lib文件夹地址
链接器-》输入-》附加依赖项  这里指代的是工程依赖对应的具体lib文件名称

VC++ Directories（VC++目录）的变量是一个Windows环境变量，和操作系统----控制面板----高级系统设置----环境变量中添加的环境变量一样，在此目录下的路径只在VS中有效。
C/C++中的设置用来设置命令行参数，只针对当前工程。
在VS2010以后，VC++Directories也只能影响单个工程。二者最大的区别在于VC++ Directories是一个Windows环境变量，C/C++是命令行参数。
相同的地方在于VC++ Directories中的include directories（包含目录） 和C/C++中的addition include directories（附加包含目录）是一样的效果。

C/C++ -》常规-》附加包含目录 这里指代工程依赖外部的头文件地址




