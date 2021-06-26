Dim gamePath
gamePath=""

' Detect 64 or 32 bit system
Dim objShell
Set objShell = WScript.CreateObject("WScript.Shell")
If (GetObject("winmgmts:root\cimv2:Win32_Processor='cpu0'").AddressWidth = 32) Then
	gamePath="rabcr32.exe"
Else
	gamePath="rabcr64.exe"
End If

' Check if file exists
Dim fso
Set fso = CreateObject("Scripting.FileSystemObject")
If (fso.FileExists(gamePath)) Then

	' Run game
	objShell.Run(gamePath)
Else

	' Get language of computer
	dim code
	Set dtmConvertedDate = CreateObject("WbemScripting.SWbemDateTime")

	strComputer = "."
	Set objWMIService = GetObject("winmgmts:" _
		& "{impersonationLevel=impersonate}!\\" & strComputer & "\root\cimv2")

	Set colOperatingSystems = objWMIService.ExecQuery _
		("Select * from Win32_OperatingSystem")

	For Each objOperatingSystem in colOperatingSystems
		code = objOperatingSystem.OSLanguage
	Next

	' Depending on the language, show massage box: game file not exist
	Select Case code
		Case 2058, 4106, 5130, 6154, 7178, 8202, 9226, 10250, 11274, 12298, 13322, 14346, 15370, 16394, 17418, 18442, 19466, 20490: MsgBox "El archivo " & gamePath & " no existe", vbOKOnly, "Error"
		Case 1046, 2070: MsgBox "O arquivo " & gamePath & " não existe", vbOKOnly, "Erro"
		Case 1029: MsgBox "Soubor " & gamePath & " neexistuje", vbOKOnly, "Chyba"
		Case 1045: MsgBox "Plik " & gamePath & " nie istnieje", vbOKOnly, "Błąd"
		Case 1051: MsgBox "Súbor " & gamePath & " neexistuje", vbOKOnly, "Chyba"
		Case 1041: MsgBox gamePath & "ファイルが存在しません", vbOKOnly, "エラー"
		Case 1031, 3079, 5127, 4103, 2055: MsgBox "Die " & gamePath & "-Datei existiert nicht", vbOKOnly, "Error"
		Case 1028: MsgBox gamePath & "文件不存在", vbOKOnly, "錯誤"
		Case 1027: MsgBox "El fitxer " & gamePath & " no existeix", vbOKOnly, "Error"
		Case 1050: MsgBox "Datoteka " & gamePath & " ne postoji", vbOKOnly, "Greška"
		Case 1030: MsgBox gamePath & "-filen findes ikke", vbOKOnly, "Fejl"
		Case 1043: MsgBox "Het " & gamePath & "-bestand bestaat niet", vbOKOnly, "Fout"
		Case 1061: MsgBox gamePath & "-faili ei eksisteeri", vbOKOnly, "Viga"
		Case 1035: MsgBox gamePath & "-tiedostoa ei ole", vbOKOnly, "Virhe"
		Case 1036, 2060, 3084, 5132, 4108, 3084: MsgBox "Le fichier " & gamePath & " n'existe pas", vbOKOnly, "Erreur"
		Case 1042: MsgBox gamePath & " 파일이 없습니다", vbOKOnly, "오류"
		Case 1054: MsgBox "ไม่มีไฟล์  " & gamePath, vbOKOnly, "ความผิดพลาด"
		Case 1058: MsgBox "Файл" & gamePath & " не існує", vbOKOnly, "Помилка"
		Case 1060: MsgBox "Datoteka " & gamePath & " ne obstaja", vbOKOnly, "Napaka"
		Case 1069: MsgBox "Ez dago " & gamePath & " fitxategia", vbOKOnly, "Akatsa"
		Case 1071: MsgBox "Датотеката " & gamePath & " не постои", vbOKOnly, "Грешка"
		Case 7169, 13313: MsgBox "غير موجود " & gamePath & " ملف", vbOKOnly, "خطأ"
		Case 1078: MsgBox "Die " & gamePath & "-lêer bestaan nie", vbOKOnly, "Fout"

		Case Else: MsgBox "The " & gamePath & " file does not exist", vbOKOnly, "Error"
	End Select

End if

Set objShell = Nothing