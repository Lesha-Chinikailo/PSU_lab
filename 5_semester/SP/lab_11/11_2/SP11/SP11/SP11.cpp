#include <Windows.h>
#include <iostream>
#include <string>
#include <fstream>
#include <vector>
#include <algorithm>
using namespace std;
int main() {
    setlocale(LC_ALL, "Russian");

    HANDLE file = CreateFile(L"test.txt", GENERIC_READ | GENERIC_WRITE, 0, nullptr, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, nullptr);
    cout << "File descriptor: " << file << endl;

    HANDLE fileMapping = CreateFileMapping(file, nullptr, PAGE_READWRITE, 0, 0, nullptr);
    LPVOID mapView = MapViewOfFile(fileMapping, FILE_MAP_READ | FILE_MAP_WRITE, 0, 0, 0);
    cout << "Displaying a file in memory: " << mapView << endl;

    string fileContent(reinterpret_cast<const char*>(mapView));
    vector<int> numbers;
    string numberStr;
    for (char c : fileContent) {
        if (isdigit(c)) {
            numberStr += c;
        }
        else if (!numberStr.empty()) {
            numbers.push_back(stoi(numberStr));
            numberStr.clear();
        }
    }
    if (!numberStr.empty()) {
        numbers.push_back(stoi(numberStr));
    }
    sort(numbers.begin(), numbers.end());
    string sortedContent;
    for (int number : numbers) {
        sortedContent += to_string(number) + " ";
    }
    CopyMemory(mapView, sortedContent.c_str(), sortedContent.size());

    UnmapViewOfFile(mapView);
    CloseHandle(fileMapping);
    CloseHandle(file);
    return 0;
}