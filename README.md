# ⚙️ Command Pattern Example (C#)
<p align="center">
  <a href="https://learn.microsoft.com/en-us/dotnet/csharp/">
    <img src="https://upload.wikimedia.org/wikipedia/commons/4/4f/Csharp_Logo.png" alt="C# Logo" width="150"/>
  </a>
</p>

---

This project demonstrates the **Command Design Pattern** using a simple **Remote Control and Light** example in C#.

The Command pattern turns a **request into an object**, allowing you to **parameterize**, **queue**, and **undo** operations — all without tightly coupling the sender (Invoker) and the receiver (the actual performer of the action).

---

## 🧩 How It Works

1. **ICommand** – Defines the common interface for all commands, including `Execute()` and `Undo()`.  
2. **Light** – The **Receiver**, which knows how to perform the actual actions (turning on or off).  
3. **TurnOnLightCommand** / **TurnOffLightCommand** – The **ConcreteCommand** classes that call specific methods on the receiver.  
4. **RemoteControl** – The **Invoker** that triggers the commands and can also undo them.  
5. **Program (Client)** – The entry point that sets everything up and demonstrates executing and undoing commands.

---

## 🚀 Key Takeaways

- Decouples **Invoker** (the requester) from the **Receiver** (the executor).  
- Makes it easy to **add new commands** without changing existing code.  
- Supports **undo/redo functionality** with simple history tracking.  
- Great for scenarios like **remote controls, GUIs, macros, and transactional systems**.

---
