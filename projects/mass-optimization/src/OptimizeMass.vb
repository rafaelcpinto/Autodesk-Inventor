Sub Main()
	Dim oPartDoc As PartDocument
	oPartDoc = ThisApplication.ActiveDocument
	Dim oPartComp As ComponentDefinition
	oPartComp = oPartDoc.ComponentDefinition
	Dim calc As New calculos
	Dim XL As Double
	Dim XU As Double 
	Dim valorOtimo As Double 
	Dim varOtmz As String
	XL = oPartComp.Parameters.Item("X1").Value
	XU = oPartComp.Parameters.Item("X2").Value
	valorOtimo=oPartComp.Parameters.Item("MASSA").Value
	varOtmz=oPartComp.Parameters.Item("COTA").Value
	calc.inicializar(oPartDoc)
	oPartComp.Parameters.Item("VALORES_OTIMOS").Value=calc.Otimiza(XL,XU,varOtmz,valorOtimo)
	
	oPartDoc.Update()
	oPartComp.Parameters.Item("MASSA_CALCULADA").Value = oPartComp.MassProperties.Mass
	oPartComp.Parameters.Item("ERRO").Value = Math.Abs((valorOtimo - oPartComp.MassProperties.Mass))
	'oPartComp.Parameters.Item("VALORES_OTIMOS").Value
End Sub

Public Class calculos

	Dim oPartDoc As PartDocument
	Dim oPartComp As ComponentDefinition
	Dim varOtmz As String
	
	Sub inicializar(oPartDoc As PartDocument)
		Me.oPartDoc=oPartDoc
		Me.oPartComp = oPartDoc.ComponentDefinition
	End Sub


	Function Otimiza(XL As Double, XU As Double,varOtmz As String,valorOtimo As Double) As Double
		Dim R As Double
		Dim d As Double
		Dim iteracoes As Double
		Dim x1 As Double
		Dim x2 As Double
		Dim f1 As Double
		Dim f2 As Double
		Dim xopt As Double
		Dim custo As Double
		Dim fx As Double
		Dim ea As Double
		
		Me.varOtmz=varOtmz
		iteracoes = 1
		R=(Math.Sqrt(5)-1)/2
		d=R*(XU-XL)
		x1=XL+d
		x2=XU-d
		f1=Math.Abs(Me.CALCMASS(x1)-valorOtimo)
		f2=Math.Abs(Me.CALCMASS(x2)-valorOtimo)

		If f1<f2 Then
			xopt=x1
			fx=f1
		Else
			xopt=x2
			fx=f2
		End If
		ea=(1-R)*Math.Abs(XU-XL)/xopt

		Do
			d=R*d
			If f1<f2  Then
				XL=x2
				x2=x1
				x1=XL+d
				f2=f1
				f1=Math.Abs(Me.CALCMASS(x1)-valorOtimo)
			Else
				XU=x1
				x1=x2
				x2=XU-d
				f1=f2
				f2=Math.Abs(Me.CALCMASS(x2)-valorOtimo)
			End If
			iteracoes=iteracoes+1

			If f1<f2 Then
				xopt = x1
				fx=f1
			Else
			xopt=x2
			fx=f2
			End If
			ea=(1-R)*Math.Abs(XU-XL)/xopt
			If iteracoes>50 Or ea<2e-8 Then
				Exit Do
			End If
		Loop
		Return xopt
	End Function


	Function CALCMASS(A As Double) As Double
		Dim mass As Double
		Try
			oPartComp.Parameters.Item(Me.varOtmz).Value = A
			oPartDoc.Update()
		Catch
		End Try
		mass = oPartComp.MassProperties.Mass
		oPartComp.Parameters.Item("MASSA_CALCULADA").Value = mass
		Return Math.Abs(mass)
	End Function
	
	
	Function CALCMASS2(A As Double) As Double
		Dim mass As Double
		Try
			oPartComp.Parameters.Item(Me.varOtmz).Value = A
			oPartDoc.Update()
		Catch
		End Try
		mass = oPartComp.MassProperties.Mass
		oPartComp.Parameters.Item("MASSA_CALCULADA").Value = mass
		Return Math.Abs(mass)
	End Function
	
End Class

