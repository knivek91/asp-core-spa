const HtmlWebpackPlugin = require("html-webpack-plugin");
const Dotenv = require('dotenv-webpack');
const paths = require("./paths");

const fileName = env =>
    env === "production" ? "bundle.[chunkhash:8].js" : "bundle.js";

module.exports = (env, argv) => ({
    entry: paths.entry,
    output: {
        path: paths.dist,
        filename: fileName(argv.mode)
    },
    module: {
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /node_modules/,
                use: { loader: "babel-loader" }
            },
            { test: /\.css$/, use: ["style-loader", "css-loader"] }
        ]
    },
    resolve: {
        extensions: [".js", ".jsx"]
    },
    plugins: [
        new Dotenv(),
        new HtmlWebpackPlugin({
            title: "BoilerPlate React + Webpack4",
            template: paths.html,
            hash: process.env.NODE_ENV === "production"
        })
    ],
    devtool: "cheap-module-source-map"
});
