const path = require('path');

module.exports = {
    mode: "development",
    entry: {
      api: "./app/index.jsx",
    },
    output: {
      path: path.resolve(__dirname, "../WebShopBackend/WebShopApi/wwwroot/js/"),
      filename: "[name].bundle.js",
    },
    module: {
      rules: [
        {
          test: /\.jsx?$/,
          exclude: /(node_modules)/,
          loader: "babel-loader",
          options: {
            presets: ["@babel/preset-react"],
          },
        },
        {
          test: /\.(scss|css)$/,
          use: ["style-loader", "css-loader", "postcss-loader", "sass-loader"],
        },
      ],
    },
  };