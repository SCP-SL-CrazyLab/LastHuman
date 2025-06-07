# Last Human Notifier Plugin for SCP: Secret Laboratory

> A simple Exiled plugin that broadcasts a message to all players when only one human player remains alive.

---

## 📌 Overview

This plugin detects when there is only **one living human player** left on the server and sends a **broadcast message** to everyone, notifying them that this player is the last human still alive.

- Sends a special message to the last human.
- Sends a different message to other players.
- Works with **Exiled v3+** framework.

---

## ✅ Features

- Automatically checks whenever a player dies or spawns.
- Sends broadcast messages using `ShowHint()` (screen message).
- Customizable message duration.
- Supports color formatting using HTML tags.

---

## 🧩 Requirements

- [SCP: Secret Laboratory Server](https://store.steampowered.com/app/1065920/SCP_Secret_Laboratory/) 
- [Exiled Framework v9.6.0](https://github.com/ExSLMod-Team/EXILED) 
- .NET Framework 4.8 compatible compiler (for building from source)

---

## 🛠️ Installation

### From DLL (Pre-built):

1. Download the latest `.dll` file from releases.
2. Place it in your server's `Plugins` folder.
3. Start/restart your server.
