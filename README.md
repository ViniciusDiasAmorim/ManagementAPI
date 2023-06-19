# ManagementAPI


## O Gerenciador é um sistema de gerenciamento de usuários e pedidos. Ele permite criar, visualizar, atualizar e excluir usuários, bem como realizar pedidos, adicionar produtos aos pedidos e alterar o status dos pedidos.

## Tecnologias utilizadas
- ASP.NET Core
- Entity Framework Core
- MySQL
## Funcionalidades
- Listar todos os usuários
- Obter um usuário por ID
- Pesquisar usuários por nome
- Criar um novo usuário
- Atualizar informações de um usuário existente
- Excluir um usuário
- Listar pedidos de um usuário por ID
- Criar um novo pedido associado a um usuário
- Adicionar produtos a um pedido
- Alterar o status de entrega de um pedido
## Configuração
- Certifique-se de ter o .NET Core SDK instalado em sua máquina.
- Clone este repositório para o seu ambiente local.
- Abra o arquivo appsettings.json e atualize a string de conexão do banco de dados, se necessário.
- Abra o terminal na raiz do projeto e execute o comando dotnet ef database update para criar as tabelas do banco de dados.
- Execute o comando dotnet run para iniciar o aplicativo.
- O aplicativo estará disponível em http://localhost:5000.
## API Endpoints
- GET /api/user - Obtém todos os usuários.
- GET /api/user/{id} - Obtém um usuário por ID.
- GET /api/user/search/{queryString} - Pesquisa usuários por nome.
- POST /api/user - Cria um novo usuário.
- PUT /api/user/{id} - Atualiza as informações de um usuário existente.
- DELETE /api/user/{id} - Exclui um usuário por ID.
- GET /api/order/{id} - Obtém os pedidos de um usuário por ID.
- POST /api/order - Cria um novo pedido associado a um usuário.
- PUT /api/order - Altera o status de entrega de um pedido.
