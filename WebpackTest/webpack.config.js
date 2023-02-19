const path = require('path');
const { VueLoaderPlugin } = require('vue-loader');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');

module.exports = {
    entry: './src/main.js',
    output: {
        path: path.resolve(__dirname,'dist'),
        filename: 'bundle.js',

    },
    module: {
        rules: [
            { test: /\.vue$/, use: 'vue-loader' },
            {
                test: /\.css$/, use: [
                    {
                        loader:'vue-style-loader'
                    },
                    {
                        loader:'css-loader'
                    }
                ]
            },
            {
                // 处理图片资源
                test: /\.(jpg|png|gif)$/,
                // webpack5中使用assets-module（url-loader已废弃）
                type: 'asset',
                parser: {
                    dataUrlCondition: {
                        maxSize: 10 * 1024
                    }
                },
                generator: {
                    filename: 'img/[name].[hash:6][ext]',
                }
            }
        ],
    },
    plugins: [
        new VueLoaderPlugin(),
        new CleanWebpackPlugin(),
    ],
}