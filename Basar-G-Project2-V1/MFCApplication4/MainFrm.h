
// MainFrm.h : interface of the CMainFrame class
//

#pragma once
#include "ChildView.h"

class CMainFrame : public CFrameWnd
{
protected:
	CStatusBar        m_wndStatusBar;
	CChildView    m_wndView;
	DECLARE_DYNAMIC(CMainFrame)
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnSetFocus(CWnd *pOldWnd);
	DECLARE_MESSAGE_MAP()
public:
	CMainFrame();
	void OnPaint();
	void OnMove(int i, int j);
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	virtual BOOL OnCmdMsg(UINT nID, int nCode, void* pExtra, AFX_CMDHANDLERINFO* pHandlerInfo);\
	virtual ~CMainFrame();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif
};


