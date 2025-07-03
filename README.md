# 🔗 Projeto Encurtador de URL

Este projeto é um **encurtador de URLs** minimalista, desenvolvido com **ASP.NET Core (Minimal API)** no back-end e **React com TypeScript** no front-end. Ele permite transformar uma URL longa em um link curto, reutilizável e redirecionável.

## 🚀 Tecnologias Utilizadas

### 🔧 Back-end
- [ASP.NET Core](https://learn.microsoft.com/aspnet/core/) com Minimal API
- Armazenamento em memória (com suporte a MongoDB em versões futuras)
- Redirecionamento automático via código curto

### 🌐 Front-end
- [React](https://reactjs.org/) com [TypeScript](https://www.typescriptlang.org/)
- [Axios](https://axios-http.com/) para chamadas HTTP
- Formulário simples e funcional para envio e exibição da URL encurtada

---

## 🧩 Detalhes Técnicos

### ✅ Minimal API (ASP.NET Core)

Este projeto adota a filosofia **Minimal API**, focando em uma arquitetura simples e direta. Os principais benefícios dessa abordagem incluem:

- Redução de arquivos e camadas intermediárias
- Endpoints mais fáceis de entender e modificar
- Ideal para protótipos, estudos e MVPs

A API responde a:

- `POST /api/linkshortner/shorten` — recebe uma URL original e retorna o link encurtado
- `GET /{code}` — redireciona para a URL original com base no código curto

### ✅ Front-end React com Axios

O front-end é composto por um único formulário onde o usuário:

1. Informa a URL original
2. Clica no botão para gerar o link
3. Visualiza o link encurtado (com redirecionamento funcional)

A comunicação com a API é feita via `Axios`, utilizando `POST` com payload JSON e tratamento de resposta em tempo real.

---

## 📷 Capturas de Tela

> (Adicione aqui imagens da interface, se desejar)

---

## 📌 Funcionalidades

- ✅ Envio de URL original
- ✅ Geração de código único (baseado em GUID)
- ✅ Redirecionamento automático
- ✅ Armazenamento em memória (thread-safe)
- 🔜 Integração com MongoDB
- 🔜 Expiração de links e estatísticas de acesso

---

## 🛠️ Como rodar o projeto

### Backend

```bash
cd backend
dotnet run
