CREATE DATABASE ProjetoSTI3
GO
CREATE TABLE Categoria
(
  Id INT PRIMARY KEY IDENTITY(1,1),
  Categoria VARCHAR(200),
  Desconto DECIMAL(18,2)
)
GO

INSERT INTO Categoria(Categoria, Desconto)
VALUES('REGULAR', 5.00)
INSERT INTO Categoria(Categoria, Desconto)
VALUES('PREMIUM', 10.00)
INSERT INTO Categoria(Categoria, Desconto)
VALUES('VIP', 15.00)
GO

CREATE TABLE Cliente

(
  Id UNIQUEIDENTIFIER PRIMARY KEY,
  Nome VARCHAR(200),
  CPF VARCHAR(20),
  Categoria VARCHAR(200)
)
GO

INSERT INTO Cliente (Id, Nome, CPF, Categoria) VALUES ('104B4852-228E-4DBA-AE12-345CDE66EA25', 'João', '111.222.333-44','REGULAR')
INSERT INTO Cliente (Id, Nome, CPF, Categoria) VALUES (NEWID(),'Maria', '222.333.444-55', 'PREMIUM')
INSERT INTO Cliente (Id, Nome, CPF, Categoria) VALUES (NEWID(),'Pedro', '666.777.888-99', 'VIP')
GO



CREATE TABLE Produto
( 
   Id INT PRIMARY KEY,
   Nome VARCHAR(200)
)
GO

INSERT INTO Produto(Id, Nome)
VALUES(87, 'Camisa Polo Preta M')
INSERT INTO Produto(Id, Nome)
VALUES(25, 'Calça Jeans 42')
INSERT INTO Produto(Id, Nome)
VALUES(1, 'Calça Jeans 44')
GO


CREATE TABLE Pedido
(
  Id UNIQUEIDENTIFIER PRIMARY KEY,
  ClienteId UNIQUEIDENTIFIER,
  DataVenda DATETIME,
  Subtotal DECIMAL(18,2),
  Descontos DECIMAL(18,2),
  ValorTotal DECIMAL(18,2),
  [Status] VARCHAR(50)
  FOREIGN KEY (ClienteId) REFERENCES Cliente(Id)
)
GO

CREATE TABLE PedidoItem
(
  Id INT PRIMARY KEY IDENTITY(1,1),
  PedidoId UNIQUEIDENTIFIER,
  ProdutoId INT,
  Quantidade DECIMAL(18,1),
  PrecoUnitario DECIMAL(18,2),
  FOREIGN KEY (ProdutoId) REFERENCES Produto(Id)
)



