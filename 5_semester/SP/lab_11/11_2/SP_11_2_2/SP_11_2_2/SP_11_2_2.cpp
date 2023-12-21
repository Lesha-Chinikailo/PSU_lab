#include <Windows.h>
#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <algorithm>
using namespace std;
int main() {

    HANDLE file = CreateFile(L"text.txt", GENERIC_READ | GENERIC_WRITE, 0, nullptr, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, nullptr);
    cout << "File descriptor: " << file << endl;

    HANDLE fileMapping = CreateFileMapping(file, nullptr, PAGE_READWRITE, 0, 0, nullptr);
    LPVOID mapView = MapViewOfFile(fileMapping, FILE_MAP_READ | FILE_MAP_WRITE, 0, 0, 0);
    cout << "Displaying a file in memory: " << mapView << endl;

    string content(reinterpret_cast<const char*>(mapView));
    int count = 0;
    for (char c : content) {
        if (isdigit(c)) {
            count++;
        }
    }
    cout << "count number: " << count << endl;
    UnmapViewOfFile(mapView);
    CloseHandle(fileMapping);
    CloseHandle(file);
    return 0;
}