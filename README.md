# 🎮 Dodge The Red Balls

![Unity](https://img.shields.io/badge/Unity-2D%20Engine-black?style=for-the-badge&logo=unity)
![C#](https://img.shields.io/badge/Language-C%23-blue?style=for-the-badge&logo=c-sharp)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

A fast-paced, interactive 2D arcade survival game built in Unity. Navigate the arena, avoid hazardous red obstacles, collect power-up items, and set new high scores!

---

## 📸 Overview & Gameplay

In **Dodge The Red Balls**, players control an entity in a high-stakes arena where survival depends on quick reflexes and state control.

* 🔴 **Red Balls (Hazards)**: Collision triggers an instant Game Over state.
* 🔵 **Blue Balls (Power-Ups)**: Collectible objects that boost your score multiplier and enhance player survival capabilities.
* 🏆 **High Score Tracking**: Automatically saves your highest score across sessions using Unity's `PlayerPrefs` data persistence API.

---

## ⚡ Core Features

* **Complete UI Architecture**:
  * Persistent top-level HUD with score and high-score displays using **TextMeshPro**.
  * On-screen toggleable Pause Menu (`PauseMenuPanel`) with fully wired **Resume**, **Restart**, and **Quit** operations.
* **Custom Audio & Visual Presentation**:
  * Immersive background music loop powered by an optimized `AudioSource` component.
  * Support for static canvas backgrounds and dynamic looping video backgrounds rendered via `VideoPlayer` and `RenderTexture`.
  * Multi-layered Z-depth sorting to ensure gameplay elements remain crisp and visible over background media.
* **Clean Code Structure**:
  * Event-driven game loop managed via a centralized `GameManager` script.
  * Strict separation between gameplay physics and UI overlay systems.

---

## 🎮 Controls

| Action | Input |
| :--- | :--- |
| **Move Player** | `W` `A` `S` `D` / Arrow Keys |
| **Pause / Resume** | `Esc` / On-Screen Pause Button |

---

## 🛠️ Tech Stack

* **Engine**: Unity 2022+ (2D Pipeline)
* **Language**: C#
* **UI Component**: TextMeshPro & Unity Canvas
* **Version Control**: Git & GitHub

---

## 🚀 Getting Started

### Prerequisites
Make sure you have **Unity Hub** and a compatible Unity Editor version installed.

### Installation
1. **Clone the Repository**:
   ```bash
   git clone [https://github.com/yashintocodes/DodgeTheRedBalls.git](https://github.com/yashintocodes/DodgeTheRedBalls.git)
