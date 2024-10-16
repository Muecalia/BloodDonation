# BloodDonation
Desenvolver um sistema de gerenciamento de um banco de dados de doação de sangue.

1. Cadastro de doadores
	1.1. Validar dados.
	1.2. No cadastro de endereço integrar API externa para consulta CEP. (https://viacep.com.br)

2. Controle de estoque de sangue
	2.1. Avisar quando o estoque atingir a quantidade mínima definida.

3. Registro de doações
	3.1. Atualizar o estoque de sangue sempre que registrar uma doação.

4. Consulta de doadores
	4.1. Consultar o histórico de doações de um doador.

5. Relatórios
	5.1. Gerar um relatório sobre a quantidade total de sangue por tipo disponível. 
	5.2. Relatório de doações nos últimos 30 dias com informações dos doadores. 

# Language
1. C#

# Framework
1. .NET CORE 8.0

# Data Base
1. SQL Server

# Arquitetura
1. Arquitetura Limpa (Clean Architecture)

# Padrões
1. CQRS
2. Repository

# Container
1. Docker

# Testes
1. Unitário

# Regras de negócio
1. Não deixar cadastrar um doador com o mesmo e-mail.
2. Menor de idade não pode doar, mas pode ter cadastro.
3. Pesar no mínimo 50KG.
4. Mulheres só podem doar de 90 em 90 dias.(PLUS)
5. Homens só podem doar de 60 em 60 dias. (PLUS)
6. Quantidade de mililitros de sangue doados deve ser entre 420ml e 470ml (PLUS)

