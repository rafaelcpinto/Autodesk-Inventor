Dim oPartDoc As PartDocument
oPartDoc = ThisApplication.ActiveDocument
Dim oPartComp As ComponentDefinition
oPartComp = oPartDoc.ComponentDefinition

oPartComp.Parameters.Item("COTA").Value = Parameter("VALORES_OTIMOS")

Parameter("X1") = Parameter("VALORES_OTIMOS") * 0.8
Parameter("X2")=Parameter("VALORES_OTIMOS")*1.2
