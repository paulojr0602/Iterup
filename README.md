# Iterup
Este projeto é uma Web API RestFull utilizando ASP.Net CORE e uma arquitetura em camadas baseada em DDD e DI.
Implementa um exemplo de CRUD simples de objeto Pessoa, com uma tabela de relacionamento UF.
Para algumas ações exige a auteticação do usuário pelo seu cpf e senha cadastrados previamente, e ao fazer o login o sistema
retorna a toke Microsoft.AspNetCore.Authentication.JwtBearer a ser utilizado nas ações.
O padrão de arquitetura em camadas e utilizando DI é interessante, pois oferece maior escalabilidade, melhor organização do código, melhor 
práticas para manutenção, menor acoplamento do código e menor chances de Bugs de desenvolvimento. 
Como um entusiasta dos padrões de desenvolvimento e do SOLID, sempre busco a melhor solução para cada caso. ;-)

Autor: Paulo Roberto de Almeida Jr.
Email: paulojr0602@gmail.com
