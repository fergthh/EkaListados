<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ListadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LsiatdoDeHorasPorClienteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListadoDeHorasPorEmpleadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListadoDeControlPorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcesosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CerrarSistemaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ListadosToolStripMenuItem, Me.ProcesosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(580, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ListadosToolStripMenuItem
        '
        Me.ListadosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LsiatdoDeHorasPorClienteToolStripMenuItem, Me.ListadoDeHorasPorEmpleadoToolStripMenuItem, Me.ListadoDeControlPorToolStripMenuItem})
        Me.ListadosToolStripMenuItem.Name = "ListadosToolStripMenuItem"
        Me.ListadosToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.ListadosToolStripMenuItem.Text = "Listados"
        '
        'LsiatdoDeHorasPorClienteToolStripMenuItem
        '
        Me.LsiatdoDeHorasPorClienteToolStripMenuItem.Name = "LsiatdoDeHorasPorClienteToolStripMenuItem"
        Me.LsiatdoDeHorasPorClienteToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.LsiatdoDeHorasPorClienteToolStripMenuItem.Text = "Listado de Horas por Cliente"
        '
        'ListadoDeHorasPorEmpleadoToolStripMenuItem
        '
        Me.ListadoDeHorasPorEmpleadoToolStripMenuItem.Name = "ListadoDeHorasPorEmpleadoToolStripMenuItem"
        Me.ListadoDeHorasPorEmpleadoToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.ListadoDeHorasPorEmpleadoToolStripMenuItem.Text = "Listado de Horas por Empleado"
        '
        'ListadoDeControlPorToolStripMenuItem
        '
        Me.ListadoDeControlPorToolStripMenuItem.Name = "ListadoDeControlPorToolStripMenuItem"
        Me.ListadoDeControlPorToolStripMenuItem.Size = New System.Drawing.Size(239, 22)
        Me.ListadoDeControlPorToolStripMenuItem.Text = "Listado de Control de Horas"
        '
        'ProcesosToolStripMenuItem
        '
        Me.ProcesosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CerrarSistemaToolStripMenuItem})
        Me.ProcesosToolStripMenuItem.Name = "ProcesosToolStripMenuItem"
        Me.ProcesosToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.ProcesosToolStripMenuItem.Text = "Procesos"
        '
        'CerrarSistemaToolStripMenuItem
        '
        Me.CerrarSistemaToolStripMenuItem.Name = "CerrarSistemaToolStripMenuItem"
        Me.CerrarSistemaToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.CerrarSistemaToolStripMenuItem.Text = "Cerrar Sistema"
        '
        'MenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 329)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MenuPrincipal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ListadosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LsiatdoDeHorasPorClienteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListadoDeHorasPorEmpleadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListadoDeControlPorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProcesosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CerrarSistemaToolStripMenuItem As ToolStripMenuItem
End Class
