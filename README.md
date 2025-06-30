# Unity - RTML Tool Kit: **A Real-Time Machine Learning Framework for Unity**  


Lightweight, modular, and open-source. Designed for live performance, Mixed Reality, and mobile deployment.

---

## ✨ Overview

RTML Tool Kit is a real-time, OSC-controllable machine learning framework for Unity, inspired by [Wekinator](http://wekinator.org).  
While Wekinator pioneered GUI-based interactive machine learning, its reliance on desktop environments and lack of runtime portability made it unsuitable for mobile and XR pipelines. RTML addresses this gap by offering a Unity-native runtime alternative with Android support and Inspector-based integration.

- 🎛️ **Inspector-driven**: no external GUI or dependencies
- 🧠 **Built-in models**: Linear Regression, K-Nearest Neighbours, DTW placeholder
- 💾 **Runtime model saving/loading**
- 🎯 **Designed for mobile and Mixed Reality workflows**
- 🛰️ **Full OSC I/O** for external tools (TouchDesigner, Max/MSP, etc.)
- 🧪 **Runtime-safe** with Unity Test Framework support

---

## 📁 Project Structure

```
Assets/
└── RTMLToolKit/
    ├── Core/           # Engine: RTMLCore, IModel, model classes
    ├── IO/             # OSCReceiver, OSCSender, optional command parser
    ├── Util/           # Logger, normalisers, math helpers
    ├── Editor/         # Custom Inspector tools
    ├── Runtime/        # Prefabs for scene-based setups (optional)
    ├── SavedModels/    # Serialized models (JSON)
    ├── Tests/          # Unit + runtime verification
    └── ExampleScenes/  # Demo scenes + controller scripts
```

---

## 🚀 Quick Start

1. Import RTML Tool Kit into your Unity project  
2. Create a GameObject and add the `RTMLCore` script  
3. Configure `inputSize`, `outputSize`, and `modelType` in the Inspector  
4. Feed input data manually or via OSC  
5. Use Inspector toggles to Record → Train → Run  
6. Use the buttons “Save Model” and “Load Model” to persist models across sessions

---

## 💡 Supported Models

| Model Type        | Use Case                        | Notes                        |
|-------------------|----------------------------------|------------------------------|
| LinearRegression  | Continuous regression            | Fast and lightweight         |
| KNNClassifier     | Classification or regression     | Memory-based, non-parametric |
| DTWRecognizer     | Gesture/time-series matching     | Placeholder, extendable      |

All models implement the `IModel` interface with consistent `Train()` and `Predict()` methods.

---

## 💾 Saving & Loading Models

You can persist model state at runtime:

```csharp
core.SaveModel("myModel");
core.LoadModel("myModel");
```

Files are saved in:
```
Assets/RTMLToolKit/SavedModels/
```

Depending on model type, serialised data includes:
- LinearRegression: weights and biases
- KNN: training samples
- DTW: template sequences

---

## 🌐 OSC Integration

RTML supports OSC (Open Sound Control) for external communication.

| OSC Role | Address                  | Value          |
|----------|--------------------------|----------------|
| Input    | `/rtml/inputs`           | float array    |
| Output   | `/rtml/outputs`          | float array    |
| Record   | `/rtml/control/record`   | float 0/1      |
| Train    | `/rtml/control/train`    | float 0/1      |
| Run      | `/rtml/control/run`      | float 0/1      |

Enable OSC in the Inspector by toggling `useOsc`.

---

## ✅ Tests & Scenes

RTML is tested with Unity's Test Framework (NUnit-compatible).  
Scenes and tests include:

- `LinearRegressionTest.cs`
- `KNNClassifierTest.cs`
- `RuntimeSmokeTest.cs`
- `AutomatedModelTester.cs`

Sample scenes:
- `LinearRegressionTest.scene` (more coming soon)

Run tests via: **Window > General > Test Runner**

---

## 📌 TODO

- [ ] Visualise real-time I/O streams and model state (black-box → glass-box)
- [ ] Extend DTW to true dynamic time warping (sequence comparison)
- [ ] Add optional Barracuda backend for neural models
- [ ] Modular command parsing (custom OSC handlers)
- [ ] Android build with Meta Quest Mixed Reality support
- [ ] Refactor Inspector into collapsible widget system

---

## 🤝 Credits & License

RTML Tool Kit is authored by **Saim Gülay**.  
It draws conceptual inspiration from Wekinator but is written from scratch to support modern XR workflows and embedded deployment in Unity-based systems.

This project was originally developed for academic research in **real-time, embodied machine learning interfaces**.

📄 Licensed under the **Apache License 2.0** – see [LICENSE](./LICENSE) for full terms.

---

## 🧾 Citation

If you use RTML Tool Kit in your academic work, please cite:

```
Saim Gülay. "RTML Tool Kit: A Real-Time, Unity-Native Machine Learning Framework for XR." (2025). [arXiv link coming soon]
```

---
RTML Tool Kit empowers artists, performers, and researchers with a plug-and-play ML interface that works **where traditional tools can't** — inside Unity, in real time, across platforms.



# RTML Tool Kit: A Lightweight, Platform-Agnostic Real-Time ML Framework for Unity

## Abstract

Real-time, interactive machine learning (ML) workflows are increasingly vital in creative coding, live performance, and immersive media applications. While frameworks such as Wekinator have pioneered GUI-based ML pipelines for artists and designers, their reliance on desktop interfaces and external runtimes limits their applicability in mobile and Mixed Reality (MR) contexts.  
**RTML Tool Kit** addresses this gap by providing a lightweight, Unity-native ML runtime with full OSC integration, modular architecture, and support for Android deployment. This paper introduces the design rationale, core architecture, and preliminary performance benchmarks of the system.

---

## 1. Introduction

Creative technologists often require rapid iteration and live adaptation of ML systems during rehearsals, performances, or interactive installations. Tools like [Wekinator](http://wekinator.org) have enabled accessible workflows by exposing supervised learning through graphical interfaces. However, Wekinator's desktop-centric architecture, reliance on external GUIs, and lack of runtime serialisation make it incompatible with mobile or embedded deployments.

**RTML Tool Kit** is designed as a real-time, in-Editor and runtime-capable alternative. Built entirely in C# for the Unity engine, RTML allows users to:
- Train, run, and export ML models directly in Unity
- Integrate OSC I/O for external tools (TouchDesigner, Max/MSP)
- Deploy to mobile devices (e.g., Android-based MR headsets)
- Replace GUI-based ML interaction with Inspector-driven pipelines

This paper documents the motivation, architectural design, implemented models, and evaluation results of the RTML Tool Kit.

---

## 2. Related Work

- **Wekinator** (Fiebrink, 2011): GUI-based interactive ML tool for artists. Lacks mobile support and requires external OSC bridge.
- **RunwayML**: ML-as-a-service for creatives. High latency, cloud-dependent, not suitable for embedded performance workflows.
- **Unity ML-Agents**: RL-oriented framework for agents in Unity simulations. Not intended for low-latency interactive ML.
- **Encodex (TouchDesigner)**: Custom CHOPs allow real-time learning, but lack portability and in-scene serialisation.

RTML Tool Kit situates itself in this landscape by targeting *low-latency, local, supervised ML* within Unity itself.

---

## 3. System Architecture

RTML is composed of modular components grouped under functional domains:

- **RTMLCore.cs**: Central controller, manages data, model lifecycle, and OSC routing
- **IModel.cs**: Shared interface defining `Train()` and `Predict()` for all models
- **Model Classes**: `LinearRegression`, `KNNClassifier`, `DTWRecognizer`
- **SampleBuffer.cs**: Circular buffer for collecting and replaying training samples
- **OSCReceiver / OSCSender**: Bi-directional OSC input/output
- **Inspector Tools**: Save/Load model buttons, record/train/run toggles

Models can be swapped at runtime, and serialised via Unity's `JsonUtility` to `Assets/RTMLToolKit/SavedModels/`.

---

## 4. Implemented Models

| Model            | Type           | Purpose                        | Current Status |
|------------------|----------------|--------------------------------|----------------|
| LinearRegression | Supervised     | Continuous regression          | ✅ Fully tested |
| KNNClassifier    | Supervised     | Lazy classification/regression | ⚠ Integrated only |
| DTWRecognizer    | Sequence-based | Temporal gesture recognition   | ⚠ Placeholder |

All models conform to a shared `IModel` interface and are selectable via an Inspector dropdown.  
Only `LinearRegression` has been evaluated in real runtime scenarios thus far.

---

## 5. Evaluation

### 5.1 Test Conditions

- Unity 2022.3 LTS on macOS (M1 chip)
- Editor-only tests using Inspector UI
- InputSize: 5, OutputSize: 12
- Sample count: 50 training samples

### 5.2 Results (Linear Regression only)

| Metric                        | Value       |
|-------------------------------|-------------|
| Training latency              | ~2 ms       |
| Prediction latency            | <1 ms       |
| Save/Load roundtrip           | Verified    |
| Serialized model file size    | ~120 KB     |

No evaluation has yet been conducted for `KNNClassifier` or `DTWRecognizer`. They are structurally integrated and will be validated in future updates.

---

## 6. Case Study: Linear Regression in Unity Runtime

A sample scene (`LinearRegressionTest.scene`) was built to demonstrate real-time interaction between OSC inputs and Unity parameters. Inputs were streamed via TouchDesigner and processed by RTML to control the position of GameObjects. The pipeline required no external ML servers and performed entirely within Unity’s runtime loop.

---

## 7. Discussion

RTML demonstrates that supervised ML models can be feasibly trained and deployed entirely within Unity for small to medium-scale applications. Its modular architecture encourages model extension and custom input/output routing. However, limitations remain:

- No GPU acceleration (pure C#)
- No support yet for deep learning models (e.g. CNNs, RNNs)
- DTW and KNN remain untested
- Requires manual data collection (no auto-label pipeline)

The framework is best suited for rapid prototyping, performance interfaces, and embedded MR experiments.

---

## 8. Conclusion & Future Work

RTML Tool Kit presents a viable direction for GUI-free, real-time ML in Unity, enabling new workflows in mobile and XR contexts. Future directions include:

- Full evaluation of `KNNClassifier` and `DTWRecognizer`
- Android .apk deployment and latency profiling
- Optional support for Barracuda or ONNX backends
- Visual monitoring of input/output signals in-scene

We hope this project helps bridge the gap between creative coding and deployable, low-latency ML.

---

## References

- Fiebrink, R. et al. (2011). *Wekinator: Machine Learning for Musicians and Artists*. NIME Proceedings.
- Unity ML-Agents Toolkit. https://github.com/Unity-Technologies/ml-agents
- RunwayML. https://runwayml.com
- Open Sound Control. http://opensoundcontrol.org
- Gülay, S. (2025). *RTML Tool Kit Repository*. https://github.com/saimgulay/RTMLToolKit


