﻿' ///////////////////////////////////////////////////////////////////////
' Copyright 2001-2015 Aspose Pty Ltd. All Rights Reserved.
'
' This file is part of Aspose.Email. The source code in this file
' is only intended as a supplement to the documentation, and is provided
' "as is", without warranty of any kind, either expressed or implied.
' ///////////////////////////////////////////////////////////////////////

Imports System.IO
Imports Aspose.Email.Mail
Imports Aspose.Email.Outlook
Imports Aspose.Email.Pop3
Imports Aspose.Email
Imports Aspose.Email.Mime
Imports Aspose.Email.Imap
Imports System.Configuration
Imports System.Data
Imports Aspose.Email.Mail.Bounce

Public Class DraftAppointmentRequest
    Public Shared Sub Run()
        ' The path to the documents directory.
        Dim dataDir As String = RunExamples.GetDataDir_Email()
        Dim dstDraft As String = dataDir & Convert.ToString("appointment-draft.msg")

        Dim sender As String = "test@gmail.com"
        Dim recipient As String = "test@email.com"

        Dim message As New MailMessage(sender, recipient, String.Empty, String.Empty)

        Dim app As New Appointment(String.Empty, DateTime.Now, DateTime.Now, sender, recipient)
        app.Method = AppointmentMethodType.Publish

        message.AddAlternateView(app.RequestApointment())

        Dim msg As MapiMessage = MapiMessage.FromMailMessage(message)

        ' Save the appointment as draft.
        msg.Save(dstDraft)

        Console.WriteLine(Environment.NewLine + "Draft saved at " & dstDraft)
    End Sub
End Class
