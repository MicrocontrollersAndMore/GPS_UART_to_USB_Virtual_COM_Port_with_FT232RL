<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Me.cboCOMPort = New System.Windows.Forms.ComboBox()
		Me.btnPauseOrResume = New System.Windows.Forms.Button()
		Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
		Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
		Me.line1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
		Me.spGPSData = New System.IO.Ports.SerialPort(Me.components)
		Me.lblSelectComPort = New System.Windows.Forms.Label()
		Me.lblTime = New System.Windows.Forms.Label()
		Me.lblLatLong = New System.Windows.Forms.Label()
		Me.lblPosFixIndicator = New System.Windows.Forms.Label()
		Me.lblNumSat = New System.Windows.Forms.Label()
		Me.lblAltitude = New System.Windows.Forms.Label()
		Me.lblLatLongMoreInfo = New System.Windows.Forms.Label()
		Me.txtTime = New System.Windows.Forms.TextBox()
		Me.txtLatLong = New System.Windows.Forms.TextBox()
		Me.txtPosFixIndicator = New System.Windows.Forms.TextBox()
		Me.txtNumSat = New System.Windows.Forms.TextBox()
		Me.txtAltitude = New System.Windows.Forms.TextBox()
		Me.txtGPSData = New System.Windows.Forms.TextBox()
		Me.lblLatLongMoreInfo2 = New System.Windows.Forms.Label()
		Me.SuspendLayout
		'
		'cboCOMPort
		'
		Me.cboCOMPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.cboCOMPort.FormattingEnabled = true
		Me.cboCOMPort.Location = New System.Drawing.Point(232, 4)
		Me.cboCOMPort.MaxDropDownItems = 50
		Me.cboCOMPort.Name = "cboCOMPort"
		Me.cboCOMPort.Size = New System.Drawing.Size(124, 30)
		Me.cboCOMPort.TabIndex = 0
		'
		'btnPauseOrResume
		'
		Me.btnPauseOrResume.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.btnPauseOrResume.Location = New System.Drawing.Point(392, 4)
		Me.btnPauseOrResume.Name = "btnPauseOrResume"
		Me.btnPauseOrResume.Size = New System.Drawing.Size(112, 32)
		Me.btnPauseOrResume.TabIndex = 1
		Me.btnPauseOrResume.Text = "pause"
		Me.btnPauseOrResume.UseVisualStyleBackColor = true
		Me.btnPauseOrResume.Visible = false
		'
		'ShapeContainer1
		'
		Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
		Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
		Me.ShapeContainer1.Name = "ShapeContainer1"
		Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1, Me.line1})
		Me.ShapeContainer1.Size = New System.Drawing.Size(877, 553)
		Me.ShapeContainer1.TabIndex = 2
		Me.ShapeContainer1.TabStop = false
		'
		'LineShape1
		'
		Me.LineShape1.Name = "LineShape1"
		Me.LineShape1.X1 = 375
		Me.LineShape1.X2 = 375
		Me.LineShape1.Y1 = 1
		Me.LineShape1.Y2 = 44
		'
		'line1
		'
		Me.line1.Name = "line1"
		Me.line1.X1 = 3
		Me.line1.X2 = 504
		Me.line1.Y1 = 44
		Me.line1.Y2 = 44
		'
		'spGPSData
		'
		Me.spGPSData.BaudRate = 4800
		Me.spGPSData.PortName = "COM3"
		'
		'lblSelectComPort
		'
		Me.lblSelectComPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblSelectComPort.Location = New System.Drawing.Point(4, 8)
		Me.lblSelectComPort.Name = "lblSelectComPort"
		Me.lblSelectComPort.Size = New System.Drawing.Size(224, 28)
		Me.lblSelectComPort.TabIndex = 3
		Me.lblSelectComPort.Text = "select COM port to begin:"
		'
		'lblTime
		'
		Me.lblTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblTime.Location = New System.Drawing.Point(4, 52)
		Me.lblTime.Name = "lblTime"
		Me.lblTime.Size = New System.Drawing.Size(232, 28)
		Me.lblTime.TabIndex = 4
		Me.lblTime.Text = "time (U.S. EST time zone):"
		'
		'lblLatLong
		'
		Me.lblLatLong.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblLatLong.Location = New System.Drawing.Point(4, 84)
		Me.lblLatLong.Name = "lblLatLong"
		Me.lblLatLong.Size = New System.Drawing.Size(232, 28)
		Me.lblLatLong.TabIndex = 5
		Me.lblLatLong.Text = "latitude, longitude:"
		'
		'lblPosFixIndicator
		'
		Me.lblPosFixIndicator.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblPosFixIndicator.Location = New System.Drawing.Point(4, 116)
		Me.lblPosFixIndicator.Name = "lblPosFixIndicator"
		Me.lblPosFixIndicator.Size = New System.Drawing.Size(232, 28)
		Me.lblPosFixIndicator.TabIndex = 6
		Me.lblPosFixIndicator.Text = "position fix indicator:"
		'
		'lblNumSat
		'
		Me.lblNumSat.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblNumSat.Location = New System.Drawing.Point(4, 148)
		Me.lblNumSat.Name = "lblNumSat"
		Me.lblNumSat.Size = New System.Drawing.Size(232, 28)
		Me.lblNumSat.TabIndex = 7
		Me.lblNumSat.Text = "# of satellites used:"
		'
		'lblAltitude
		'
		Me.lblAltitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblAltitude.Location = New System.Drawing.Point(4, 180)
		Me.lblAltitude.Name = "lblAltitude"
		Me.lblAltitude.Size = New System.Drawing.Size(232, 28)
		Me.lblAltitude.TabIndex = 8
		Me.lblAltitude.Text = "mean sea level altitude:"
		'
		'lblLatLongMoreInfo
		'
		Me.lblLatLongMoreInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblLatLongMoreInfo.Location = New System.Drawing.Point(584, 44)
		Me.lblLatLongMoreInfo.Name = "lblLatLongMoreInfo"
		Me.lblLatLongMoreInfo.Size = New System.Drawing.Size(212, 28)
		Me.lblLatLongMoreInfo.TabIndex = 9
		Me.lblLatLongMoreInfo.Text = "for latitude, longitude:"
		'
		'txtTime
		'
		Me.txtTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.txtTime.Location = New System.Drawing.Point(236, 52)
		Me.txtTime.Name = "txtTime"
		Me.txtTime.ReadOnly = true
		Me.txtTime.Size = New System.Drawing.Size(268, 28)
		Me.txtTime.TabIndex = 10
		'
		'txtLatLong
		'
		Me.txtLatLong.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.txtLatLong.Location = New System.Drawing.Point(236, 84)
		Me.txtLatLong.Name = "txtLatLong"
		Me.txtLatLong.ReadOnly = true
		Me.txtLatLong.Size = New System.Drawing.Size(268, 28)
		Me.txtLatLong.TabIndex = 11
		'
		'txtPosFixIndicator
		'
		Me.txtPosFixIndicator.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.txtPosFixIndicator.Location = New System.Drawing.Point(236, 116)
		Me.txtPosFixIndicator.Name = "txtPosFixIndicator"
		Me.txtPosFixIndicator.ReadOnly = true
		Me.txtPosFixIndicator.Size = New System.Drawing.Size(268, 28)
		Me.txtPosFixIndicator.TabIndex = 12
		'
		'txtNumSat
		'
		Me.txtNumSat.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.txtNumSat.Location = New System.Drawing.Point(236, 148)
		Me.txtNumSat.Name = "txtNumSat"
		Me.txtNumSat.ReadOnly = true
		Me.txtNumSat.Size = New System.Drawing.Size(268, 28)
		Me.txtNumSat.TabIndex = 13
		'
		'txtAltitude
		'
		Me.txtAltitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.txtAltitude.Location = New System.Drawing.Point(236, 180)
		Me.txtAltitude.Name = "txtAltitude"
		Me.txtAltitude.ReadOnly = true
		Me.txtAltitude.Size = New System.Drawing.Size(268, 28)
		Me.txtAltitude.TabIndex = 14
		'
		'txtGPSData
		'
		Me.txtGPSData.Font = New System.Drawing.Font("Courier New", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.txtGPSData.Location = New System.Drawing.Point(0, 212)
		Me.txtGPSData.Multiline = true
		Me.txtGPSData.Name = "txtGPSData"
		Me.txtGPSData.ReadOnly = true
		Me.txtGPSData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtGPSData.Size = New System.Drawing.Size(876, 340)
		Me.txtGPSData.TabIndex = 15
		'
		'lblLatLongMoreInfo2
		'
		Me.lblLatLongMoreInfo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
		Me.lblLatLongMoreInfo2.Location = New System.Drawing.Point(524, 76)
		Me.lblLatLongMoreInfo2.Name = "lblLatLongMoreInfo2"
		Me.lblLatLongMoreInfo2.Size = New System.Drawing.Size(344, 64)
		Me.lblLatLongMoreInfo2.TabIndex = 16
		Me.lblLatLongMoreInfo2.Text = "latitude and longitude are in decimal degrees"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"for latitude, + = N, - = S"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"for lo"& _ 
    "ngitude, + = E, - = W"
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(877, 553)
		Me.Controls.Add(Me.lblLatLongMoreInfo2)
		Me.Controls.Add(Me.txtGPSData)
		Me.Controls.Add(Me.txtAltitude)
		Me.Controls.Add(Me.txtNumSat)
		Me.Controls.Add(Me.txtPosFixIndicator)
		Me.Controls.Add(Me.txtLatLong)
		Me.Controls.Add(Me.txtTime)
		Me.Controls.Add(Me.lblLatLongMoreInfo)
		Me.Controls.Add(Me.lblAltitude)
		Me.Controls.Add(Me.lblNumSat)
		Me.Controls.Add(Me.lblPosFixIndicator)
		Me.Controls.Add(Me.lblLatLong)
		Me.Controls.Add(Me.lblTime)
		Me.Controls.Add(Me.lblSelectComPort)
		Me.Controls.Add(Me.btnPauseOrResume)
		Me.Controls.Add(Me.cboCOMPort)
		Me.Controls.Add(Me.ShapeContainer1)
		Me.Name = "Form1"
		Me.Text = "GPSData"
		Me.ResumeLayout(false)
		Me.PerformLayout

End Sub
    Friend WithEvents cboCOMPort As System.Windows.Forms.ComboBox
    Friend WithEvents btnPauseOrResume As System.Windows.Forms.Button
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents line1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents spGPSData As System.IO.Ports.SerialPort
    Friend WithEvents lblSelectComPort As System.Windows.Forms.Label
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents lblLatLong As System.Windows.Forms.Label
    Friend WithEvents lblPosFixIndicator As System.Windows.Forms.Label
    Friend WithEvents lblNumSat As System.Windows.Forms.Label
    Friend WithEvents lblAltitude As System.Windows.Forms.Label
    Friend WithEvents lblLatLongMoreInfo As System.Windows.Forms.Label
    Friend WithEvents txtTime As System.Windows.Forms.TextBox
    Friend WithEvents txtLatLong As System.Windows.Forms.TextBox
    Friend WithEvents txtPosFixIndicator As System.Windows.Forms.TextBox
    Friend WithEvents txtNumSat As System.Windows.Forms.TextBox
    Friend WithEvents txtAltitude As System.Windows.Forms.TextBox
    Friend WithEvents txtGPSData As System.Windows.Forms.TextBox
    Friend WithEvents lblLatLongMoreInfo2 As System.Windows.Forms.Label

End Class
