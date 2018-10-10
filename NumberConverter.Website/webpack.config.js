const path = require('path');
const webpack = require('webpack');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const CleanWebpackPlugin = require('clean-webpack-plugin');
const BrowserSyncPlugin = require('browser-sync-webpack-plugin');
const bundleOutputDir = './wwwroot';

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);
    return [{
        mode: 'development',
        entry: { 'main': './Assets/Js/index.js' },
        output: {
            path: path.join(__dirname, bundleOutputDir),
            filename: '[name].js',
            publicPath: '/',
        },
        module: {
            rules: [
                {
                    test: /\.m?js$/,
                    exclude: /node_modules/,
                    use: {
                        loader: 'babel-loader',
                    }
                },
                {
                    test: /\.scss$/,
                    use: [
                        'style-loader',
                        MiniCssExtractPlugin.loader,
                        'css-loader',
                        'sass-loader'
                    ]
                }
            ]
        },
        plugins: [
            new BrowserSyncPlugin(
                {
                    host: 'localhost',
                    port: 3000,
                    server: { baseDir: ['wwwroot'] }
                }),
             new MiniCssExtractPlugin({
                filename: 'style.css'
            }),
            new HtmlWebpackPlugin({
                template: './Assets/Layouts/index.html',
                filename: 'index.html'
            })
        ]
    }];
};