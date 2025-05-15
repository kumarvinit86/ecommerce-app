
const HtmlWebPackPlugin = require("html-webpack-plugin");
const ModuleFederationPlugin = require("webpack/lib/container/ModuleFederationPlugin");

const deps = require("./package.json").dependencies;
const path = require('path');
module.exports = (_, argv) => ({
  output: {
    publicPath: "http://localhost:3002/",
  },

  resolve: {
    extensions: [".tsx", ".ts", ".jsx", ".js", ".json"],
    alias: {
      '@ecommerce/shared-components/components': path.resolve(__dirname, '../shared-components/src/components'),
      '@ecommerce/shared-components/api': path.resolve(__dirname, '../shared-components/src/api'),
      '@ecommerce/shared-components/stores': path.resolve(__dirname, '../shared-components/src/stores'),
    },
  },
  devtool: "source-map",
  devServer: {
    port: 3002,
    hot: true,
    historyApiFallback: true,
    headers: {
      "Access-Control-Allow-Origin": "*", // Allow all origins
    },
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
      name: "authentication_app",
      filename: "authentication-app.js",
      remotes: {},
      exposes: {
        "./Login": "./src/components/auth/Login.tsx",
      },
      shared: {
        ...deps,
        react: { singleton: true, requiredVersion: "^19.1.0" },
        "react-dom": { singleton: true, requiredVersion: "^19.1.0" },
        "@mui/material": { singleton: true, requiredVersion: "^7.1.0" },
        "@emotion/react": { singleton: true, requiredVersion: "^11.14.0" },
        "@emotion/styled": { singleton: true, requiredVersion: "^11.14.0" },
        "@mui/icons-material": { singleton: true, requiredVersion: "^7.1.0" },
        zustand: { singleton: true, requiredVersion: "^5.0.4" },

      },
    }),
    new HtmlWebPackPlugin({
      template: "./index.html",
    }),
  ],
});
