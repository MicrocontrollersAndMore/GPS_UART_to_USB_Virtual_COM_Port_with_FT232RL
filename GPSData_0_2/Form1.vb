Option Strict

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Public Class Form1

' constants '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Public Const NUM_COM_PORTS_IN_DROP_DOWN As Integer = 10

' member variables ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Dim blnFirstTimeInResizeEvent As Boolean = True
Dim intOrigFormWidth As Integer = 0
Dim intOrigFormHeight As Integer = 0
Dim intOrigTextBoxWidth As Integer = 0
Dim intOrigTextBoxHeight As Integer = 0

Dim strTime As String = ""
Dim strLatLong As String = ""
Dim strPosFixIndicator As String = ""
Dim strNumSat As String = ""
Dim strAltitude As String = ""

' constructor '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Sub New()
	InitializeComponent()		'always call this in a visual basic form constructor, necessary to init form
	
	For i As Integer = 1 To NUM_COM_PORTS_IN_DROP_DOWN
		cboCOMPort.Items.Add("COM" + i.ToString())
	Next
	
	spGPSData.NewLine = Convert.ToString(ChrW(13)) + Convert.ToString(ChrW(10))
	
	intOrigFormWidth = Me.Width
	intOrigFormHeight = Me.Height
	intOrigTextBoxWidth = txtGPSData.Width
	intOrigTextBoxHeight = txtGPSData.Height
End Sub

' destructor ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Protected Overrides Sub Finalize()
	If(spGPSData.IsOpen = True) Then
		spGPSDataCloseCatchError()
	End If
End Sub

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Private Sub Form1_Resize( sender As System.Object,  e As System.EventArgs) Handles MyBase.Resize
	'This If Else statement is necessary to throw out the first time the Form1_Resize event is called.
	'For some reason, in VB.NET the Resize event is called once before the constructor, then the constructor is called,
	'then the Resize event is called each time the form is resized.  The first time the Resize event is called
	'(i.e. before the constructor is called) the coordinates of the components on the form all read as zero,
	'therefore we have to throw out this first call, then the constructor will run and get the correct initial
	'component location data, then every time after that we can let the Resize event run as expected
	If (blnFirstTimeInResizeEvent = True) Then
		blnFirstTimeInResizeEvent = False
	Else
		txtGPSData.Width = Me.Width - (intOrigFormWidth - intOrigTextBoxWidth)
		txtGPSData.Height = Me.Height - (intOrigFormHeight - intOrigTextBoxHeight)
	End If
End Sub

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Private Sub spGPSData_DataReceived( sender As System.Object,  e As System.IO.Ports.SerialDataReceivedEventArgs) Handles spGPSData.DataReceived
	Dim strBuff As String = ""
	Dim blnValidGPSData As Boolean = False
	
	Try
		strBuff = spGPSData.ReadLine()
	Catch ex As Exception
		'
	End Try
	
	blnValidGPSData = ParseForGPSData(strBuff, strTime, strLatLong, strPosFixIndicator, strNumSat, strAltitude)
	
	If(blnValidGPSData) Then
		txtTime.Text = strTime
		txtLatLong.Text = strLatLong
		txtPosFixIndicator.Text = strPosFixIndicator
		txtNumSat.Text = strNumSat
		txtAltitude.Text = strAltitude
	End If
	
	txtGPSData.AppendText(strBuff + Environment.NewLine)
	
End Sub

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Private Sub cboCOMPort_SelectedIndexChanged( sender As System.Object,  e As System.EventArgs) Handles cboCOMPort.SelectedIndexChanged
	If (spGPSData.IsOpen = False And btnPauseOrResume.Visible = False) Then		'if at very beginning of program
		spGPSData.PortName = cboCOMPort.SelectedItem.ToString()										'update COM port string
		btnPauseOrResume.Visible = True																						'make pause or resume button visible
		spGPSDataOpenCatchError()																									'an open connection
	ElseIf (spGPSData.IsOpen = True) Then																			'if was not paused when combo box changed
		spGPSDataCloseCatchError()																								'then close the connection
		spGPSData.PortName = cboCOMPort.SelectedItem.ToString()										'change the COM port string
		spGPSDataOpenCatchError()																									'then reopen the connection
	ElseIf (spGPSData.IsOpen = False) Then																		'if was paused when combo box changed
		spGPSData.PortName = cboCOMPort.SelectedItem.ToString()										'we can immediately change the string
	Else
		'should never get here
	End If
End Sub

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Private Sub btnPauseOrResume_Click( sender As System.Object,  e As System.EventArgs) Handles btnPauseOrResume.Click
	If (btnPauseOrResume.Text = "pause") Then												'if button says pause (currently not paused)
		spGPSDataCloseCatchError()																			'close connection
		btnPauseOrResume.Text = "resume"																'update button to say resume for next time
	ElseIf (btnPauseOrResume.Text = "resume") Then									'if button says resume (currently paused)
		txtGPSData.AppendText(Environment.NewLine)											'start new line in big text box
		spGPSDataOpenCatchError()																				'open connection
		btnPauseOrResume.Text = "pause"																	'update button to say pause for next time
	Else
		'should never get here
	End If
End Sub

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Sub spGPSDataOpenCatchError()
	Try
		spGPSData.Open()
	Catch ex As Exception
		txtGPSData.Text = ex.Message
	End Try
End Sub

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Sub spGPSDataCloseCatchError()
	Try
		spGPSData.Close()
	Catch ex As Exception
		txtGPSData.Text = ex.Message
	End Try
End Sub

End Class
