using System;
using System.Collections.Generic;
using System.Text;

namespace neural_network1._0
{
    public class NeuralNetwork
    {
        public int inputNodes;
        public int hiddenNodes;
        public int outputNodes;

        public Matrix weights_ih;
        public Matrix weights_ho;
        public Matrix bias_h;
        public Matrix bias_o;
        public double learning_rate;
        public NeuralNetwork(int inputNodes, int hiddenNodes, int outputNodes)
        {
            this.inputNodes = inputNodes;
            this.hiddenNodes = hiddenNodes;
            this.outputNodes = outputNodes;

            this.weights_ih = new Matrix(this.hiddenNodes, this.inputNodes);
            this.weights_ho = new Matrix(this.outputNodes, this.hiddenNodes);
            this.weights_ih.Randomize();
            this.weights_ho.Randomize();

            this.bias_h = new Matrix(this.hiddenNodes, 1);
            this.bias_o = new Matrix(this.outputNodes, 1);

            this.learning_rate = 0.1;
        }

        public Array FeedForward(Array input_array)
        {
            var inputs = Matrix.FromArray(input_array);
            var hiddens = Matrix.MultiplyWithMatrix(this.weights_ih, inputs);
            hiddens.AddWithMatrix(this.bias_h);
            hiddens.Map(Sigmoid);

            var outputs = Matrix.MultiplyWithMatrix(this.weights_ho, hiddens);
            outputs.AddWithMatrix(this.bias_o);
            outputs.Map(Sigmoid);

            return outputs.ToArray();
        }

        public void Train(Array input_array, Array target_array)
        {
            // Generating the Hidden Outputs
            var inputs = Matrix.FromArray(input_array);
            var hidden = Matrix.MultiplyWithMatrix(this.weights_ih, inputs);
            hidden.AddWithMatrix(this.bias_h);
            // activation function!
            hidden.Map(Sigmoid);

            // Generating the output's output!
            var outputs = Matrix.MultiplyWithMatrix(this.weights_ho, hidden);
            outputs.AddWithMatrix(this.bias_o);
            outputs.Map(Sigmoid);

            var targets = Matrix.FromArray(target_array);

            //calculate the error
            var output_errors = Matrix.Subtract(targets, outputs);

            // let gradient = outputs * (1 - outputs);
            // Calculate gradient
            var gradients = Matrix.Map(outputs, DerivativeSigmoid);
            gradients.MultiplyWithMatrix(output_errors);
            gradients.Multiply(this.learning_rate);

            // Calculate deltas
            var hidden_T = Matrix.Transpose(hidden);
            var weight_ho_deltas = Matrix.MultiplyWithMatrix(gradients, hidden_T);

            // Adjust the weights by deltas
            this.weights_ho.AddWithMatrix(weight_ho_deltas);
            // Adjust the bias by its deltas (which is just the gradients)
            this.bias_o.AddWithMatrix(gradients);

            // Calculate the hidden layer errors
            var who_t = Matrix.Transpose(this.weights_ho);
            var hidden_errors = Matrix.MultiplyWithMatrix(who_t, output_errors);

            // Calculate hidden gradient
            var hidden_gradient = Matrix.Map(hidden, DerivativeSigmoid);
            hidden_gradient.MultiplyWithMatrix(hidden_errors);
            hidden_gradient.Multiply(this.learning_rate);

            // Calcuate input->hidden deltas
            var inputs_T = Matrix.Transpose(inputs);
            var weight_ih_deltas = Matrix.MultiplyWithMatrix(hidden_gradient, inputs_T);

            this.weights_ih.AddWithMatrix(weight_ih_deltas);
            // Adjust the bias by its deltas (which is just the gradients)
            this.bias_h.AddWithMatrix(hidden_gradient);

            //outputs.Print();
            //targets.Print();
            //output_errors.Print();
            //hidden_errors.Print();
        }

        public double Sigmoid(double x)
        {
            return 1 / (1 + (Math.Exp(-x)));
        }

        public double DerivativeSigmoid(double y)
        {
            return y * (1 - y);
        }
    }
}
