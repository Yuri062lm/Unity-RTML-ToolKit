# Contributing to RTML Tool Kit

We welcome contributions from the community to improve and expand the RTML Tool Kit. Whether you're fixing a bug, adding a feature, improving documentation, or helping with testing, your input is appreciated.

This document outlines the procedures and conventions to follow when contributing to the project.

---

## 🔧 How to Contribute

### 1. Fork and Clone

First, fork the repository to your GitHub account and clone it to your local development environment:

```bash
git clone https://github.com/yourusername/RTMLToolKit.git
cd RTMLToolKit
```

### 2. Create a Feature Branch

Use descriptive names for your branches:

```bash
git checkout -b feature/improve-osc-logging
```

### 3. Make Changes

Ensure your code:
- Is clean, readable, and consistent with existing style.
- Uses British spelling (e.g., *initialise*, *normalise*).
- Includes summary comments on all public methods and classes.

### 4. Run Tests

Before submitting a pull request, run all available tests:

```bash
# In Unity: Run PlayMode and EditMode tests via Test Runner.
# Or use Unity Test Framework via CLI if configured.
```

Add new tests if you’re introducing significant logic or functionality.

### 5. Submit a Pull Request

Push your branch and open a pull request (PR) from your fork to the `main` branch. Your PR should include:
- A clear title
- A concise summary of changes
- Any open questions or implementation caveats

We may request changes or suggestions before merging.

---

## 📂 Project Structure Overview

```
RTMLToolKit/
├── Core/        # Core ML logic and controller (RTMLCore.cs, LinearRegression.cs, etc.)
├── IO/          # OSC communication modules
├── Util/        # Maths helpers, logging, normalisation
├── Editor/      # Unity Editor extensions
├── Tests/       # Automated unit and integration tests
├── SavedModels/ # JSON-serialised models (ignored from version control)
```

---

## ✅ Code of Conduct

All contributors are expected to adhere to respectful and inclusive behaviour. We do not tolerate harassment or exclusion of any kind.

---

## 📋 TODOs and Future Work

- Visualise model I/O connections in the Unity Inspector
- Add support for Recurrent Neural Networks (RNNs)
- Enable live OSC stream inspection
- Export model graphs to external viewers
- Improve Android compatibility for DTW gesture tracking
- Expand test coverage to include edge-case scenarios
- Integrate dataset import from CSV
- Document OSC command schema via web-based interface

Feel free to tackle any of these or propose new directions.

---

## ℹ️ Inspiration and Attribution

RTML Tool Kit draws conceptual inspiration from [Wekinator](http://www.wekinator.org), a GUI-based interactive machine learning system. RTML is built from scratch in C# for native Unity integration, especially targeting **Mixed Reality** workflows and **Android** deployment where Wekinator cannot operate.

---

## 🧠 Academic Usage

If you're using RTML Tool Kit in academic research, feel free to cite or acknowledge the repository. For licensing details, refer to `LICENSE`.

---

Thank you for contributing to RTML Tool Kit!
