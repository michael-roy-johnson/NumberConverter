const path = require('path');
const webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const bundleOutputDir = './wwwroot/dist';

module.exports = (env) => {
    const isDevBuild = !(env && env.prod);
    return [{
        entry: { 'main': './Assets/Js/main.js' },
        output: {
            path: path.join(__dirname, bundleOutputDir),
            filename: '[name].js',
            publicPath: 'dist/'
        },
        module: {
            rules: [
                {
                    test: /\.scss$/,
                    use: ExtractTextPlugin.extract(
                        {
                            fallback: 'style-loader',
                            use: ['css-loader', 'sass-loader']
                        })
                }
            ]
        },
        plugins: [
            //new MiniCssExtractPlugin({
            //    filename: 'style.[contenthash].css',
            //}),
            new HtmlWebpackPlugin({
                template: './Assets/Layouts/index.html',
                filename: 'index.html'
            }),
        ]
    }];
};