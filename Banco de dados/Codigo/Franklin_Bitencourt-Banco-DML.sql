BULK INSERT EQUIPAMENTOS 
FROM 'CaminhoParaOProjeto\Treinamento Lan House\Banco de dados\CSV\equipamentos.csv' 
WITH (FIELDTERMINATOR = ',', ROWTERMINATOR = ';', firstrow = 1, codepage = 'acp')

BULK INSERT 
TIPOS_DEFEITO 
FROM 'CaminhoParaOProjeto\Desktop\Treinamento Lan House\Banco de dados\CSV\tipos_defeito.csv' 
WITH (FIELDTERMINATOR = ',', ROWTERMINATOR = ';', firstrow = 1, codepage = 'acp')

BULK INSERT 
REGISTROS_DEFEITOS 
FROM 'CaminhoParaOProjeto\Desktop\Treinamento Lan House\Banco de dados\CSV\registros_defeitos.csv' 
WITH (FIELDTERMINATOR = ',', ROWTERMINATOR = ';', firstrow = 1, codepage = 'acp')

INSERT INTO USUARIOS VALUES('admin@email.com', '123456')
