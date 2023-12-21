#include <windows.h>
#include <iostream>

using namespace std;

LRESULT CALLBACK FilterProc(int nCode, WPARAM wParam, LPARAM lParam) {
    if (nCode >= 0) {
        switch (nCode)
        {
        case HCBT_ACTIVATE:
            cout << "ACTIVATE" << endl;
            break;

        case HCBT_CLICKSKIPPED:
            cout << "CLICKSKIPPED" << endl;
            break;

        case HCBT_CREATEWND:
            cout << "CREATEWND" << endl;
            break;

        case HCBT_DESTROYWND:
            cout << "DESTROYWND" << endl;
            break;

        case HCBT_KEYSKIPPED:
            cout << "KEYSKIPPED" << endl;
            break;

        case HCBT_MINMAX:
            cout << "MINMAX" << endl;
            break;

        case HCBT_MOVESIZE:
            cout << "MOVESIZE" << endl;
            break;

        case HCBT_QS:
            cout << "WM_QUEUESYNC" << endl;
            break;

        case HCBT_SETFOCUS:
            cout << "SETFOCUS" << endl;
            break;

        case HCBT_SYSCOMMAND:
            cout << "SYSCOMMAND" << endl;
            break;

        default:
            cout << "Default" << endl;
            break;
        }
    }
    return CallNextHookEx(NULL, nCode, wParam, lParam);
}

LRESULT CALLBACK WindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam) {
    switch (uMsg) {
    case WM_DESTROY:
        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hwnd, uMsg, wParam, lParam);
    }
    return 0;
}

int main() {
    WNDCLASS windowClass = {};
    windowClass.lpfnWndProc = WindowProc;
    windowClass.hInstance = GetModuleHandle(NULL);
    windowClass.lpszClassName = L"HookedWindowClass";

    RegisterClass(&windowClass);

    HWND HookedWindow = CreateWindowEx(0, L"HookedWindowClass", L"Window", WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, 200, 200, NULL, NULL, GetModuleHandle(NULL), NULL);

    HHOOK _hook = SetWindowsHookEx(WH_CBT, FilterProc, NULL, GetCurrentThreadId()); // 0

    cout << "Hook was set sucessfully for: " << GetCurrentThreadId() << endl;

    ShowWindow(HookedWindow, SW_SHOWNORMAL);
    UpdateWindow(HookedWindow);

    cout << "Waiting for messages!" << endl;
    MSG msg;
    while (GetMessage(&msg, NULL, 0, 0)) {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }

    UnhookWindowsHookEx(_hook);

    return 0;
}