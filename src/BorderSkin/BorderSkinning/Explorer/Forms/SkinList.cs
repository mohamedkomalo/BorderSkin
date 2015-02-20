//class SkinList
//    Inherits ListView

//    Public SkinElement As SkinElement
//    Public BoxElement As SkinElement

//    Private Sub Handle_DrawItem(ByVal sender As Object, _
//                                ByVal e As System.Windows.Forms.DrawListViewItemEventArgs) Handles Me.DrawItem
//        e.Draw()
//        Dim aa As ButtonState = ButtonState.Normal
//        If CBool(e.State And ListViewItemStates.Hot) Then
//            aa = ButtonState.Hover
//        End If
//        If CBool(e.State And ListViewItemStates.Selected) Then
//            aa = ButtonState.Hover
//        End If
//        'Debug.WriteLine(e.State.ToString)
//        BoxElement.DrawButton(e.Graphics, ActiveState.Active, aa, e.Bounds.Location, e.Bounds.Width, False, 255)
//        e.DrawText()
//        If e.State = ListViewItemStates.Default Then
//            Font.Dispose()
//        End If
//    End Sub

//    'Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
//    '    Dim BufferImage As New DCImage(Me.Size)
//    '    Dim g As Graphics = Graphics.FromHdc(BufferImage.DC)
//    '    SkinElement.DrawImage(BufferImage, ActiveState.Active, Me.Width, Me.Height)

//    '    BitBlt(e.Graphics.GetHdc, 0, 0, Width, Height, BufferImage.DC, 0, 0, CopyPixelOperation.SourceCopy)
//    '    e.Graphics.ReleaseHdc()

//    '    BufferImage.Dispose()
//    '    g.Dispose()
//    '    MyBase.OnPaint(e)
//    'End Sub

//    'Protected Overrides Sub OnPaintBackground(ByVal pevent As System.Windows.Forms.PaintEventArgs)
//    '    Dim BufferImage As New DCImage(Me.Size)
//    '    Dim g As Graphics = Graphics.FromHdc(BufferImage.DC)
//    '    SkinElement.DrawImage(BufferImage, ActiveState.Active, Me.Width, Me.Height)

//    '    BitBlt(pevent.Graphics.GetHdc, 0, 0, Width, Height, BufferImage.DC, 0, 0, CopyPixelOperation.SourceCopy)
//    '    pevent.Graphics.ReleaseHdc()

//    '    BufferImage.Dispose()
//    '    g.Dispose()

//    '    'MyBase.OnPaintBackground(pevent)
//    'End Sub
//End Class
