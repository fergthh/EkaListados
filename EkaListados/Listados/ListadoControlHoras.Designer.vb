<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ListadoControlHoras
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHastaEmpleado = New System.Windows.Forms.TextBox()
        Me.txtDesdeEmpleado = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAño = New System.Windows.Forms.TextBox()
        Me.txtMes = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lblDescCliente = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCliente = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnConsultas = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnPantalla = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(588, 64)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Candara", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(419, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 33)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "EKA"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Candara", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(423, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(146, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Estudio Kreutzer & Asociados"
        Me.Label3.UseMnemonic = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Candara", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(36, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Listado de Control de Horas"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtHastaEmpleado)
        Me.GroupBox1.Controls.Add(Me.txtDesdeEmpleado)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 81)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(557, 55)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Empleado"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(159, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Hasta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Desde"
        '
        'txtHastaEmpleado
        '
        Me.txtHastaEmpleado.Location = New System.Drawing.Point(203, 21)
        Me.txtHastaEmpleado.MaxLength = 8
        Me.txtHastaEmpleado.Name = "txtHastaEmpleado"
        Me.txtHastaEmpleado.Size = New System.Drawing.Size(63, 20)
        Me.txtHastaEmpleado.TabIndex = 1
        Me.txtHastaEmpleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDesdeEmpleado
        '
        Me.txtDesdeEmpleado.Location = New System.Drawing.Point(90, 21)
        Me.txtDesdeEmpleado.MaxLength = 8
        Me.txtDesdeEmpleado.Name = "txtDesdeEmpleado"
        Me.txtDesdeEmpleado.Size = New System.Drawing.Size(63, 20)
        Me.txtDesdeEmpleado.TabIndex = 0
        Me.txtDesdeEmpleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtAño)
        Me.GroupBox2.Controls.Add(Me.txtMes)
        Me.GroupBox2.Location = New System.Drawing.Point(357, 150)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(217, 55)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Periodo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(107, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Año"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Mes"
        '
        'txtAño
        '
        Me.txtAño.Location = New System.Drawing.Point(139, 21)
        Me.txtAño.MaxLength = 4
        Me.txtAño.Name = "txtAño"
        Me.txtAño.Size = New System.Drawing.Size(46, 20)
        Me.txtAño.TabIndex = 6
        Me.txtAño.Text = "2018"
        Me.txtAño.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMes
        '
        Me.txtMes.Location = New System.Drawing.Point(70, 21)
        Me.txtMes.MaxLength = 2
        Me.txtMes.Name = "txtMes"
        Me.txtMes.Size = New System.Drawing.Size(30, 20)
        Me.txtMes.TabIndex = 6
        Me.txtMes.Text = "11"
        Me.txtMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblDescCliente)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.txtCliente)
        Me.GroupBox4.Location = New System.Drawing.Point(17, 150)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(334, 55)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        '
        'lblDescCliente
        '
        Me.lblDescCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblDescCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescCliente.Location = New System.Drawing.Point(110, 21)
        Me.lblDescCliente.Name = "lblDescCliente"
        Me.lblDescCliente.Size = New System.Drawing.Size(208, 19)
        Me.lblDescCliente.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Cliente"
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(67, 20)
        Me.txtCliente.MaxLength = 8
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(39, 20)
        Me.txtCliente.TabIndex = 6
        Me.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnSalir)
        Me.GroupBox7.Controls.Add(Me.btnConsultas)
        Me.GroupBox7.Controls.Add(Me.btnImprimir)
        Me.GroupBox7.Controls.Add(Me.btnPantalla)
        Me.GroupBox7.Location = New System.Drawing.Point(17, 211)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(557, 72)
        Me.GroupBox7.TabIndex = 0
        Me.GroupBox7.TabStop = False
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.SystemColors.Control
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSalir.Location = New System.Drawing.Point(412, 17)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(113, 44)
        Me.btnSalir.TabIndex = 13
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'btnConsultas
        '
        Me.btnConsultas.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultas.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnConsultas.Location = New System.Drawing.Point(285, 17)
        Me.btnConsultas.Name = "btnConsultas"
        Me.btnConsultas.Size = New System.Drawing.Size(113, 44)
        Me.btnConsultas.TabIndex = 12
        Me.btnConsultas.Text = "Consultas"
        Me.btnConsultas.UseVisualStyleBackColor = False
        '
        'btnImprimir
        '
        Me.btnImprimir.BackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnImprimir.Location = New System.Drawing.Point(158, 17)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(113, 44)
        Me.btnImprimir.TabIndex = 11
        Me.btnImprimir.Text = "Imprimir Listado"
        Me.btnImprimir.UseVisualStyleBackColor = False
        '
        'btnPantalla
        '
        Me.btnPantalla.BackColor = System.Drawing.SystemColors.Control
        Me.btnPantalla.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPantalla.Location = New System.Drawing.Point(31, 17)
        Me.btnPantalla.Name = "btnPantalla"
        Me.btnPantalla.Size = New System.Drawing.Size(113, 44)
        Me.btnPantalla.TabIndex = 10
        Me.btnPantalla.Text = "Mostrar por Pantalla"
        Me.btnPantalla.UseVisualStyleBackColor = False
        '
        'ListadoControlHoras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(588, 294)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListadoControlHoras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtHastaEmpleado As TextBox
    Friend WithEvents txtDesdeEmpleado As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents lblDescCliente As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtCliente As TextBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents btnPantalla As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnConsultas As Button
    Friend WithEvents btnImprimir As Button
    Friend WithEvents txtAño As TextBox
    Friend WithEvents txtMes As TextBox
End Class
