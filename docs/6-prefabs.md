# Prefabs do Jogo

## PlayerPrefab

- **Nome:** PlayerPrefab
- **Descrição:** Jogador controlando o aluno de Ciência da Computação.
- **Quando são utilizados:** No início e durante toda a partida.
- **Componentes:**
  - **Sprites:** Personagem do aluno em pixel art.
  - **Colisores:** Detecta colisão com inimigos, perks e projéteis.
  - **Fontes de áudio:** Passos, ataque, dano, coleta de perk.
  - **Scripts:** PlayerController.cs
    - Movimentação do jogador.
    - Ataques e uso de armas.
    - Coleta de perks e upgrades.
    - Controle de vida e dano.

---

## EnemyPrefab

- **Nome:** EnemyPrefab
- **Descrição:** Inimigos representando as disciplinas do curso.
- **Quando são utilizados:** Durante as ondas de ataque.
- **Componentes:**
  - **Sprites:** Inimigos pixelados.
  - **Colisores:** Detecta contato com jogador e armas.
  - **Fontes de áudio:** Ataque e destruição do inimigo.
  - **Scripts:** EnemyController.cs
    - Movimento em direção ao jogador.
    - Ataques ao colidir.
    - Recebe dano e morre.
    - Chance de soltar perks.

---

## PerkPrefab

- **Nome:** PerkPrefab
- **Descrição:** Power-ups para melhorar o jogador.
- **Quando são utilizados:** Soltos pelo mapa ou dropados por inimigos.
- **Componentes:**
  - **Sprites:** Ainda em discussão
  - **Colisores:** Detecta coleta pelo jogador.
  - **Fontes de áudio:** Som de coleta.
  - **Scripts:** PerkController.cs
    - Define o tipo de perk.
    - Aplica o efeito ao jogador.
    - Desaparece após ser coletado.

---

## WeaponPrefab

- **Nome:** WeaponPrefab
- **Descrição:** Armas usadas pelo jogador.
- **Quando são utilizados:** Ao atirar ou pegar uma nova arma.
- **Componentes:**
  - **Sprites:** Projétil ou arma.
  - **Colisores:** Detecta impacto com inimigos.
  - **Fontes de áudio:** Disparo e impacto.
  - **Scripts:** WeaponController.cs
    - Movimento do projétil.
    - Aplica dano nos inimigos.
    - Some ao atingir inimigo ou sair da tela.

# Protótipos

![image](https://github.com/user-attachments/assets/1c0a5c13-5543-4068-af33-2e9c05d2114b)
![image](https://github.com/user-attachments/assets/b0c2d0d6-04d6-4147-bde8-281e5f6801d2)
![image](https://github.com/user-attachments/assets/b1bffa03-5720-43c2-b2f4-648f22b83862)
![image](https://github.com/user-attachments/assets/9d97ccad-fdf9-407f-83fa-744bac36eba8)



