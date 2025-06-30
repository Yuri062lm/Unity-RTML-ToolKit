/*
 * DTWRecognizer.cs
 *
 * Implements IModel as a placeholder DTW recogniser.
 * Construct with inputSize and outputSize.
 * Call Train(templates, outputs) to store reference frames,
 * then Predict(input) returns the output of the nearest template by Euclidean distance.
 */

using System.Collections.Generic;
using UnityEngine;

namespace RTMLToolKit
{
    /// <summary>
    /// Placeholder DTW recogniser using one-nearest-neighbour on single frames.
    /// Full sequence-based DTW support may be added later.
    /// </summary>
    public class DTWRecognizer : IModel
    {
        /// <summary>Number of features expected per input vector.</summary>
        public int inputSize;

        /// <summary>Number of dimensions in the output vector.</summary>
        public int outputSize;

        /// <summary>Stored template inputs.</summary>
        public List<float[]> templates;

        /// <summary>Stored template outputs corresponding to each template.</summary>
        public List<float[]> templateOutputs;

        /// <summary>
        /// Constructor: specify the dimensions of input and output vectors.
        /// </summary>
        public DTWRecognizer(int inputSize, int outputSize)
        {
            this.inputSize       = inputSize;
            this.outputSize      = outputSize;
            this.templates       = new List<float[]>();
            this.templateOutputs = new List<float[]>();
        }

        /// <summary>
        /// Stores each input–output pair as a template for one-nearest-neighbour matching.
        /// No longer rejects by vector length—accepts all pairs.
        /// </summary>
        public void Train(List<float[]> inputs, List<float[]> outputs)
        {
            if (inputs.Count != outputs.Count)
            {
                Logger.LogWarning("[DTWRecognizer] Input/output count mismatch.");
                return;
            }

            templates.Clear();
            templateOutputs.Clear();

            for (int i = 0; i < inputs.Count; i++)
            {
                templates.Add((float[])inputs[i].Clone());
                templateOutputs.Add((float[])outputs[i].Clone());
            }

            Logger.Log($"[DTWRecognizer] Stored {templates.Count} template frames (one-nearest-neighbour placeholder).");
        }

        /// <summary>
        /// Predicts output for the given input by finding the nearest template in Euclidean space.
        /// </summary>
        public float[] Predict(float[] input)
        {
            if (templates.Count == 0)
            {
                Logger.LogWarning("[DTWRecognizer] No templates available.");
                return new float[outputSize];
            }

            float bestDistance = float.PositiveInfinity;
            int bestIndex = 0;

            // Compare only up to the shorter length
            for (int i = 0; i < templates.Count; i++)
            {
                int len = Mathf.Min(input.Length, templates[i].Length);
                float sumSq = 0f;
                for (int j = 0; j < len; j++)
                {
                    float d = input[j] - templates[i][j];
                    sumSq += d * d;
                }
                float distance = Mathf.Sqrt(sumSq);
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    bestIndex    = i;
                }
            }

            return (float[])templateOutputs[bestIndex].Clone();
        }
    }
}
