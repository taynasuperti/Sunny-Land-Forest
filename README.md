# Sunny Land Forest – Jogo 2D em Pixel Art
**Unity 6 · C# · Game Development**

O Sunny Land Forest é um jogo 2D em pixel art desenvolvido na Unity 6, criado com o objetivo de estudar e consolidar os fundamentos do desenvolvimento de jogos utilizando a engine.
O projeto foi construído do zero, passando por todas as etapas essenciais de criação, organização e funcionamento de um jogo 2D, desde a importação e manipulação de assets até a implementação da lógica e mecânicas em C#.

O foco principal do projeto foi compreender o funcionamento da Unity, sua estrutura baseada em componentes, organização de cenas, sistema de animações, colisões, física e interação do jogador com o ambiente.

---

## Funcionalidades

### Mecânicas do Jogador
- Movimentação lateral
- Pulo e queda
- Interação com o ambiente
- Sistema de animações sincronizado com ações do personagem

### Sistema de Inimigos
- Inimigos com animações próprias: Bee e Slug
- Colisões e detecção de dano
- Sistema de morte do inimigo

### Cenários e Ambiente
- Criação de cenários em pixel art
- Uso de Tilemaps
- Organização por camadas (Layers)
- Props e elementos decorativos
- Sistema de colisores para cenário e objetos

### Interface e Feedback Visual
- HUD do jogador
- Ícones e elementos gráficos
- Botões de interface
- Props e elementos decorativos
- Transições entre cenas
  
---

## Tecnologias Utilizadas

### Engine
- **Unity 6**

### Linguagem
- **C#**

### Recursos da Unity
- **Sistema de Animações**
- **Tilemap**
- **Physics 2D**
- **Input System**
- **Scenes Management**
- **Prefabs**
- **TextMesh Pro**

---

## Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- Unity Hub
- Unity 6
- Sistema operacional Windows, Linux ou macOS

---

## Instalação e Configuração

#### 1. Clone o Repositório

```bash
git clone <url-do-repositorio>
```
#### 2. Abra o Unity Hub
#### 3. Clique em Open Project
#### 4. Selecione a pasta do projeto clonado
#### 5. Aguarde a Unity importar os arquivos e gerar o cache
#### 6. Abra a cena principal e clique em Play

---

## Estrutura do Projeto


```
Assets/
│
├── Projeto/
│   ├── Animations/ - Animações do jogador, inimigos e objetos
|   |
│   ├── Audios/ - Efeitos sonoros
|   |
│   ├── Fonts/ - Fontes utilizadas no jogo
|   |
│   ├── Materials/ - Materiais do projeto
|   |
│   ├── Prefabs/ - Prefabs reutilizáveis
|   |
│   ├── Scenes/
|   |   ├── Inicio – Cena de abertura do jogo
|   |   └── Nível_01 – Cena principal do jogo
|   |
│   ├── Scripts/
|   |   ├── CameraController.cs – Controle da câmera seguindo o jogador
|   |   ├── ControllerFade.cs – Transições visuais entre cenas
|   |   ├── ControllerGame.cs – Controle geral do fluxo do jogo
|   |   ├── ControllerPlataforma.cs – Lógica de plataformas e interações
|   |   ├── ControllerScenes.cs – Gerenciamento de cenas
|   |   ├── PlayerController.cs – Movimentação e ações do jogador
|   |   ├── IASlug.cs – Lógica de comportamento do inimigo Slug
|   |   └── PlayerInputActions.cs – Configuração do sistema de inputs
|   |
│   ├── Sprites/ - Sprites em pixel art
│   │   ├── Enemies/ 
│   │   │   ├── bee
│   │   │   ├── slug
│   │   │   ├── piranha-plant
│   │   │   └── piranha-plant-attack
│   │   ├── Environment/
│   │   │   ├── Layers
│   │   │   ├── Materials
│   │   │   └── Props
│   │   ├── Misc/
│   │   │   ├── carrot
│   │   │   ├── chest
│   │   │   ├── enemy-death
│   │   │   ├── hud
│   │   │   └── star
│   │   └── Player/
│   │       ├── player-idle
│   │       ├── player-jump
│   │       ├── player-fall
│   │       ├── player-climb
│   │       ├── player-duck
│   │       ├── player-hurt
│   │       └── player-skip
│   │
│   ├── UI/
│   │   └── Buttons
│   │
│   ├── Tilemaps/
│   └── Resources/
│
├── TextMesh Pro/
|   
├── Packages/
|   
├── ProjectSettings/
|   
└── README.md – Este arquivo
```
---

## Objetivo do Projeto
Este projeto tem finalidade educacional, sendo utilizado para:
- Compreender o funcionamento da Unity 6
- Aprender a estruturar projetos de jogos 2D
- Aplicar lógica de programação em C#
- Trabalhar com animações, colisões e física
- Organizar assets e scripts de forma profissional
  
---

## Metodologia e Arquitetura

Desenvolvido utilizando:

- Organização modular de assets
- Separação clara entre lógica, visual e cenários
- Uso de Prefabs para reutilização
- Estrutura padrão da Unity
- Scripts com responsabilidades bem definidas
