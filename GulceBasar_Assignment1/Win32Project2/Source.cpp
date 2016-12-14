#include <windows.h>
#include <stdlib.h>
#include <string.h>
#include <tchar.h>

int y = 25;
int color1 = 0;
int color2 = 100;
int color3 = 200;

static TCHAR szWindowClass[] = _T("win32app");
static TCHAR szTitle[] = _T("Win32 Guided Tour Application");
HINSTANCE hInst;
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);
	wcex.style = CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc = WndProc;
	wcex.cbClsExtra = 0;
	wcex.cbWndExtra = 0;
	wcex.hInstance = hInstance;
	wcex.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_APPLICATION));
	wcex.hCursor = LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wcex.lpszMenuName = NULL;
	wcex.lpszClassName = szWindowClass;
	wcex.hIconSm = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_APPLICATION));

	if (!RegisterClassEx(&wcex))
	{
		MessageBox(NULL, _T("Call to RegisterClassEx failed!"), _T("Win32 Guided Tour"), NULL);
		return 1;
	}

	hInst = hInstance;
	HWND Window = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW, CW_USEDEFAULT, CW_USEDEFAULT, 700, 450, NULL, NULL, hInstance, NULL);

	if (!Window)
	{
		MessageBox(NULL, _T("Call to CreateWindow failed!"), _T("Win32 Guided Tour"), NULL);
		return 1;
	}

	ShowWindow(Window, nCmdShow);
	UpdateWindow(Window);

	MSG msg;
	while (GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

	return (int)msg.wParam;
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	PAINTSTRUCT paintStr;
	HDC hdc;
	TCHAR hfg[] = _T("Hello from Gulce");
	HFONT font;
	static HWND hWndEdit;

	switch (message)
	{
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &paintStr);
		TextOut(hdc, 5, 5, hfg, _tcslen(hfg));
		EndPaint(hWnd, &paintStr);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	case WM_LBUTTONUP:
		hdc = GetDC(hWnd);
		SetTextColor(hdc, RGB(color1, color2, color3));
		font = CreateFont(30, 0, 0, 0, FW_BOLD, 0, 0, 0, DEFAULT_CHARSET, OUT_OUTLINE_PRECIS,
			CLIP_DEFAULT_PRECIS, ANTIALIASED_QUALITY, FF_MODERN, __T("Calibri"));
		SelectObject(hdc, font);
		TextOut(hdc, 5, y, TEXT("Hello"), _tcslen(TEXT("Hello")));
		ReleaseDC(hWnd, hdc);
		y = y + 30;
		color1 = color1 + 20;
		color2 = color2 + 30;
		color3 = color3 + 40;
	break;

	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
		break;
	}
	return 0;
}
