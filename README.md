# TradeExec

**TradeExec** is a lightweight Windows desktop application for streamlined algorithmic trade execution. It serves as a bridge between **TradingView alerts** and **NinjaTrader execution**, built with a clean, modern interface and practical utility tools.

Revamped from the original V1-R project, TradeExec offers better UI, easier account control, integrated logging, and fast access to server metrics—all without unnecessary complexity.

TradeExec leverages NinjaTrader's Add-on Library to ensure faster executions and more dynamic information logging.

---

## 🧭 Overview

* 🖥️ **Modern C#/WPF UI**
* 🔁 **Direct TradingView → NinjaTrader relay**
* 🌐 **Ngrok static URL integration**
* 📊 **Execution + server metrics dashboard**
* 📁 **AppData config & local user profiles**
* 🛠️ **Built-in issue logging (Support tab)**

> **No charting or trading visuals** – TradeExec is focused entirely on execution control and utility. [For now]

---

## 📦 Download

Visit the [**Releases**](https://github.com/0-src/TradeExec/releases) tab to download the latest packaged version.
No manual build or Visual Studio setup required.

---

## 🚀 Features

| Feature                  | Description                                                          |
| ------------------------ | -----------------------------------------------------------------    |
| **Execution Relay**      | Relays TradingView webhook alerts to NinjaTrader via a custom `Addon`|
| **Static Webhook Setup** | Quick setup flow for static `ngrok` URLs                             |
| **Execution Log Panel**  | Built-in log viewer for real-time execution tracking                 |
| **Server Metrics**       | Internal status and metric display in the Dashboard                  |
| **Account Control**      | Simple profile switching stored safely in `AppData`                  |
| **Support Tab**          | Submit logs and report issues directly from the app                  |

---

## 🛠️ Requirements

* Windows 10+
* [.NET Desktop Runtime 8.0+](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* [ngrok (static URL plan)](https://ngrok.com/)

---

## 🗂️ Configuration

All configuration files and local profiles are stored in:

```plaintext
C:\Users\<YourName>\AppData\Roaming\TradeExec\
```

This includes your static webhook endpoint, account metadata, and session logs.

---

## 🧪 Roadmap

* [x] Execution relay system
* [x] Local profile management
* [x] Dashboard with server metrics
* [x] Internal execution log viewer
* [x] Support tab for issue submission
* [ ] Alert receipt notification system
* [ ] Custom log filtering and export tools

---

## 🎨 UI Preview

Take a look at the full interface redesign in Figma:
👉 [**View Figma Design**](https://www.figma.com/design/AWUcWXyTDojSrclSWSzIkO/Dashboard?node-id=0-1&t=esEtqlPoeJhMZA90-1)

---

## 📄 License

GPL-3.0 license
