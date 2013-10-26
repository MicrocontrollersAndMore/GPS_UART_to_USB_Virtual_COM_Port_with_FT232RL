Option Strict

Module ParseForGPSDataMod

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Function ParseForGPSData(strBuff As String, ByRef strTime As String, ByRef strLatLong As String, ByRef strPosFixIndicator As String, ByRef strNumSat As String, ByRef strAltitude As String) As Boolean
	Dim intBegOfSubstring As Integer = 0
	Dim intEndOfSubstring As Integer = 0
	Dim intNumCommas As Integer = 0
	
	Dim strLat As String = ""
	Dim strNSIndicator As String = ""
	Dim strLong As String = ""
	Dim strEWIndicator As String = ""
	Dim strAltitudeUnits As String = ""
	
	Dim blnValidTime As Boolean = False

	strTime = ""
	strLatLong = ""
	strPosFixIndicator = ""
	strNumSat = ""
	strAltitude = ""

	If(strBuff.Length < 6) Then						'bail if string does not have at least 6 chars (next If would crash prog. if ran on string with < 6 chars)
		Return(False)
	End If
																				'if string does not start "$GPGGA, bail
	If(strBuff(0) <> "$"C Or strBuff(1) <> "G"C Or strBuff(2) <> "P"C Or strBuff(3) <> "G"C Or strBuff(4) <> "G"C Or strBuff(5) <> "A"C) Then
		Return(False)
	End If

	If(Not strBuff.Contains("*"C)) Then					'if string does not contain at least one '*', bail
		Return(False)
	End If

	intNumCommas = CountChars(strBuff, ","C)					'get the number of commas in the string

	If(intNumCommas <> 14) Then												'if not exactly 14 commas, string is not valid, bail
		Return(False)
	End If

	If(CheckIfForFirst12CommasNextCharIsAlsoAComma(strBuff) = True) Then			'if, for first 12 commas, the next char is also a comma . . .
		Return(False)																														'then there is a missing substring, bail
	End If
	
	intBegOfSubstring = 0																'start of locating 1st substring (after "$GPGGA")

	While(strBuff(intBegOfSubstring) <> ","C)
		intBegOfSubstring = intBegOfSubstring + 1
	End While
	intBegOfSubstring = intBegOfSubstring + 1

	intEndOfSubstring = intBegOfSubstring
	While(strBuff(intEndOfSubstring) <> ","C)
		intEndOfSubstring = intEndOfSubstring + 1
	End While
	intEndOfSubstring = intEndOfSubstring - 1						'end of locating 1st substring
																											'now at 1st substring (time)
	strTime = strBuff.Substring(intBegOfSubstring, intEndOfSubstring - intBegOfSubstring + 1)		'get time substring	
	
	blnValidTime = FormatTime(strTime)																													'format time

	If(blnValidTime = False) Then
		Return(False)
	End If
	
	GoToNextSubstring(strBuff, intBegOfSubstring, intEndOfSubstring)														'go to 2nd substring (latitude)

	strLat = strBuff.Substring(intBegOfSubstring, intEndOfSubstring - intBegOfSubstring + 1)

	GoToNextSubstring(strBuff, intBegOfSubstring, intEndOfSubstring)																		'go to 3rd substring (NS indicator)

	strNSIndicator = strBuff.Substring(intBegOfSubstring, intEndOfSubstring - intBegOfSubstring + 1)

	GoToNextSubstring(strBuff, intBegOfSubstring, intEndOfSubstring)																		'go to 4th substring (longitude)

	strLong = strBuff.Substring(intBegOfSubstring, intEndOfSubstring - intBegOfSubstring + 1)
	
	GoToNextSubstring(strBuff, intBegOfSubstring, intEndOfSubstring)																		'go to 5th substring (EW indicator)

	strEWIndicator = strBuff.Substring(intBegOfSubstring, intEndOfSubstring - intBegOfSubstring + 1)
	
	strLatLong = FormatLatLong(strLat, strNSIndicator, strLong, strEWIndicator)

	GoToNextSubstring(strBuff, intBegOfSubstring, intEndOfSubstring)																		'go to 6th substring (position fix indicator)
	
	strPosFixIndicator = strBuff.Substring(intBegOfSubstring, intEndOfSubstring - intBegOfSubstring + 1)
	
	AddDescriptionToPositionFixIndicator(strPosFixIndicator)
	
	GoToNextSubstring(strBuff, intBegOfSubstring, intEndOfSubstring)																		'go to 7th substring (# satellites used)

	strNumSat = strBuff.Substring(intBegOfSubstring, intEndOfSubstring - intBegOfSubstring + 1)

	strNumSat = Convert.ToString(Convert.ToInt32(strNumSat))

	GoToNextSubstring(strBuff, intBegOfSubstring, intEndOfSubstring)																		'go to 8th substring (horiz. dilution of precision)
	GoToNextSubstring(strBuff, intBegOfSubstring, intEndOfSubstring)																		'go to 9th substring (mean sea level altitude)
	
	strAltitude = strBuff.Substring(intBegOfSubstring, intEndOfSubstring - intBegOfSubstring + 1)
	
	GoToNextSubstring(strBuff, intBegOfSubstring, intEndOfSubstring)																		'go to 10th substring (altitude units)
	
	If(strBuff(intBegOfSubstring) = "M"C) Then
		strAltitudeUnits = "meters"
	ElseIf(strBuff(intBegOfSubstring) = "F"C) Then
		strAltitudeUnits = "feet"
	End If

	strAltitude = strAltitude + " " + strAltitudeUnits
	Return(True)
End Function

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Sub GoToNextSubstring(strBuff As String, ByRef intBegOfSubstring As Integer, ByRef intEndOfSubstring As Integer)
	intBegOfSubstring = intEndOfSubstring + 2
	intEndOfSubstring = intBegOfSubstring
	
	While(strBuff(intEndOfSubstring) <> ","C)
		intEndOfSubstring = intEndOfSubstring + 1
	End While
	intEndOfSubstring = intEndOfSubstring - 1
End Sub


'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Function countChars(str As String, charToCount As Char) As Integer
	Dim intNumInstancesOfChar As Integer = 0

	For i As Integer = 0 To (str.Length - 1)
		If(str(i) = charToCount) Then
			intNumInstancesOfChar = intNumInstancesOfChar + 1
		End If
	Next

	Return(intNumInstancesOfChar)
End Function


'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Function CheckIfForFirst12CommasNextCharIsAlsoAComma(strBuff As String) As Boolean
'	Dim intCommaCount As Integer = 0
	Dim intCharIndex As Integer = 0

	For intCommaCount As Integer = 0 To 11
		While(strBuff(intCharIndex) <> ","C)
			intCharIndex = intCharIndex + 1
		End While

		If(strBuff(intCharIndex+1) = ","C) Then
			Return(True)
		Else
			intCharIndex = intCharIndex + 1
		End If
	Next
	
	Return(False)
End Function

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Function FormatTime(ByRef strTime As String) As Boolean
	Dim strHour As String = ""
	Dim intHour As Integer = 0
	Dim strAMorPM As String = ""
	Dim strMinute As String = ""
	Dim intMinute As Integer = 0
	Dim strSec As String = ""
	Dim intSec As Integer = 0
																				'before we get started, verify that we have a valid time string, bail if not
	If(strTime.Length <> 10) Then														'string has to be 10 chars total
		Return(False)
	End If

	If(strTime(6) <> "."C) Then															'the 7th char (index #6) should be a '.'
		Return(False)
	End If

	For i As Integer = 0 To 5
		If(strTime(i) < "0"C Or strTime(i) > "9"C) Then				'all other chars should be numbers
			Return(False)
		End If
	Next

	For i As Integer = 7 To 9
		If(strTime(i) < "0"C Or strTime(i) > "9"C) Then
			Return(False)
		End If
	Next

	strHour = strTime.Substring(0, 2)
	intHour = Convert.ToInt32(strHour)

	intHour = intHour - 4														'convert from UTC time to EST time
	If(intHour < 0) Then
		intHour = intHour + 24
	End If

	If(intHour = 0) Then
		intHour = 12
		strAMorPM = "AM"
	ElseIf(intHour >= 1 And intHour <= 11) Then
		strAMorPM = "AM"
	ElseIf(intHour = 12) Then
		strAMorPM = "PM"
	ElseIf(intHour >= 13 And intHour <= 24) Then
		intHour = intHour - 12
		strAMorPM = "PM"
	Else
		'should never get here
	End If
	
	strMinute = strTime.Substring(2, 2)
	intMinute = Convert.ToInt32(strMinute)
	
	strSec = strTime.Substring(4, 2)
	intSec = Convert.ToInt32(strSec)
	
	strTime = intHour.ToString() + ":" + strMinute + " " + strAMorPM + " EST, and " + strSec + " seconds"
	Return(True)
End Function

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Function FormatLatLong(strLatitude As String, strNSIndicator As String, strLongitude As String, strEWIndicator As String) As String
	Dim strLatLong As String = ""
	Dim strTempLat As String = ""
	Dim strTempLong As String = ""
	
	Dim decLat As Decimal = 0.0D
	Dim decLatDegPortion As Decimal = 0.0D
	Dim decLatMinPortion As Decimal = 0.0D
	
	Dim decLong As Decimal = 0.0D
	Dim decLongDegPortion As Decimal = 0.0D
	Dim decLongMinPortion As Decimal = 0.0D

	decLatDegPortion = Convert.ToDecimal(strLatitude.Substring(0, 2))
	decLatMinPortion = Convert.ToDecimal(strLatitude.Substring(2, 7)) / 60.0D

	decLat = decLatDegPortion + decLatMinPortion
	If(strNSIndicator = "S"C) Then
		decLat = decLat * -1
	End If

	decLongDegPortion = Convert.ToDecimal(strLongitude.Substring(0, 3))
	decLongMinPortion = Convert.ToDecimal(strLongitude.Substring(3, 7)) / 60.0D

	decLong = decLongDegPortion + decLongMinPortion
	If(strEWIndicator = "W"C) Then
		decLong = decLong * -1
	End If

	strTempLat = decLat.ToString()
	If(strTempLat.Length > 10) Then												'if lat is > 10 chars, only use the first 10
		strTempLat = strTempLat.Substring(0, 10)
	End If

	strTempLong = decLong.ToString()
	If(strTempLong.Length > 10) Then													'if long is > 10 chard, only use the first 10
		strTempLong = strTempLong.Substring(0, 10)
	End If
	
	strLatLong = strTempLat + ", " + strTempLong
	
	Return(strLatLong)
End Function

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
Sub AddDescriptionToPositionFixIndicator(ByRef strPosFixIndicator As String)
	If(strPosFixIndicator = "0") Then
		strPosFixIndicator = strPosFixIndicator + " - fix not available or invalid"
	ElseIf(strPosFixIndicator = "1") Then
		strPosFixIndicator = strPosFixIndicator + " - GPS SPS mode, fix valid"
	ElseIf(strPosFixIndicator = "2") Then
		strPosFixIndicator = strPosFixIndicator + " - differential GPS, SPS mode, fix valid"
	ElseIf(strPosFixIndicator = "6") Then
		strPosFixIndicator = strPosFixIndicator + " - dead reckoning mode, fix valid"
	End If
End Sub

End Module
