# 🗕️ Administrador de Tarefas API

Sistema para administração de tarefas utilizando .NET Core e PostgreSQL.

---

## 💪 Como executar o projeto localmente

### ✅ Requisitos

Antes de começar, certifique-se de ter instalado:

- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Git](https://git-scm.com/)
- [PostgreSQL](https://www.postgresql.org/download/)
- (Opcional) [pgAdmin](https://www.pgadmin.org/download/) para gerenciar o banco de dados graficamente

---

### 📦 Clonando o projeto

```bash
git clone https://github.com/italofernandorodrigues55/AdministradorTarefas.Api.git
```

---

### ⚙️ Configurando o banco de dados

O projeto utiliza PostgreSQL como banco de dados.

Você pode:

#### ✅ Criar manualmente via pgAdmin:

1. Acesse `Servers > PostgreSQL > Databases`.
2. Clique com o botão direito > `Create > Database`.
3. Dê o nome: `DB_ADMINISTRADOR_TAREFAS`.

#### 💻 Ou via terminal/psql:

```sql
CREATE DATABASE DB_ADMINISTRADOR_TAREFAS;
```

> Pode criar com outro nome, mas lembre-se de ajustar a *Connection String*.

---

### 🛠️ Connection String

Edite o `appsettings.json` com as informações do seu ambiente:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=DB_ADMINISTRADOR_TAREFAS;Username=postgres;Password=admin@123"
}
```

---

### 🧱 Aplicando a migration

Para criar as tabelas no banco:

```bash
dotnet ef database update
```

Se você ainda **não tiver o EF CLI instalado**, rode:

```bash
dotnet tool install --global dotnet-ef
```

---

### 🚀 Executando a API

```bash
cd AdministradorTarefas.API
dotnet restore
dotnet run
```

Acesse:

```
https://localhost:7053/swagger
```

> Verifique se a porta está correta no seu `launchSettings.json`.

---

## 🧹 Estrutura do Projeto

```
AdministradorTarefas.API             --> Camada de apresentação (Controllers, Swagger, Middlewares)
AdministradorTarefas.Application     --> Camada de aplicação (DTOs, Interfaces, Services, Validations)
AdministradorTarefas.Domain          --> Camada de domínio (Entidades)
AdministradorTarefas.Infra.Data      --> Camada de acesso a dados (Repositories, Migrations e DbContext)
AdministradorTarefas.Infra.IoC       --> Injeção de dependência
AdministradorTarefas.Util            --> Enums, extensões, helpers
```

---

## 📦 Padrão de Resposta da API

```json
{
  "success": true,
  "message": "Tarefas listadas com sucesso",
  "data": {
    // objeto retornado
  }
}
```

---

## 📌 Endpoints principais

| Método | Rota                          | Descrição                 |
| ------ | ----------------------------- | ------------------------- |
| POST   | `/api/Tarefa`                 | Criar uma nova tarefa     |
| GET    | `/api/Tarefa/status/{status}` | Listar tarefas por status |
| GET    | `/api/Tarefa/{id}`            | Buscar tarefa por ID      |
| PUT    | `/api/Tarefa`                 | Atualizar tarefa          |
| DELETE | `/api/Tarefa/{id}`            | Excluir tarefa            |

> Todos os endpoints estão disponíveis em `/swagger`.
