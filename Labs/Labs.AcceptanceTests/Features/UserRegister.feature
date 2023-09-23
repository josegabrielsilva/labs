#language: en-us

Feature: Cadastro de usuário na API Users
	Como um desenvolvedor de API
	Eu quero testar o cadastro de usuário
	Para garantir que os usuários possam se cadastrar com sucesso no sistema.

Background:
	Given que a API User está disponível

Scenario: Cadastro bem sucedido
	When eu envio uma solicitação POST para o endpoint /user com os seguintes dados:
	| Name | Email         | Password |
	| John | john@mail.com | password |
	Then a resposta da API deve conter o código de status 201
	And o usuário deve ser cadastrado com sucesso no sistema

Scenario: Tentativa de cadastro com dados inválidos
	When eu envio uma solicitação POST para o endpoint /user com os dados inválidos:
	| Name | Email         | Password |
	|      | john@mail.com | password |
	Then a resposta da API deve conter o cógido de status 400
	And a resposta da API deve conter uma mensagem de erro

Scenario: Tentativa de cadastro com um e-mail já existente
	When eu envio uma solicitação POST para o endpoint /user com os seguintes dados:
	| Name | Email         | Password |
	| John | john@mail.com | password |
	Then a resposta da API deve conter o codigo de status 400
	And a resposta da API deve conter uma mensagem indicando que o e-mail já está cadastrado
