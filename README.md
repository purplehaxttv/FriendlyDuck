# 🐤 Friendly Duck – REPO Mod

This mod turns the apex predator duck in **R.E.P.O.** into a wholesome, bouncy companion. No more attacks. No more trauma. Just a duck that hops after you with joy in its eyes and chaos in its heart.

---

## 💾 What It Does

- 🦆 Disables all attack behaviors  
- 🛡️ Makes the duck invulnerable to damage and stuns  
- 🧠 Replaces aggression with cute jumping when grabbed  
- 🔒 Prevents despawn so you always have a feathery friend  

---

## 📦 Installation

### 📁 Manual Install

1. Make sure you have [BepInEx 5.4.21 for REPO](https://thunderstore.io/c/repo/p/BepInEx/BepInExPack/) installed.  
2. Drop the compiled `FriendlyDuck.dll` into:

   ```
   REPO/BepInEx/plugins/FriendlyDuck/
   ```

3. Launch the game. If BepInEx is working, you should see logs and behavior changes immediately.

---

## 🛠️ Build Setup

If you're building this mod yourself:

**🧰 Requirements:**
- .NET Framework 4.8  
- Visual Studio 2022 (Community Edition works fine)  
- HarmonyLib (via NuGet or manual DLL reference)

**Project structure:**
```
/FriendlyDuck.sln
/src/
  └── FriendlyDuckPlugin.cs
  └── DuckPatches.cs
/ThunderstoreBuild/
  └── manifest.json
  └── icon.png
  └── README.md (Thunderstore version)
/bin/ (ignored)
/obj/ (ignored)
```

---

## 👥 Credits

- **purplehaxttv** – Dev and duck sympathizer. [Twitch](https://twitch.tv/purplehaxttv)  
- **AmberTheRambler** – The inspiration behind it all. [Twitch](https://twitch.tv/ambertherambler)  
- **Bibbity12** – Tester, duck wrangler, chaos contributor. [Twitch](https://twitch.tv/bibbity12)  
- **NimbleSquidd** – Emotional support squid. [Twitch](https://twitch.tv/nimblesquidd)

---

## 📜 License

This mod is licensed under a **Custom License**:

- ✅ Free for personal use, modification, and redistribution.  
- ❌ Commercial use is **not allowed**.  
- 📝 Credit to the original author **must be given** in any redistributed or derivative work.  

---

## 🤝 Contributing

Want to make the duck even cuter? Here's how:

1. Fork this repository  
2. Create a new branch (`git checkout -b feature-something`)  
3. Make your changes  
4. Submit a pull request  

We’re open to suggestions, improvements, or even cursed ideas.
