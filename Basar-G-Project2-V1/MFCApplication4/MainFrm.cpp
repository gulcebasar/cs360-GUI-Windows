
#include "stdafx.h"
#include "MFCApplication4.h"

#include "MainFrm.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


IMPLEMENT_DYNAMIC(CMainFrame, CFrameWnd)

BEGIN_MESSAGE_MAP(CMainFrame, CFrameWnd)
	ON_WM_PAINT()
	ON_WM_MOVE()
END_MESSAGE_MAP()


void CMainFrame::OnPaint()
{
	CPaintDC dc(this);
	CString msg;
	msg.Format(_T("Hello from Alper"));
	dc.TextOut(5, 5, msg);

	CDC *cdc;
	cdc = GetDC();
	RECT rc;
	GetWindowRect(&rc);

	CString top, bottom, right, left;
	top.Format(L"%d", rc.top);
	bottom.Format(L"%d", rc.bottom);
	right.Format(L"%d", rc.right);
	left.Format(L"%d", rc.left);

	CString clear(' ', rc.right = rc.left);
	(*cdc).TextOut(5, 25, clear);
	(*cdc).TextOut(5, 25, L"Top: " + top + L"    Left: " + left + L"    Bottom: " + bottom + L"    Right: " + right);
}

void CMainFrame::OnMove(int i, int j)
{
	CDC *cdc;
	cdc = GetDC();
	RECT rc;
	GetWindowRect(&rc);

	CString top, bottom, right, left;
	top.Format(L"%d", rc.top);
	bottom.Format(L"%d", rc.bottom);
	right.Format(L"%d", rc.right);
	left.Format(L"%d", rc.left);

	CString clear(' ', rc.right = rc.left);
	(*cdc).SetTextColor(RGB(255, 0, 0));
	(*cdc).TextOut(5, 25, clear);
	(*cdc).TextOut(5, 25, L"Top: " + top + L"    Left: " + left + L"    Bottom: " + bottom + L"    Right: " + right);
}



static UINT indicators[] =
{
	ID_SEPARATOR,           // status line indicator
	ID_INDICATOR_CAPS,
	ID_INDICATOR_NUM,
	ID_INDICATOR_SCRL,
};


CMainFrame::CMainFrame(){}

CMainFrame::~CMainFrame(){}

BOOL CMainFrame::PreCreateWindow(CREATESTRUCT& cs)
{
	if (!CFrameWnd::PreCreateWindow(cs))
		return FALSE;

	cs.dwExStyle &= ~WS_EX_CLIENTEDGE;
	cs.lpszClass = AfxRegisterWndClass(0);
	return TRUE;
}

#ifdef _DEBUG
void CMainFrame::AssertValid() const
{
	CFrameWnd::AssertValid();
}

void CMainFrame::Dump(CDumpContext& dc) const
{
	CFrameWnd::Dump(dc);
}
#endif //_DEBUG

BOOL CMainFrame::OnCmdMsg(UINT nID, int nCode, void* pExtra, AFX_CMDHANDLERINFO* pHandlerInfo)
{
	if (m_wndView.OnCmdMsg(nID, nCode, pExtra, pHandlerInfo))
		return TRUE;

	return CFrameWnd::OnCmdMsg(nID, nCode, pExtra, pHandlerInfo);
}
