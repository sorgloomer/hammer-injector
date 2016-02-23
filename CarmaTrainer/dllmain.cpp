// dllmain.cpp : Defines the entry point for the DLL application.
#include "stdafx.h"

struct CarObject {
	float vx, vy, vz;
	float ax, ay, az;
	float qx, qy, qz, qw;
	float px, py, pz;
};

DWORD WINAPI MyTrainer(LPVOID lpParam)
{
	MessageBox(0, L"Success", L"Inject", 0);
	for (;;) {
		Sleep(50);
		if (GetAsyncKeyState((int)'H') & ~1) {
			CarObject* obj = *(CarObject**)((*(int*)(0x61545c)) + 0x98);
			obj->vy = 0.1f;
			obj->py += 1.5f;
		}
	}
	return 0;
};

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
					 )
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
		CreateThread(NULL, 0, &MyTrainer, NULL, 0, NULL);
		break;
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}

