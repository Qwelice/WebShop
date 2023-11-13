const path = require("path");

const appConfig = {
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

const adminAppConfig = {
  mode: "development",
    entry: {
      api: "./appAdmin/index.jsx",
    },
    output: {
      path: path.resolve(__dirname, "../WebShopBackend/WebShopAdminApi/wwwroot/js/"),
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
}

module.exports = [appConfig, adminAppConfig];
