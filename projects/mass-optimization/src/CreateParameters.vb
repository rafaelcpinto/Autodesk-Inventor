Try
	p = Parameter("X")
Catch
	ThisDoc.Document.ComponentDefinition.Parameters.UserParameters.AddByValue("X", 10, UnitsTypeEnum.kDefaultDisplayLengthUnits)
	
End Try

Try
	p = Parameter("MASSA_CALCULADA")
Catch
	ThisDoc.Document.ComponentDefinition.Parameters.UserParameters.AddByValue("MASSA_CALCULADA", 1 * 1e-3, UnitsTypeEnum.kKilogramMassUnits)
	
End Try

Try
	p = Parameter("X1")
Catch
	ThisDoc.Document.ComponentDefinition.Parameters.UserParameters.AddByValue("X1", 10, UnitsTypeEnum.kDefaultDisplayLengthUnits)	
End Try

Try
	p = Parameter("X2")
Catch
	ThisDoc.Document.ComponentDefinition.Parameters.UserParameters.AddByValue("X2", 10, UnitsTypeEnum.kDefaultDisplayLengthUnits)	
End Try

Try
	p = Parameter("ITERACOES")
Catch
	ThisDoc.Document.ComponentDefinition.Parameters.UserParameters.AddByValue("ITERACOES", 0, UnitsTypeEnum.kUnitlessUnits)
End Try


Try
	p = Parameter("MASSA")
Catch
	ThisDoc.Document.ComponentDefinition.Parameters.UserParameters.AddByValue("MASSA", 10, UnitsTypeEnum.kKilogramMassUnits)
	
End Try

Try
	p = Parameter("ERRO")
Catch
	ThisDoc.Document.ComponentDefinition.Parameters.UserParameters.AddByValue("ERRO", 10, UnitsTypeEnum.kKilogramMassUnits)
	
End Try

Try
	p = Parameter("COTA")
Catch
	ThisDoc.Document.ComponentDefinition.Parameters.UserParameters.AddByValue("COTA","X",UnitsTypeEnum.kTextUnits)
	
End Try


Try
	p = Parameter("VALORES_OTIMOS")
Catch
	ThisDoc.Document.ComponentDefinition.Parameters.UserParameters.AddByValue("VALORES_OTIMOS", 10, UnitsTypeEnum.kDefaultDisplayLengthUnits)
	
End Try
