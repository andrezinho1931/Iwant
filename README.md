Este projeto é uma aplicação web desenvolvida com ASP.NET Core MVC e .NET 8.0, focada em um sistema de gerenciamento de senhas ou autenticação. A aplicação demonstra o uso de tecnologias Microsoft para construir soluções web escaláveis e seguras.

Tecnologias Utilizadas

•
Backend: C#, ASP.NET Core MVC, .NET 8.0

•
Banco de Dados: SQL Server (indicado pelo Microsoft.EntityFrameworkCore.SqlServer)

•
Frontend: HTML, CSS, JavaScript (com Bootstrap, jQuery, SignalR)

•
Autenticação/Autorização: ASP.NET Core Identity

•
Comunicação em Tempo Real: SignalR

•
Gerenciamento de Dependências: NuGet

•
Controle de Versão: Git

Funcionalidades Principais

•
Sistema de Autenticação: Utiliza ASP.NET Core Identity para gerenciamento de usuários, registro, login e controle de acesso.

•
Gerenciamento de Senhas: Implantação de BCrypt.Net-Next para hashing seguro de senhas, garantindo a proteção dos dados sensíveis dos usuários.

•
Comunicação em Tempo Real: Integração com SignalR para funcionalidades interativas, como chat ou notificações em tempo real.

•
Desenvolvimento Web Moderno: Utilização de Bootstrap para um design responsivo e jQuery para manipulação do DOM e interatividade.

•
Acesso a Dados: Entity Framework Core para interação com o banco de dados SQL Server, seguindo o padrão Code-First ou Database-First.

Estrutura do Projeto

O projeto segue a arquitetura MVC (Model-View-Controller) típica de aplicações ASP.NET Core, com a organização de arquivos e pastas que reflete essa abordagem.

Plain Text


projetofinal/
├── projeto final/
│   ├── Controllers/
│   ├── Data/
│   ├── Models/
│   ├── Views/
│   ├── wwwroot/
│   │   ├── css/
│   │   ├── imagens/
│   │   ├── js/
│   │   ├── lib/
│   │   └── Pasta do signalR/
│   ├── appsettings.json
│   ├── CliSenhas2024.csproj
│   ├── Program.cs
│   └── ... (outros arquivos de configuração e build)
└── README.md


