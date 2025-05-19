
const HtmlWebPackPlugin = require("html-webpack-plugin");
const ModuleFederationPlugin = require("webpack/lib/container/ModuleFederationPlugin");

const deps = require("./package.json").dependencies;
const path = require('path');

module.exports = (_, argv) => ({
  output: {
    path: path.resolve(__dirname, 'dist'),
    filename: '[name].[contenthash].js',
    publicPath: '/main/', // <-- or adjust based on how it's served
  },

  resolve: {
    extensions: [".tsx", ".ts", ".jsx", ".js", ".json"],
  },

  devServer: {
    port: 84,
    historyApiFallback: true,
  },

  module: {
    rules: [
      {
        test: /\.m?js/,
        type: "javascript/auto",
        resolve: {
          fullySpecified: false,
        },
      },
      {
        test: /\.(css|s[ac]ss)$/i,
        use: ["style-loader", "css-loader", "postcss-loader"],
      },
      {
        test: /\.(ts|tsx|js|jsx)$/,
        exclude: /node_modules/,
        use: {
          loader: "babel-loader",
        },
      },
    ],
  },

  plugins: [
    new ModuleFederationPlugin({
      name: "ecommerce_main",
      filename: "ecommerce-main.js",
      remotes: {
        authentication_app: "authentication_app@http://localhost:84/auth/authentication-app.js",
      },
      exposes: {},
      shared: {
        ...deps,
        react: { singleton: true, requiredVersion: '^19.1.0' },
        'react-dom': { singleton: true, requiredVersion: '^19.1.0' },
        '@mui/material': { singleton: true, requiredVersion: '^7.1.0' },
        '@emotion/react': { singleton: true, requiredVersion: '^11.14.0' },
        '@emotion/styled': { singleton: true, requiredVersion: '^11.14.0' },
        zustand: { singleton: true, requiredVersion: '^5.0.4' },
      },
    }),
    new HtmlWebPackPlugin({
      template: "./index.html",
    }),
  ],
});
