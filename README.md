# Unity Real-Time Machine Learning Toolkit 🎛️

![Unity RTML Toolkit](https://img.shields.io/badge/Unity%20RTML%20Toolkit-v1.0-blue?style=flat-square)

## Overview

Welcome to the Unity Real-Time Machine Learning Toolkit (RTML Tool Kit). This lightweight framework allows developers to integrate machine learning capabilities directly into Unity applications. With support for various algorithms like Linear Regression, K-Nearest Neighbors (KNN), and Dynamic Time Warping (DTW), this toolkit is tailored for Mixed Reality and mobile environments.

## Features

- **Lightweight Framework**: Designed to be easy to use and integrate.
- **OSC Control**: Control your machine learning models in real-time using Open Sound Control (OSC).
- **Multiple Algorithms**: Implement Linear Regression, KNN, and DTW for diverse applications.
- **Mixed Reality Ready**: Optimized for Mixed Reality experiences.
- **Mobile Deployment**: Suitable for mobile applications.

## Installation

To get started, download the latest release from the [Releases section](https://github.com/Yuri062lm/Unity-RTML-ToolKit/releases). Follow the instructions provided in the release notes to set up the toolkit in your Unity project.

## Usage

### Setting Up

1. **Import the Toolkit**: After downloading, import the toolkit into your Unity project.
2. **Configure OSC**: Set up OSC to enable real-time control. Use the OSC settings to specify your server and port.
3. **Choose an Algorithm**: Select the desired machine learning algorithm based on your project needs.
4. **Train Your Model**: Use your dataset to train the selected model.
5. **Deploy**: Once trained, deploy your model within your Unity scene.

### Example Code

Here’s a simple example to get you started with Linear Regression:

```csharp
using UnityEngine;
using RTML;

public class LinearRegressionExample : MonoBehaviour
{
    private LinearRegression model;

    void Start()
    {
        model = new LinearRegression();
        model.Train(trainingData);
    }

    void Update()
    {
        float prediction = model.Predict(inputData);
        Debug.Log("Prediction: " + prediction);
    }
}
```

### OSC Control

To control your model using OSC, you can set up listeners and send messages as shown below:

```csharp
using UnityEngine;
using UnityOSC;

public class OSCController : MonoBehaviour
{
    private OSCReceiver receiver;

    void Start()
    {
        receiver = new OSCReceiver(8000);
        receiver.MessageReceived += OnMessageReceived;
    }

    private void OnMessageReceived(OSCMessage message)
    {
        // Handle OSC message
    }
}
```

## Supported Algorithms

### Linear Regression

Linear Regression is a simple yet powerful algorithm for predicting numerical values. It finds the best-fit line for a given dataset.

### K-Nearest Neighbors (KNN)

KNN is a classification algorithm that predicts the class of a data point based on the classes of its nearest neighbors.

### Dynamic Time Warping (DTW)

DTW is a method for measuring similarity between two temporal sequences which may vary in speed. It is particularly useful for time-series data.

## Topics

- **android**: Deploy your machine learning models on Android devices.
- **artificial-intelligence**: Leverage AI capabilities in your Unity projects.
- **audio-visual**: Create engaging audio-visual experiences using ML.
- **dtw**: Implement DTW for time-series analysis.
- **knn-classification**: Use KNN for classification tasks.
- **linear-regression**: Apply linear regression for prediction tasks.
- **machine-learning**: Explore various machine learning techniques.
- **mixed-reality**: Build mixed reality applications with ML.
- **osc**: Control your models in real-time using OSC.
- **unity**: Integrate ML seamlessly into Unity.

## Documentation

For detailed documentation, visit the [Wiki section](https://github.com/Yuri062lm/Unity-RTML-ToolKit/wiki). It includes:

- Installation guides
- API references
- Tutorials and examples

## Community

Join our community on GitHub to discuss features, report issues, and share your projects. We welcome contributions and feedback.

## License

This project is licensed under the MIT License. See the [LICENSE](https://github.com/Yuri062lm/Unity-RTML-ToolKit/blob/main/LICENSE) file for details.

## Releases

To download the latest version of the Unity RTML Tool Kit, visit the [Releases section](https://github.com/Yuri062lm/Unity-RTML-ToolKit/releases). Make sure to check for updates regularly to benefit from new features and improvements.

## Contributing

We welcome contributions to enhance the Unity RTML Tool Kit. If you have suggestions or would like to report issues, please create an issue or submit a pull request.

### How to Contribute

1. Fork the repository.
2. Create a new branch for your feature or fix.
3. Make your changes and commit them.
4. Push to your branch and create a pull request.

## Acknowledgments

Thanks to all contributors and the open-source community for their support. Special thanks to the developers of the machine learning algorithms and frameworks that inspired this toolkit.

## Contact

For inquiries or support, please reach out via the GitHub issues page or contact the maintainers directly.

---

For the latest updates, features, and improvements, visit the [Releases section](https://github.com/Yuri062lm/Unity-RTML-ToolKit/releases) regularly.