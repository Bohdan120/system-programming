#define EXPORT extern "C" _declspec(dllexport)
EXPORT int add(int a, int b);
EXPORT int sub(int a, int b); 
EXPORT int mult(int a, int b);
EXPORT int devide(int a, int b);