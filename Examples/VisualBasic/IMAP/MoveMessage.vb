﻿Imports Aspose.Email.Imap
Imports Aspose.Email.Mail

Public Class MoveMessage
    Private Shared Sub Run()
        'ExStart: MoveMessage
        '<summary>
        'This example shows how to move a message from one folder of a mailbox to another one using the ImapClient API of Aspose.Email for .NET
        'Available from Aspose.Email for .NET 6.4.0 onwards
        ' -------------- Available API Overload Members --------------
        'void ImapClient.MoveMessage(IConnection iConnection, int sequenceNumber, string folderName, bool commitDeletions)
        'void ImapClient.MoveMessage(IConnection iConnection, string uniqueId, string folderName, bool commitDeletions)
        'void ImapClient.MoveMessage(int sequenceNumber, string folderName, bool commitDeletions)
        'void ImapClient.MoveMessage(string uniqueId, string folderName, bool commitDeletions)
        'void ImapClient.MoveMessage(IConnection iConnection, int sequenceNumber, string folderName)
        'void ImapClient.MoveMessage(IConnection iConnection, string uniqueId, string folderName)
        'void ImapClient.MoveMessage(int sequenceNumber, string folderName)
        'void ImapClient.MoveMessage(string uniqueId, string folderName)
        '</summary>

        Using client As New ImapClient("host.domain.com", 993, "username", "password")
            Dim folderName As String = "EMAILNET-35151"
            If Not client.ExistFolder(folderName) Then
                client.CreateFolder(folderName)
            End If
            Try
                Dim message As New MailMessage("from@domain.com", "to@domain.com", "EMAILNET-35151 - " + Guid.NewGuid().ToString(), "EMAILNET-35151 ImapClient: Provide option to Move Message")
                client.SelectFolder(ImapFolderInfo.InBox)
                'Append the new message to Inbox folder
                Dim uniqueId As String = client.AppendMessage(ImapFolderInfo.InBox, message)
                Dim messageInfoCol1 As ImapMessageInfoCollection = client.ListMessages()
                Console.WriteLine(messageInfoCol1.Count)
                'Now move the message to the folder EMAILNET-35151
                client.MoveMessage(uniqueId, folderName)
                client.CommitDeletes()
                'Verify that the message was moved to the new folder
                client.SelectFolder(folderName)
                messageInfoCol1 = client.ListMessages()
                Console.WriteLine(messageInfoCol1.Count)
                'Verify that the message was moved from the Inbox
                client.SelectFolder(ImapFolderInfo.InBox)
                messageInfoCol1 = client.ListMessages()
                Console.WriteLine(messageInfoCol1.Count)
            Finally
                Try
                    client.DeleteFolder(folderName)
                Catch
                End Try
            End Try
        End Using
        'ExEnd: MoveMessage
    End Sub
End Class
